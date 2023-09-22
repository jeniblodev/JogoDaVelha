using System;

class JogoDaVelha
{
    private int[][] tabuleiro = new int[3][];
    private int jogador = 1;

    public JogoDaVelha()
    {
        for (int i = 0; i < 3; i++)
        {
            tabuleiro[i] = new int[3]; 
        }
    }

    public bool Jogar(int linha, int coluna)
    {
        if (linha < 0 || linha > 2 || coluna < 0 || coluna > 2)
        {
            return false;
        }

        if (tabuleiro[linha][coluna] != 0)
        {
            return false;
        }

        tabuleiro[linha][coluna] = jogador;
        jogador = (jogador == 1) ? 2 : 1;
        return true;
    }

    public int VerificaVencedor()
    {
        for (int jogador = 1; jogador <= 2; jogador++)
        {
            for (int linha = 0; linha < 3; linha++)
            {
                bool completo = true;
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    if (tabuleiro[linha][coluna] != jogador)
                    {
                        completo = false;
                        break;
                    }
                }

                if (completo)
                {
                    return jogador;
                }
            }

            for (int coluna = 0; coluna < 3; coluna++)
            {
                bool completo = true;
                for (int linha = 0; linha < 3; linha++)
                {
                    if (tabuleiro[linha][coluna] != jogador)
                    {
                        completo = false;
                        break;
                    }
                }

                if (completo)
                {
                    return jogador;
                }
            }

            bool diagonalCompleta = true;
            for (int posicao = 0; posicao < 3; posicao++)
            {
                if (tabuleiro[posicao][posicao] != jogador)
                {
                    diagonalCompleta = false;
                    break;
                }
            }

            if (diagonalCompleta)
            {
                return jogador;
            }

            diagonalCompleta = true;
            for (int posicao = 2; posicao >= 0; posicao--)
            {
                if (tabuleiro[posicao][2 - posicao] != jogador)
                {
                    diagonalCompleta = false;
                    break;
                }
            }

            if (diagonalCompleta)
            {
                return jogador;
            }
        }

        bool empate = true;
        for (int linha = 0; linha < 3; linha++)
        {
            for (int coluna = 0; coluna < 3; coluna++)
            {
                if (tabuleiro[linha][coluna] == 0)
                {
                    empate = false;
                    break;
                }
            }
        }

        return empate ? 3 : 0;
    }

    public string ExibeTabuleiro()
    {
        string campo = "";
        for (int linha = 0; linha < 3; linha++)
        {
            for (int coluna = 0; coluna < 3; coluna++)
            {
                switch (tabuleiro[linha][coluna])
                {
                    case 0:
                        campo += "_ ";
                        break;
                    case 1:
                        campo += "O ";
                        break;
                    case 2:
                        campo += "X ";
                        break;
                }
            }
            campo += "\n";
        }
        return campo;
    }

    public void ExecutarJogo()
    {
        Console.WriteLine("Boas vindas ao Jogo da Velha!!");
        Console.WriteLine("Olá jogador 1, qual seu nome?");
        string nomeJogador1 = Console.ReadLine();

        Console.WriteLine("Olá jogador 2, qual seu nome?");
        string nomeJogador2 = Console.ReadLine();

        while (VerificaVencedor() == 0)
        {
            Console.WriteLine(ExibeTabuleiro());

            if (jogador == 1)
            {
                Console.WriteLine($"É a vez de {nomeJogador1} jogar com O ");
            }
            else
            {
                Console.WriteLine($"É a vez de {nomeJogador2} jogar com X ");
            }
            Console.Write("Informe a linha: ");
            int linha = int.Parse(Console.ReadLine());
            Console.Write("Informe a coluna: ");
            int coluna = int.Parse(Console.ReadLine());

            if (!Jogar(linha, coluna))
            {
                Console.WriteLine("Jogada inválida, tente novamente");
            }
        }
        Console.WriteLine(ExibeTabuleiro());

        switch (VerificaVencedor())
        {
            case 1:
                Console.WriteLine($"Vitória de {nomeJogador1}!!");
                break;
            case 2:
                Console.WriteLine($"Vitória de {nomeJogador2}!!");
                break;
            case 3:
                Console.WriteLine("Xii deu velha!");
                break;
        }
    }

    public static void Main(string[] args)
    {
        JogoDaVelha jogo = new JogoDaVelha();
        jogo.ExecutarJogo();
    }
}
