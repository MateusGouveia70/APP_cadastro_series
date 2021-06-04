using APP_series.Entities;
using APP_series.Entities.Enum;
using APP_series.Repository;
using APP_series.Repository.Implamentation;
using System;
using System.Collections.Generic;

namespace APP_series
{
    class Program
    {
        static SerieRepository serieRepository = new SerieRepository();
        static FilmeRepository filmeRepository = new FilmeRepository();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        FindAllSerie();
                        break;

                    case "2":
                        FindAllFilme();
                        break;

                    case "3":
                        FindByIdSerie();
                        break;

                    case "4":
                        FindByIdFilme();
                        break;

                    case "5":
                        CreateSerie();
                        break;

                    case "6":
                        CreateFilme();
                        break;

                    case "7":
                        UpdateSerie();
                        break;

                    case "8":
                        UpdateFilme();
                        break;

                    case "9":
                       DeleteSerie();
                        break;

                    case "10":
                        DeleteFilme();
                        break;


                    case "C":
                        Console.Clear();
                        break;


                    default:
                        throw new ArgumentException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

        }

       

        private static void FindAllSerie()
        {
            Console.WriteLine("Listar Séries");

            var list = serieRepository.FindAll();

            if (list.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in list)
            {
                var status = serie.Status;
                Console.WriteLine($"Id {serie.GetId()}, {serie.Titulo}, {serie.Status}");
            }

            Console.WriteLine();
        }

        private static void FindByIdSerie()
        {
            Console.WriteLine("Informe o id da série: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine();

            var serie = serieRepository.FindById(id);

            Console.WriteLine(serie);
        }

        private static void CreateSerie()
        {
            Console.WriteLine("Adicionar nova série");

            foreach (int generos in Enum.GetValues(typeof(GeneroOpcoes)))
            {
                Console.WriteLine($"{generos} - {Enum.GetName(typeof(GeneroOpcoes), generos)}");
            }

            Console.WriteLine("");

            Console.Write("Escolha o gênero entre as apções acima: ");
            int input_genero = int.Parse(Console.ReadLine());

            Console.Write("Informe o título da série: ");
            string titulo = Console.ReadLine();

            Console.Write("infome a descrição da série: ");
            string descricao = Console.ReadLine();

            Console.Write("infome o ano da estréria da série: ");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Serie serie = new Serie(id: serieRepository.Next(), titulo, genero: (GeneroOpcoes)input_genero, descricao, ano);

            serieRepository.Create(serie);
        }


        private static void UpdateSerie()
        {
            Console.WriteLine("Atualizar série");
            Console.WriteLine("Informe o Id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            foreach (int generos in Enum.GetValues(typeof(GeneroOpcoes)))
            {
                Console.WriteLine($"{generos} - {Enum.GetName(typeof(GeneroOpcoes), generos)}");
            }

            Console.WriteLine();

            Console.WriteLine("Escolha o gênero entre as opções acima: ");
            int input_genero = int.Parse(Console.ReadLine());

            Console.Write("Informe o título da série: ");
            string titulo = Console.ReadLine();

            Console.Write("infome a descrição da série: ");
            string descricao = Console.ReadLine();

            Console.Write("infome o ano da estréria da série: ");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Serie serie = new Serie(id: idSerie, titulo, genero: (GeneroOpcoes)input_genero, descricao, ano);

            serieRepository.Update(idSerie, serie);


        }

        private static void DeleteSerie()
        {
            Console.WriteLine("Deletar série");
            Console.WriteLine("Informe o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            Console.WriteLine();

            serieRepository.Delete(idSerie);
        }

        private static void FindAllFilme()
        {
            var filmesList = filmeRepository.FindAll();

            if(filmesList.Count == 0)
            {
                Console.WriteLine("Nenhum filme encontrado.");
                return;
            }

            foreach(var filmes in filmesList)
            {
                Console.WriteLine(filmes);
            }

            Console.WriteLine();

        }

        private static void FindByIdFilme()
        {
            Console.Write("Informe o id do filme: ");
            int idFilme = int.Parse(Console.ReadLine());

            var filme = filmeRepository.FindById(idFilme);

            Console.WriteLine(filme);

            Console.WriteLine();

        }

        private static void CreateFilme()
        {
            Console.WriteLine("Adicionar novo filme");

            foreach (int generos in Enum.GetValues(typeof(GeneroOpcoes)))
            {
                Console.WriteLine($"{generos} - {Enum.GetName(typeof(GeneroOpcoes), generos)}");
            }

            Console.WriteLine();

            Console.WriteLine("Escolha o gênero entre as opções acima: ");
            int input_genero = int.Parse(Console.ReadLine());

            Console.Write("Informe o título do filme: ");
            string titulo = Console.ReadLine();

            Console.Write("Informe a descrição do filme: ");
            string descricao = Console.ReadLine();

            Console.Write("Informe o ano da estréria do filme: ");
            int ano = int.Parse(Console.ReadLine());

            Console.Write("Informe o nome do diretor: ");
            string diretor = Console.ReadLine();

            Filme filme = new Filme(id: filmeRepository.Next(), titulo, genero: (GeneroOpcoes)input_genero, descricao, diretor, ano);

            filmeRepository.Create(filme);

            Console.WriteLine();
        }

        private static void UpdateFilme()
        {
            Console.WriteLine("Atualizar filme");
            Console.Write("Infome o id do filme: ");
            int filmeId = int.Parse(Console.ReadLine());

            foreach (int generos in Enum.GetValues(typeof(GeneroOpcoes)))
            {
                Console.WriteLine($"{generos} - {Enum.GetName(typeof(GeneroOpcoes), generos)}");
            }

            Console.WriteLine();

            Console.WriteLine("Escolha o gênero entre as opções acima: ");
            int input_genero = int.Parse(Console.ReadLine());

            Console.Write("Informe o título do filme: ");
            string titulo = Console.ReadLine();

            Console.Write("Informe a descrição do filme: ");
            string descricao = Console.ReadLine();

            Console.Write("Informe o ano da estréria do filme: ");
            int ano = int.Parse(Console.ReadLine());

            Console.Write("Informe o nome do diretor: ");
            string diretor = Console.ReadLine();

            Filme filme = new Filme(filmeId, titulo, genero: (GeneroOpcoes)input_genero, descricao, diretor, ano);

            filmeRepository.Update(filmeId, filme);

            Console.WriteLine();
        }
                
        private static void DeleteFilme()
        {
            Console.WriteLine("Deletar filme ");
            Console.Write("Informe o id do filme: ");
            int filmeId = int.Parse(Console.ReadLine());

            filmeRepository.Delete(filmeId);
        }

        private static string ObterOpcaoUsuario()
        {

            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1 ->  Listar series");
            Console.WriteLine("2 ->  Listar filmes");
            Console.WriteLine("3 ->  Vizualizar série");
            Console.WriteLine("4 ->  Vizualizar filme");
            Console.WriteLine("5 ->  Inserir nova série");
            Console.WriteLine("6 ->  Inserir novo filme");
            Console.WriteLine("7 ->  Atualizar série");
            Console.WriteLine("8 ->  Atualizar filme");
            Console.WriteLine("9 ->  Apagar série");
            Console.WriteLine("10 -> Apagar filme");
            Console.WriteLine("C ->  Limpar Tela");
            Console.WriteLine("X ->  Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}