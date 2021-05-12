using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySqlConnector;

namespace TestePraticoWevo {
    public class UserQuery: IUserQuery {
        public AppDb Db { get; }

        public UserQuery(AppDb db) {
            Db = db;
        }

        public async Task<User> FindOneAsync(int id) {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `ID`, `NAME`, `CPF`, `EMAIL`, `PHONE`, `GENDER`, `BIRTH_DATE` FROM `user` WHERE `ID` = @id";
            cmd.Parameters.Add(new MySqlParameter {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<List<User>> LatestPostsAsync() {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `ID`, `NAME`, `CPF`, `EMAIL`, `PHONE`, `GENDER`, `BIRTH_DATE` FROM `user` ORDER BY `Id` DESC LIMIT 10;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        public async Task DeleteAllAsync() {
            using var txn = await Db.Connection.BeginTransactionAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `user`";
            await cmd.ExecuteNonQueryAsync();
            await txn.CommitAsync();
        }

        private async Task<List<User>> ReadAllAsync(DbDataReader reader) {
            var users = new List<User>();
            using(reader) {
                while(await reader.ReadAsync()) {
                    var user = new User(Db) {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Cpf = reader.GetString(2),
                        Email = reader.GetString(3),
                        Phone = reader.GetString(4),
                        Gender = reader.GetInt32(5),
                        BirthDate = reader.GetDateTime(6)
                    };
                    users.Add(user);
                }
            }
            return posts;
        }
    }
}