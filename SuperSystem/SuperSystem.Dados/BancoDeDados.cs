using SuperSystem.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSystem.Dados
{
    public class BancoDeDados
    {
        // Propriedade para armazenar os dados dos funcionários, simulando banco de dados
        private  int Id {  get; set; } = 0;
        private  Dictionary<int,Funcionario> Banco { get; set; } = new Dictionary<int, Funcionario>();

        public BancoDeDados() 
        {
            AdicionarFuncionario(new Funcionario("Gellyorge", "gellyorge@email.com", "123.123.123-12"));
            //AdicionarFuncionario(new Funcionario("Maria Souza", "maria@email.com", "987.654.321-00"));
            //AdicionarFuncionario(new Funcionario("Carlos Silva", "carlos@email.com", "111.222.333-44"));
        }

        public Dictionary<int, Funcionario> LerBanco()
        {
            VerificarExistenciaDeDadosNoBanco();
            return Banco;
        }
        public Funcionario PegarFuncionarioPorId(int id) 
        {
            ValidarExistenciaDeFuncionario(id);
            return Banco[id];
        }

        public void AdicionarFuncionario(Funcionario funcionario)
        {
            
            Banco.Add(Id,funcionario);
            Id++;
        }

        public void RemoverFuncionario(int id)
        {
            ValidarExistenciaDeFuncionario(id);
            Banco.Remove(id);
        }
        public void AtualizarFuncionario(int id,Funcionario funcionario)
        {
            ValidarExistenciaDeFuncionario(id);
            Banco[Id] = funcionario;
        }
        public void ValidarExistenciaDeFuncionario(int id)
        {
            DadosException.when(!Banco.ContainsKey(id),$"ID:{id} nao pode ser encontrado no banco!");
        }
        public void VerificarExistenciaDeDadosNoBanco()
        {
            DadosException.when(Banco.Count==0, "Banco de Dados Vazio!");
        }
    }
}