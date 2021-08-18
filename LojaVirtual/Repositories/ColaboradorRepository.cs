using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {

        private LojaVirtualContext _banco;

        public ColaboradorRepository(LojaVirtualContext banco)
        {
            _banco = banco;
        }

        public void Atualizar(Colaborador colaborador)
        {
            _banco.Update(colaborador);
            _banco.SaveChanges();
        }

        public void Cadastrar(Colaborador colaborador)
        {
            _banco.Add(colaborador);
            _banco.SaveChanges();
        }

        public void Excluir(int id)
        {
            Colaborador colaborador = ObterColaborador(id);
            _banco.Remove(colaborador);
            _banco.SaveChanges();
        }

        public Colaborador Login(string email, string senha)
        {
            return _banco.Colaboradores.Where(m => m.Email == email && m.Senha == senha).FirstOrDefault();
        }

        public Colaborador ObterColaborador(int id)
        {
            return _banco.Colaboradores.Find(id);
        }

        public IEnumerable<Colaborador> ObterTodosColaboradores()
        {
            return _banco.Colaboradores.ToList();
        }
    }
}
