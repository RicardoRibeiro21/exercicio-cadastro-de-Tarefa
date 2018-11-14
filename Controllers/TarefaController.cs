using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.CadastroDeTarefas.Models;
using System;
using System.IO;
namespace Senai.CadastroDeTarefas.Controllers
{
    public class TarefaController : Controller
    {
        [HttpGet] 
        public ActionResult CadastrarTarefa() {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("emailUsuario")))
            {
                return RedirectToAction("FazerLogin", "Usuario");}            
                return View();
        }
        [HttpPost]
        public ActionResult CadastrarTarefa(IFormCollection form) {
            TarefaModel tarefa = new TarefaModel();
            tarefa.Id =+ 1;
            tarefa.Descricao = form ["Descricao"];
            tarefa.Nome = form ["Nome"];
            tarefa.Tipo = form ["Tipo"];
            tarefa.DataCriacao = DateTime.Now;
            // tarefa.IdUsuario = string "emailUsuario"; 
            using (StreamWriter sw = new StreamWriter("tarefas.csv", true))
            {
                sw.WriteLine($"{tarefa.Id};{tarefa.Nome};{tarefa.Descricao};{tarefa.Tipo};{tarefa.DataCriacao};{tarefa.IdUsuario}");
            }  
            @ViewBag.Mensagem = "Tarefa cadastrada";
            return RedirectToAction("CadastrarTarefa", "Tarefa");
        }

        [HttpGet]
        public ActionResult LerTarefa() {
            return View();
        }
        [HttpPost]
        public ActionResult LerTarefa(IFormFileCollection form) {

            return RedirectToAction ("Cadastrar", "Tarefa");
        }
    }
}