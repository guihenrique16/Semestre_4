using System;
using System.Collections.Generic;
using System.Linq;

namespace AdicionarJogo
{
    public class Jogo
    {
        public string? Nome { get; set; }
        public int Quantidade { get; set; }
    }

    public static class ControleDeJogos
    {
        private static List<Jogo> listaDeJogos = new List<Jogo>();

        public static string AdicionarJogo(Jogo jogo)
        {
            Jogo jogoA = new Jogo();
            jogoA.Nome = "fifa";

            listaDeJogos.Add(jogoA);
            var produtoExistente = listaDeJogos.FirstOrDefault(p => p.Nome == produto.Nome);

            if (produtoExistente != null)
            {
                produtoExistente.Quantidade += jogo.Quantidade;
                return "A quantidade foi incrementada";
            }
            else
            {

                listaDeJogos.Add(jogo);

                return "cadastrado com sucesso";
            }
        }
    }
}
