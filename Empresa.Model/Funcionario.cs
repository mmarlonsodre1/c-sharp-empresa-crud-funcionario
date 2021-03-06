﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Empresa.Model
{
    //int, float, decimal para numeros
    //string para textos
    //char represente 1 caracter
    //DateTime para datas
    //conjunto de dados [] é um array
    //conjunto de dados List é um tipo de array

    //Quando não existe um tipo de valor equivalente, vamos criar uma classe (abstração)
    //classe é uma estrutura para criar objetos
    public class Funcionario
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeCadastro { get; private set; }
        public DateTime DataDeNascimento { get; set; }

        public Funcionario()
        {
            DataDeCadastro = DateTime.Now;
        }

        public Funcionario(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
            DataDeCadastro = DateTime.Now;
        }

        public Funcionario(string nome, string cpf, DateTime dataDeCadastro)
        {
            Nome = nome;
            Cpf = cpf;
            DataDeCadastro = dataDeCadastro;
        }

        public int ObterDiasRestantesParaAniversario()
        {
            return 0;
        }
    }
}
