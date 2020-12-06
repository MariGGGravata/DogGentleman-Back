using DogGentleman.Controllers.TransferObjects;
using DogGentleman.Controllers.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DogGentleman.Models;

namespace DogGentleman.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/racao")]
    public class RacaoController : ApiController
    {
        // GET: api/Cadastro
        public IHttpActionResult Get()
        {
            RacoesResponse rResponse = new RacoesResponse();

            try
            {
                List<Racao> lista = Racao.Listar();
                rResponse.Racoes = new List<RacaoTO>();
                foreach(Racao r in lista)
                {
                    RacaoTO rTO = new RacaoTO();
                    rTO.Id = r.Id;
                    rTO.Peso = r.Peso;
                    rTO.Nome = r.Nome;

                    rResponse.Racoes.Add(rTO);
                }

            }
            catch (Exception ex)
            {
                rResponse.Status = -1;
                rResponse.Detalhes = ex.Message;
            }

            return Ok(rResponse);

        }

        // GET: api/Racao/5
        public IHttpActionResult Get(int id)
        {
            RacaoResponse rResponse = new RacaoResponse();

            try
            {
                Racao r = Racao.Consultar(id);
                rResponse.Racao = new RacaoTO();
                rResponse.Racao.Id = r.Id;
                rResponse.Racao.Peso = r.Peso;
                rResponse.Racao.Nome = r.Nome;

            }
            catch (NegocioException nex)
            {
                rResponse.Status = (int)nex.Codigo;
                rResponse.Detalhes = nex.Message;
            }
            catch (Exception ex)
            {
                rResponse.Status = -1;
                rResponse.Detalhes = ex.Message;
            }

            return Ok(rResponse);
        }

        // POST: api/Racao
        public IHttpActionResult Post([FromBody]RacaoTO racaoTO)
        {

            RacaoResponse rResponse = new RacaoResponse();
            rResponse.Racao.Peso = racaoTO.Peso;
            rResponse.Racao.Nome = racaoTO.Nome;

            try
            {

                rResponse.Racao.Id = Racao.Inserir(racaoTO.Peso, racaoTO.Nome);

            }
            catch (NegocioException nex)
            {
                rResponse.Status = (int)nex.Codigo;
                rResponse.Detalhes = nex.Message;
            }
            catch (Exception ex)
            {
                rResponse.Status = -1;
                rResponse.Detalhes = ex.Message;
            }

            return Ok(rResponse);

        }

        // PUT: api/Racao/5
        public IHttpActionResult Put(int id, [FromBody]RacaoTO racaoTO)
        {

            BaseResponse baseResponse = new BaseResponse();

            try
            {
                Racao.Atualizar(racaoTO.Id, racaoTO.Peso, racaoTO.Nome);

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

        // DELETE: api/Racao/5
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
        [Route ("Atualizar")]

        public IHttpActionResult Update([FromBody] RacaoTO racaoTO)
        {

            BaseResponse baseResponse = new BaseResponse();

            try
            {
                Racao.Atualizar(racaoTO.Id, racaoTO.Peso, racaoTO.Nome);

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
        public IHttpActionResult Remover([FromBody] RacaoTO racaoTO)
        {

            BaseResponse baseResponse = new BaseResponse();

            try
            {
                Racao.Remover(racaoTO.Id);

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
