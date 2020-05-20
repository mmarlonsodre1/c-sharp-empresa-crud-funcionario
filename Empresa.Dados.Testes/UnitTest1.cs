using Empresa.Model;
using System;
using Xunit;

namespace Empresa.Dados.Testes
{
    public class UnitTest1
    {
        [Fact]
        public void TestBuscaFuncionarioPeloCpf()
        {
            //Dado //Given //Arrange
            string cpf = "123";
            var funcionario = new Funcionario("vitor", cpf);
            var repositorio = new RepositorioDeFuncionariosDeArquivos();
            repositorio.Salvar(funcionario);

            //Quando //When //Act
            var funcionarioEncontrado = repositorio.BuscarFuncionarioPelo(cpf);

            //Então // Then //Assert
            Assert.True(funcionario.Cpf == funcionarioEncontrado.Cpf);
        }

        [Fact]
        public void TestSalvarFuncionar()
        {
            var funcionario = new Funcionario("123", "123");

            var repositorio = new RepositorioDeFuncionariosDeArquivos();
            repositorio.Salvar(funcionario);
        }
    }
}
