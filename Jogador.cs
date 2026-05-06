namespace Jogo_da_Velha
{
    public class Jogador (string nome, string simbolo)
    {
        private readonly string nome = nome;
        private readonly string simbolo = simbolo;
        private int pontos = 0;

        public void AdicionarPonto()
        {
            this.pontos++;
        }
        public string GetNome()
        {
            return nome;
        }
        public string GetSimbolo()
        {
            return simbolo;
        }
        public int GetPontos()
        {
            return pontos;
        }
    }
}