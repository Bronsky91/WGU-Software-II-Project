using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace C969___Software_II
{
    class DataHelper
    {
        private static int _currentUserId;
        private static string _currentUserName;
        public static string conString = "server=52.206.157.109 ;database=U05jyp;uid=U05jyp;pwd=53688524521;";

        public static int getCurrentUserId()
        {
            return _currentUserId;
        }

        public static void setCurrentUserId(int currentUserId)
        {
            _currentUserId = currentUserId;
        }

        public static string getCurrentUserName()
        {
            return _currentUserName;
        }

        public static void setCurrentUserName(string currentUserName)
        {
            _currentUserName = currentUserName;
        }

        public static int newID(List<int> idList)
        {
            int highestID = 0;
            foreach (int id in idList)
            {
                if (id > highestID)
                    highestID = id;
            }
            return highestID + 1;
        }

        public static string createTimestamp()
        {
            return DateTime.Now.ToString("u");
        }

        public static int createID(string table)
        {
            MySqlConnection c = new MySqlConnection(conString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT {table+"Id"} FROM {table}", c);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<int> idList = new List<int>();
            while(rdr.Read())
            {
                idList.Add(Convert.ToInt32(rdr[0]));
            }
            rdr.Close();
            c.Close();
            return newID(idList);
        }
    }

}
