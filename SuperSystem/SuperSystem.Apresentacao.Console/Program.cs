using SuperSystem.Dados;
using SuperSystem.Dominio;

BancoDeDados bancoDeDados = new BancoDeDados();

while (true) 
{
    try
    {
        CarregarMenuInicial();

    }
    catch (Exception e)
    {
        Console.WriteLine($"----{e.Message}----");
    }
}



void CarregarMenuInicial()
{
    Console.WriteLine("Digite: ");
    Console.WriteLine("1: Exibir Funcionarios");
    Console.WriteLine("2: Exibir Funcionario por Id");
    Console.WriteLine("3: Cadastrar Funcionarios ");
    Console.WriteLine("4: Remover um Funcionario ");
    Console.WriteLine("5: Sair");

    switch (Console.ReadLine())
    {
        case "1":
            var listaDeFuncionarios = bancoDeDados.LerBanco();
            foreach (var funcionario in listaDeFuncionarios)
            {
                Console.WriteLine(funcionario);
            }
            break;

        case "2":
            var id = RetornarInt();
            var funcionarioId = bancoDeDados.PegarFuncionarioPorId(id);
            Console.WriteLine(funcionarioId);
            break;

        case "3":
            Console.WriteLine("Digite o Nome do Funcionario:");
            var nome = Console.ReadLine();

            Console.WriteLine("Digite o Email do Funcionario:");
            var email = Console.ReadLine();

            Console.WriteLine("Digite o Cpf do Funcionario:");
            var cpf = Console.ReadLine();            

            var novoFuncio = new Funcionario
                (nome, email, cpf);

            bancoDeDados.AdicionarFuncionario(novoFuncio);
            Console.WriteLine("Cadastrado com sucesso!");
            break;

        case "4":
            Console.WriteLine("Digite o ID do Funcionario:");
            var idDeletar = RetornarInt();
            bancoDeDados.RemoverFuncionario(idDeletar);
            Console.WriteLine("Deletado com sucesso!");
            break;

        default:
            throw new InvalidOperationException("operacao invalida!");
    }
}
int RetornarInt()
{
    try
    {
        Console.WriteLine("Digite um Numero!");
        var numero = Console.ReadLine();
        return int.Parse(numero!);
    }
    catch
    {
        throw new InvalidOperationException("Digite um Numero valido!");
    }
}