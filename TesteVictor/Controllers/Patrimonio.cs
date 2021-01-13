using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteVictor.Models
{
    public class Patrimonio
    {
        public Patrimonio(int codigo, string nome, string descricao, Marca marca)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.descricao = descricao;
            this.marca = marca;
        }
        public Patrimonio()
        {
         
        }
        public int codigo { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public Marca marca { get; set; }
    }
}