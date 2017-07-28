using System;
using System.Windows;
using System.Collections.Generic;

using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace BrajicaApp
{
    public static class Baza
    {
        private static string connectionString = "Data Source=Baza.sqlite;Version=3;";

        public static Dictionary<string, string> get()
        {
            Dictionary<string,string>dic=new Dictionary<string, string>();

            dic.Add("a", "1");
            dic.Add("1", "1");
            dic.Add("b", "101");
            dic.Add("2", "101");
            dic.Add("c", "11");
            dic.Add("3", "11");
            dic.Add("č", "100001");
            dic.Add("ć", "110001");
            dic.Add("d", "1101");
            dic.Add("4", "1101");
            dic.Add("dž", "111101");
            dic.Add("đ", "110101");
            dic.Add("e", "1001");
            dic.Add("5", "1001");
            dic.Add("f", "111");
            dic.Add("6", "111");
            dic.Add("g", "1111");
            dic.Add("7", "1111");
            dic.Add("h", "1011");
            dic.Add("8", "1011");
            dic.Add("i", "011");
            dic.Add("9", "011");
            dic.Add("j", "0111");
            dic.Add("0", "0111");
            dic.Add("k", "10001");
            dic.Add("l", "10101");
            dic.Add("lj", "101001");
            dic.Add("m", "11001");
            dic.Add("n", "11011");
            dic.Add("nj", "111001");
            dic.Add("o", "10011");
            dic.Add("p", "11101");
            //dic.Add("q", "11111");
            dic.Add("r", "10111");
            dic.Add("s", "01101");
            dic.Add("š", "100101");
            dic.Add("t", "01111");
            dic.Add("u", "100011");
            dic.Add("v", "101011");
            /*dic.Add("w", "011101");
            dic.Add("x", "110011");
            dic.Add("y", "110111");*/
            dic.Add("z", "100111");
            dic.Add("ž", "011011");
            dic.Add("^", "010001");
            dic.Add("$", "010111");
            dic.Add(".", "001101");
            dic.Add(",", "001");
            dic.Add("!", "00111");
            dic.Add("-", "000011");
            dic.Add(" ", "0");
            dic.Add("°", "000001");
            
            return dic;
        }
        public static void init()
        {
            SQLiteConnection.CreateFile("Baza.sqlite");
            SQLiteConnection con = new SQLiteConnection(connectionString);
            con.Open();
            SQLiteCommand com1 = new SQLiteCommand("create table STANJA_R (slovo nvarchar(25),poluraspad decimal(15,5),datum datetime)", con);
            SQLiteCommand com2 = new SQLiteCommand("create table STANJA_C (slovo nvarchar(25),poluraspad decimal(15,5),datum datetime)", con);
            com1.ExecuteNonQuery();
            com2.ExecuteNonQuery();
        }
        public static void callsPreBase()
        {
            var D = get();
            DBOperation("DELETE FROM STANJA_R;");
            DBOperation("DELETE FROM STANJA_C;");
            Random r = new Random();
            
            foreach (var K in D)
            {
                if ((K.Key[0] >= 'a' && K.Key[0] <= 'z'))
                {
                    int kol = r.Next(2342, 2563);
                    double rj = kol / 100.0;
                    DBOperation("INSERT INTO STANJA_R (slovo,poluraspad,datum) VALUES ('" + K.Key + "',"+rj+",CURRENT_TIMESTAMP)");
                    kol = r.Next(2342, 2563);
                    rj = kol / 100.0;
                    DBOperation("INSERT INTO STANJA_C (slovo,poluraspad,datum) VALUES ('" + K.Key + "',"+rj+",CURRENT_TIMESTAMP)");

                    if (K.Key[0] >= 'a' && K.Key[0] <= 'z')
                    {
                        string veliko = "";
                        if (K.Key.Length > 1) veliko = K.Key[0].ToString().ToUpper() + K.Key.Substring(1);
                        else veliko = K.Key.ToUpper();
                        int kol2 = r.Next(2342, 2562);
                        double rj2 = kol / 100.0;
                        DBOperation("INSERT INTO STANJA_R (slovo,poluraspad,datum) VALUES ('" + veliko + "',"+rj2+",CURRENT_TIMESTAMP)");
                        kol2 = r.Next(2342, 2562);
                        rj2 = kol / 100.0;
                        DBOperation("INSERT INTO STANJA_C (slovo,poluraspad,datum) VALUES ('" + veliko + "',"+rj2+",CURRENT_TIMESTAMP)");
                    }
                }
            }
        }
        public static string getNextLetter(int type)
        {
            SortedList<string, double> lista = new SortedList<string,double>();
            string dbname = "";
            dbname = type == 1 ? "STANJA_C" : "STANJA_R";
            SQLiteConnection con = new SQLiteConnection(connectionString);
            con.Open();
            SQLiteCommand com = new SQLiteCommand("SELECT * FROM " + dbname, con);

            SQLiteDataReader reader= com.ExecuteReader();
            while(reader.Read())
            {
                DateTime dateTime = Convert.ToDateTime(reader["datum"]);
                //MessageBox.Show(reader.GetValue(1).ToString());
                double poluraspad = Convert.ToDouble(reader["poluraspad"]);
                DateTime nowTime = DateTime.Now;
                var hours = (nowTime - dateTime).TotalHours;
                //MessageBox.Show(hours.ToString() + " " + poluraspad.ToString());
                double ans = Math.Pow(2.00, -hours / poluraspad);
                lista.Add(reader["slovo"].ToString(), ans);
                    
                }
            con.Close();
            string k = "";
            double kol = 56;
            foreach(var D in lista)
            {
                if(kol>D.Value)
                {
                    kol = D.Value;
                    k = D.Key;
                }
            }
            
            //MessageBox.Show(kol.ToString());
            return k;
        }

        public static double getGrade(int type)
        {
            
            string dbname = "";
            dbname = type == 1 ? "STANJA_C" : "STANJA_R";
            double ans = 0;
            double suma = 0;
            double kol = 0;
            SQLiteConnection con = new SQLiteConnection(connectionString);
            con.Open();
            SQLiteCommand com = new SQLiteCommand("SELECT * FROM " + dbname, con);
            SQLiteDataReader reader = com.ExecuteReader();
            while (reader.Read())
            
            {
                DateTime dateTime = Convert.ToDateTime(reader["datum"]);
                
                double poluraspad = Convert.ToDouble(reader["poluraspad"]);
                DateTime nowTime = DateTime.Now.ToUniversalTime();
                var hours = (nowTime - dateTime).TotalHours;
                //MessageBox.Show(hours + " " + poluraspad);
                double ans2 = Math.Pow(2.00, -hours / poluraspad);
                suma += ans2;
                ++kol;
            }
            con.Close();                    
            ans = suma / kol;
            return ans;
            
        }
        public static void DBOperation(string query)
        {
            SQLiteConnection con = new SQLiteConnection(connectionString);
            con.Open();
            SQLiteCommand com = new SQLiteCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }
        public static void updateLetterState(string letter, int status,int type)
        {
            string dbname = "";
            if (type == 2) dbname = "STANJA_R";
            else dbname = "STANJA_C";
            if (status==0)
                DBOperation("UPDATE  "+dbname+" SET poluraspad=poluraspad/2, datum=CURRENT_TIMESTAMP WHERE slovo='" + letter +"'");
            else
                DBOperation("UPDATE  "+dbname+" SET poluraspad=poluraspad*2, datum=CURRENT_TIMESTAMP WHERE slovo='" + letter + "'");
        }
    }
}
