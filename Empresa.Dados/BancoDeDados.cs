using System;
using System.Collections.Generic;
using Empresa.Model;

namespace Empresa.Dados
{
    public abstract class BancoDeDados
    {
        public abstract void Salvar(Funcionario funcionario);
        public abstract void Excluir(Funcionario funcionario);
        public abstract IEnumerable<Funcionario> BuscarTodosOsFuncionarios();
        public abstract IEnumerable<Funcionario> BuscarTodosOsFuncionarios(string nome);
        public abstract IEnumerable<Funcionario> BuscarTodosOsFuncionarios(DateTime dataDeCadastro);
        public abstract Funcionario BuscarFuncionarioPelo(string cpf);
    }
}
