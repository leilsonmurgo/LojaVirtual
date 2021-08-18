using LojaVirtual.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Login
{
    public class LoginColaborador
    {

        private Sessao.Sessao _sessao;
        private string key = "Login.Colaborador";

        public LoginColaborador(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Colaborador colaborador)
        {
            _sessao.Cadastrar(key, JsonConvert.SerializeObject(colaborador));
        }

        public Colaborador GetColaborador()
        {
            if (_sessao.Existe(key))
            {
                string colaboradorString = _sessao.Consultar(key);
                return JsonConvert.DeserializeObject<Colaborador>(colaboradorString);
            }
            else
            {
                return null;
            }
        }

        public void Logout()
        {
            _sessao.RemoverTodos();
        }
    }
}
