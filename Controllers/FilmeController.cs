using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api_v1_dotNetFlix.Models;

namespace api_v1_dotNetFlix.Controllers
{
    [ApiController]
    [Route("controller")]
    public class FilmeController : ControllerBase{
         private static List<Filme> filmes = new List<Filme>();

         [HttpPost]
         public void AdicionarFilme([FromBody] Filme filme){
            filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
         }

    }
}