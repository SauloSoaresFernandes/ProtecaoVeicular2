using System;
using System.Collections.Generic;

namespace Api
{
    public partial class TbVeiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public string Chassi { get; set; }
        public string Placa { get; set; }
    }
}
