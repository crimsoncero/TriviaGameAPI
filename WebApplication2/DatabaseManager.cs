

using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace WebApplication2
{
    public class DatabaseManager
    {
        string conStr = "server=LocalHost;uid=root;" +
    "pwd=Fe253826;database=triviagame";
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;


        private void Connect()
        {
            con = new MySqlConnection(conStr);
            try
            {
                con.Open();
            }
            catch
            {
                con.Close();
            }
        }

        private void Disconnect()
        {
            con?.Close();
        }

        public Dictionary<string,string> GetQuestion(int questionID)
        {
            Dictionary<string, string> questionDict = new Dictionary<string, string>();

            Connect();
            string query = $"SELECT * FROM questionsView WHERE id = {questionID}";
            cmd = new MySqlCommand(query, con);

            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                
                questionDict.Add("Category", reader.GetString("Category"));
                questionDict.Add("Genre", reader.GetString("Genre"));
                questionDict.Add("Question", reader.GetString("Question"));
                questionDict.Add("Answer", reader.GetString("Answer"));
                questionDict.Add("False1", reader.GetString("False1"));
                questionDict.Add("False2", reader.GetString("False2"));
                questionDict.Add("False3", reader.GetString("False3"));

            }
            Disconnect();
            return questionDict;
        }

        public void InsertPlayer(string name, int time)
        {
            Connect();
            string query = $"INSERT INTO players(name, loginTime) VALUES('{name}', {time});";
            cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();

            Disconnect();
        }

        public void UpdatePlayerScore(int playerId, int score)
        {
            Connect();
            string query = $"UPDATE `players` SET `score` = '{score}' WHERE (`id` = '{playerId}');";
            cmd = new MySqlCommand(query, con);

            cmd.ExecuteNonQuery();
            Disconnect();
        }

        public int GetPlayerID(string name, int time)
        {
            Connect();
            string query = $"SELECT id FROM players WHERE name = '{name}' AND loginTime = {time};";
            cmd = new MySqlCommand(query, con);

            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return reader.GetInt32(0);
            }
            return -1;
        }

        public int GetPlayerTime(int id)
        {
            Connect();
            string query = $"SELECT loginTime FROM players WHERE id = '{id}';";
            cmd = new MySqlCommand(query, con);

            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return reader.GetInt32(0);
            }
            return -1;
        }

        public int GetPlayerScore(int id)
        {
            Connect();
            string query = $"SELECT score FROM players WHERE id = {id};";
            cmd = new MySqlCommand(query, con);
            int score = -1;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader.IsDBNull(reader.GetOrdinal("score"))) return -1;
                
                score = reader.GetInt32(reader.GetOrdinal("score"));
            }
            return score;
        }

        public void DeletePlayer(int id)
        {
            Connect();
            string query = $"DELETE FROM players WHERE id = {id}; ALTER TABLE `players` AUTO_INCREMENT = 0";
            cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();

            Disconnect();
        }

        public int GetFirstPlayerTime()
        {
            Connect();
            string query = $"SELECT loginTime FROM players WHERE id = 1;";
            cmd = new MySqlCommand(query, con);

            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return reader.GetInt32(0);
            }
            return -1;
        }

        public int GetPlayerCount()
        {
            Connect();
            string query = $"SELECT COUNT(id) FROM players; ";
            cmd = new MySqlCommand(query, con);

            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return reader.GetInt32(0);
            }
            return -1;
        }

        public int GetQuestionCount()
        {
            Connect();
            string query = $"SELECT COUNT(id) FROM questions; ";
            cmd = new MySqlCommand(query, con);

            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return reader.GetInt32(0);
            }
            return -1;
        }
    }
}