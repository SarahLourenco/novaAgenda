using System;
using System.Data.SQLite;

namespace novaAgenda.Database
{
    class Repositorio
    {
        // Holds our connection with the database
        SQLiteConnection m_dbConnection;
        static SQLiteConnection conexao;
        static void Create ()
        {
            Repositorio p = new Repositorio();
        }

        public Repositorio()
        {
            createNewDatabase();
            connectToDatabase();
            createTable();
            fillTable();
        }

        // Creates an empty database file
        void createNewDatabase()
        {
            SQLiteConnection.CreateFile("MyDatabase.sqlite");
        }

        // Creates a connection with our database file.
        void connectToDatabase()
        {
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
            conexao = m_dbConnection;
        }
        public static SQLiteConnection GetConexao()
        {
            return conexao;
        }

        // Creates a table named 'highscores' with two columns: name (a string of max 20 characters) and score (an int)
        void createTable()
        {
            string sql = "create table contato (id int, nome varchar(20),numero int)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        // Inserts some values in the highscores table.
        // As you can see, there is quite some duplicate code here, we'll solve this in part two.
        void fillTable()
        {
            string sql = "insert into contato values (1,'Sarah',12345),(2,'Werick',543543534),(3,'Genezys',3432432)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
         }

        // Writes the highscores to the console sorted on score in descending order.
        void printHighscores()
        {
            string sql = "select * from highscores order by score desc";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
            Console.ReadLine();
        }
    }
}