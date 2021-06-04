using APP_series.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_series.Entities
{
    class Filme : BaseEntity
    {
        public Filme(int id, string titulo, GeneroOpcoes genero, string descricao, string diretor, int ano)
        {
            Id = id;
            Titulo = titulo;
            Genero = genero;
            Descricao = descricao;
            Diretor = diretor;
            Ano = ano;
            Status = Status.Disponivel;
        }

        public string Titulo { get; private set; }
        public GeneroOpcoes Genero { get; private set; }
        public string Descricao { get; private set; }
        public string Diretor { get; private set; }
        public int Ano { get; private set; }
        public Status Status { get; private set; }

        public void Delete()
        {
            Status = Status.Excluido;
        }

        public string GetTitulo()
        {
            return Titulo;
        }

        public int GetId()
        {
            return Id;
        }

        public string GetDiretor()
        {
            return Diretor;
        }


        public override string ToString()
        {
            string obj = "";

            obj += $"Título: {Titulo}" + Environment.NewLine;
            obj += $"Gênero: {Genero}" + Environment.NewLine;
            obj += $"Descrição: {Descricao}" + Environment.NewLine;
            obj += $"Diretor: {Diretor}" + Environment.NewLine;
            obj += $"Ano: {Ano}" + Environment.NewLine;
            obj += $"Status: {Status}" + Environment.NewLine;

            return obj;

        }
    }
}
 