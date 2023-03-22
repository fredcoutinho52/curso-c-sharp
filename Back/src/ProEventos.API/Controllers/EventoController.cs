using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

        public IEnumerable<Evento> _evento = new Evento[] {
            new Evento() {
                EventoId = 1,
                Tema = "Angular e .NET",
                Local = "Pará",
                Lote = "1º",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(2).ToString(),
                ImagemURL = "foto.png",
            },
            new Evento() {
                EventoId = 2,
                Tema = "Angular e .NET e muito mais",
                Local = "Ceará",
                Lote = "2º",
                QtdPessoas = 350,
                DataEvento = DateTime.Now.AddDays(3).ToString(),
                ImagemURL = "foto.png",
            }
        };

        public EventoController()
        {
            
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _evento.Where(evento => evento.EventoId == id);
        }

        [HttpPost("{id}")]
        public string Post(int id)
        {
            return $"Rota com post com o id {id}";
        }

        [HttpPut]
        public string Put()
        {
            return "Rota com put";
        }

        [HttpDelete]
        public string Delete()
        {
            return "Rota com delete";
        }
   }
}
