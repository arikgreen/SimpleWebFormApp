using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;

namespace SimpleWebApplication.Models
{
    public class User
    {
        private readonly string connString = WebConfigurationManager.ConnectionStrings["SimpleAppDbConnectionString"].ConnectionString;

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        /// <summary>
        /// Get all users from DB
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            List<User> userList = new List<User>();

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                SqlCommand usersCmd = new SqlCommand("SELECT UserID, Name, Email, FirstName, LastName FROM Users", connection);

                SqlDataReader reader = usersCmd.ExecuteReader();

                if (reader != null)
                {
                    while (reader.Read())
                    {
                        User user = new User()
                        {
                            UserId = Convert.ToInt32(reader["UserID"]),
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString()
                        };
                        userList.Add(user);
                    }
                }
                connection.Close();
            }

            return userList;
        }

        /// <summary>
        /// Add a new user to DB
        /// </summary>
        /// <param name="user"></param>
        public void CreateUser(User user)
        {
            if (VerifyUser(user))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connString))
                    {
                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO Users(Name, Email, FirstName, LastName) VALUES(@Name, @Email, @FName, @LName)", connection);

                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                        cmd.Parameters["@Name"].Value = user.Name;

                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                        cmd.Parameters["@Email"].Value = user.Email;

                        cmd.Parameters.Add("@FName", SqlDbType.NVarChar);
                        cmd.Parameters["@FName"].Value = user.FirstName;

                        cmd.Parameters.Add("@LName", SqlDbType.NVarChar);
                        cmd.Parameters["@LName"].Value = user.LastName;

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Get current user from DB
        /// </summary>
        /// <param name="userId">Id of user</param>
        /// <returns></returns>
        public User GetUserData(int userId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand(
                        "SELECT UserID, Name, Email, FirstName, LastName FROM Users WHERE UserID=@UserId", connection);

                    cmd.Parameters.Add("UserId", SqlDbType.Int);
                    cmd.Parameters["UserId"].Value = userId;

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    User user = new User();

                    if (reader.Read())
                    {
                        user.UserId = Convert.ToInt32(reader["UserID"]);
                        user.Name = reader["Name"].ToString();
                        user.Email = reader["Email"].ToString();
                        user.FirstName = reader["FirstName"].ToString();
                        user.LastName = reader["LastName"].ToString();
                    }

                    connection.Close();

                    return user;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update data for current user
        /// </summary>
        /// <param name="user">User object</param>
        public void EditUser(User user)
        {
            if (VerifyUser(user))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connString))
                    {
                        SqlCommand cmd = new SqlCommand(
                            "UPDATE Users SET Name=@Name, Email=@Email, FirstName=@FName, LastName=@LName WHERE UserID=@UserId", connection);

                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                        cmd.Parameters["@Name"].Value = user.Name;

                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                        cmd.Parameters["@Email"].Value = user.Email;

                        cmd.Parameters.Add("@FName", SqlDbType.NVarChar);
                        cmd.Parameters["@FName"].Value = user.FirstName;

                        cmd.Parameters.Add("@LName", SqlDbType.NVarChar);
                        cmd.Parameters["@LName"].Value = user.LastName;

                        cmd.Parameters.Add("UserId", SqlDbType.Int);
                        cmd.Parameters["UserId"].Value = user.UserId;

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Delete current user from DB
        /// </summary>
        /// <param name="userId">Id of user</param>
        public void DeleteUser(int userId)
        {           
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand(
                        "DELETE Users WHERE UserID=@UserId", connection);

                    cmd.Parameters.Add("UserId", SqlDbType.Int);
                    cmd.Parameters["UserId"].Value = userId;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Verify user name and email
        /// user name - letters, numbers, _, min length - 3
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool VerifyUser(User user)
        {
            if (Regex.Match(user.Name, @"\b[a-zA-Z][a-zA-Z0-9_]{3,}").Success)
                if (Regex.Match(user.Email, @"\b[a-z][a-z0-9_\-\.]+@[a-zA-Z0-9_\-]+\.[a-zA-Z]{2,3}").Success)
                    return true;

            return false;
        }
    }
}
