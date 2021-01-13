using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TesteVictor.Models
{
    //STRING DE CONEXAO

    public class Conexao
    {
        public SqlConnection conexao = new SqlConnection("Data Source = localhost; Initial Catalog = teste; Integrated Security = True;");
    }
}