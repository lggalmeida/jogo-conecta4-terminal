namespace ConecteQuatro {
    public class Jogador {
        public string Nome { get; }
        public Peca Peca { get; }

        public Jogador(string nome, char simbolo) {
            Nome = nome;
            Peca = new Peca(simbolo);
        }
    }

}
