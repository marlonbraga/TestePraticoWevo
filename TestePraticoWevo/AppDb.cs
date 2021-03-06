using System;
using MySqlConnector;

namespace TestePraticoWevo {
    public class AppDb:IDisposable {
        public MySqlConnection Connection { get; }

        public AppDb(string connectionString) {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose() => Connection.Dispose();
    }
}
