using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AluraChallenge.Domain.Entities
{
    public class Video : BaseEntity
    {
        public string Titulo { get; set; }
        public string Descricao{ get; set; }
        [Url]
        public string Url { get; set; }
    }
}
