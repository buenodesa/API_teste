using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TesteVictor.Models
{

    public class MarcaModel
    {
        Conexao con = new Conexao();
        public void inserirMarca(Marca marca)
        {
            try
            {

                SqlCommand cmmd = new SqlCommand();
                cmmd.CommandText = "INSERT INTO MARCA (NOME) VALUES ('" + marca.nome + "')";
                cmmd.Connection = con.conexao;
                con.conexao.Open();
                cmmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {

            }
            finally
            {
                con.conexao.Close();
            }
        }
        public void deletarMarca(int codigo)
        {
            try
            {

                SqlCommand cmmd = new SqlCommand();
                cmmd.CommandText = "DELETE PATRIMONIO WHERE CODIGO_MARCA = " + codigo + " " +
                                   "DELETE MARCA WHERE CODIGO = " + codigo + " ";
                cmmd.Connection = con.conexao;
                con.conexao.Open();
                cmmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {

            }
            finally
            {
                con.conexao.Close();
            }
        }
        public void atualizarMarca(Marca marca)
        {
            try
            {

                SqlCommand cmmd = new SqlCommand();
                cmmd.CommandText = "UPDATE MARCA SET NOME = ('" + marca.nome + "') WHERE CODIGO = ('" + marca.codigo + "')";
                cmmd.Connection = con.conexao;
                con.conexao.Open();
                cmmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {

            }
            finally
            {
                con.conexao.Close();
            }
        }
        public Marca listarMarca(int codigo)
        {
            Marca marca = new Marca();

            try
            {
                SqlCommand cmmd = new SqlCommand();
                cmmd.CommandText = "SELECT CODIGO, NOME FROM MARCA WHERE CODIGO =" + codigo + " AND ATIVO = 1 ";
                cmmd.Connection = con.conexao;
                con.conexao.Open();
                SqlDataReader reader = null;
                reader = cmmd.ExecuteReader();
                reader.Read();

                marca.codigo = Convert.ToInt32(reader["CODIGO"]);
                marca.nome = reader["NOME"].ToString();
                return marca;
            }
            catch (Exception E)
            {
                return marca;
            }
            finally
            {
                con.conexao.Close();
            }
        }
        public List<Marca> ListarTodasmarcas()
        {
            List<Marca> Listmarca = new List<Marca>();
            try
            {
                SqlCommand cmmd = new SqlCommand();
                cmmd.CommandText = "SELECT CODIGO, NOME FROM MARCA WHERE ATIVO = 1";
                cmmd.Connection = con.conexao;
                con.conexao.Open();
                SqlDataReader reader = null;
                reader = cmmd.ExecuteReader();
                while (reader.Read())
                {
                    Marca marca = new Marca();
                    marca.codigo = Convert.ToInt32(reader["CODIGO"]);
                    marca.nome = reader["NOME"].ToString();
                    Listmarca.Add(marca);
                }               

                return Listmarca;
            }
            catch (Exception E)
            {
                return Listmarca;
            }
            finally
            {
                con.conexao.Close();
            }
        }
        public List<Patrimonio> ListarPatrimonio(int codigo)
        {
            List<Patrimonio> ListPatrimonio = new List<Patrimonio>();
            try
            {
                SqlCommand cmmd = new SqlCommand();
                cmmd.CommandText = "SELECT " +
                                        "PAT.CODIGO, " +
                                        "PAT.NOME, " +
                                        "PAT.DESCRICAO, " +
                                        "PAT.CODIGO_MARCA, " +
                                        "MAR.NOME NOME_MARCA " +
                                        "FROM " +
                                      "PATRIMONIO PAT " +
                                 "INNER JOIN MARCA MAR ON MAR.CODIGO = PAT.CODIGO_MARCA" +
                                 " WHERE" +
                                      " PAT.ATIVO = 1 " +
                                      " AND MAR.ATIVO = 1" +
                                      " AND MAR.CODIGO=" + codigo + ";";
                cmmd.Connection = con.conexao;
                con.conexao.Open();
                SqlDataReader reader = null;
                reader = cmmd.ExecuteReader();
                while (reader.Read())
                {
                    Patrimonio patrimonio = new Patrimonio(
                         Convert.ToInt32(reader["CODIGO"]),
                         reader["NOME"].ToString(),
                         reader["DESCRICAO"].ToString(),
                          new Marca(
                               Convert.ToInt32(reader["CODIGO_MARCA"]),
                               reader["NOME_MARCA"].ToString()
                              )
                        );
                   
                    ListPatrimonio.Add(patrimonio);
                }

                return ListPatrimonio;
            }
            catch (Exception E)
            {
                return ListPatrimonio;
            }
            finally
            {
                con.conexao.Close();
            }
        }
    }
}
