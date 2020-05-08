using System;
using System.Collections.Generic;
using Empresa.Model;

namespace Empresa.Dados
{
    public class BancoDeDadosSql : BancoDeDados
    {
        public override Funcionario BuscarFuncionarioPelo(string cpf)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Funcionario> BuscarTodosOsFuncionarios()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Funcionario> BuscarTodosOsFuncionarios(string nome)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Funcionario> BuscarTodosOsFuncionarios(DateTime dataDeCadastro)
        {
            throw new NotImplementedException();
        }

        public override void Excluir(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public override void Salvar(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }
    }
}
