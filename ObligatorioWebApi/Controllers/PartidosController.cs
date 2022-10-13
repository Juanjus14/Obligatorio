using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Obligatorio.LogicaNegocio.Entidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ObligatorioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidosController : ControllerBase
    {
        #region Inyección del repositorio de partidos
        private IRepositorioPartido _repoPartidos;
        public PartidosController(IRepositorioPartido repoPartido)
        {
            _repoPartidos = repoPartido;
        }
        #endregion
        // GET: api/<PartidosController>
        [HttpGet]
        public ActionResult<Partido> Get()
        {
            try
            {
                var partidos = _repoPartidos.FindAll();
                if (partidos == null)
                {
                    return NotFound();
                }
                return Ok(partidos);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // GET api/<PartidosController>/5
        [HttpGet, Route("{id}", Name = "Get")]
        public ActionResult<Partido> Get(int id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest("No puede ser null");
                }
                var partido = _repoPartidos.FindById(id);
                if (partido == null)
                {
                    return NotFound();
                }
                return Ok(partido);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // POST api/<PartidosController>
        [HttpPost]
        public ActionResult<Partido> Post([FromBody] Partido partido)
        {
            try
            {
                if (partido == null)
                {
                    return BadRequest("No puede ser null");
                }
                if (_repoPartidos.Add(partido))
                {
                    return CreatedAtRoute("Get", new { id = partido.Id }, partido);
                }
                return Conflict(partido);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT api/<PartidosController>/5
        [HttpPut("{id}")]
        public ActionResult<Partido> Put(int id, [FromBody] Partido partido)
        {
            try
            {
                if (id == null || partido == null)
                {
                    return BadRequest();
                }
                partido.Id = id;
                if (_repoPartidos.Update(partido))
                {
                    return Ok(partido);
                }
                return Conflict();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<PartidoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            if (_repoPartidos.Remove(id))
            {
                return NoContent();
            }
            return Conflict();
        }
    }
}
