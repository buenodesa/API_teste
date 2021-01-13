using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteVictor.Models;
using FromBodyAttribute = System.Web.Http.FromBodyAttribute;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace TesteVictor.Controllers
{
    [RoutePrefix("Marca")]
    public class MarcaController : ApiController
    {
        MarcaModel modelMarca = new MarcaModel();
        [HttpGet()]
        [Produces("application/json")]
        [Route("ListarTodas")]

        public IHttpActionResult ListarTodasmarcas()
        {
            try
            {
                return Json(modelMarca.ListarTodasmarcas());
                // LISTA TODAS AS MARCAS
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            //https://localhost:44321/Marca/ListarTodas

        }

        [HttpGet()]
        [Produces("application/json")]
        [Route("ListarMarca/{codigo}")]
        public IHttpActionResult Listarmarca(int codigo)
        {
            try
            {// LISTA A MARCA PELO CODIGO
                return Json(modelMarca.listarMarca(codigo));
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            //https://localhost:44321/Marca/ListarMarca/1
        }
        [HttpGet()]
        [Produces("application/json")]
        [Route("ListarMarca/{codigo}/Patrimonio")]
        public IHttpActionResult ListarPatrimonio(int codigo)
        {
            try
            {
                // LISTA TODOS OS PATRIMONIOS DA MARCA
                return Json(modelMarca.ListarPatrimonio(codigo));
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            //https://localhost:44321/Marca/ListarMarca/1
        }

        [HttpPost()]
        [Produces("application/json")]
        [Route("InserirMarca")]
        public IHttpActionResult inserirMarca(Marca marca)
        {
            try
            {                 //EXECUTA O METODO QUE INSERE A MARCA SE NÃO EXISTIR UMA MARCA COM ESSE NOME

                List<Marca> todasMarcas = new List<Marca>();
                todasMarcas = modelMarca.ListarTodasmarcas();
                if (todasMarcas.FindAll(x => x.nome == marca.nome).Count == 0)
                    modelMarca.inserirMarca(marca);
                return Ok();
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

        }
        [HttpPut()]
        [Produces("application/json")]
        [Route("Atualizar")]
        public void atualizarMarca(Marca marca)
        {
            try
            {
                //EXECUTA O METODO QUE ATUALIZA A MARCA SE NÃO EXISTIR UMA MARCA COM ESSE NOME

                List<Marca> todasMarcas = new List<Marca>();
                todasMarcas = modelMarca.ListarTodasmarcas();
                if (todasMarcas.FindAll(x => x.nome == marca.nome).Count == 0)
                    modelMarca.atualizarMarca(marca);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
        [HttpDelete()]
        [Route("DeletarMarca/{codigo}")]

        public IHttpActionResult deletarMarca(int codigo)
        {
            try
            {                //EXECUTA O METODO QUE DELETA A MARCA

                modelMarca.deletarMarca(codigo);
                return Ok();
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

        }
    }
}
