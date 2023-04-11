using Microsoft.AspNetCore.Mvc;
using MVSNChallenge.Models;
using MVSNChallenge.Models.DB;
using MVSNChallenge.Repository;

namespace MVSNChallenge.Controller
{
    public class IndirizzoController : ControllerBase
    {

        private readonly MvsnchallengeContext _dbContext;
        public IndirizzoController(MvsnchallengeContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("CaricaIndirizzo")]
        public IActionResult CaricaIndirizzo([FromBody] IndirizzoCRUD indirizzo)
        {
            try
            {
                if (indirizzo != null)
                {
                    IndirizzoRepository _indirizzoRepository = new IndirizzoRepository();
                    var res = _indirizzoRepository.caricaIndirizzo(indirizzo);
                    if (res == false)
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
        [Route("GetIndirizziByCitta")]
        public async Task<ActionResult<IEnumerable<Prodotti>>> GetIndirizziByCitta(string citta)
        {
            IndirizzoRepository _indirizzoRepository = new IndirizzoRepository();
            var res = _indirizzoRepository.getIndirizziByCitta(_dbContext, citta);
            if (_dbContext.Indirizzis == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpGet]
        [Route("GetIndirizziByCompagnia")]
        public async Task<ActionResult<IEnumerable<Prodotti>>> GetIndirizziByCompagnia(int? IDCompagnia)
        {
            if (IDCompagnia == null)
                return NotFound();
            IndirizzoRepository _indirizzoRepository = new IndirizzoRepository();
            var res = _indirizzoRepository.getIndirizziByCompagnia(_dbContext, int.Parse(IDCompagnia.ToString()));
            if (_dbContext.Indirizzis == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPost]
        [Route("UpdateIndirizzo")]
        public IActionResult UpdateIndirizzo([FromBody] IndirizzoCRUD indirizzo)
        {
            try
            {
                if (indirizzo != null)
                {
                    IndirizzoRepository _indirizzoRepository = new IndirizzoRepository();
                    var res = _indirizzoRepository.updateIndirizzo(indirizzo);
                    if (res == false)
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

        [HttpPost]
        [Route("DeleteIndirizzo")]
        public IActionResult DeleteIndirizzo(int? ID)
        {
            try
            {
                if (ID != null)
                {
                    IndirizzoRepository _indirizzoRepository = new IndirizzoRepository();
                    var res = _indirizzoRepository.deleteIndirizzo(int.Parse(ID.ToString()));
                    if (res == false)
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
