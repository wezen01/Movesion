using Microsoft.AspNetCore.Mvc;
using MVSNChallenge.Models;
using MVSNChallenge.Models.DB;
using MVSNChallenge.Repository;

namespace MVSNChallenge.Controller
{
    public class ProdottoController : ControllerBase
    {
        private readonly MvsnchallengeContext _dbContext;
        public ProdottoController(MvsnchallengeContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost]
        [Route("CaricaProdotto")]
        public IActionResult CaricaProdotto([FromBody] ProdottoCRUD prodotto)
        {
            try
            {
                if (prodotto != null)
                {
                    ProdottoRepository _prodottoRepository = new ProdottoRepository();
                    var res = _prodottoRepository.caricaProdotto(prodotto);
                    if(res == false)
                        return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                    return new OkResult();

                }
                else
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);

                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("GetProdotti")]
        public async Task<ActionResult<IEnumerable<Prodotti>>> GetProdotti()
        {
            ProdottoRepository _prodottoRepository = new ProdottoRepository();
            var res = _prodottoRepository.getProdotti(_dbContext);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpGet]
        [Route("GetProdotto")]
        public async Task<ActionResult<IEnumerable<Prodotti>>> GetProdotto(int ID)
        {
            ProdottoRepository _prodottoRepository = new ProdottoRepository();
            var res = _prodottoRepository.getProdotto(_dbContext, ID);
            if (res == null || res.Count == 0)
            {
                return NotFound();
            }

            return Ok(res);
        }


        [HttpPost]
        [Route("UpdateProdotto")]
        public IActionResult UpdateProdotto([FromBody] ProdottoCRUD prodotto)
        {
            try
            {
                if (prodotto != null)
                {
                    ProdottoRepository _prodottoRepository = new ProdottoRepository();
                    var res = _prodottoRepository.updateProdotto(prodotto);
                    if(res == false)
                    {
                        return new StatusCodeResult(StatusCodes.Status409Conflict);
                    }
                    return new OkResult();
                }
                else
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// API di tipo POST per la cancellazione di un prodotto in base all'ID.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteProdotto")]
        public IActionResult DeleteProdotto(int? ID)
        {
            try
            {
                if (ID != null)
                {
                    ProdottoRepository _prodottoRepository = new ProdottoRepository();
                    var res = _prodottoRepository.deleteProdotto(int.Parse(ID.ToString()));
                    if(res == false)
                        return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                    return new OkResult();
                }
                else
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


    }
}   
