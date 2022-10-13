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
    public class SeleccionesController : ControllerBase
    {
        #region Inyección del repositorio de selecciones
        private IRepositorioSeleccion _repoSelecciones;
        public SeleccionesController(IRepositorioSeleccion repoSeleccion)
        {
            _repoSelecciones = repoSeleccion;
        }
        #endregion
        // GET: api/<SeleccionesController>
        [HttpGet]
        public ActionResult<Seleccion> Get()
        {
            try
            {
                var selecciones = _repoSelecciones.FindAll();
                if (selecciones == null)
                {
                    return NotFound();
                }
                return Ok(selecciones);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // GET api/<SeleccionesController>/5
        [HttpGet, Route("{id}", Name = "Get")]
        public ActionResult<Seleccion> Get(int id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest("No puede ser null");
                }
                var seleccion = _repoSelecciones.FindById(id);
                if (seleccion == null)
                {
                    return NotFound();
                }
                return Ok(seleccion);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // POST api/<SeleccionesController>
        [HttpPost]
        public ActionResult<Seleccion> Post([FromBody] Seleccion seleccion)
        {
            try
            {
                if (seleccion == null)
                {
                    return BadRequest("No puede ser null");
                }
                if (_repoSelecciones.Add(seleccion))
                {
                    return CreatedAtRoute("Get", new { id = seleccion.Id }, seleccion);
                }
                return Conflict(seleccion);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT api/<SeleccionesController>/5
        [HttpPut("{id}")]
        public ActionResult<Seleccion> Put(int id, [FromBody] Seleccion seleccion)
        {
            try
            {
                if (id == null || seleccion == null)
                {
                    return BadRequest();
                }
                seleccion.Id = id;
                if (_repoSelecciones.Update(seleccion))
                {
                    return Ok(seleccion);
                }
                return Conflict();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<SeleccionesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            if (_repoSelecciones.Remove(id))
            {
                return NoContent();
            }
            return Conflict();
        }
    }
}
