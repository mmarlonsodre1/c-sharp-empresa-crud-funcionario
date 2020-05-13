using System;
using System.Collections.Generic;
using Empresa.Model;

namespace Empresa.Dados
{
    public abstract class RepositorioDeFuncionarios
    {
        public void Salvar(Funcionario funcionario)
        {
            if (FuncionarioJaEstaCadastrado(funcionario))
            {
                AlterarExistente(funcionario);
            }
            else
            {
                CriarNovo(funcionario);
            }
        }

        private bool FuncionarioJaEstaCadastrado(Funcionario funcionario)
        {
            var cpf = funcionario.Cpf;

            var funcionarioEncontrado = BuscarFuncionarioPelo(cpf);

            if (funcionarioEncontrado != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected abstract void CriarNovo(Funcionario funcionario);
        protected abstract void AlterarExistente(Funcionario funcionario);

        public abstract void Excluir(Funcionario funcionario);
        public abstract IEnumerable<Funcionario> BuscarTodosOsFuncionarios();
        public abstract IEnumerable<Funcionario> BuscarTodosOsFuncionarios(string nome);
        public abstract IEnumerable<Funcionario> BuscarTodosOsFuncionarios(DateTime dataDeCadastro);
        public abstract Funcionario BuscarFuncionarioPelo(string cpf);
    }
}
