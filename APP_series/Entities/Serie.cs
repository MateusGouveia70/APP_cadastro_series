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
            Status = StatusSerie.Disponivel;
        }

        public string Titulo { get; private set; }
        public GeneroOpcoes Genero { get; private set; }
        public string Descricao { get; private set; }
        public int Ano { get; private set; }
        public StatusSerie Status { get; private set; }


        public void Delete()
        {
            Status = StatusSerie.Excluido;
        }

        public int GetId()
        {
            return Id;
        }


        public override string ToString()
        {
            string retorno = "";

            retorno += $"Título: {Titulo}" + Environment.NewLine;
            retorno += $"Gênero: {Genero}" + Environment.NewLine;
            retorno += $"Descrição: {Descricao}" + Environment.NewLine;
            retorno += $"Ano: {Ano}" + Environment.NewLine;
            retorno += $"Status: {Status}" + Environment.NewLine;

            return retorno;

        }
    }
}
