using System;
using System.Collections.Generic;

namespace ConsoleListaDeTarefas
{
	class TodoItem
	{
		public string Título { get; set; }
		public string Descrição { get; set; }
		public bool Concluída { get; set; }
	}

	class Program
	{
		static void Main(string[] args)
		{
			// Cria uma nova lista para armazenar as tarefas
			List<TodoItem> listaDeTarefas = new List<TodoItem>();

			// Cria um loop infinito para exibir o menu e processar as opções escolhidas pelo usuário
			while (true)
			{
				Console.Clear();
				Console.WriteLine("==== Lista de Tarefas ====");
				Console.WriteLine();

				// Exibe as opções do menu
				Console.WriteLine("1 - Adicionar tarefa");
				Console.WriteLine("2 - Marcar tarefa como concluída");
				Console.WriteLine("3 - Editar tarefa");
				Console.WriteLine("4 - Listar tarefas");
				Console.WriteLine("5 - Sair");
				Console.WriteLine();

				// Pede ao usuário para escolher uma opção
				Console.Write("Escolha uma opção: ");
				string opcao = Console.ReadLine();
				Console.WriteLine();

				// Processa a opção escolhida pelo usuário
				switch (opcao)
				{
					// Adiciona uma nova tarefa à lista
					case "1":
						Console.Write("Digite o título da tarefa: ");
						string titulo = Console.ReadLine();

						Console.Write("Digite a descrição da tarefa: ");
						string descricao = Console.ReadLine();

						TodoItem item = new TodoItem
						{
							Título = titulo,
							Descrição = descricao,
							Concluída = false
						};

						listaDeTarefas.Add(item);

						Console.WriteLine();
						Console.WriteLine("Tarefa adicionada com sucesso!");
						Console.ReadKey();
						break;

					// Marca uma tarefa como concluída
					case "2":
						Console.Write("Digite o número da tarefa que deseja marcar como concluída: ");
						int numero = int.Parse(Console.ReadLine());

						// Verifica se o número da tarefa é válido
						if (numero <= 0 || numero > listaDeTarefas.Count)
						{
							Console.WriteLine("Número inválido! Tente novamente.");
							Console.ReadKey();
							break;
						}

						// Marca a tarefa como concluída
						listaDeTarefas[numero - 1].Concluída = true;

						Console.WriteLine();
						Console.WriteLine("Tarefa marcada como concluída com sucesso!");
						Console.ReadKey();
						break;

					// Edita uma tarefa existente
					case "3":
						Console.Write("Digite o número da tarefa que deseja editar: ");
						int num = int.Parse(Console.ReadLine());

						// Verifica se o número da tarefa é válido
						if (num <= 0 || num > listaDeTarefas.Count)
						{
							Console.WriteLine("Número inválido! Tente novamente.");
							Console.ReadKey();
							break;
						}

						// Obtém a tarefa a ser editada
						TodoItem tarefa = listaDeTarefas[num - 1];

						// Edita o título da tarefa
						Console.WriteLine("Título atual: " + tarefa.Título);
						Console.Write("Digite o novo título da tarefa: ");
						string novoTitulo = Console.ReadLine();
						tarefa.Título = novoTitulo;

						// Edita a descrição da tarefa
						Console.WriteLine("Descrição atual: " + tarefa.Descrição);
						Console.Write("Digite a nova descrição da tarefa: ");
						string novaDescricao = Console.ReadLine();
						tarefa.Descrição = novaDescricao;

						Console.WriteLine();
						Console.WriteLine("Tarefa editada com sucesso!");
						Console.ReadKey();
						break;

					// Lista todas as tarefas da lista
					case "4":
						for (int i = 0; i < listaDeTarefas.Count; i++)
						{
							Console.WriteLine("Tarefa #" + (i + 1));

							Console.WriteLine("\tTítulo: " + listaDeTarefas[i].Título);

							if (listaDeTarefas[i].Concluída)
							{
								Console.WriteLine("\tConcluída");
							}
							else
							{
								Console.WriteLine("\tNão concluída");
							}

							Console.WriteLine("\tDescrição: " + listaDeTarefas[i].Descrição);
						}

						Console.ReadKey();
						break;

					// Sai do programa
					case "5":
						Console.WriteLine("Saindo...");
						return;

					// Trata opções inválidas
					default:
						Console.WriteLine("Opção inválida! Tente novamente.");
						Console.ReadKey();
						break;
				}
			}
		}
	}
}

