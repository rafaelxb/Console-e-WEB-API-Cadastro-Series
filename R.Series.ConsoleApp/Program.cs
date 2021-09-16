using System;
using R.Series;

namespace R.Series.ConsoleApp
{
    class Program
    {

		static RegistroRepositorio repositorio = new RegistroRepositorio();

		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarRegistros();
						break;
					case "2":
						InserirRegistro();
						break;
					case "3":
						AtualizarRegistro();
						break;
					case "4":
						ExcluirRegistro();
						break;
					case "5":
						VisualizarRegistro();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static void ListarRegistros()
		{
			Console.WriteLine("Listar Registros");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum Registro cadastrada.");
				return;
			}

			foreach (var Registro in lista)
			{
				var excluido = Registro.retornaExcluido();

				Console.WriteLine("#ID {0}: - {1} - {2} {3}",
									Registro.retornaId(),
									Registro.retornaTitulo(),
									Enum.GetName(typeof(Tipo), Registro.retornaTipo()),
									(excluido ? "*Registro Excluído*" : ""));
			}
		}

		private static void InserirRegistro()
		{
			Console.WriteLine("Inserir novo Registro");

			int indiceRegistro = repositorio.ProximoId();

			Registro registro = PreparaRegistro(indiceRegistro);
			repositorio.Insere(registro);
		}

		private static void AtualizarRegistro()
		{
			Console.Write("Digite o id do Registro: ");
			int indiceRegistro = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Registro registro = PreparaRegistro(indiceRegistro);

			repositorio.Atualiza(indiceRegistro, registro);
		}

		private static void ExcluirRegistro()
		{
			int indiceRegistro = ObterId();

			repositorio.Exclui(indiceRegistro);
		}

		private static void VisualizarRegistro()
		{
			int indiceRegistro = ObterId();

			var Registro = repositorio.RetornaPorId(indiceRegistro);

			Console.WriteLine(Registro);
		}

		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("RX Séries e Filmes");
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Registros");
			Console.WriteLine("2- Inserir novo Registro");
			Console.WriteLine("3- Atualizar Registro");
			Console.WriteLine("4- Excluir Registro");
			Console.WriteLine("5- Visualizar Registro");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		// Função para preparar os dados de gravação para Novo Registro ou Atualizar
		private static Registro PreparaRegistro(int indiceRegistro)
		{
			int entradaTipo, entradaGenero, entradaAno;
			decimal entradaNota;
			string entradaTitulo, entradaDescricao;
			ObterInfos(out entradaTipo,
					   out entradaGenero,
					   out entradaTitulo,
					   out entradaAno,
					   out entradaDescricao,
					   out entradaNota);


			Registro atualizaRegistro = new Registro(id: indiceRegistro,
													tipo: (Tipo)entradaTipo,
													genero: (Genero)entradaGenero,
													titulo: entradaTitulo,
													ano: entradaAno,
													descricao: entradaDescricao,
													nota: entradaNota);
			return atualizaRegistro;
		}

		private static void ObterInfos(out int entradaTipo,
									   out int entradaGenero,
									   out string entradaTitulo,
									   out int entradaAno,
									   out string entradaDescricao,
									   out decimal entradaNota)
		{
			Console.WriteLine();

			foreach (int t in Enum.GetValues(typeof(Tipo)))
			{
				Console.WriteLine("{0}-{1}", t, Enum.GetName(typeof(Tipo), t));
			}

			Console.Write("Digite o tipo entre as opções acima: ");
			entradaTipo = int.Parse(Console.ReadLine());

			Console.WriteLine();

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			entradaGenero = int.Parse(Console.ReadLine());

			Console.WriteLine();

			Console.Write("Digite o Título do Registro: ");
			entradaTitulo = Console.ReadLine();
			Console.Write("Digite o Ano de Início do Registro: ");
			entradaAno = int.Parse(Console.ReadLine());
			Console.Write("Digite a Descrição do Registro: ");
			entradaDescricao = Console.ReadLine();
			Console.Write("Digite a Nota: ");
			string nota = Console.ReadLine();
			nota = nota.Replace(".", ","); //garante apenas valores com vírgula
			entradaNota = Convert.ToDecimal(nota);
		}
		private static int ObterId()
		{
			Console.Write("Digite o id do Registro: ");
			int indiceRegistro = int.Parse(Console.ReadLine());
			return indiceRegistro;
		}

	}
}
