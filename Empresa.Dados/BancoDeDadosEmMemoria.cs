using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Empresa.Model;

namespace Empresa.Dados
{
    //abstração = utilizar classes, na maioria das vezes
    //encapsulamento = uso correto de métodos e modificadores de acesso
    public class BancoDeDadosEmMemoria : BancoDeDados
    {
        //não usar em memória e usar arquivos ou bancos de dados
        private static List<Funcionario> funcionariosCadastros = new List<Funcionario>();

        public override void Salvar(Funcionario funcionario)
        {
            bool funcionarioJaExisteNaListaDeCadastrados = false;

            //algoritmo para dizer se já existe na lista ou não
            foreach (var func in funcionariosCadastros)
            {
                if (func == funcionario)
                {
                    funcionarioJaExisteNaListaDeCadastrados = true;
                }
            }

            //executar essa linha somente se o funcionario não existe na lista de cadastrados
            if (funcionarioJaExisteNaListaDeCadastrados == false)
            {
                funcionariosCadastros.Add(funcionario);
            }
        }

        public override IEnumerable<Funcionario> BuscarTodosOsFuncionarios()
        {
            return funcionariosCadastros;
        }

        public override IEnumerable<Funcionario> BuscarTodosOsFuncionarios(string nome)
        {
            //dica: nas consultas retornas ienumerable
            return funcionariosCadastros
                   .Where(funcionario => funcionario.Nome.Contains(nome, StringComparison.InvariantCultureIgnoreCase));
        }

        public override IEnumerable<Funcionario> BuscarTodosOsFuncionarios(DateTime dataDeCadastro)
        {
            return funcionariosCadastros
                   .Where(funcionario => funcionario.DataDeCadastro.Date == dataDeCadastro);
        }

        public override Funcionario BuscarFuncionarioPelo(string cpf)
        {
            return funcionariosCadastros.Find(funcionario => funcionario.Cpf == cpf);
        }

        //método é definido pela assinatura
        //assinatura do método = tipo de retorno + nome do método + lista de parâmetros
        public override void Excluir(Funcionario funcionario)
        {
            funcionariosCadastros.Remove(funcionario);
        }
    }
}
