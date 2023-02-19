using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLIB.Database
{
    public class DB
    {
        private string host = "localhost";
        private string user = "root";
        private string password = "myrootpassword";
        private string database = "redstone";
        private int port = 3306;
        private string connectionString = "";
        private string tableName = null;
        public DB()
        {
            this.connectionString = $"server={host};database={database};port={port};uid={user};pwd={password}";
        }

        protected void SetTable(string name)
        {
            this.tableName = name;
        }

        protected void Insert(Dictionary<string, object> data)
        {
            string[] keys = data.Keys.ToArray();
            object[] values = data.Values.ToArray();
            string keysString = string.Join(", ", keys);
            string valuesString = string.Join("', '", values);
            string query = $"INSERT INTO {this.tableName} ({keysString}) VALUES ('{valuesString}')";

            using (MySqlConnection conn = new MySqlConnection(this.connectionString)) { 
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.ExecuteReader();
                }
            }
        }

        protected void Delete(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(this.connectionString))
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand($"DELETE FROM ", conn))
                {
                    command.ExecuteReader();
                }
            }
        }

        protected Dictionary<int, Dictionary<string, object>> Select(string search, int limit = 0, params string[] fields)
        {
            Dictionary<int, Dictionary<string, object>> results = new Dictionary<int, Dictionary<string, object>>();

            string fieldsString = fields.Length == 0 ? "*" : string.Join(", ", fields);
            string limitString = limit == 0 ? "" : $" LIMIT {limit}";

            using (MySqlConnection conn = new MySqlConnection(this.connectionString))
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand($"SELECT {fieldsString} FROM {this.tableName} WHERE {search}{limitString}", conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        int count = 0;
                        while (reader.Read())
                        {
                            Dictionary<string, object> result = new Dictionary<string, object>();
                            for(int fieldIndex = 0; fieldIndex < reader.FieldCount; fieldIndex++)
                            {
                                result.Add(reader.GetName(fieldIndex), reader[reader.GetName(fieldIndex)]);
                            }
                            results.Add(count, result);
                            count++;
                        }
                    }
                }
            }
            return results;
        }


        public Dictionary<int, Dictionary<string, object>> Query(string query)
        {
            Dictionary<int, Dictionary<string, object>> results = new Dictionary<int, Dictionary<string, object>>();
            using (MySqlConnection conn = new MySqlConnection(this.connectionString))
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        int count = 0;
                        while (reader.Read())
                        {
                            Dictionary<string, object> result = new Dictionary<string, object>();
                            for (int fieldIndex = 0; fieldIndex < reader.FieldCount; fieldIndex++)
                            {
                                result.Add(reader.GetName(fieldIndex), reader[reader.GetName(fieldIndex)]);
                            }
                            results.Add(count, result);
                            count++;
                        }
                    }
                }
            }
            return results;
        }

    }
}
