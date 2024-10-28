using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bida.DAO
{
    class DataProvider
    {
        public static string onStr = "Server=DLONG\\SQLEXPRESS;Database=Bida;Integrated Security=True;";
        //public static string onStr = "Server=DESKTOP-PEH7GUJ\\SQLEXPRESS;Database=Bida;Integrated Security=True;";
        //public static string onStr = "Server=LENOVO\\SQLEXPRESS01;Database=Bida;Integrated Security=True;";


        SqlConnection conn;
        private SqlCommand command;

        public DataProvider()
        {
            conn = new SqlConnection(onStr);
        }

        public void Connect()
        {
            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Connection error: " + ex.Message);
                throw;
            }
        }
        public void Disconnect()
        {
            conn.Close();
        }
        public SqlDataReader ExcuteReader(String sql)
        {
            command = new SqlCommand(sql, conn);
            return command.ExecuteReader();
        }
        public void executeNonQuery(string sql)
        {
            this.command = new SqlCommand(sql, conn);
            this.command.ExecuteNonQuery();
        }
    }
}
