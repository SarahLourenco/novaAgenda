using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using novaAgenda.Models;

namespace novaAgenda.Database
{
    public class ContatoDAO
    {
        public Contato  GetContatoByID(int id) {
            string sql = "select * from Contato where id = " + id ;
            SQLiteCommand command = new SQLiteCommand(sql, Repositorio.GetConexao());
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
              return (new Contato{Id = Convert.ToInt32(reader["id"]), nome= Convert.ToString(reader["nome"]), numero=Convert.ToInt32(reader["numero"]) });
            return null;
        }
    }
}