using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.CadastroDeTarefas.Models;

namespace Senai.CadastroDeTarefas.Controllers {
    public class UsuarioController : Controller {
        [HttpGet]
        public ActionResult Cadastrar () {
            return View ();
        }  
        
        [HttpPost]
        public ActionResult Cadastrar (IFormCollection form) {
            UsuarioModel usuario = new UsuarioModel ();
            int contador =0;
            usuario.Id = contador+ 1; 
            usuario.Nome = form["Nome"];
            usuario.Email = form["Email"];
            usuario.Senha = form["Senha"];
            usuario.Tipo = form["Tipo"];
            usuario.Data = DateTime.Now;

            using (StreamWriter sw = new StreamWriter ("usuarios.csv", true)) {
                sw.WriteLine ($"{usuario.Id};{usuario.Nome};{usuario.Email};{usuario.Senha};{usuario.Tipo};{usuario.Data}");
            }
            ViewBag.Mensagem = "Usuário cadastrado com sucesso!";
            return RedirectToAction ();
        }

        [HttpGet]
        public ActionResult FazerLogin () {
            return View ();
        }

        [HttpPost]
        public ActionResult FazerLogin (IFormCollection form) {
            UsuarioModel usuario = new UsuarioModel ();
            usuario.Email = form["Email"];
            usuario.Senha = form["Senha"];

            using (StreamReader sr = new StreamReader ("usuarios.csv")) {
                while (!sr.EndOfStream) {
                    string[] linha = sr.ReadLine ().Split (";");
                    if (linha[1] == usuario.Email && linha[2] == usuario.Senha) {
                        HttpContext.Session.SetString ("emailUsuario", usuario.Email);
                        return RedirectToAction ("Cadastrar");
                    }
                }
            }
            ViewBag.Mensagem = "Usuario inválido.";
            return RedirectToAction ("CadastrarTarefa", "Tarefa");
        }
    }
}