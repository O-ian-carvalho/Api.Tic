using ApiTic.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTic.Business.Notificações
{
    public class Notificador : INotificador
    {

        public Notificador()
        {
            _notificacaos = new List<Notificacao>();
        }
        private List<Notificacao> _notificacaos;
        public void Handle(Notificacao notificacao)
        {
           _notificacaos.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacao()
        {
           return _notificacaos;
        }

        public bool TemNotificacao()
        {
            return _notificacaos.Any();
        }
    }
}
