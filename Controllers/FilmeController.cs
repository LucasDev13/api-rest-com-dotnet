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
         public void AdicionaFilme([FromBody] Filme filme){
            filme.Id = id++; 
            filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
         }

         [HttpGet]
         public IEnumerable<Filme> RecuperarFilmes(){
             return filmes;
         }
    }
}