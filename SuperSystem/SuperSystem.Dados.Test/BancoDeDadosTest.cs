using SuperSystem.Dados;
using System;

namespace SuperSystem.Dominio.Test
{
    public class BancoDeDadosTest
    {
        [Fact]
        public void AdicionarFuncionario()
        {
            var funcionario = new Funcionario
                ("Gellyorge", "teste@email.com", "123.123.123-12");

            BancoDeDados bancoDeDados = new BancoDeDados();
            bancoDeDados.AdicionarFuncionario(funcionario);
            var funcionarioAdicionadoPeloBanco = bancoDeDados.PegarFuncionarioPorId(0);

            Assert.NotNull(bancoDeDados.LerBanco());
            Assert.NotEmpty(funcionarioAdicionadoPeloBanco.Nome!);
            Assert.Contains(funcionario.Nome!, funcionarioAdicionadoPeloBanco.Nome!);
            
        }
        [Fact]
        public void QuandoIdNaoExistirNoBancoDeveGerarExececao()
        {
            BancoDeDados bancoDeDados = new BancoDeDados();

            var ex =
            Assert.Throws<DadosException>(() => {
                bancoDeDados.RemoverFuncionario(10);
            });

            Assert.NotNull(ex);
            Assert.Contains(ex.Message, "ID:10 nao pode ser encontrado no banco!");
        }
    }
}
