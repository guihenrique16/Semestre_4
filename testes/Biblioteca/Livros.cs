using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public static class Livros
    {
        static List<string> livros = new List<string>();

        public static string AdicionarLivro(string titulo)
        {
            livros.Add(titulo);
            return titulo;
        }

        //public static List<string> ObterTodosOsLivros()
        //{
        //    return new List<string>(livros); // Retorna uma cópia da lista para evitar modificação externa
        //}

    }
}
