using Empresa.Model;
using Empresa.Dados;
using System;

namespace Empresa.Aplicacao
{
    public class Class1
    {
        public static void CadastrarFuncionario(string nome, string cpf)
        {
            var funcionario = new Funcionario(nome, cpf);

            BancoDeDados.Salvar(funcionario);
        }

        public static RepositorioDeFuncionarios BancoDeDados
        {
            get
            {
                _bancoDeDados ??= new RepositorioDeFuncionariosDeArquivos();
                BancoDeDados = _bancoDeDados;
                return _bancoDeDados;
            }
            set
            {
                _bancoDeDados = value;
            }
        }

        private static RepositorioDeFuncionarios _bancoDeDados;
    }
}
