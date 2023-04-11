using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MVSNChallenge.Models;
using MVSNChallenge.Repository;
using MVSNChallenge.Models.DB;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MVSNChallenge.Controller
{

    [Route("/api/controller")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CompagniaController : ControllerBase
    {
        private readonly MvsnchallengeContext _dbContext;
        public CompagniaController(MvsnchallengeContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost]
        [Route("CaricaCompagnia")]
        public IActionResult CaricaCompagnia([FromBody] CompagniaCRUD compagnia)
        {
            try
            {
                if (compagnia != null)
                {
                    CompagniaRepository _compagniaRepository = new CompagniaRepository();
                    var res = _compagniaRepository.caricaCompagnia(compagnia);
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
        [Route("GetCompagnie")]
        public async Task<ActionResult<IEnumerable<Compagnie>>> GetCompagnie()
        {
            CompagniaRepository _compagniaRepository = new CompagniaRepository();
            var res = _compagniaRepository.getCompagnie(_dbContext);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet]
        [Route("GetCompagnia")]
        public async Task<ActionResult<IEnumerable<Compagnie>>> GetCompagnia(int ID)
        {
            CompagniaRepository _compagniaRepository = new CompagniaRepository();
            var res = _compagniaRepository.getCompagnia(_dbContext, ID);
            if (res == null || res.Count == 0)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPost]
        [Route("UpdateCompagnia")]
        public IActionResult UpdateCompagnia([FromBody] CompagniaCRUD compagnia)
        {
            try
            {
                if (compagnia != null)
                {
                    CompagniaRepository _compagniaRepository = new CompagniaRepository();
                    var res = _compagniaRepository.updateCompagnia(compagnia);
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

        /// <summary>
        /// API di tipo POST per la cancellazione di una compagnia in base all'ID.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteCompagnia")]
        public IActionResult DeleteCompagnia(int? ID)
        {
            try
            {
                if (ID != null)
                {
                    CompagniaRepository _compagniaRepository = new CompagniaRepository();
                    var res = _compagniaRepository.deleteCompagnia(int.Parse(ID.ToString()));
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