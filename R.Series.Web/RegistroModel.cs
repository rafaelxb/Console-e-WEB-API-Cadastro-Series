using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace R.Series.Web
{
    public class RegistroModel
    {
        public int Id { get; set; }
        public Tipo Tipo { get; set; }
        public Genero Genero { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        public decimal Nota { get; set; }
        public bool Excluido { get; set; }

        public RegistroModel() {}

        public RegistroModel(Registro registro)
        {
            Id = registro.retornaId();
            Tipo = registro.retornaTipo();
            Genero = registro.retornaGenero();
            Titulo = registro.retornaTitulo();
            Ano = registro.retornaAno();
            Nota = registro.retornaNota();
            Excluido = registro.retornaExcluido();
        }

        public Registro ToRegistro()
        {
            return new Registro(Id, Tipo, Genero, Titulo, Ano, Nota);
        }

    }
}
