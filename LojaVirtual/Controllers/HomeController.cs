﻿using LojaVirtual.Libraries.Email;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text;
using LojaVirtual.Database;
using LojaVirtual.Repositories;
using LojaVirtual.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private IClienteRepository _clienteRepository;
        private INewsletterRepository _newsRepository;
        public HomeController(IClienteRepository clienteRepository, INewsletterRepository newsRepository)
        {
            _clienteRepository = clienteRepository;
            _newsRepository = newsRepository;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm]NewsletterEmail newsletter)
        {
            
            if (ModelState.IsValid)
            {

                _newsRepository.Cadastrar(newsletter);

                TempData["MSG_SUCESSO"] = "E-mail cadastrado. Você receberá nossas promoções e novidades.";

                return RedirectToAction(nameof(Index));
            } else
            {
                return View();
            }
            
        }

        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult ContatoAcao()
        {
            try
            {
                Contato contato = new Contato();
                contato.Nome = HttpContext.Request.Form["nome"];
                contato.Email = HttpContext.Request.Form["email"];
                contato.Texto = HttpContext.Request.Form["texto"];

                var listaMensagens = new List<ValidationResult>();
                var contexto = new ValidationContext(contato);
                bool isValid = Validator.TryValidateObject(contato, contexto, listaMensagens, true);

                if (isValid)
                {
                    ContatoEmail.EnviarContatoPorEmail(contato);
                    ViewData["MSG_S"] = "Mensagem de contato enviado com sucesso!";

                } else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var texto in listaMensagens)
                    {
                        sb.AppendLine(texto.ErrorMessage + "<br />");
                    }
                    ViewData["MSG_E"] = sb.ToString();
                    ViewData["CONTATO"] = contato;
                }

            }
            catch (Exception)
            {
                ViewData["MSG_E"] = "Ocorreu um problema ao enviar o e-mail. Tente novamente mais tarde!";
            }
           
            return View("Contato");
            
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm]Cliente cliente)
        {
            if(cliente.Email == "teste@teste.com" && cliente.Senha == "1234")
            {
                HttpContext.Session.Set("ID", new byte[] { 52 });
                HttpContext.Session.SetString("email", "teste@teste.com");
                HttpContext.Session.SetInt32("idade", 32);
                
                return new ContentResult() { Content = "Logado" };
            }
            else
            {
                return new ContentResult() { Content = "Não Logado" };
            }
                        
        }

        [HttpGet]
        public IActionResult Painel()
        {

            byte[] UsuarioId;

            if (HttpContext.Session.TryGetValue("ID", out UsuarioId))
            {
                return new ContentResult() { Content = "Acesso confirmado do usuario " + UsuarioId[0] };
            } else
            {
                return new ContentResult() { Content = "Acesso Negado!" };
            }            
            
        }


        [HttpGet]
        public IActionResult CadastroCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroCliente([FromForm] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteRepository.Cadastrar(cliente);

                TempData["MSG_SUCESSO"] = "Cadastro realizado com sucesso!";
                return RedirectToAction(nameof(CadastroCliente));
            }
            return View();
        }

        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}
