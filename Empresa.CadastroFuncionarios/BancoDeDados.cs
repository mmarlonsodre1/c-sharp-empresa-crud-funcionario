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

                //para trabalhar com arquivos

                //abrir o arquivo
                //escrever no arquivo
                //dar nome ao arquivo
                //salvar
                //fechar

                string nome = funcionario.Nome;
                string cpf = funcionario.Cpf;
                string dataCadastro = funcionario.DataDeCadastro.ToString();

                //salvar funcionarios em arquivos 
                var pastaDesktop = Environment.SpecialFolder.Desktop;

                var localDaPastaDesktop = Environment.GetFolderPath(pastaDesktop);

                var nomeDoArquivo = @"\dadosDosFuncionarios.txt";

                File.AppendAllText(localDaPastaDesktop + nomeDoArquivo, nome);
            }
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
