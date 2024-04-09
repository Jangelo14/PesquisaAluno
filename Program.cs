using System;

class Aluno
{
    private static int idAluno = 1;
    private static List<Aluno> alunos = new List<Aluno>();

    public int Id { get; }
    public string Nome { get; }
    public string Turma { get; }

    public Aluno(string nome, string turma)
    {
        Id = idAluno++;
        Nome = nome;
        Turma = turma;
        alunos.Add(this);
    }

    public static Aluno BuscarAlunoPorIndice(int indice)
    {
        if (indice >= 0 && indice < alunos.Count)
            return alunos[indice];
        else
            return null;
    }

    public static void ExibirTodosAlunos()
    {
        Console.WriteLine("Lista de Alunos:");
        Console.WriteLine("Índice | ID | Nome | Turma");
        foreach (var aluno in alunos)
        {
            Console.WriteLine($"{alunos.IndexOf(aluno)} | {aluno.Id} | {aluno.Nome} | {aluno.Turma}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.ExibirMenu();
    }
}

class Menu
{
    public void ExibirMenu()
    {
        Aluno aluno = null;
        while (true)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1. Adicionar aluno");
            Console.WriteLine("2. Buscar aluno pelo índice");
            Console.WriteLine("3. Exibir todos os alunos");
            Console.WriteLine("4. Sair");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o nome do aluno: ");
                    string nome = Console.ReadLine();
                    Console.Write("Digite a turma do aluno: ");
                    string turma = Console.ReadLine();
                    aluno = new Aluno(nome, turma);
                    Console.WriteLine("Aluno adicionado com sucesso!");
                    break;

                case "2":
                    if (aluno != null)
                    {
                        Console.WriteLine($"ID: {aluno.Id}, Nome: {aluno.Nome}, Turma: {aluno.Turma}");
                    }
                    else
                    {
                        Console.WriteLine("Nenhum aluno adicionado ainda.");
                    }
                    break;

                case "3":
                    Aluno.ExibirTodosAlunos();
                    break;

                case "4":
                    Console.WriteLine("Saindo do programa...");
                    return;

                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    break;
            }
        }
    }
}
