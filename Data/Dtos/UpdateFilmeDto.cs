using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api_v1_dotNetFlix.Models;

namespace api_v1_dotNetFlix.Data.Dtos
{
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage ="O campo titulo é obrigatório.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage ="O campo titulo é obrigatório.")]
        public string Diretor { get; set; }
        [StringLength(300, ErrorMessage = "Máximo de caracteres - 30")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A duaração dever ser entre 1 e 600 min.")]
        public int Duracao { get; set; }
    }

}