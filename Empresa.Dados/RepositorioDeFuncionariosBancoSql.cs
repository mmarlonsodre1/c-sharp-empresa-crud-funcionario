using System;
using System.Collections.Generic;
using Empresa.Model;

namespace Empresa.Dados
{
    public class RepositorioDeFuncionariosBancoSql : RepositorioDeFuncionarios
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

        protected override void AlterarExistente(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        protected override void CriarNovo(Funcionario funcionario)
        {
            //abrir conexao com banco de dados
            //escrever o insert utilizando os dados
            //insert into funcionar (...)
            //efetivar o comando de insert
            //fechar conexao com banco de dados
        }
    }
}
