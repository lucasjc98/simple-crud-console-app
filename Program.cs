using System;
using simple_crud_console_app.Classes;
using simple_crud_console_app.Enums;
using simple_crud_console_app.Repositories;

namespace simple_crud_console_app
{
  class Program
  {
    static SerieRepository repository = new SerieRepository();
    static void Main(string[] args)
    {
      string option = getUserOption();

      while (option != "X")
      {
        switch (option)
        {
          case "1":
            ListAvailableSeries();
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
            ExibirSerie();
            break;
          case "6":
            ListAllSeries();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }

        option = getUserOption();
      }
    }
    private static void ListAvailableSeries()
    {
      Console.Clear();
      Console.WriteLine("===== TODAS AS SÉRIES DISPONÍVEIS =====");

      var lista = repository.ListNotDeleted();

      if (lista.Count > 0)
      {
        foreach (var serie in lista)
        {
          Console.WriteLine($"#ID {serie.GetId()}: - {serie.GetTitulo()}");
        }
      }
      else
      {
        Console.WriteLine("Nenhuma série cadastrada!");
      }
			Console.WriteLine();
      Console.WriteLine("Pressione ENTER para continuar...");
      Console.ReadLine();
    }

    private static void InserirSerie()
    {
      int inGenero;
      do
      {
        Console.Clear();
        Console.WriteLine("===== INSERIR SÉRIE =====");

        foreach (int index in Enum.GetValues(typeof(Genero)))
        {
          Console.WriteLine($"{index}. {Enum.GetName(typeof(Genero), index)}");
        }
        Console.Write("Informe o Gênero entre as opções acima: ");
        inGenero = int.Parse(Console.ReadLine());
      } while (inGenero < 1 || inGenero > 13);

      Console.Write("Informe o Título: ");
      string inTitulo = Console.ReadLine();

      Console.Write("Informe o Ano: ");
      int inAno = int.Parse(Console.ReadLine());

      Console.Write("Informe o Descriação: ");
      string inDescricao = Console.ReadLine();

      Serie serie = new Serie(id: repository.NextID(),
                              genero: (Genero)inGenero,
                              titulo: inTitulo,
                              descricao: inDescricao,
                              ano: inAno);

      repository.Insert(serie);
    }

    private static void AtualizarSerie()
    {
      Console.Clear();
      Console.WriteLine("===== ATUALIZAR SÉRIE =====");
      Console.Write("Informe o ID da série: ");
      int indexSerie = int.Parse(Console.ReadLine());

      if (indexSerie <= repository.List().Count - 1)
      {
        int inGenero;
        do
        {
          Console.Clear();
          Console.WriteLine("===== ATUALIZAR SÉRIE =====");

          foreach (int index in Enum.GetValues(typeof(Genero)))
          {
            Console.WriteLine($"{index}. {Enum.GetName(typeof(Genero), index)}");
          }
          Console.Write("Informe o Gênero entre as opções acima: ");
          inGenero = int.Parse(Console.ReadLine());
        } while (inGenero < 1 || inGenero > 13);

        Console.Write("Informe o Título: ");
        string inTitulo = Console.ReadLine();

        Console.Write("Informe o Ano: ");
        int inAno = int.Parse(Console.ReadLine());

        Console.Write("Informe o Descriação: ");
        string inDescricao = Console.ReadLine();

        Serie serie = new Serie(id: indexSerie,
                                genero: (Genero)inGenero,
                                titulo: inTitulo,
                                descricao: inDescricao,
                                ano: inAno);

        repository.Update(indexSerie, serie);
      }
      else
      {
				Console.WriteLine();
        Console.WriteLine("Série não encontrada!");
        Console.WriteLine("Pressione ENTER para continuar...");
        Console.ReadLine();
      }
    }

    private static void ExcluirSerie()
    {
      Console.Clear();
      Console.WriteLine("===== EXCLUIR SÉRIE =====");
      Console.Write("Informe o ID da série: ");
      int indexSerie = int.Parse(Console.ReadLine());

      if (indexSerie <= repository.List().Count - 1)
      {
        repository.Delete(indexSerie);
        Console.WriteLine("Série excluída!");
      }
      else
      {
        Console.WriteLine("Série não encontrada!");
      }
			Console.WriteLine();
      Console.WriteLine("Pressione ENTER para continuar...");
      Console.ReadLine();
    }

    private static void ExibirSerie()
    {
      Console.Clear();
      Console.WriteLine("===== EXIBIR SÉRIE =====");
      Console.Write("Informe o ID da série: ");
      int indexSerie = int.Parse(Console.ReadLine());

      if (indexSerie <= repository.List().Count - 1)
      {
        var serie = repository.GetByID(indexSerie);

        Console.WriteLine(serie.ToString());
      }
      else
      {
        Console.WriteLine("Série não encontrada!");
      }
			Console.WriteLine();
      Console.WriteLine("Pressione ENTER para continuar...");
      Console.ReadLine();
    }

    private static void ListAllSeries()
    {
      Console.Clear();
      Console.WriteLine("===== TODAS AS SÉRIES =====");

      var lista = repository.List();

      if (lista.Count > 0)
      {
        foreach (var serie in lista)
        {
          Console.WriteLine($"#ID {serie.GetId()}: - {serie.GetTitulo()}");
        }
      }
      else
      {
        Console.WriteLine("Nenhuma série cadastrada!");
      }
			Console.WriteLine();
      Console.WriteLine("Pressione ENTER para continuar...");
      Console.ReadLine();
    }

    private static string getUserOption()
    {
      Console.Clear();
      Console.WriteLine("LJC Séries a seu dispor!!!");
      Console.WriteLine("Informe a opção desejada:");
      Console.WriteLine("1. Listar séries disponíveis.");
      Console.WriteLine("2. Inserir nova série.");
      Console.WriteLine("3. Atualizar série.");
      Console.WriteLine("4. Excluir série.");
      Console.WriteLine("5. Exibir série.");
      Console.WriteLine("6. Listar todas as séries.");
      Console.WriteLine("X. Sair");
      Console.WriteLine();

      return Console.ReadLine().ToUpper();
    }
  }
}
