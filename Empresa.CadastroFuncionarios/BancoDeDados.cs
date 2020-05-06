using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Empresa.CadastroFuncionarios
{
    //abstração = utilizar classes, na maioria das vezes
    //encapsulamento = uso correto de métodos e modificadores de acesso
    class BancoDeDados
    {
        //não usar em memória e usar arquivos ou bancos de dados
        private static List<Funcionario> funcionariosCadastros = new List<Funcionario>();
        
        public static void Salvar(Funcionario funcionario)
        {
            bool funcionarioJaExiste = false;

            foreach (var funcionarioNaLista in funcionariosCadastros)
            {
                if (funcionarioNaLista == funcionario)
                {
                    funcionarioJaExiste = true; 
                    break;
                }
            }

            if (funcionarioJaExiste == false)
            {
                funcionariosCadastros.Add(funcionario);
            }

            //var dadosDosFuncionarios = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\funcionarios.txt";
            //File.AppendAllText(dadosDosFuncionarios, funcionario.Nome);
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

        public static Funcionario BuscarFuncionarioPelo(string cpf)
        {
            return funcionariosCadastros.Find(funcionario => funcionario.Cpf == cpf);
        }

        //método é definido pela assinatura
        //assinatura do método = tipo de retorno + nome do método + lista de parâmetros
        public static void Excluir(Funcionario funcionario)
        {
            funcionariosCadastros.Remove(funcionario);
        }
    }
}
