using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class NewsletterRepository : INewsletterRepository
    {
        private LojaVirtualContext _banco;

        public NewsletterRepository(LojaVirtualContext banco)
        {
            _banco = banco;
        }

        public void Atualizar(NewsletterEmail news)
        {
            _banco.Update(news);
            _banco.SaveChanges();
        }

        public void Cadastrar(NewsletterEmail news)
        {
            _banco.Add(news);
            _banco.SaveChanges();
        }

        public void Excluir(int id)
        {
            NewsletterEmail news = ObterPorId(id);
            _banco.Remove(news);
            _banco.SaveChanges();

        }


        public NewsletterEmail ObterPorId(int id)
        {
            return _banco.NewsletterEmails.Find(id);
            
        }


        public IEnumerable<NewsletterEmail> ObterTodos()
        {
            return _banco.NewsletterEmails.ToList();
        }
    }
}
