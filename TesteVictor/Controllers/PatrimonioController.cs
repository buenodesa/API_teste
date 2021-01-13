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
    [RoutePrefix("Patrimonio")]
    //DEFINE O PREFIXO DA ROTA
    public class PatrimonioController : ApiController
    {

   
        PatrimonioModel modelPatrimonio = new PatrimonioModel();
        [HttpGet()]
        [Produces("application/json")]
        //DEFINE QUE SERA EM JSON 
        [Route("ListarTodos")]
        //NOME DA ROTA DO METODO
        public IHttpActionResult ListarTodosPatrimonios()
        {
            try
            {
                //EXECUTA O METODO QUE LISTA TODOS OS PATRIMONIOS
                return Json(modelPatrimonio.ListarTodosPatrimonios());
            }
            catch (Exception)
            {
                // RETORNA BADREQUEST = ERRO 400
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet()]
        [Produces("application/json")]
        [Route("ListarPatrimonio/{codigo}")]
        public IHttpActionResult ListarPatrimonio(int codigo)
        {
            try
            {
                //EXECUTA O METODO QUE LISTA O PATRIMONIO PELO CODIGO

                return Json(modelPatrimonio.listarPatrimonio(codigo));
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost()]
        [Produces("application/json")]
        [Route("InserirPatrimonio")]
        public IHttpActionResult inserirPatrimonio(Patrimonio patrimonio)
        {
            try
            {
                //EXECUTA O METODO QUE INSERE UM PATRIMONIO

                modelPatrimonio.inserirPatrimonio(patrimonio);
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
        public void atualizarPatrimonio(Patrimonio patrimonio)
        {
            try
            {              
                //EXECUTA O METODO QUE ATUALIZA UM PATRIMONIO CONFORME O CODIGO DELE

                modelPatrimonio.atualizarPatrimonio(patrimonio);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
        [HttpDelete()]
        [Route("DeletarPatrimonio/{codigo}")]

        public IHttpActionResult deletarPatrimonio(int codigo)
        {
            try
            {
                   //EXECUTA O METODO QUE DELETA O PATRIMONIO PELO CODIGO
                modelPatrimonio.deletarPatrimonio(codigo);
                //RETORNA COMO EXECUTADO METODO
                return Ok();
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

        }
    }
}