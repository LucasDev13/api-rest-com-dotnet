using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api_v1_dotNetFlix.Models;

namespace api_v1_dotNetFlix.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase{
         private static List<Filme> filmes = new List<Filme>();
         private static int id = 1;

         [HttpPost]
         public IActionResult AdicionaFilme([FromBody] Filme filme){
            filme.Id = id++; 
            filmes.Add(filme);
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id}, filme);
         }

         [HttpGet]
         public IActionResult RecuperarFilmes(){
             return Ok(filmes);
         }

         [HttpGet("{id}")]
         public IActionResult RecuperaFilmesPorId(int id){
             foreach(Filme filme in filmes){
                 if(filme.Id == id){
                    //retorna o status 200-sucesso
                    return Ok(filme);
                 }
             }
             //retorna 404-notfound
             return NotFound();
             
         }

    }
}