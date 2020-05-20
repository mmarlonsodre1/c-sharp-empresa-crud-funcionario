using Empresa.Model;
using Empresa.Dados;
using System;

namespace Empresa.Aplicacao
{
    public class Class1
    {
        public static CadastrarFuncionarioResult CadastrarFuncionario(string nome, string cpf)
        {
            var funcionario = new Funcionario(nome, cpf);

            try
            {
                BancoDeDados.Salvar(funcionario);
                return new CadastrarFuncionarioResult { CadastradoComSucesso = true };
            }
            catch (Exception e)
            {
                return new CadastrarFuncionarioResult { CadastradoComSucesso = false };
            }
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

    public class CadastrarFuncionarioResult
    {
        public bool CadastradoComSucesso { get; set; }
    }
}
