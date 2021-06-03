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

                    case "C":
                        Console.Clear();
                        break;
                        

                    default:
                        throw new ArgumentException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

        }

        private static void Update()
        {
            throw new NotImplementedException();
        }

        private static void Create()
        {
            Console.WriteLine("Adicionar nova série");

            foreach (int GeneroOpcoes in Enum.GetValues(typeof(GeneroOpcoes)))
            {
                Console.WriteLine($"{GeneroOpcoes} - {Enum.GetName(typeof(GeneroOpcoes), GeneroOpcoes)}"  );
            }

            Console.Write("Escolha o gênero entre as apções acima: ");
            int input_genero = int.Parse(Console.ReadLine());

            Console.Write("Informe o título da série: ");
            string titulo = Console.ReadLine();

            Console.Write("infome a descrição da série: ");
            string descricao = Console.ReadLine();

            Console.Write("infome o ano da estréria da série: ");
            int ano = int.Parse(Console.ReadLine());

            Serie serie = new Serie(id: repository.Next(), titulo, genero: (GeneroOpcoes)input_genero, descricao, ano);

            repository.Create(serie);
        }

        private static void FindById()
        {
            Console.WriteLine("Informe o id da série: ");
            int id = int.Parse(Console.ReadLine());

            var serie = repository.FindById(id);

            Console.WriteLine(serie);
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

            foreach(var serie in list)
            {
                var status = serie.Status;
                Console.WriteLine($"Id {serie.GetId()}, {serie.Titulo}, {serie.Status}");
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar series");
            Console.WriteLine("2 - Vizualizar série");
            Console.WriteLine("3 - Inserir nova série");
            Console.WriteLine("4 - Atualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}