using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Aartist
    {
        readonly DataSet customers;

        public Aartist()
        {
            this.customers = new DataSet("Artists");
        }

        public void ShowAllArtistsWithReader()
        {
            using (MySqlConnection conn = DBConnection.Connection())
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM artists", conn))
                    {
                        using (MySqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                int id = (int)dataReader[0];
                                string name = (string)dataReader[1];
                                string surname = (string)dataReader[2];
                                Console.WriteLine($"Id: {id}, Imie: {name}, Nazwisko: {surname}");
                            }
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Błąd reader");
                }
            }
        }

        public void ShowAllArtistsWithAdapter()
        {
            using (MySqlConnection conn = DBConnection.Connection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM artists";
                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn))
                    {
                        dataAdapter.Fill(this.customers);
                        foreach (DataTable dt in this.customers.Tables)
                        {
                            for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                            {
                                Console.Write(dt.Columns[curCol].ColumnName.Trim() + "\t");
                            }
                            Console.WriteLine();
                            for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
                            {
                                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                                {
                                    Console.Write(dt.Rows[curRow][curCol].ToString().Trim() + "\t");
                                }
                                Console.WriteLine();
                            }
                        }
                    }

                }
                catch
                {
                    Console.WriteLine("Błąd adapter");
                }
            }
        }
    }
}
