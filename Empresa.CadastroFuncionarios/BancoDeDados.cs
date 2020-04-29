using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Empresa.CadastroFuncionarios
{
    //abstração = utilizar classes, na maioria das vezes
    //encapsulamento = uso correto de métodos e modificadores de acesso
    class BancoDeDados
    {
        private static List<Funcionario> funcionariosCadastros = new List<Funcionario>();
        //não usar em memória e usar arquivos ou bancos de dados

        public static void Salvar(Funcionario funcionario)
        {
            funcionariosCadastros.Add(funcionario);
        }

        public static IEnumerable<Funcionario> BuscarTodosOsFuncionarios()
        {
            return funcionariosCadastros;
        }

        public static IEnumerable<Funcionario> BuscarTodosOsFuncionarios(string nome)
        {
            //dica: nas consultas retornas ienumerable
            return funcionariosCadastros
                   .Where(funcionario => funcionario.Nome.Contains(nome, StringComparison.InvariantCultureIgnoreCase));
        }

        public static IEnumerable<Funcionario> BuscarTodosOsFuncionarios(DateTime dataDeCadastro)
        {
            return funcionariosCadastros
                   .Where(funcionario => funcionario.DataDeCadastro.Date == dataDeCadastro);
        }

        //método é definido pela assinatura
        //assinatura do método = tipo de retorno + nome do método + lista de parâmetros
    }
}
