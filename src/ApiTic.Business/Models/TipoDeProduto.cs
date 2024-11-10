using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTic.Business.Models
{
    public class TipoDeProduto : Entity
    {
        public string? Titulo { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}

