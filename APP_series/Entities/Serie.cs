using APP_series.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_series.Entities
{
    class Serie : BaseEntity
    {
        public Serie(int id, string titulo, GeneroOpcoes genero, string descricao, int ano)
        {
            Id = id;
            Titulo = titulo;
            Genero = genero;
            Descricao = descricao;
            Ano = ano;
            Status = Status.Disponivel;
        }

        public string Titulo { get; private set; }
        public GeneroOpcoes Genero { get; private set; }
        public string Descricao { get; private set; }
        public int Ano { get; private set; }
        public Status Status { get; private set; }


        public void Delete()
        {
            Status = Status.Excluido;
        }

        public int GetId()
        {
            return Id;
        }


        public override string ToString()
        {
            string obj = "";

            obj += $"Título: {Titulo}" + Environment.NewLine;
            obj += $"Gênero: {Genero}" + Environment.NewLine;
            obj += $"Descrição: {Descricao}" + Environment.NewLine;
            obj += $"Ano: {Ano}" + Environment.NewLine;
            obj += $"Status: {Status}" + Environment.NewLine;

            return obj;

        }
    }
}
