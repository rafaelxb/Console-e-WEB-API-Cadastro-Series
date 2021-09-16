using System;
using System.Collections.Generic;
using R.Series.Interfaces;

namespace R.Series
{
    public class RegistroRepositorio : IRepositorio<Registro>
    {
        private List<Registro> listaRegistro = new List<Registro>();
        
        public void Atualiza(int id, Registro objeto)
		{
			listaRegistro[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaRegistro[id].Excluir();
		}

		public void Insere(Registro objeto)
		{
			listaRegistro.Add(objeto);
		}

		public List<Registro> Lista()
		{
			return listaRegistro;
		}

		public int ProximoId()
		{
			return listaRegistro.Count;
		}

		public Registro RetornaPorId(int id)
		{
			return listaRegistro[id];
		}
    }
}