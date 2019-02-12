using System;
using BLL.Model;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;

namespace DAL.Persistence
{
    public class FilhoDal : Conexao
    {
        public void Salvar(Filho filho)
        {
            try
            {
                var sql = "INSERT INTO filho(nome, idPai, idMae, dtCadastro)" +
                    "VALUES (@nome,@idPai,@idMae, CURDATE())";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nome", filho.Nome);
                command.Parameters.AddWithValue("@idPai", filho.IdPai);
                command.Parameters.AddWithValue("@idMae", filho.IdMae);
                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado" + erro);
            }
        }

        public Filho PesquisarPorId(int id)
        {
            try
            {
                var sql = "SELECT * FROM filho WEHERE id = @id";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                dataReader = command.ExecuteReader(); //receber o resultado da consulta
                Filho filho = new Filho();
                if (dataReader.Read())
                {
                    filho.Id = Convert.ToInt32(dataReader["id"]);
                    filho.IdPai = Convert.ToInt32(dataReader["idPai"]);
                    filho.IdMae = Convert.ToInt32(dataReader["idMae"]);
                    filho.Nome = dataReader["nome"].ToString();
                    filho.dtCadastro = dataReader["dtCadastro"].ToString();
                }
                return filho;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado" + erro);
            }

        }

        public List<Filho> PesquisarPorNome(string nome)
        {
            try
            {
                var sql = "SELECT * FROM filho WEHERE nome LIKE '%" + nome + "%' ";

                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader(); //receber o resultado da consulta
                List<Filho> listaFilho = new List<Filho>();


                if (dataReader.Read())
                {
                    Filho filho = new Filho();
                    filho.Id = Convert.ToInt32(dataReader["id"]);
                    filho.IdPai = Convert.ToInt32(dataReader["idPai"]);
                    filho.IdMae = Convert.ToInt32(dataReader["idMae"]);
                    filho.Nome = dataReader["nome"].ToString();
                    filho.dtCadastro = dataReader["dtCadastro"].ToString();
                    listaFilho.Add(filho);
                }
                return listaFilho;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado" + erro);
            }

        }
        public FilhoDal()
        {
        }
    }
}
