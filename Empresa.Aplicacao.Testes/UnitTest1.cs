using System;
using Xunit;

namespace Empresa.Aplicacao.Testes
{
    public class CadastrarFuncionarioTestes
    {
        [Fact]
        public void TestCadastrarFuncionarioComSucesso()
        {
            string nome = "nome";
            string cpf = "cpf";

            var result = FuncionarioApp.CadastrarFuncionario(nome, cpf);

            Assert.True(result.CadastradoComSucesso);
        }
    }
}
