using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Npgsql;
using System.Threading.Tasks;
using NpgsqlTypes;

namespace Fishingtracker1
{
    class SQL
    {
        static private NpgsqlConnection connection;
        private const string HOST = "localhost";
        private const string USERNAME = "postgres";
        private const string PASSWORD = "postgres";
        private const string DB = "fishing_tracker";
        private const string CONNECTION_STRING = "Host=" + HOST + ";Username=" + USERNAME + ";Password=" + PASSWORD + ";Database=" + DB;
        static private NpgsqlCommand lisaaKala = null;
        static private NpgsqlCommand kaikkiKalat = null;


        public static void SqlConnection() // Yhteys tietokantaan
        {

            try
            {
                connection = new NpgsqlConnection(CONNECTION_STRING);
                connection.Open();
            }
            catch (NpgsqlException ex)
            {
                throw new NpgsqlException($"Error in database connection ({ ex.Message }).");
            }
        }
        public static void AddFish(Catch saaliit)
        {
            using (lisaaKala = new NpgsqlCommand("INSERT INTO catch(fk_fish, fish_weight, fish_lenght, fish_time)" + "VALUES (@fish, @lenght, @weight, @fishtime)", connection))
            {
                lisaaKala.Parameters.AddWithValue("fish", saaliit.GetFishNumber());
                lisaaKala.Parameters.AddWithValue("lenght", saaliit.GetFishLenght());
                lisaaKala.Parameters.AddWithValue("weight", saaliit.GetFishWeight());
                lisaaKala.Parameters.AddWithValue("fishtime", saaliit.GetFishTime());
                lisaaKala.ExecuteNonQuery();
                
            }

                
        }
        static public void SelectKaikkiSaaliit()
        {
            
            using (kaikkiKalat = new NpgsqlCommand("SELECT species, fish_weight, fish_lenght FROM catch INNER JOIN fish ON catch.fk_fish = fish.id_fish", connection))
            {
                kaikkiKalat.Prepare();

                using (NpgsqlDataReader kalat = kaikkiKalat.ExecuteReader())
                {

                    while (kalat.Read())
                    {
                        Console.WriteLine($"{kalat.GetString(0)}, {kalat.GetInt32(1)} Kg {kalat.GetInt32(2)} Cm");
                        }
                }
            }
        }
    }
}
