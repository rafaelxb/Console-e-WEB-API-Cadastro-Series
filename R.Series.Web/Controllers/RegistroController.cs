using Microsoft.AspNetCore.Mvc;
using R.Series.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace R.Series.Web.Controllers
{
    [Route("[controller]")]
    public class RegistroController : Controller
    {
        private readonly IRepositorio<Registro> _repositorioRegistro;

        public RegistroController(IRepositorio<Registro> repositorioRegistro)
        {
            _repositorioRegistro = repositorioRegistro;
        }

        [HttpGet("")]
        public IActionResult Lista()
        {
            return Ok(_repositorioRegistro.Lista().Select(r => new RegistroModel(r)));            
        }

        [HttpPut("{id}")]

        public IActionResult Atualiza(int id, [FromBody] RegistroModel model)
        {
            _repositorioRegistro.Atualiza(id, model.ToRegistro());
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult Exclui(int id)
        {
            _repositorioRegistro.Exclui(id);
            return NoContent();
        }

        [HttpPost("")]

        public IActionResult Insere([FromBody] RegistroModel model)
        {
            model.Id = _repositorioRegistro.ProximoId();
            
            Registro registro = model.ToRegistro();
            
            _repositorioRegistro.Insere(registro);
            return Created("", registro);
        }

        [HttpGet("{id}")]

        public IActionResult Consulta(int id)
        {
            return Ok(new RegistroModel(_repositorioRegistro.Lista().FirstOrDefault(r => r.Id == id)));
        }

    }
}
