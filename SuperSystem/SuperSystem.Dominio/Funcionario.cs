using System.Text.RegularExpressions;

namespace SuperSystem.Dominio
{
    public class Funcionario
    {
        public Funcionario(string? nome, string? email, string? cpf)
        {
            ValidarFuncionario(nome, email, cpf);
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }

        private void ValidarFuncionario(string? nome, string? email, string? cpf)
        {
            //nome
            DominioException.when(string.IsNullOrEmpty(nome), "Nome nao pode ser nulo ou vazio");
            DominioException.when(nome!.Length < 3, "Nome nao pode ser menor que 3 caracteres");
            DominioException.when(nome!.Length > 50, "Nome nao pode ser maior que 3 caracteres");

            //cpf
            DominioException.when(string.IsNullOrEmpty(cpf), "cpf nao pode ser nulo ou vazio");

            var regex = Regex.IsMatch(cpf!, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$|^\d{11}$");
            DominioException.when(!regex, "CPF fora do formato padrao.");

            //email
            DominioException.when(string.IsNullOrEmpty(email), "email nao pode ser nulo ou vazio");

            regex = Regex.IsMatch(email!, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            DominioException.when(!regex, "Email fora do formato!");

        }

        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }

        public override string ToString()
        {
            return $"Nome:{Nome}\nEmail:{Email}\nCpf:{Cpf}\n";
        }

    }
}
