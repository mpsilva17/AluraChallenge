using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AluraChallenge.Domain.DTO
{
    public class VideoPostDTO
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        [Url]
        public string Url { get; set; }
    }
}
