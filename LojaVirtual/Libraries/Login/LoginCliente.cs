using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Sessao;
using LojaVirtual.Models;
using Newtonsoft.Json;

namespace LojaVirtual.Libraries.Login
{

    public class LoginCliente
    {
       
        private Sessao.Sessao _sessao;
        private string key = "Login.Cliente";

        public LoginCliente(Sessao.Sessao sessao) {
            _sessao = sessao;
        }

        public void Login(Cliente cliente)
        {
            _sessao.Cadastrar(key, JsonConvert.SerializeObject(cliente));
        }

        public Cliente GetCliente()
        {
            if (_sessao.Existe(key)) { 
                string clienteString = _sessao.Consultar(key);
                return JsonConvert.DeserializeObject<Cliente>(clienteString);
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
