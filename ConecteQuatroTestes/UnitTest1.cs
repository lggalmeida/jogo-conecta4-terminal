using ConecteQuatro;

namespace ConecteQuatroTestes {
    [TestClass]
    public class TabuleiroTests {
        [TestMethod]
        public void InserirPeca_DeveAdicionarPecaNaColunaCorreta() {
            var tabuleiro = new Tabuleiro();
            var peca = new Peca('X');
            bool resultado = tabuleiro.SoltarPeca(0, peca.Simbolo);
            Assert.IsTrue(resultado);
            Assert.AreEqual('X', tabuleiro.ObterPeca(5, 0));
        }

        [TestMethod]
        public void VerificarVitoriaHorizontal_DeveRetornarTrue() {
            var tabuleiro = new Tabuleiro();
            var peca = new Peca('O');
            for (int i = 0; i < 4; i++) {
                // Simular uma horizontal (-)
                tabuleiro.SoltarPeca(i, peca.Simbolo); 
            }
            bool vitoria = tabuleiro.VerificarVencedor(peca.Simbolo);
            Assert.IsTrue(vitoria);
        }

        [TestMethod]
        public void VerificarVitoriaVertical_DeveRetornarTrue() {
            var tabuleiro = new Tabuleiro();
            var peca = new Peca('X');
            for (int i = 0; i < 4; i++) {
                // Simular uma vertical (|)
                tabuleiro.SoltarPeca(0, peca.Simbolo); 
            }
            bool vitoria = tabuleiro.VerificarVencedor(peca.Simbolo);
            Assert.IsTrue(vitoria);
        }

        [TestMethod]
        public void VerificarVitoriaDiagonal_DeveRetornarTrue() {
            var tabuleiro = new Tabuleiro();
            var pecaO = new Peca('O');
            var pecaX = new Peca('X');
            // Simular uma diagonal (\)
            tabuleiro.SoltarPeca(0, pecaO.Simbolo);
            tabuleiro.SoltarPeca(1, pecaX.Simbolo);
            tabuleiro.SoltarPeca(1, pecaO.Simbolo);
            tabuleiro.SoltarPeca(2, pecaX.Simbolo);
            tabuleiro.SoltarPeca(2, pecaX.Simbolo);
            tabuleiro.SoltarPeca(2, pecaO.Simbolo);
            tabuleiro.SoltarPeca(3, pecaX.Simbolo);
            tabuleiro.SoltarPeca(3, pecaX.Simbolo);
            tabuleiro.SoltarPeca(3, pecaX.Simbolo);
            tabuleiro.SoltarPeca(3, pecaO.Simbolo);
            bool vitoria = tabuleiro.VerificarVencedor(pecaO.Simbolo);
            Assert.IsTrue(vitoria);
        }
    }
}