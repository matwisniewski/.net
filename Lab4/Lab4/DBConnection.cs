using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Lab4
{
    class DBConnection
    {
        public static MySqlConnection Connection()
        {
                MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder
                {
                    Port = uint.Parse("3306"),
                    Server = "localhost",
                    UserID = "root",
                    Password = "",
                    Database = "RockMusic"
                };
                MySqlConnection connection = new MySqlConnection(connectionStringBuilder.ToString());
                return connection;
        }
    }
}
