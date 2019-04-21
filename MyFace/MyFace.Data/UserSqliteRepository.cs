using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Text;
using MyFace.Common;
using MyFace.Domain;

namespace MyFace.Data
{

    /// <summary>
    /// A Sqlite Repository for the MyFace Application
    /// </summary>
    public class UserSqliteRepository : IUserRepository
    {

        // technically you could have just one download method that returned one or all depending on a limiting param
        // but just to be thorough, we'll have separate ones here.
        public List<User> DownloadAllUsers()
        {
            List<User> AllUsers = new List<User>();

            using (SQLiteConnection conn = new SQLiteConnection(SqliteConnString()))
            {
                using (SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Users", conn))
                {
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        Logger.Write(ex);
                    }

                    if (conn.State == ConnectionState.Open)
                    {
                        using (SQLiteDataReader reader = comm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User user = MapReaderToUser(reader);
                                AllUsers.Add(user);
                            }
                        }
                    }
                }
            }

            return AllUsers;
        }

        public User DownloadSingleUser(int id)
        {
            User user = null;

            using (SQLiteConnection conn = new SQLiteConnection(SqliteConnString()))
            {
                using (SQLiteCommand comm = new SQLiteCommand("SELECT * FROM Users WHERE [Id] = @id", conn))
                {
                    comm.Parameters.AddWithValue("@id", id);

                    try
                    {
                        conn.Open();
                    }
                    catch(Exception ex)
                    {
                        Logger.Write(ex);
                    }

                    if (conn.State == ConnectionState.Open)
                    {
                        try
                        {
                            using (SQLiteDataReader reader = comm.ExecuteReader())
                            {
                                user = MapReaderToUser(reader);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Write(ex);
                        }
                    }
                }
            }

            return user;
        }

        public User LogInUser(string email, string password)
        {
            User user = null;

            using (SQLiteConnection conn = new SQLiteConnection(SqliteConnString()))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Logger.Write(ex);
                }

                // First, this method checks to see if there's an email from the user attempting to log in. If so, it will check the password against the User_credentials table
                if (conn.State == ConnectionState.Open)
                {
                    int tempId = 0;
                    using (SQLiteCommand getIdCommand = new SQLiteCommand("SELECT * FROM Users WHERE [Email] = @email", conn))
                    {
                        getIdCommand.Parameters.AddWithValue("@email", email);
                        
                        try
                        {
                            using (SQLiteDataReader idReader = getIdCommand.ExecuteReader())
                            {
                                while (idReader.Read())
                                {
                                    int.TryParse(idReader["Id"].ToString(), out tempId);
                                    user = MapReaderToUser(idReader);
                                    user.Id = tempId;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Write(ex);
                            // if there's no user with this email, return null -- the UI can state there's no such user
                            return null;
                        }
                    }

                    int successPasswordCount = 0;
                    // if id is not 0, we def have that user in DB; compare the password they entered 
                    if (tempId != 0)
                    {
                        using (SQLiteCommand checkPassCommand = new SQLiteCommand("SELECT Id FROM Users_Credentials WHERE UserId = @userid AND Password = @password", conn))
                        {
                            checkPassCommand.Parameters.AddWithValue("@userid", user.Id);
                            checkPassCommand.Parameters.AddWithValue("@password", password);

                            try
                            {
                                using (SQLiteDataReader passreader = checkPassCommand.ExecuteReader())
                                {
                                    while (passreader.Read())
                                    {
                                        // we don't actually have to parse the data -- if it reads, it was successful
                                        successPasswordCount++;
                                    }
                                }

                                if (successPasswordCount == 0)
                                {
                                    // didn't give an error but got no result; we'll return null and make a more informative error later
                                    return null;
                                }

                            }
                            catch (Exception ex)
                            {
                                Logger.Write(ex);
                                // if there's an error, for now return null -- later make sure there are better errors on UI
                                return null;
                            }
                        }
                    }
                }
            }            

            // we're all the way here. Success! return the user for login purposes.
            return user;
        }

        public User SignUpNewUser(string firstName, string lastName, string email, string password)
        {
            User user = null;

            using (SQLiteConnection conn = new SQLiteConnection(SqliteConnString()))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Logger.Write(ex);
                }

                // we'll save the inserted user Id, its row in the DB, here, to validate that we should move to next step
                int tempId = 0;
                using (SQLiteCommand comm = new SQLiteCommand("INSERT INTO Users (FirstName, LastName, Email) VALUES (@firstname, @lastname, @email)", conn))
                {
                    comm.Parameters.AddWithValue("@firstname", firstName);
                    comm.Parameters.AddWithValue("@lastname", lastName);
                    comm.Parameters.AddWithValue("@email", email);

                    try
                    {
                        comm.ExecuteNonQuery();
                        // get the last inset back;
                        // this command is specific to sqlite.
                        // to do this in SQL Server, your sqlcommand would be "insert into [Table] (...) OUTPUT INSERTED.Id (...)
                        // and then you'd comm.executeScalar();
                        tempId = (int)conn.LastInsertRowId;
                    }
                    catch(Exception ex)
                    {
                        Logger.Write(ex);
                    }
                }

                // same id as above
                int newPassCount = 0;
                // since we've successfully saved the important information to the user table, 
                // we need to save their password to the credentials table.
                if (tempId != 0)
                {
                    using(SQLiteCommand newPassCommand = new SQLiteCommand("INSERT INTO Users_Credentials (UserID, Password) VALUES (@id, @password);", conn))
                    {
                        newPassCommand.Parameters.AddWithValue("@id", tempId);
                        // Later we will encrypt these before they are saved. Right now while we just test, it will be plain text. 
                        // Do not do this in production. 
                        newPassCommand.Parameters.AddWithValue("@password", password);

                        try
                        {
                            newPassCount = (int)newPassCommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Logger.Write(ex);
                        }
                    }
                }

                // we only want to create a user if the user and password were successfully saved, or there will be problems
                if (newPassCount > 0)
                {
                    user = new User(firstName: firstName, lastName: lastName, email: email);
                    user.Id = tempId;
                }

            }

            return user;
        }

        public User MapReaderToUser(SQLiteDataReader reader)
        {
            int id = 0;
            int.TryParse(reader["Id"].ToString(), out id);
            string firstName = reader["FirstName"].ToString();
            string lastName = reader["lastName"].ToString();
            string email = reader["Email"].ToString();
            string status = reader["Status"].ToString();

            return new User(id: id, firstName: firstName, lastName: lastName, email: email, status: status);
        }

        public bool DeleteUserFromDb(int id)
        {
            bool successfulDelete = false;

            using (SQLiteConnection conn = new SQLiteConnection(SqliteConnString()))
            {
                try
                {
                    conn.Open();
                }
                catch(Exception ex)
                {
                    Logger.Write(ex);
                }

                if (conn.State == ConnectionState.Open)
                {
                    using (SQLiteCommand comm = new SQLiteCommand("DELETE FROM Users_Credentials WHERE UserID = @id; DELETE FROM USERS WHERE ID = @id;", conn))
                    {
                        comm.Parameters.AddWithValue("@id", id);

                        try
                        {
                            comm.ExecuteNonQuery();
                            successfulDelete = true;
                        }
                        catch(Exception ex)
                        {
                            Logger.Write(ex);
                        }
                    }
                }
            }

            return successfulDelete;
        }

        private static string SqliteConnString(string id = "SqlLiteDefault")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
