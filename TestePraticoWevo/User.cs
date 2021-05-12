using MySqlConnector;
using System;
using System.Data;
using System.Threading.Tasks;

namespace TestePraticoWevo {
	public class User {
		public int? Id { get; set; }
		public string Name { get; set; }
		public string Cpf { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public int? Gender { get; set; }
		public DateTime? BirthDate { get; set; }

		internal AppDb Db { get; set; }

        public User() {
        }

        internal User(AppDb db) {
            Db = db;
        }

        public async Task InsertAsync() {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `user` (`NAME`, `CPF`, `EMAIL`, `PHONE`, `GENDER`, `BIRTH_DATE`) VALUES (@Name, @Cpf, @Email, @Phone, @Gender, @BirthDate);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            Id = (int)cmd.LastInsertedId;
        }

        public async Task UpdateAsync() {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE `user` SET `NAME` = @Name, `CPF` = @Cpf, `EMAIL` = @Email, `PHONE` = @Phone, `GENDER` = @Gender, `BIRTH_DATE` = @BirthDate WHERE `ID` = @Id;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync() {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `user` WHERE `ID` = @Id;";
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        private void BindId(MySqlCommand cmd) {
            cmd.Parameters.Add(new MySqlParameter {
                ParameterName = "@Id",
                DbType = DbType.Int32,
                Value = Id,
            });
        }

        private void BindParams(MySqlCommand cmd) {
            cmd.Parameters.Add(new MySqlParameter {
                ParameterName = "@Name",
                DbType = DbType.String,
                Value = Name,
            });
            cmd.Parameters.Add(new MySqlParameter {
                ParameterName = "@Cpf",
                DbType = DbType.String,
                Value = Cpf,
            });
            cmd.Parameters.Add(new MySqlParameter {
                ParameterName = "@Email",
                DbType = DbType.String,
                Value = Email,
            });
            cmd.Parameters.Add(new MySqlParameter {
                ParameterName = "@Phone",
                DbType = DbType.String,
                Value = Phone,
            });
            cmd.Parameters.Add(new MySqlParameter {
                ParameterName = "@Gender",
                DbType = DbType.String,
                Value = Gender,
            });
            cmd.Parameters.Add(new MySqlParameter {
                ParameterName = "@BirthDate",
                DbType = DbType.String,
                Value = BirthDate,
            });
        }
    }
}
