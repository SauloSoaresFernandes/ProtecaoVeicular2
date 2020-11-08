using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Associados
    {
        public int Id { get; set; }
        public string NomeAssociado { get; set; }
        public string DataNasc { get; set; }
        public string TelefoneCel { get; set; }
        public string Email { get; set; }
    }
}
