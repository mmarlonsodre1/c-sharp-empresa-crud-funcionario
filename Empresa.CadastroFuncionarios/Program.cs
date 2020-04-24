using System;
using System.Collections.Generic;

namespace Empresa.CadastroFuncionarios
{
    class Program
    {
        static List<Funcionario> funcionarios = new List<Funcionario>();

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

            funcionarios.Add(funcionario);

            MenuPrincipal();
        }

        private static void LimparTela()
        {
            Console.Clear();
        }

        static void ConsultarFuncionario()
        {
            Console.Clear();
            //listar tudo
            //primeiros vou listar tudo
            //para cada func (string) in funcionarios(list<string>)
            foreach (var funcionario in funcionarios)
            {
                EscreverNaTela($"Nome: {funcionario.Nome} Cpf: {funcionario.Cpf} Cadastrado em: {funcionario.DataDeCadastro}");
            }

            ExibirOpcoesDeFiltro();
        }

        static void ExibirOpcoesDeFiltro()
        {
            EscreverNaTela("Escolha uma opção de filtro");
            EscreverNaTela("1 - Consultar pelo nome");
            //IMPLEMENTAR A CONSULTA PELO NOME
            EscreverNaTela("2 - Data de cadastro");
            //IMPLEMENTAR CONSULTA PELA DATA DE CADASTRO (OBS: PODE RETORNAR MAIS DE UM FUNCIONÁRIO)
            //PARA QUEM TÁ AVANÇADO: FAÇA FUNCIONAR COM TESTES.

            //MenuPrincipal();
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
