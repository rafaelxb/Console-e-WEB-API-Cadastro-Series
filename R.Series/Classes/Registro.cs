using System;

namespace R.Series
{
    public class Registro : EntidadeBase
    {
        private Tipo tipo;
        private Genero genero;

        //Atributos
        private Tipo Tipo {get;set;}
        private Genero Genero {get; set;}
        private string Titulo {get; set;}
        private string Descricao {get; set;}
        private int Ano {get; set;}
        private decimal Nota {get; set;}
        private bool Excluido {get; set;}

        //Métodos 

		public Registro(int id, Tipo tipo, Genero genero, string titulo, string descricao, int ano, decimal nota)
		{
			this.Id = id;
            this.Tipo = tipo;
			this.Genero = genero;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Ano = ano;
            this.Nota = nota;
            this.Excluido = false;
		}

        public Registro(int id, Tipo tipo, Genero genero, string titulo, int ano, decimal nota)
        {
            Id = id;
            this.tipo = tipo;
            this.genero = genero;
            Titulo = titulo;
            Ano = ano;
            Nota = nota;
        }

        public override string ToString()
        {
            /*Modifica o retorno do ToString. 
            O environment.newline ajuda a colocar 
            a quebra de linha independente do SO.
            Link que explica o funcionamento do Environment.NewLine
            https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1*/

            string retorno = "";
            retorno += "Tipo: " + this.Tipo + Environment.NewLine;
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Nota: " + this.Nota + Environment.NewLine;
            retorno += "Excluído: " + this.Excluido + Environment.NewLine;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        public Tipo retornaTipo()
        {
            return this.Tipo;
        }

        public Genero retornaGenero()
        {
            return this.Genero;
        }

        public string retornaDescricao()
        {
            return this.Descricao;
        }

        public int retornaAno()
        {
            return this.Ano;
        }

        public decimal retornaNota()
        {
            return this.Nota;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    
    }



}