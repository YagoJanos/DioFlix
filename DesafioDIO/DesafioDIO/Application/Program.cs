using System;


namespace DesafioDIO
{
    class Program
    {
        static SerieRepositorio repositorioSeries = new SerieRepositorio();
        static FilmeRepositorio repositorioFilmes = new FilmeRepositorio();

        //Método principal que contem os métodos de exibição de menus e os métodos de processamento dos dados inseridos nos menus
        static void Main(string[] args)
        {
            string opcaoUsuario = ExibirMenuPrincipal();

            
            while (opcaoUsuario != "X")
            {
                string entrada;
                try
                {
                    switch (opcaoUsuario)
                    {
                        case "1":
                            entrada = ExibirMenuFilme();
                            ProcessarEntradaDeDadosFilmes(entrada);
                            break;
                        case "2":
                            entrada = ExibirMenuSerie();
                            ProcessarEntradaDeDadosSeries(entrada);
                            break;
                        case "C":
                            Console.Clear();
                            break;
                        case "X":
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();

                    }

                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }

                opcaoUsuario = ExibirMenuPrincipal();
            }

                

            Console.WriteLine("Obrigado por utilizar o DioFlix, volte sempre.");
            Console.ReadLine();


        }

        


        
        //Método que exibie uma lista com todas as séries cadastradas 
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorioSeries.Lista();

            if (lista.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Nenhuma série cadastrada.");
                Console.WriteLine("Aperte qualquer tecla para continuar");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            foreach (var serie in lista)
            {
                bool excluido = serie.RetornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.RetornaId(), serie.RetornaTitulo(), excluido ? "(Excluído)" : "");
            }




            Console.WriteLine();
            Console.WriteLine("Aperte qualquer tecla");
            Console.ReadLine();
            Console.Clear();
        }

        //Método que exibe uma lista com todos os filmes cadastrados
        private static void ListarFilmes()
        {
            Console.WriteLine("Listar filmes");

            var lista = repositorioFilmes.Lista();

            if (lista.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Nenhum filme cadastrado.");
                Console.WriteLine("Aperte qualquer tecla para continuar");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            foreach (var filme in lista)
            {
                bool excluido = filme.RetornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", filme.RetornaId(), filme.RetornaTitulo(), excluido ? "(Excluído)" : "");
            }



            Console.WriteLine();
            Console.WriteLine("Aperte qualquer tecla");
            Console.ReadLine();
            Console.Clear();
        }





        //Método que insere uma nova série no armazenamento do programa
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            Serie novaSerie = EntrarDadosSerie(null);

            repositorioSeries.Insere(novaSerie);




            Console.Clear();
            Console.WriteLine("Série cadastrada com sucesso");
            Console.WriteLine();
            Console.WriteLine("Aperte qualquer tecla");
            Console.ReadLine();
            Console.Clear();
        }

        //Método que insere um novo filme no armazenamento do programa
        private static void InserirFilme()
        {
            Console.WriteLine("Inserir novo filme");

            Filme novoFilme = EntrarDadosFilme(null);

            repositorioFilmes.Insere(novoFilme);




            Console.Clear();
            Console.WriteLine("Filme cadastrado com sucesso");
            Console.WriteLine();
            Console.WriteLine("Aperte qualquer tecla");
            Console.ReadLine();
            Console.Clear();
        }





        //Método que atualiza os dados de uma série já existente
        private static void AtualizarSerie()
        {
            Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            if(indiceSerie >= repositorioSeries.Lista().Count)
            {
                Console.Clear();

                Console.WriteLine("Não há elemento nessa posição");

                Console.WriteLine("Aperte qualquer botão para continuar");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            Serie novaSerie = EntrarDadosSerie(indiceSerie);

            repositorioSeries.Atualiza(indiceSerie, novaSerie);



            Console.Clear();
            Console.WriteLine("Série atualizada com sucesso");
            Console.WriteLine();
            Console.WriteLine("Aperte qualquer tecla");
            Console.ReadLine();
            Console.Clear();


        }

        //Método que atualiza os dados de um filme já existente
        private static void AtualizarFilme()
        {
            Console.Write("Digite o ID do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            if(indiceFilme >= repositorioFilmes.Lista().Count)
            {
                Console.Clear();


                Console.WriteLine("Não há elemento nessa posição");

                Console.WriteLine("Aperte qualquer tecla para continuar");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            Filme novoFilme = EntrarDadosFilme(indiceFilme);


            repositorioFilmes.Atualiza(indiceFilme, novoFilme);



            Console.Clear();
            Console.WriteLine("Filme atualizado com sucesso");
            Console.WriteLine();
            Console.WriteLine("Aperte qualquer tecla");
            Console.ReadLine();
            Console.Clear();

        }





        //Método que exibe o formulários de dados da serie a ser inserida ou atualizada e que também efetua a entrada de tais dados
        private static Serie EntrarDadosSerie(int? indiceSerie)
        {
            int indice = indiceSerie ?? repositorioSeries.ProximoId();

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opões acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());



            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();



            Serie novaSerie = new Serie(id: indice,
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            descricao: entradaDescricao,
            ano: entradaAno);

            return novaSerie;
        }

        //Método que exibe o formulários de dados do filme a ser inserida ou atualizada e que também efetua a entrada de tais dados
        private static Filme EntrarDadosFilme(int? indiceFilme)
        {
            int indice = indiceFilme ?? repositorioFilmes.ProximoId();


            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opões acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());



            Console.Write("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();



            Filme novoFilme = new Filme(id: indice,
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            descricao: entradaDescricao,
            ano: entradaAno);

            return novoFilme;
        }






        //Método para exclusão de uma série.
        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());



            if (indiceSerie >= repositorioSeries.Lista().Count)
            {
                Console.Clear();

                Console.WriteLine("Não há elemento nessa posição");

                Console.WriteLine("Aperte qualquer tecla para continuar");
                Console.ReadLine();
                Console.Clear();
                return;
            }



            Console.WriteLine("Deseja mesma excluir \"" + repositorioSeries.RetornaPorId(indiceSerie).RetornaTitulo() + "\"? S/N");
            string confirmacao = Console.ReadLine();
            
            if(confirmacao.ToUpper() == "S")
            {
                repositorioSeries.Exclui(indiceSerie);
                Console.WriteLine("A série \"" + repositorioSeries.RetornaPorId(indiceSerie).RetornaTitulo() + "\" foi excluída");
            }




            Console.WriteLine();
            Console.WriteLine("Aperte qualquer tecla");
            Console.ReadLine();
            Console.Clear();
        }

        //Método para a exclusão de um filme.
        private static void ExcluirFilme()
        {
            Console.Write("Digite o id do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());



            if (indiceFilme >= repositorioFilmes.Lista().Count)
            {
                Console.Clear();

                Console.WriteLine("Não há elemento nessa posição");

                Console.WriteLine("Aperte qualquer tecla para continuar");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            Console.WriteLine("Deseja mesma excluir \"" + repositorioFilmes.RetornaPorId(indiceFilme).RetornaTitulo() + "\"? S/N");
            string confirmacao = Console.ReadLine();



            if (confirmacao.ToUpper() == "S")
            {
                repositorioFilmes.Exclui(indiceFilme);
                Console.WriteLine("O filme \"" + repositorioFilmes.RetornaPorId(indiceFilme).RetornaTitulo() + "\" foi excluído");
            }




            Console.WriteLine();
            Console.WriteLine("Aperte qualquer tecla");
            Console.ReadLine();
            Console.Clear();
        }







        //Método para a exibição dos dados de uma série em específico
        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o Id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());




            if (indiceSerie >= repositorioSeries.Lista().Count)
            {
                Console.Clear();

                Console.WriteLine("Não há elemento nessa posição");

                Console.WriteLine("Aperte qualquer tecla para continuar");
                Console.ReadLine();
                Console.Clear();
                return;
            }




            var serie = repositorioSeries.RetornaPorId(indiceSerie);




            Console.WriteLine(serie);
            Console.WriteLine();
            Console.WriteLine("Aperte qualquer tecla para continuar");
            Console.ReadLine();
            Console.Clear();
        }

        //Método para a exibição dos dados de um filme em específico
        private static void VisualizarFilme()
        {
            Console.WriteLine("Digite o Id do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());




            if (indiceFilme >= repositorioFilmes.Lista().Count)
            {
                Console.Clear();

                Console.WriteLine("Não há elemento nessa posição");

                Console.WriteLine("Aperte qualquer tecla para continuar");
                Console.ReadLine();
                Console.Clear();
                return;
            }




            var filme = repositorioFilmes.RetornaPorId(indiceFilme);





            Console.WriteLine(filme);
            Console.WriteLine();
            Console.WriteLine("Aperte qualquer tecla");
            Console.ReadLine();
            Console.Clear();
        }






        //Método para a exibição do menu de manipulação de series e entrada da escolha 
        private static string ExibirMenuSerie()
        {
            Console.WriteLine("DIOFlix a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("X- Sair");
            Console.WriteLine();


            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.Clear();
            return opcaoUsuario;

        }
        // Método para a exibição do menu de manipulação de filmes e entrada da escolha
        private static string ExibirMenuFilme()
        {
            Console.WriteLine("DIOFlix a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar filmes");
            Console.WriteLine("2- Inserir novo filme");
            Console.WriteLine("3- Atualizar filme");
            Console.WriteLine("4- Excluir filme");
            Console.WriteLine("5- Visualizar filme");
            Console.WriteLine("X- Sair");
            Console.WriteLine();


            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.Clear();
            return opcaoUsuario;
        }





        //Método para a exibição do menu principal e entrada da escolha.
        private static string ExibirMenuPrincipal()
        {
            Console.WriteLine("DIOFlix a seu dispor!!!");
            Console.WriteLine("Informe a seção desejada:");

            Console.WriteLine("1- Filmes");
            Console.WriteLine("2- Series");
            Console.WriteLine("X- Sair");
            Console.WriteLine();


            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.Clear();
            return opcaoUsuario;

        }





        //Método para o processamento de dados do menu secundário de Filmes

        private static void ProcessarEntradaDeDadosFilmes(string entrada)
        {
            string opcaoUsuario = entrada;

            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarFilmes();
                        break;
                    case "2":
                        InserirFilme();
                        break;
                    case "3":
                        AtualizarFilme();
                        break;
                    case "4":
                        ExcluirFilme();
                        break;
                    case "5":
                        VisualizarFilme();
                        break;
                    case "X":
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ExibirMenuFilme();
            }
        }

        //Método para o processamento de dados do menu secundário de Séries
        private static void ProcessarEntradaDeDadosSeries(string entrada)
        {
            string opcaoUsuario = entrada;

            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "X":
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ExibirMenuSerie();
            }
        }
    }
}