using System;
using System.Linq;
using System.Collections.Generic;

namespace Empresa.CadastroFuncionarios
{
    class Program
    {
        static List<Funcionario> funcionariosCadastros = new List<Funcionario>();

        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        static void MenuPrincipal()
        {
            EscreverNaTela("Menu do sistema:");
            EscreverNaTela("Selecione uma operação");
            EscreverNaTela("1 - Cadastrar funcionário");
            EscreverNaTela("2 - Consultar funcionário");
            EscreverNaTela("3 - Alterar dados do funcionário");
            EscreverNaTela("4 - Excluir funcionário");
            EscreverNaTela("5 - Sair");

            char operacao = Console.ReadLine().ToCharArray()[0];

            if (operacao == '1')
            {
                CadastrarFuncionario();
            }
            if (operacao == '2')
            {
                ConsultarFuncionario();
            }
        }
                                                //Menu do sistema:
        private static void EscreverNaTela(string texto)
        {
            Console.WriteLine(texto);
        }

        static void CadastrarFuncionario()
        {
            LimparTela(); //Limpar o console

            EscreverNaTela("Entre com o Nome:");
            string nome = Console.ReadLine(); //armazenar numa variável o nome do funcionário

            EscreverNaTela("Entre com o CPF:"); //pedir cpf
            string cpf = Console.ReadLine(); //armazenar cpf

            DateTime dataDeCadastro = DateTime.Now; //armazenar data de cadastro
            
            Funcionario funcionario = new Funcionario();
            funcionario.Cpf = cpf;
            funcionario.Nome = nome;
            funcionario.DataDeCadastro = dataDeCadastro;

            funcionariosCadastros.Add(funcionario);

            MenuPrincipal();
        }

        private static void LimparTela()
        {
            Console.Clear();
        }

        static void ConsultarFuncionario()
        {
            Console.Clear();
            
            foreach (var funcionario in funcionariosCadastros)
            {
                EscreverNaTela($"Nome: {funcionario.Nome} Cpf: {funcionario.Cpf} Cadastrado em: {funcionario.DataDeCadastro}");
            }

            ExibirOpcoesDeFiltro();
        }

        static void ExibirOpcoesDeFiltro()
        {
            EscreverNaTela("Escolha uma opção de filtro");
            EscreverNaTela("1 - Consultar pelo nome");
            EscreverNaTela("2 - Data de cadastro");
            string tipoDeConsulta = Console.ReadLine();

            switch (tipoDeConsulta)
            {
                case "1": 
                    ConsultarPeloNome(); 
                    break;

                case "2": 
                    ConsultarPelaData(); 
                    break;

                default: 
                    EscreverNaTela("Consulta incorreta");
                    ExibirOpcoesDeFiltro();
                    break;
            }
        }

        static void ConsultarPeloNome()
        {
            EscreverNaTela("Entre com o nome da pessoa");
            string nome = Console.ReadLine();

            var funcionariosEncontrados = funcionariosCadastros.Where(funcionario => funcionario.Nome.Contains(nome, StringComparison.InvariantCultureIgnoreCase));

            int quantidadeDefuncionariosEncontrados = funcionariosEncontrados.Count();

            if (quantidadeDefuncionariosEncontrados > 0)
            { 
                EscreverNaTela("Funcionários contrados");

                foreach (var funcionario in funcionariosEncontrados)
                {
                    Console.WriteLine(funcionario.Nome);
                }
            }
            else
            {
                EscreverNaTela("Nenhum funcionário encontrado para o nome: " + nome);
            }
            
            MenuPrincipal();
        }

        static void ConsultarPelaData()
        {
            Console.WriteLine("Entre com a data");

            var dataDeCadastro = DateTime.Parse(Console.ReadLine());

            var funcionarioFiltradosPelaDataDeCadastro = funcionariosCadastros.Where(funcionario => funcionario.DataDeCadastro.Date == dataDeCadastro);

            EscreverNaTela("Funcionários contrados");

            foreach (var funcionario in funcionarioFiltradosPelaDataDeCadastro)
            {
                Console.WriteLine(funcionario.Nome);
            }

            MenuPrincipal();
        }

        //int, float, decimal para numeros
        //string para textos
        //Cpf cpf
        //char represente 1 caracter
        //DateTime para datas
        //conjunto de dados [] é um array
        //conjunto de dados List é um tipo de array

        //Quando não existe um tipo de valor equivalente, vamos criar uma classe (abstração)
        public class Funcionario
        {
            public string Nome { get; set; }
            public string Cpf { get; set; }
            public DateTime DataDeCadastro { get; set; }
        } 
    }
}
