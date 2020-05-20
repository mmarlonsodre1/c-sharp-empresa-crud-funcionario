using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Principal;
using Empresa.Model;

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
            throw new NotImplementedException();
        }

        public override IEnumerable<Funcionario> BuscarTodosOsFuncionarios(DateTime dataDeCadastro)
        {
            throw new NotImplementedException();
        }

        public override Funcionario BuscarFuncionarioPelo(string cpf)
        {
            var funcionarios = this.BuscarTodosOsFuncionarios();
           
            foreach(Funcionario funcionario in funcionarios)
            {
                if (funcionario.Cpf == cpf)
                    return funcionario;
            }

            return null;
        }

        protected override void CriarNovo(Funcionario funcionario)
        {
            string nomeDoArquivo = ObterNomeArquivo();

            string formato = $"{funcionario.Cpf},{funcionario.Nome},{funcionario.DataDeCadastro.ToString()};";

            File.AppendAllText(nomeDoArquivo, formato);
        }

        protected override void AlterarExistente(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }
    }
}
