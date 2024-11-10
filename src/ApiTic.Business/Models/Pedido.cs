using ApiTic.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTic.Business.Models
{
    public class Pedido : Entity
    {
        public Guid ClienteId { get; set; }

        public EStatusPedido Status { get; set; }

        public Cliente Cliente { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
