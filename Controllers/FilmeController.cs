using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api_v1_dotNetFlix.Models;
using api_v1_dotNetFlix.Data;

namespace api_v1_dotNetFlix.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase{
        
        private FilmeContext _context;

        public FilmeController(FilmeContext context){
            _context = context;
        }


         [HttpPost]
         public IActionResult AdicionaFilme([FromBody] Filme filme){
             //adiciona um filme ao contexto.
            _context.Filmes.Add(filme);
            //salva os dados no banco.
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id}, filme);
         }

         [HttpGet]
         public IActionResult RecuperarFilmes(){
             return Ok(_context.Filmes);
         }

         [HttpGet("{id}")]
         public IActionResult RecuperaFilmesPorId(int id){
            var filme = _context.Filmes.Find(id);
            if(filme != null){
                return Ok(filme);      
            }             
             //retorna 404-notfound
             return NotFound();
             
         }

    }
}