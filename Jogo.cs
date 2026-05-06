namespace Jogo_da_Velha
{
    public class Jogo
    {
        private Jogador? jogador1, jogador2, jogadorAtual;
        private Tabuleiro? tabu;
        private int empates = 0;
        private bool rodada;

        // Método que Inicia o Jogo:
        public void Iniciar()
        {
            MenuInicial.ExibirMenu();

            string nome1 = SolicitarNomes(1);
            jogador1 = new Jogador(nome1, "X");
            string nome2 = SolicitarNomes(2);
            jogador2 = new Jogador(nome2, "O");

            bool repetirjogo = true;

            while (repetirjogo)
            {
                rodada = true;
                tabu = new Tabuleiro();
                jogadorAtual = jogador1;

                while (rodada)
                {
                    Console.Clear();
                    tabu.ExibirTabuleiro();
                    Pontuacao();

                    EscolhaDoJogador();
                    VerificarFimDeJogo();
                }

                Console.SetCursorPosition(1, 18);
                Console.Write("Deseja jogar Novamente?\n (Se sim, pressione S): ");
                string resposta = Console.ReadLine()!.ToUpper().Trim();

                if (resposta != "S") repetirjogo = false;
            }
        }


        // Método de Inscrição do Jogo:
        private static string SolicitarNomes(int numero)
        {
            while (true)
            {
                Console.SetCursorPosition(1, 17);
                Console.Write($"Jogador {numero}, insira o seu Nome: ");
                string nome = Console.ReadLine()!;
                Console.Clear();

                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.SetCursorPosition(1, 18);
                    Console.WriteLine($"O nome do Jogador não pode estar Vazio!");
                    continue;
                }
                return nome;
            }
        }


        // Métodos de Controle do Jogo:
        private void EscolhaDoJogador()
        {
            while (true)
            {
                Console.SetCursorPosition(1, 1);
                Console.Write($"{jogadorAtual!.GetNome()} ({jogadorAtual.GetSimbolo()}), informe a Posição: ");
                string entrada = Console.ReadLine()!;
                Console.Clear();
                tabu!.ExibirTabuleiro();
                Pontuacao();

                if (ValidaOpcao(entrada))
                {
                    AtualizarPosicao(entrada, jogadorAtual.GetSimbolo());
                    break;
                }
                else
                {
                    Console.SetCursorPosition(1, 2);
                    Console.WriteLine("Posição Inválida ou já Ocupada!");
                }
            }
        }
        private void TrocarJogador()
        {
            if (jogadorAtual == jogador1) jogadorAtual = jogador2;
            else jogadorAtual = jogador1;
        }
        private bool ValidaOpcao(string escolha)
        {
            string[] t = tabu!.GetTabuleiro();

            for (int i = 0; i < 9; i++)
            {
                if (t[i] == escolha && escolha != "X" && escolha != "O") return true;
            }
            return false;
        }
        private void AtualizarPosicao(string escolha, string simbolo)
        {
            string[] t = tabu!.GetTabuleiro();

            for (int i = 0; i < 9; i++)
            {
                if (t[i] == escolha)
                {
                    t[i] = simbolo;
                    break;
                }
            }
        }


        // Métodos de Progressão do Jogo:
        private void VerificarFimDeJogo()
        {
            if (VerificarVitoria())
            {
                Console.Clear();
                tabu!.ExibirTabuleiro();
                jogadorAtual!.AdicionarPonto();
                Console.SetCursorPosition(1, 17);
                Console.WriteLine($"Parabéns! {jogadorAtual.GetNome()} venceu!");
                rodada = false;
            }
            else if (VerificarEmpate())
            {
                Console.Clear();
                tabu!.ExibirTabuleiro();
                Console.SetCursorPosition(1, 17);
                Console.WriteLine("O jogo empatou (Velha)!");
                empates++;
                rodada = false;
            }
            else
            {
                TrocarJogador();
            }
        }
        private bool VerificarVitoria()
        {
            string[] t = tabu!.GetTabuleiro();

            if (t[0] == t[1] && t[1] == t[2]) return true;
            if (t[3] == t[4] && t[4] == t[5]) return true;
            if (t[6] == t[7] && t[7] == t[8]) return true;
            if (t[0] == t[3] && t[3] == t[6]) return true;
            if (t[1] == t[4] && t[4] == t[7]) return true;
            if (t[2] == t[5] && t[5] == t[8]) return true;
            if (t[0] == t[4] && t[4] == t[8]) return true;
            if (t[2] == t[4] && t[4] == t[6]) return true;

            return false;
        }
        private bool VerificarEmpate()
        {
            foreach (string p in tabu!.GetTabuleiro())
            {
                if (p != "X" && p != "O") return false;
            }
            return true;
        }
        private void Pontuacao()
        {
            Console.SetCursorPosition(1, 17);
            Console.Write($"{jogador1!.GetNome()}: {jogador1.GetPontos()}");
            Console.SetCursorPosition(1, 18);
            Console.Write($"{jogador2!.GetNome()}: {jogador2.GetPontos()}");
            Console.SetCursorPosition(1, 19);
            Console.Write($"Empates: {empates}");
            Console.WriteLine();
        }
    }
}