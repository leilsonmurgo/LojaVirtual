﻿using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories.Interfaces
{
    public interface INewsletterRepository
    {

        void Cadastrar(NewsletterEmail newsletter);
        void Atualizar(NewsletterEmail newsletter);
        void Excluir(int id);
        NewsletterEmail ObterPorId(int id);
        IEnumerable<NewsletterEmail> ObterTodos();


    }
}
