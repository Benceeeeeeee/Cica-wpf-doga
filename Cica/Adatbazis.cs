﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cica
{
    internal class Adatbazis
    {
        private List<Cicak> lista;
        private string connectionString;

        public Adatbazis()
        {
            lista = new List<Cicak>();
            connectionString = "server=localhost;database=cicadb;user=root;password='';";
        }
        public List<Cicak> Feltolt()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM cicak";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cicak cica = new Cicak
                                (
                                reader.GetString("nev"),
                                reader.GetString("fajta"),
                                reader.GetFloat("suly"),
                                reader.GetInt32("rendetlensegi_szint")
                                );
                            lista.Add(cica);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba " + ex.Message);
                Environment.Exit(1);
            }

            return lista;
        }

        public string Kereses(string nev)
        {
            string s = "";
            foreach (Cicak c in lista)
            {
                if(c.Nev == nev)
                {
                    s += "Név: " + c.Nev + "\nFajta: " + c.Fajta + "\nSúly: " + c.Suly + "\nRendetlenségi szint: " + c.Rendetlensegi_szint;
                }
            }
            return s;
        }

        public Cicak LengehezebbCica()
        {
            return lista.OrderByDescending(x => x.Suly).FirstOrDefault();
        }

        public Cicak LengRendetlenebbCica()
        {
            return lista.OrderByDescending(x => x.Rendetlensegi_szint).FirstOrDefault();
        }

        public bool CicaHozzaadas(string nev, string fajta, float suly, int rendetlensegiSzint)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO cicak (nev, fajta, suly, rendetlensegi_szint) VALUES (@nev, @fajta, @suly, @rendetlenseg)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nev", nev);
                        cmd.Parameters.AddWithValue("@fajta", fajta);
                        cmd.Parameters.AddWithValue("@suly", suly);
                        cmd.Parameters.AddWithValue("@rendetlenseg", rendetlensegiSzint);

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba az adatbázisban: " + ex.Message);
                return false;
            }
        }

        public void CicaTorlese(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM `cicak` WHERE `cicak.id` = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        int rows = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba az adatbázisban: " + ex.Message);
            }
        }

    }
}
