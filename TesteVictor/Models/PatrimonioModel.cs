using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TesteVictor.Models
{

    public class PatrimonioModel
    {    Conexao con = new Conexao();

        public void inserirPatrimonio(Patrimonio patrimonio)
        {
            try
            {

                SqlCommand cmmd = new SqlCommand();
                cmmd.CommandText = "INSERT INTO Patrimonio (NOME, DESCRICAO, CODIGO_MARCA) VALUES ('" + patrimonio.nome + "'," +
                    "'"+patrimonio.descricao+"','"+patrimonio.marca.codigo+"')";
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
        public void deletarPatrimonio(int codigo)
        {
            try
            {

                SqlCommand cmmd = new SqlCommand();
                cmmd.CommandText = "DELETE Patrimonio WHERE CODIGO = " + codigo + " ";
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
        public void atualizarPatrimonio(Patrimonio patrimonio)
        {
            try
            {

                SqlCommand cmmd = new SqlCommand();
                cmmd.CommandText = "UPDATE PATRIMONIO" +
                    " SET NOME = '" + patrimonio.nome + "'," +
                    "  DESCRICAO = '"+patrimonio.descricao+ "'," +
                    "  CODIGO_MARCA = "+patrimonio.codigo+" " +
                    " WHERE CODIGO = ('" + patrimonio.codigo + "')";
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
        public Patrimonio listarPatrimonio(int codigo)
        {
            Patrimonio patrimonio = new Patrimonio();
            Marca marca = new Marca();

            try
            {
                SqlCommand cmmd = new SqlCommand();
                cmmd.CommandText = "SELECT CODIGO, NOME,DESCRICAO,CODIGO_MARCA FROM PATRIMONIO WHERE CODIGO =" + codigo + " AND ATIVO = 1 ";
                cmmd.Connection = con.conexao;
                con.conexao.Open();
                SqlDataReader reader = null;
                reader = cmmd.ExecuteReader();
                reader.Read();

                patrimonio.codigo = Convert.ToInt32(reader["CODIGO"]);
                patrimonio.descricao = reader["DESCRICAO"].ToString();
                patrimonio.nome = reader["NOME"].ToString();
                marca.codigo = Convert.ToInt32(reader["CODIGO_MARCA"]);
                patrimonio.marca = marca;
                return patrimonio;
            }
            catch (Exception E)
            {
                return patrimonio;
            }
            finally
            {
                con.conexao.Close();
            }
        }
        public List<Patrimonio> ListarTodosPatrimonios()
        {
            List<Patrimonio> Listmarca = new List<Patrimonio>();
            try
            {
                SqlCommand cmmd = new SqlCommand();
                cmmd.CommandText = "SELECT " +
                                        "P.CODIGO, " +
                                        "P.NOME, " +
                                        "P.DESCRICAO, " +
                                        "P.CODIGO_MARCA, " +
                                        "M.NOME NOME_MARCA " +
                                        "FROM " +
                                        "PATRIMONIO P " +
                                        "INNER JOIN MARCA M ON M.CODIGO = P.CODIGO_MARCA " +
                                        " WHERE M.ATIVO = 1 AND P.ATIVO = 1;";
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
                    Listmarca.Add(patrimonio);
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
    }
}
