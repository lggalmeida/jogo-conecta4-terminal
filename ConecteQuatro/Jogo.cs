namespace ConecteQuatro {
    public class Jogo {
        private Tabuleiro tabuleiro;
        private Jogador jogador1;
        private Jogador jogador2;
        private Jogador jogadorAtual;

        public Jogo() {
            Console.Write("Nome do Jogador 1: ");
            string nome1 = Console.ReadLine();
            Console.Write("Nome do Jogador 2: ");
            string nome2 = Console.ReadLine();

            jogador1 = new Jogador(nome1, 'X');
            jogador2 = new Jogador(nome2, 'O');
            jogadorAtual = jogador1;

            tabuleiro = new Tabuleiro();
        }

        public void Iniciar() {
            bool venceu = false;
            int rodadas = 0;

            while (!venceu && rodadas < 42) {
                tabuleiro.Exibir();
                Console.WriteLine($"{jogadorAtual.Nome}, escolha uma coluna (0-6): ");

                if (int.TryParse(Console.ReadLine(), out int coluna) && coluna >= 0 && coluna < 7) {
                    if (tabuleiro.SoltarPeca(coluna, jogadorAtual.Peca.Simbolo)) {
                        rodadas++;
                        venceu = tabuleiro.VerificarVencedor(jogadorAtual.Peca.Simbolo);

                        if (!venceu)
                            jogadorAtual = (jogadorAtual == jogador1) ? jogador2 : jogador1;
                    }
                    else {
                        Console.WriteLine("Coluna cheia! Escolha outra.");
                        Console.ReadKey();
                    }
                }
                else {
                    Console.WriteLine("Entrada inválida! Digite um número entre 0 e 6.");
                    Console.ReadKey();
                }
            }

            tabuleiro.Exibir();
            if (venceu)
                Console.WriteLine($"Parabéns {jogadorAtual.Nome}, você venceu!");
            else
                Console.WriteLine("Empate! O tabuleiro está cheio.");
        }
    }
}
