using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.Data.SqlClient;

namespace JsonDAL
{
    public class SqlUsersDAO : IUsersDAL
    {
        private static readonly string connectionString = "Server=localhost;Database=UsersOrAwardsDB;Trusted_Connection=True;TrustServerCertificate=True";
        public User AddUser(string name, DateTime dateOfBirthday, string login, string password)
        {
            User user = new User(name, dateOfBirthday, login, password);
            using(SqlConnection _connection = new SqlConnection(connectionString))
            {
                var queryAtUsersTable = "INSERT INTO dbo.Users(id, Name, DateOfBirthday, Age, Login, Password)" +
                    "VALUES(@id, @name, @date, @age, @login, @pass)";
                var command = new SqlCommand(queryAtUsersTable, _connection);
                command.Parameters.AddWithValue("@id", user.Id);
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@date", user.DateOfBirthday);
                command.Parameters.AddWithValue("@age", user.Age);
                command.Parameters.AddWithValue("@login", user.Login);
                command.Parameters.AddWithValue("@pass", user.Password);
                _connection.Open();
                var result = command.ExecuteScalar();
                return user;

            }
        }

        public void EditUser(Guid id, string name, DateTime dateOfBirthday)
        {
            using(SqlConnection _connection = new SqlConnection(connectionString))
            {
                var queryAtUsersTable = "UPDATE Users SET Name=@name, DateOfBirthday=@dateOfB, Age=@age"
                    +"WHERE id = @id";
                int newAge = User.GetNewAge(dateOfBirthday);
                var command = new SqlCommand(queryAtUsersTable, _connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@dateOfB", dateOfBirthday);
                command.Parameters.AddWithValue(@"age", newAge);
                command.Parameters.AddWithValue("@id", id);
                _connection.Open();
                command.ExecuteNonQuery();

            }
        }

        public void EditUser(Guid id, Award award)
        {
            using (SqlConnection _connection = new SqlConnection(connectionString))
            {
                var queryAtUsersTable = "INSERT INTO dbo.UsersAwards (UserId, AwardsId)" +
                    "VALUES(@userId, @awardsId)";

                var command = new SqlCommand(queryAtUsersTable, _connection);
                command.Parameters.AddWithValue("@userId", id);
                command.Parameters.AddWithValue("@awardsId", award.Id);
                _connection.Open();
                command.ExecuteScalar();

            }
        }

        public User GetUser(Guid id)
        {
            
            using (SqlConnection _connection = new SqlConnection(connectionString))
            {
                var queryAtUsersTable = $"SELECT * FROM Users WHERE id = @userId";
                var command = new SqlCommand(queryAtUsersTable, _connection);
                command.Parameters.AddWithValue("@userId", id);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                User user = new User();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        user = new User(
                            id,
                            reader["Name"].ToString(),
                            (DateTime)reader["DateOfBirthday"],
                            reader["Login"].ToString(),
                            reader["Password"].ToString()
                            );

                    }
                }
                user.AwardsId.AddRange(GetAwardsIdUser(id));
                user.AddAwards(GetAwardsUser(user));
                return user;
            }
        }

        public IEnumerable<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection _connection = new SqlConnection(connectionString))
            {
                var queryAtUsersTable = $"SELECT * FROM Users";
                var command = new SqlCommand(queryAtUsersTable, _connection);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                User user;
                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user = new User(
                            Guid.Parse(reader["id"].ToString()),
                            reader["Name"].ToString(),
                            (DateTime)reader["DateOfBirthday"],
                            reader["Login"].ToString(),
                            reader["Password"].ToString()
                            );
                        users.Add(user);
                    }

                }
            }
            return UsersAndAwards(users);
        }
        private IEnumerable<User> UsersAndAwards(List<User> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                users[i].AddAwards(GetAwardsUser(users[i]));
            }
            return users;
        }
        private IEnumerable<Award> GetAwardsUser(User user)
        {
            using (SqlConnection _connection = new SqlConnection(connectionString))
            {
                List<Award> result = new List<Award>();
                for (int i=0; i< user.AwardsId.Count; i++)
                {
                    var queryAtUsersTable = $"SELECT * FROM Awards WHERE Id=@awardsId";

                    var command = new SqlCommand(queryAtUsersTable, _connection);
                    command.Parameters.AddWithValue(@"userId", user.AwardsId[i]);
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Award award = new Award();
                    
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            award = new Award(
                                user.AwardsId[i],
                                reader["Title"].ToString()
                                );
                            result.Add(award);
                        }
                    }
                }
                return result;
            }
        }
        private IEnumerable<Guid> GetAwardsIdUser(Guid idUser)
        {
            using (SqlConnection _connection = new SqlConnection(connectionString))
            {
                var queryAtUsersTable = $"SELECT * FROM UsersAwards WHERE UserId=@userId";

                var command = new SqlCommand(queryAtUsersTable, _connection);
                command.Parameters.AddWithValue(@"userId", idUser);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Award award = new Award();
                List<Guid> result = new List<Guid>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Add(Guid.Parse(reader["AwardsId"].ToString()));
                    }
                }
                return result;
            }
        }
        public void RemoveUser(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Save(User user)
        {
            using (SqlConnection _connection = new SqlConnection(connectionString))
            {
                var queryAtUsersTable = "UPDATE Users SET Name=@name, DateOfBirthday=@dateOfB, Age=@age"
                    + "WHERE id = @id";
                int newAge = User.GetNewAge(user.DateOfBirthday);
                var command = new SqlCommand(queryAtUsersTable, _connection);
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@dateOfB", user.DateOfBirthday);
                command.Parameters.AddWithValue(@"age", newAge);
                command.Parameters.AddWithValue("@id", user.Id);
                _connection.Open();
                command.ExecuteNonQuery();

            }
        }

        public void SetPhoto(Guid id, string path)
        {
            throw new NotImplementedException();
        }
    }
}
