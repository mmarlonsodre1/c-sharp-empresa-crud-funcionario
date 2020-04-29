using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Empresa.CadastroFuncionarios
{
    class Apresentacao
    {
        private static void EscreverNaTela(string texto)
        {
            Console.WriteLine(texto);
        }

        public static void MenuPrincipal()
        {
            EscreverNaTela("Menu do sistema:");
            EscreverNaTela("Selecione uma operação");
            EscreverNaTela("1 - Cadastrar funcionário");
            EscreverNaTela("2 - Consultar funcionário");
            EscreverNaTela("3 - Alterar dados do funcionário"); //Fazer
            EscreverNaTela("4 - Excluir funcionário"); //Fazer
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

        static void CadastrarFuncionario()
        {
            LimparTela();

            EscreverNaTela("Entre com o Nome:");
            string nome = Console.ReadLine(); //armazenar numa variável o nome do funcionário

            EscreverNaTela("Entre com o CPF:"); //pedir cpf
            string cpf = Console.ReadLine(); //armazenar cpf

            DateTime dataDeCadastro = DateTime.Now; //armazenar data de cadastro

            Funcionario funcionario = new Funcionario();
            funcionario.Cpf = cpf;
            funcionario.Nome = nome;
            funcionario.DataDeCadastro = dataDeCadastro;

            BancoDeDados.Salvar(funcionario);

            MenuPrincipal();
        }

        private static void LimparTela() //Limpar o console
        {
            Console.Clear();
        }

        static void ConsultarFuncionario()
        {
            Console.Clear();

            foreach (var funcionario in BancoDeDados.BuscarTodosOsFuncionarios())
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

            var funcionariosEncontrados = BancoDeDados.BuscarTodosOsFuncionarios(nome);

            int quantidadeDefuncionariosEncontrados = funcionariosEncontrados.Count();

            if (quantidadeDefuncionariosEncontrados > 0)
            {
                EscreverNaTela("Funcionários contrados");

                foreach (var funcionario in funcionariosEncontrados)
                {
                    EscreverNaTela(funcionario.Nome);
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
            EscreverNaTela("Entre com a data");

            var dataDeCadastro = DateTime.Parse(Console.ReadLine());

            var funcionarioFiltradosPelaDataDeCadastro = BancoDeDados.BuscarTodosOsFuncionarios(dataDeCadastro);

            EscreverNaTela("Funcionários contrados");

            foreach (var funcionario in funcionarioFiltradosPelaDataDeCadastro)
            {
                EscreverNaTela(funcionario.Nome);
            }

            MenuPrincipal();
        }
    }
}
