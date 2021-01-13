using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteVictor.Models
{
    public class Marca
    {
        //CONSTRUTOR 
        public Marca(int codigo, string nome)
        {
            this.codigo = codigo;
            this.nome = nome;
        }
        public Marca()
        {
        }
        public int codigo { get; set; }
        public string nome { get; set; }
    }
}