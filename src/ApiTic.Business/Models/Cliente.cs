using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTic.Business.Models
{
    public class Cliente : Entity
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? NumeroContato { get; set; }
        public DateOnly DataDeNascimento { get; set; }
        
        public List<Pedido> Pedidos { get; set; }
    }
}
