using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDIO
{
    internal class Cinematografia : EntidadeBase
    {
        private Genero _genero;
        private string _titulo;
        private string _descricao;
        private int _ano;
        private bool _excluido;

        public Cinematografia(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            _genero = genero;
            _titulo = titulo;
            _descricao = descricao;
            _ano = ano;
            _excluido = false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Genero: " + _genero);
            sb.AppendLine("Titulo: " + _titulo);
            sb.AppendLine("Descrição: " + _descricao);
            sb.AppendLine("Ano de Início: " + _ano);
            sb.AppendLine("Excluído: " + _excluido);
            return sb.ToString();
        }

        public string RetornaTitulo()
        {
            return _titulo;
        }

        public int RetornaId()
        {
            return Id;
        }

        public bool RetornaExcluido()
        {
            return _excluido;
        }

        public void Excluir()
        {
            _excluido = true;
        }
    }
}

