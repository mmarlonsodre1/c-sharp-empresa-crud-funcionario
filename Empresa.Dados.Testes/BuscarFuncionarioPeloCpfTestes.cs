using Empresa.Model;
using System;
using Xunit;

namespace Empresa.Dados.Testes
{
    public class BuscarFuncionarioPeloCpfTestes
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

            //Ent�o // Then //Assert
            Assert.True(funcionario.Cpf == funcionarioEncontrado.Cpf);
        }
    }

    public class SalvarFuncionarioTestes
    {
        [Fact]
        public void TestSalvarFuncionar()
        {
            //Given
            var funcionario = new Funcionario("123", "123");
            var repositorio = new RepositorioDeFuncionariosDeArquivos();

            //When
            repositorio.Salvar(funcionario);

            //Then
        }
    }
}
