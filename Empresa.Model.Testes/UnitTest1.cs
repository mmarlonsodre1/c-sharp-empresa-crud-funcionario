using System;
using Xunit;

namespace Empresa.Model.Testes
{
    public class UnitTest1
    {
        [Fact]
        public void TestDiasParaOAniversarioDoFuncionario()
        {
            //Dado
            Funcionario funcionario = new Funcionario();
            funcionario.DataDeNascimento = DateTime.Now.AddDays(35);

            //Quando
            var diasParaAniversario = funcionario.ObterDiasRestantesParaAniversario();

            //Então
            Assert.Equal(35, diasParaAniversario);
        }
    }
}
