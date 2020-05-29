using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Principal;
using Empresa.Model;
using System.Linq;

namespace Empresa.Dados
{
    public class RepositorioDeFuncionariosDeArquivos : RepositorioDeFuncionarios
    {
        public override IEnumerable<Funcionario> BuscarTodosOsFuncionarios()
        {
            string nomeDoArquivo = ObterNomeArquivo();

            FileStream arquivo;
            if (!File.Exists(nomeDoArquivo))
            {
                arquivo = File.Create(nomeDoArquivo);
                arquivo.Close();
            }

            string resultado = File.ReadAllText(nomeDoArquivo);

            //identificar cada funcionario
            string[] funcionarios = resultado.Split(';');

            List<Funcionario> funcionariosList = new List<Funcionario>();

            for (int i = 0; i < funcionarios.Length - 1; i++)
            {
                string[] dadosDoFuncionario = funcionarios[i].Split(',');

                //identificar cada dado do funcionário
                string cpf = dadosDoFuncionario[0];
                string nome = dadosDoFuncionario[1];
                DateTime dataDeCadastro = Convert.ToDateTime(dadosDoFuncionario[2]);

                //preencher a classe funcionario com esses dados
                Funcionario funcionario = new Funcionario(nome, cpf, dataDeCadastro);

                //adicionar em uma lista esse funcionario
                funcionariosList.Add(funcionario);
            }

            //retornar a lista
            return funcionariosList;
        }

        private static string ObterNomeArquivo()
        {
            var pastaDesktop = Environment.SpecialFolder.Desktop;

            string localDaPastaDesktop = Environment.GetFolderPath(pastaDesktop);
            string nomeDoArquivo = @"\dadosDosFuncionarios.txt";

            return localDaPastaDesktop + nomeDoArquivo;
        }

        public override void Excluir(Funcionario funcionario)
        {

        }

        public override IEnumerable<Funcionario> BuscarTodosOsFuncionarios(string nome)
        {

            //SEE: https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/concepts/linq/
            return (from x in BuscarTodosOsFuncionarios()
                    where x.Nome.Contains(nome)
                    orderby x.Nome
                    select x);
        }

        public override IEnumerable<Funcionario> BuscarTodosOsFuncionarios(DateTime dataDeCadastro)
        {
            throw new NotImplementedException();
        }

        public override Funcionario BuscarFuncionarioPelo(string cpf)
        {
            //SEE: https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/concepts/linq/
            return (from x in BuscarTodosOsFuncionarios()
                    where x.Cpf == cpf
                    select x).FirstOrDefault();
        }
    

        protected override void CriarNovo(Funcionario funcionario)
        {
            string nomeDoArquivo = ObterNomeArquivo();

            string formato = $"{funcionario.Cpf},{funcionario.Nome},{funcionario.DataDeCadastro.ToString()};";

            File.AppendAllText(nomeDoArquivo, formato);
        }

        protected override void AlterarExistente(Funcionario funcionario)
        {
            //codificar a alteração

        }
    }
}
