using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;

namespace BrajicaApp
{
    class Controller
    {
        public static void update_letter_state(string letter, bool success)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Baza.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM pismo", con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        MessageBox.Show(reader.GetString(0) + reader.GetString(1));
                    }
                }
            }
        }
        
    }
}
