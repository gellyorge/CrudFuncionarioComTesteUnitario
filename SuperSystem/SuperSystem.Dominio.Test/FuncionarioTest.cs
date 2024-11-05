namespace SuperSystem.Dominio.Test
{
    public class FuncionarioTest
    {
        [Fact]
        public void CriarFuncionarioValido()
        {
            var func = new Funcionario
                ("Gellyorge","teste@email.com","123.123.123-12");
            
            Assert.NotNull(func);
            Assert.Contains("Gellyorge",func.Nome);
            Assert.NotEmpty(func.Nome!);
        }

        [Fact]
        public void QuandoValidarNomeNuloDeveGerarExcecao()
        {
            var ex =
            Assert.Throws<DominioException>(() => {
                var func = new Funcionario("", "teste@email.com", "123.123.123-12");
            });

            Assert.NotNull(ex);
            Assert.Contains(ex.Message, "Nome nao pode ser nulo ou vazio");
        }
    }
}