namespace ConecteQuatro {
    public class Tabuleiro {
        private const int Linhas = 6;
        private const int Colunas = 7;
        private char[,] grade;

        public Tabuleiro() {
            grade = new char[Linhas, Colunas];
            for (int i = 0; i < Linhas; i++)
                for (int j = 0; j < Colunas; j++)
                    grade[i, j] = ' ';
        }

        public bool SoltarPeca(int coluna, char simbolo) {
            for (int linha = Linhas - 1; linha >= 0; linha--) {
                if (grade[linha, coluna] == ' ') {
                    grade[linha, coluna] = simbolo;
                    return true;
                }
            }
            return false; // Coluna cheia
        }

        public void Exibir() {
            Console.Clear();
            for (int i = 0; i < Linhas; i++) {
                for (int j = 0; j < Colunas; j++) {
                    Console.Write($"| {grade[i, j]} ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("  0   1   2   3   4   5   6");
        }

        public bool VerificarVencedor(char simbolo) {
            // Verificar Linhas, Colunas e Diagonais
            for (int linha = 0; linha < Linhas; linha++) {
                for (int coluna = 0; coluna < Colunas; coluna++) {
                    if (coluna + 3 < Colunas &&                       // ( - )
                        grade[linha, coluna] == simbolo &&
                        grade[linha, coluna + 1] == simbolo &&
                        grade[linha, coluna + 2] == simbolo &&
                        grade[linha, coluna + 3] == simbolo) {
                        return true;
                    }

                    if (linha + 3 < Linhas &&                         // ( | )
                        grade[linha, coluna] == simbolo && 
                        grade[linha + 1, coluna] == simbolo &&
                        grade[linha + 2, coluna] == simbolo &&
                        grade[linha + 3, coluna] == simbolo) {
                        return true;
                    }

                    if (linha + 3 < Linhas && coluna + 3 < Colunas && // ( \ )
                        grade[linha, coluna] == simbolo &&
                        grade[linha + 1, coluna + 1] == simbolo &&
                        grade[linha + 2, coluna + 2] == simbolo &&
                        grade[linha + 3, coluna + 3] == simbolo) {
                        return true;
                    }

                    if (linha + 3 < Linhas && coluna - 3 >= 0 &&      // ( / )
                        grade[linha, coluna] == simbolo &&
                        grade[linha + 1, coluna - 1] == simbolo &&
                        grade[linha + 2, coluna - 2] == simbolo &&
                        grade[linha + 3, coluna - 3] == simbolo) {
                        return true;
                    }
                        
                }
            }
            return false;
        }
        public char ObterPeca(int linha, int coluna) {
            return grade[linha, coluna]; 
        }
    }
}
