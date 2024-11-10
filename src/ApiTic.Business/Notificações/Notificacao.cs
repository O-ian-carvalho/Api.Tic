using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTic.Business.Notificações
{
    public class Notificacao
    {
        public Notificacao(string message) {
            Mensagem = message;
        }
        public string? Mensagem { get;  }
    }
}
