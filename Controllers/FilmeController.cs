using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api_v1_dotNetFlix.Models;
using api_v1_dotNetFlix.Data;
using api_v1_dotNetFlix.Data.Dtos;
using AutoMapper;

namespace api_v1_dotNetFlix.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase{
        
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }


         [HttpPost]
         public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto){
            
            //Criação de um objeto com um construtor implícito.
            Filme filme = _mapper.Map<Filme>(filmeDto);
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
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                return Ok(filmeDto);      
            }             
             //retorna 404-notfound
             return NotFound();
             
         }

         [HttpPut("{id}")]
         public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto updateFilmeDto){
            var filme = _context.Filmes.Find(id);
            if(filme == null){
                return NotFound();    
            }
            //esse trecho pode ser mudado por um dto
            _mapper.Map(updateFilmeDto, filme);
            _context.SaveChanges();
            return NoContent();
         }

         [HttpDelete("{id}")]
         public IActionResult DeletaFilme(int id){
             var filme = _context.Filmes.Find(id);
            if(filme == null){
                return NotFound();    
            }
            _context.Remove(id);
            _context.SaveChanges();
            return NoContent();

         }

    }
}