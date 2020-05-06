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
            EscreverNaTela("3 - Alterar dados do funcionário");
            EscreverNaTela("4 - Excluir funcionário");
            EscreverNaTela("5 - Sair");

            char operacao = Console.ReadLine().ToCharArray()[0];

            switch (operacao)
            {
                case '1': CadastrarFuncionario(); break;
                case '2': ConsultarFuncionario(); break;
                case '3': AlterarFuncionario(); break;
                case '4': ExcluirFuncionario(); break;
                default: EscreverNaTela("Opção inexistente"); break;
            }
        }

        private static void CadastrarFuncionario()
        {
            LimparTela();

            EscreverNaTela("Entre com o Nome:");
            string nome = Console.ReadLine(); //armazenar numa variável o nome do funcionário

            EscreverNaTela("Entre com o CPF:"); //pedir cpf
            string cpf = Console.ReadLine(); //armazenar cpf

            var funcionario = new Funcionario(nome, cpf);

            BancoDeDados.Salvar(funcionario);

            EscreverNaTela("Cadastrado com sucesso!");
            EscreverNaTela("Pressione qualquer tecla para continuar");
            Console.ReadKey();
            LimparTela();

            MenuPrincipal();
        }

        private static void LimparTela() //Limpar o console
        {
            Console.Clear();
        }

        private static void ConsultarFuncionario()
        {
            LimparTela();

            ExibirOpcoesDeFiltro();

        }

        private static void ExibirOpcoesDeFiltro()
        {
            EscreverNaTela("Escolha uma opção de filtro");
            EscreverNaTela("1 - Consultar pelo nome");
            EscreverNaTela("2 - Consultar pela data de cadastro");
            EscreverNaTela("3 - Exibir todos os funcionários");
            string tipoDeConsulta = Console.ReadLine();

            switch (tipoDeConsulta)
            {
                case "1":
                    ConsultarPeloNome();
                    break;

                case "2":
                    ConsultarPelaData();
                    break;

                case "3":
                    ExibirTodosOsFuncionarios();
                    break;

                default:
                    EscreverNaTela("Consulta incorreta");
                    ExibirOpcoesDeFiltro();
                    break;
            }
        }

        private static void ConsultarPeloNome()
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

        private static void ConsultarPelaData()
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

        private static void ExibirTodosOsFuncionarios()
        {
            foreach (var funcionario in BancoDeDados.BuscarTodosOsFuncionarios())
            {
                EscreverNaTela($"Nome: {funcionario.Nome} Cpf: {funcionario.Cpf} Cadastrado em: {funcionario.DataDeCadastro}");
            }

            EscreverNaTela("Pressione qualquer tecla para continuar");
            Console.ReadKey();
            LimparTela();
            MenuPrincipal();
        }

        //toda vez que é omitido o modificador de acesso, então ele assume como private
        private static void AlterarFuncionario()
        {
            LimparTela();

            //primeiro identificar o funcionário
            EscreverNaTela("Entre com o CPF do funcionário:");
            string cpf = Console.ReadLine();

            //buscar o funcionário pelo identificador
            var funcionario = BancoDeDados.BuscarFuncionarioPelo(cpf);

            if (funcionario == null)
            {
                EscreverNaTela("CPF digitado incorretamente ou funcionário não encontrado");
                EscreverNaTela("Pressione qualquer tecla para continuar");
                Console.ReadKey();
                MenuPrincipal();
            }

            //alterar os dados
            EscreverNaTela("Entre com o novo nome:");
            string novoNome = Console.ReadLine();
            funcionario.Nome = novoNome;

            //salvar funcionário
            BancoDeDados.Salvar(funcionario);

            MenuPrincipal();
        }

        private static void ExcluirFuncionario()
        {
            LimparTela();

            //primeiro identificar o funcionário
            EscreverNaTela("Entre com o CPF do funcionário:");
            string cpf = Console.ReadLine();

            //buscar o funcionário pelo identificador
            var funcionario = BancoDeDados.BuscarFuncionarioPelo(cpf);

            if (funcionario == null)
            {
                EscreverNaTela("CPF digitado incorretamente ou funcionário não encontrado");
                EscreverNaTela("Pressione qualquer tecla para continuar");
                Console.ReadKey();
                MenuPrincipal();
            }

            BancoDeDados.Excluir(funcionario);

            MenuPrincipal();
        }
    }
}
