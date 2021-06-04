using APP_series.Entities;
using APP_series.Entities.Enum;
using APP_series.Repository;
using System;
using System.Collections.Generic;

namespace APP_series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        FindAll();
                        break;

                    case "2":
                        FindById();
                        break;

                    case "3":
                        Create();
                        break;

                    case "4":
                        Update();
                        break;

                    case "5":
                        Delete();
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


        private static void FindAll()
        {
            Console.WriteLine("Listar Séries");

            var list = repository.FindAll();

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

        private static void FindById()
        {
            Console.WriteLine("Informe o id da série: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine();

            var serie = repository.FindById(id);

            Console.WriteLine(serie);
        }

        private static void Create()
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

            Serie serie = new Serie(id: repository.Next(), titulo, genero: (GeneroOpcoes)input_genero, descricao, ano);

            repository.Create(serie);
        }
              

        private static void Update()
        {
            Console.WriteLine("Atualizar série");
            Console.WriteLine("Informe o Id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            foreach(int generos in Enum.GetValues(typeof(GeneroOpcoes)))
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

            repository.Update(idSerie, serie);


        }      

        private static void Delete()
        {
            Console.WriteLine("Deletar série");
            Console.WriteLine("Informe o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            Console.WriteLine();

            repository.Delete(idSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();

            Console.WriteLine("1 - Listar series");
            Console.WriteLine("2 - Vizualizar série");
            Console.WriteLine("3 - Inserir nova série");
            Console.WriteLine("4 - Atualizar série");
            Console.WriteLine("5 - Apagar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}