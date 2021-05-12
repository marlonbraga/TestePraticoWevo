using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySqlConnector;

namespace TestePraticoWevo {
    public class UserQueryMock: IUserQuery {
        private List<User> users = new List<User>();

        public UserQueryMock() {
            users.Add(new User { Id = 1, Name = "Dummy-1", Email = "dummy@email.com" });
            users.Add(new User { Id = 2, Name = "Dummy-2", Email = "dummy@email.com" });
            users.Add(new User { Id = 3, Name = "Dummy-3", Email = "dummy@email.com" });
        }

        public UserQueryMock(AppDb db) {
            users.Add(new User{Id=1, Name="Dummy-1", Email="dummy@email.com"});
            users.Add(new User{Id=2, Name="Dummy-2", Email="dummy@email.com"});
            users.Add(new User{Id=3, Name="Dummy-3", Email="dummy@email.com"});
        }

        public async Task<User> FindOneAsync(int id) {
            User user = users.Find(x => x.Id == id);
            return user;
        }

        public async Task<List<User>> LatestPostsAsync() {
            return users;
        }

        public async Task DeleteAllAsync() {
            List<User> users = new List<User>();
        }
    }
}