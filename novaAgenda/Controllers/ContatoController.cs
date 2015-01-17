using System;
using novaAgenda.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace novaAgenda.Controllers
{
    public class ContatoController : ApiController
    {
        Contato[] contatos = new Contato[3];


        public void createContato()
        {
            contatos[0] = new Contato { Id = 1, nome = "Sarah", numero = 5345435 };
            contatos[1] = new Contato { Id = 2, nome = "Werick", numero = 9993333 };
            contatos[2] = new Contato { Id = 3, nome = "Genezys", numero = 999929222 };
        }

        
        public IEnumerable<Contato> GettAllContatos(){
            createContato();
        return contatos;
        }

        public IHttpActionResult GetContato (int id){
            createContato();
            var Contato = contatos.FirstOrDefault((c) => c.Id == id);
            if(Contato == null){
                return NotFound();
            }
            return Ok(Contato);
        }
    }
}

