using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class ClienteRepository : IClienteRepository
    {

        private LojaVirtualContext _banco;

        public ClienteRepository(LojaVirtualContext banco)
        {
            _banco = banco; 
        }
        
        public void Atualizar(Cliente cliente)
        {
            _banco.Update(cliente);
            _banco.SaveChanges();
        }

        public void Cadastrar(Cliente cliente)
        {
            _banco.Add(cliente);
            _banco.SaveChanges();
        }

        public void Excluir(int id)
        {
            Cliente cliente = ObterPorId(id);
            _banco.Remove(cliente);
            _banco.SaveChanges();

        }

        public Cliente Login(string email, string senha)
        {
            return _banco.Clientes.Where(m => m.Email == email && m.Senha == senha).First();
            
        }

        public Cliente ObterPorId(int id)
        {
            return _banco.Clientes.Find(id);
        }


        public IEnumerable<Cliente> ObterTodos()
        {
            return _banco.Clientes.ToList();
        }
    }
}
