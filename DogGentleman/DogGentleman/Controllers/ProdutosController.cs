using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DogGentleman.Controllers.TransferObjects;
using DogGentleman.Controllers.Response;
using DogGentleman.Models;

namespace DogGentleman.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/produto")]
    public class ProdutosController : ApiController
    {
        // GET: api/Produtos
        public IHttpActionResult Get()
        {
            ProdutosResponse pResponse = new ProdutosResponse();

            try
            {
                List<Produto> lista = Produto.Listar();
                pResponse.Produtos = new List<ProdutoTO>();

                foreach(Produto p in lista)
                {
                    ProdutoTO pTO = new ProdutoTO();
                    pTO.Id = p.Id;
                    pTO.Preco = p.Preço;
                    pTO.Nome = p.Racao.Nome;
                    pTO.Peso = p.Racao.Peso;

                    pResponse.Produtos.Add(pTO);

                    
                                        
                }

            }
            catch (Exception ex)
            {
               
                pResponse.Status = -1;
                pResponse.Detalhes = ex.Message;

            }

            return Ok(pResponse);
        }

        // GET: api/Produtos/5
        public IHttpActionResult Get(int id)
        {
            ProdutoResponse pResponse = new ProdutoResponse();

            try
            {
                Produto p = Produto.Consultar(id);
                pResponse.Produto = new ProdutoTO();
                pResponse.Produto.Id = p.Id;
                pResponse.Produto.Preco = p.Preço;
                pResponse.Produto.Nome = p.Racao.Nome;
                pResponse.Produto.Peso = p.Racao.Peso;
                

            }
            catch (NegocioException nex)
            {
                pResponse.Status = (int)nex.Codigo;
                pResponse.Detalhes = nex.Message;
            }
            catch (Exception ex)
            {
                pResponse.Status = -1;
                pResponse.Detalhes = ex.Message;
            }

            return Ok(pResponse);
        }

        // POST: api/Produtos
        public IHttpActionResult Post([FromBody]ProdutoTO produtoTO)
        {
            ProdutoResponse pResponse = new ProdutoResponse();
            pResponse.Produto.Preco = produtoTO.Preco;

            try
            {

                pResponse.Produto.Id = Produto.Inserir(produtoTO.Preco);

            }
            catch(NegocioException nex)
            {
                pResponse.Status = (int)nex.Codigo;
                pResponse.Detalhes = nex.Message;
            }
            catch (Exception ex)
            {
                pResponse.Status = -1;
                pResponse.Detalhes = ex.Message;
            }

            return Ok(pResponse);

        }

        // PUT: api/Produtos/5
        public IHttpActionResult Put(int id, [FromBody]ProdutoTO produtoTO)
        {

            BaseResponse baseResponse = new BaseResponse();
            
            try
            {

                Produto.Atualizar(produtoTO.Id, produtoTO.Preco);
            }
            catch (NegocioException nex)
            {
                baseResponse.Status = (int)nex.Codigo;
                baseResponse.Detalhes = nex.Message;
            }
            catch (Exception ex)
            {
                baseResponse.Status = -1;
                baseResponse.Detalhes = ex.Message;
            }

            return Ok(baseResponse);

        }

        // DELETE: api/Produtos/5
        public IHttpActionResult Delete(int id)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {
                Produto.Remover(id);

            }
            catch (NegocioException nex)
            {
                baseResponse.Status = (int)nex.Codigo;
                baseResponse.Detalhes = nex.Message;
            }
            catch (Exception ex)
            {
                baseResponse.Status = -1;
                baseResponse.Detalhes = ex.Message;
            }

            return Ok(baseResponse);
        }

        [HttpPost]
        [Route("Atualizar")]

        public IHttpActionResult Update([FromBody] ProdutoTO produtoTO)
        {

            BaseResponse baseResponse = new BaseResponse();

            try
            {
                Produto.Atualizar(produtoTO.Id, produtoTO.Preco);

            }
            catch (NegocioException nex)
            {
                baseResponse.Status = (int)nex.Codigo;
                baseResponse.Detalhes = nex.Message;
            }
            catch (Exception ex)
            {
                baseResponse.Status = -1;
                baseResponse.Detalhes = ex.Message;
            }

            return Ok(baseResponse);
        }

        [HttpDelete]
        [Route("Remover")]
        public IHttpActionResult Remover([FromBody] ProdutoTO produtoTO)
        {

            BaseResponse baseResponse = new BaseResponse();

            try
            {
                Produto.Remover(produtoTO.Id);

            }
            catch (NegocioException nex)
            {
                baseResponse.Status = (int)nex.Codigo;
                baseResponse.Detalhes = nex.Message;
            }
            catch (Exception ex)
            {
                baseResponse.Status = -1;
                baseResponse.Detalhes = ex.Message;
            }

            return Ok(baseResponse);
        }

    
    }
}
