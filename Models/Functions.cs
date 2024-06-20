using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GroceryShopManagement.Models
{
    public class Functions
    {
        private SqlConnection Con;
        private SqlCommand cmd;
        private DataTable tb;
        private SqlDataAdapter adapter;
        private string ConString;

        public Functions()
        {
            ConString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Azay\Documents\GroceryDb.mdf;Integrated Security=True;Connect Timeout=30";
            Con = new SqlConnection(ConString);
            cmd = new SqlCommand();
            cmd.Connection = Con;


        }
        public DataTable getData(string query)
        {
            tb = new DataTable();
            adapter = new SqlDataAdapter(query, ConString);
            adapter.Fill(tb);
            return tb;
        }
        public int setData(string query)
        {
            int cnt = 0;
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            cmd.CommandText = query;
            cnt = cmd.ExecuteNonQuery();
            Con.Close();
            return cnt;
        }
    }
}