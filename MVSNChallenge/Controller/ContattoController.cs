using Microsoft.AspNetCore.Mvc;
using MVSNChallenge.Models;
using MVSNChallenge.Models.DB;
using MVSNChallenge.Repository;

namespace MVSNChallenge.Controller
{
    public class ContattoController : ControllerBase
    {
        private readonly MvsnchallengeContext _dbContext;
        public ContattoController(MvsnchallengeContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost]
        [Route("CaricaContatto")]
        public IActionResult CaricaContatto([FromBody] ContattoCRUD contatto)
        {
            try
            {
                if (contatto != null)
                {
                    ContattoRepository _contattoRepository = new ContattoRepository();
                    var res = _contattoRepository.caricaContatto(contatto);
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
        [Route("GetContatti")]
        public async Task<ActionResult<IEnumerable<Contatti>>> GetContatti()
        {
            ContattoRepository _contattoRepository = new ContattoRepository();
            var res = _contattoRepository.getContatti(_dbContext);
            if (_dbContext.Indirizzis == null)
            {
                return NotFound();
            }

            return Ok(res);
        }


        [HttpGet]
        [Route("GetContattiByCompagnia")]
        public async Task<ActionResult<IEnumerable<Contatti>>> GetContattiByCompagnia(int? IDCompagnia)
        {
            if (IDCompagnia == null)
                return NotFound();
            ContattoRepository _contattoRepository = new ContattoRepository();
            var res = _contattoRepository.getContattiByCompagnia(_dbContext, int.Parse(IDCompagnia.ToString()));
            if (_dbContext.Indirizzis == null)
            {
                return NotFound();
            }

            return Ok(res);
        }


        [HttpPost]
        [Route("UpdateContatto")]
        public IActionResult UpdateContatto([FromBody] ContattoCRUD contatto)
        {
            try
            {
                if (contatto != null)
                {
                    ContattoRepository _contattoRepository = new ContattoRepository();
                    var res = _contattoRepository.updateContatto(contatto);
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
        [Route("DeleteContatto")]
        public IActionResult DeleteContatto(int? ID)
        {
            try
            {
                if (ID != null)
                {
                    ContattoRepository _contattoRepository = new ContattoRepository();
                    var res = _contattoRepository.deleteContatto(int.Parse(ID.ToString()));
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
