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
    [RoutePrefix("api/carrinho")]
    public class CarrinhoController : ApiController
    {
        // GET: api/Carrinho
        public IHttpActionResult Get()
        {
            CarrinhosResponse cResponse = new CarrinhosResponse();

            try
            {
                List<Carrinho> lista = Carrinho.Listar();
                cResponse.Carrinhos = new List<CarrinhoTO>();

                foreach(Carrinho c in lista)
                {
                    CarrinhoTO cTO = new CarrinhoTO();

                    cTO.Id = c.Id;
                    cTO.Quantidade = c.Quantidade;
                    cTO.Nome = c.Racao.Nome;
                    cTO.Peso = c.Racao.Peso;
                    cTO.Preco = c.Produtos.Preço;

                    cResponse.Carrinhos.Add(cTO);
                }
            }
            catch(Exception ex)
            {
                cResponse.Status = -1;
                cResponse.Detalhes = ex.Message;
            }

            return Ok(cResponse);

        }

        // GET: api/Carrinho/5
        public IHttpActionResult Get(int id)
        {
            CarrinhoResponse cResponse = new CarrinhoResponse();

            try
            {
                Carrinho c = Carrinho.Consultar(id);
                cResponse.Carrinho = new CarrinhoTO();
                cResponse.Carrinho.Id = c.Id;
                cResponse.Carrinho.Quantidade = c.Quantidade;
                cResponse.Carrinho.Nome = c.Racao.Nome;
                cResponse.Carrinho.Peso = c.Racao.Peso;
                cResponse.Carrinho.Preco = c.Produtos.Preço;

            }
            catch (NegocioException nex)
            {
                cResponse.Status = (int)nex.Codigo;
                cResponse.Detalhes = nex.Message;
            }
            catch (Exception ex)
            {
                cResponse.Status = -1;
                cResponse.Detalhes = ex.Message;
            }

            return Ok(cResponse);
        }

        // POST: api/Carrinho
        public IHttpActionResult Post([FromBody]CarrinhoTO carrinhoTO)
        {
            CarrinhoResponse cResponse = new CarrinhoResponse();
            cResponse.Carrinho.Quantidade = carrinhoTO.Quantidade;

            try
            {
                cResponse.Carrinho.Id = Carrinho.Inserir(carrinhoTO.Quantidade);

            }
            catch (NegocioException nex)
            {
                cResponse.Status = (int)nex.Codigo;
                cResponse.Detalhes = nex.Message;
            }
            catch (Exception ex)
            {
                cResponse.Status = -1;
                cResponse.Detalhes = ex.Message;
            }

            return Ok(cResponse);

        }

        // PUT: api/Carrinho/5
        public IHttpActionResult Put(int id, [FromBody]CarrinhoTO carrinhoTO)
        {

            BaseResponse baseResponse = new BaseResponse();

            try
            {
                Carrinho.Atualizar(carrinhoTO.Id, carrinhoTO.Quantidade);

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

        // DELETE: api/Carrinho/5
        public IHttpActionResult Delete(int id)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {
                Racao.Remover(id);

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

        public IHttpActionResult Update([FromBody] CarrinhoTO carrinhoTO)
        {

            BaseResponse baseResponse = new BaseResponse();

            try
            {
                Carrinho.Atualizar(carrinhoTO.Id, carrinhoTO.Quantidade);

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
        public IHttpActionResult Remover([FromBody] CarrinhoTO carrinhoTO)
        {

            BaseResponse baseResponse = new BaseResponse();

            try
            {
                Carrinho.Remover(carrinhoTO.Id);

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

