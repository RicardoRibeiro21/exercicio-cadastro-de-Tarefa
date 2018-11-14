using System;

namespace Senai.CadastroDeTarefas.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string Nome {get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}