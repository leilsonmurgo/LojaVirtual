using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using LojaVirtual.Libraries.Lang;

namespace LojaVirtual.Models
{
    public class Contato
    {
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E_OBRIGATORIO")]
        [MinLength(4, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E_TAM_MINIMO")]
        public string  Nome { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E_OBRIGATORIO")]
        [EmailAddress(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E_EMAIL")]
        public string Email { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E_OBRIGATORIO")]
        [MinLength(2, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E_TAM_MINIMO")]
        [MaxLength(200, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E_TAM_MAXIMO")]
        public string  Texto { get; set; }
    }
}
