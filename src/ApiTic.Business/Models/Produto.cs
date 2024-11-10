using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTic.Business.Models
{
    public class Produto : Entity
    {
        public string Nome { get; set; }
        public int Valor { get; set; }
        public Guid? CategoriaId { get; set; }
        public Guid? PedidoId { get; set; }
        public TipoDeProduto Categoria { get; set; }
    }
}
