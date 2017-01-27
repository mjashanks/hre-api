using Hre.Api.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Threading.Tasks;
using Hre.Api.Extensions;

namespace Hre.Api.Database
{
    public static class UserRepository
    {
        private const string selectUsers = "select Id, FirstName, LastName, Email, Telephone, Bio, Region from users";
        private const string updateUsers = "update Users set FirstName=@FirstName, LastName=@LastName, Email=@Email, Telephone=@Telephone, Bio=@Bio, Region=@Region ";

        public static async Task<List<User>> GetAllUsers(this SqlConnection c)
        {
            var users = await c.QueryAsync<User>(selectUsers);
            return users.ToList();
        }

        public static async Task<User> GetUser(this SqlConnection c, int id)
        {
            var users = await c.QueryAsync<User>(selectUsers.SqlWhere("Id = @Id"), new { Id = id });
            return users.FirstOrDefault();
        }

        public static async Task UpdateUser(this SqlConnection c, User user)
        {
            await c.ExecuteAsync(updateUsers.SqlWhere("Id = @Id"), user);            
        }

        public static async Task<ProfilePicture> GetProfilePic(this SqlConnection c, int id)
        {
            var pics = await c.QueryAsync<ProfilePicture>("select Id, ProfilePic as Pic from Users where Id = @Id", new { Id = id });
            return pics.FirstOrDefault();
        }

        public static async Task SetProfilePic(this SqlConnection c, int id, byte[] pic)
        {
            await c.ExecuteAsync("update Users set ProfilePic = @pic where Id = @Id", new { Id = id, pic = pic });
        }
    }
}