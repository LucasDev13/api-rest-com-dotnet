using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_v1_dotNetFlix.Models;
using Microsoft.EntityFrameworkCore;

namespace api_v1_dotNetFlix.Data
{
    public class FilmeContext : DbContext {
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base (opt){
            
        }

        public DbSet<Filme> Filmes {get; set;}
        
    }
}