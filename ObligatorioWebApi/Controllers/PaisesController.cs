using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Obligatorio.LogicaNegocio.Entidades;
using static Obligatorio.LogicaNegocio.Enums.EnumeradosObligatorio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ObligatorioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        #region Inyección del repositorio de paises
        private IRepositorioPais _repoPaises;
        public PaisesController(IRepositorioPais repoPaises)
        {
            _repoPaises = repoPaises;
        }
        #endregion
        // GET: api/<PaisesController>
        [HttpGet]
        public ActionResult<Pais> Get()
        {
            try
            {
                var paises = _repoPaises.FindAll();
                if (paises == null)
                {
                    return NotFound();
                }
                return Ok(paises);
            }catch(Exception ex)
            {
                return StatusCode(500);
            }
        }

        // GET api/<PaisesController>/5
        [HttpGet,Route("{id}",Name ="Get")]
        public ActionResult<Pais> Get(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("No puede ser negativo");
                }   
                var pais = _repoPaises.FindById(id);
                if (pais == null)
                {
                    return NotFound();
                }  
                return Ok(pais);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet, Route("{id}", Name = "Get")]
        public ActionResult<Pais> GetIso(string iso)
        {
            try
            {
                if (iso == "")
                {
                    return BadRequest("No puede ser null");
                }
                var pais = _repoPaises.BuscarPaisPorCodigo(iso);
                if (pais == null)
                {
                    return NotFound();
                }
                return Ok(pais);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet, Route("{id}", Name = "Get")]
        public ActionResult<Pais> GetIso(Regiones region)
        {
            try
            {
                if (region < 0)
                {
                    return BadRequest("No puede ser null");
                }
                IEnumerable<Pais> ret = _repoPaises.ObtenerPaisesXRegion(region);
                if (ret == null)
                {
                    return NotFound();
                }
                return Ok(ret);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // POST api/<PaisesController>
        [HttpPost]
        public ActionResult<Pais> Post([FromBody] Pais pais)
        {
            try
            {
                if(pais == null)
                {
                    return BadRequest("No puede ser null");
                }
                if (_repoPaises.Add(pais))
                {
                    return CreatedAtRoute("Get", new { id = pais.Id }, pais);
                }
                return Conflict(pais);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT api/<PaisesController>/5
        [HttpPut("{id}")]
        public ActionResult<Pais> Put(int id, [FromBody] Pais pais)
        {
            try
            {
                if(id < 0 || pais == null)
                {
                    return BadRequest();
                }
                pais.Id = id;
                if (_repoPaises.Update(pais))
                {
                    return Ok(pais);
                }
                return Conflict();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<PaisesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(id < 0)
            {
                return BadRequest();
            }
            if (_repoPaises.Remove(id))
            {
                return NoContent();
            }
            return Conflict();
        }
    }
}
