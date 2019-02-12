using System;
using BLL.Model;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;

namespace DAL.Persistence
{
    public class PaiDal : Conexao
    {
        public void Salvar(Pai pai)
        {
            try{
            var sql = "INSERT INTO pai(nome, dtCadastro)" +
                "VALUES (@nome, CURDATE())";

            command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@nome", pai.Nome);
            command.ExecuteNonQuery();
            }catch(Exception erro)
            {
                throw new Exception("Erroa ao registrar dado" + erro);
            }
        }

        public Pai PesquisarPorId(int id)
        {
            try
            {
                var sql = "SELECT * FROM pai WEHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                dataReader = command.ExecuteReader(); //receber o resultado da consulta
                Pai pai = new Pai();
                if (dataReader.Read())
                {
                    pai.Id = Convert.ToInt32(dataReader["id"]);
                    pai.Nome = dataReader["nome"].ToString();
                    pai.dtCadastro = dataReader["dtCadastro"].ToString();
                }
                return pai;
            }
            catch (Exception erro)
            {
                throw new Exception("Erroa ao registrar dado" + erro);
            }

        }

        public List<Pai> PesquisarPorNome(string nome)
        {
            try
            {
                var sql = "SELECT * FROM pai WEHERE nome LIKE '%" + nome + "%' ";

                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader(); //receber o resultado da consulta
                List<Pai> listaPai = new List<Pai>();


                if (dataReader.Read())
                {
                    Pai pai = new Pai();
                    pai.Id = Convert.ToInt32(dataReader["id"]);
                    pai.Nome = dataReader["nome"].ToString();
                    pai.dtCadastro = dataReader["dtCadastro"].ToString();
                    listaPai.Add(pai);
                }
                return listaPai;
            }
            catch (Exception erro)
            {
                throw new Exception("Erroa ao registrar dado" + erro);
            }

        }
        public PaiDal()
        {
        }
    }
}
