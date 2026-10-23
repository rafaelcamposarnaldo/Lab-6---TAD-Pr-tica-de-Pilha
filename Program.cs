using System;

public class Program
{
    static string inverte(string s)
    {
        Pilha p = new Pilha(s.Length);

        for (int i = 0; i < s.Length; i++)
        {
            p.empilha(s[i]);
        }

        string resultado = "";

        while (!p.vazia())
        {
            resultado += (char)p.desempilha();
        }

        return resultado;
    }

    static int[] bubblePilhas(int[] v, out int comparacoes)
    {
        int n = v.Length;
        Pilha A = new Pilha(n);
        Pilha B = new Pilha(n);
        Pilha R = new Pilha(n);
        comparacoes = 0;

        for (int i = 0; i < n; i++)
        {
            A.empilha(v[i]);
        }

        for (int restantes = n; restantes >= 1; restantes--)
        {
            int carry = A.desempilha();

            for (int i = 1; i < restantes; i++)
            {
                int x = A.desempilha();
                comparacoes++;

                if (carry > x)
                {
                    B.empilha(x);
                }
                else
                {
                    B.empilha(carry);
                    carry = x;
                }
            }

            R.empilha(carry);

            Pilha auxiliar = A;
            A = B;
            B = auxiliar;
        }

        int[] ordenado = new int[n];

        for (int i = 0; i < n; i++)
        {
            ordenado[i] = R.desempilha();
        }

        return ordenado;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Parte 1");
        Pilha p = new Pilha(5);
        p.empilha(1);
        p.empilha(3);
        p.empilha(5);
        p.empilha(7);
        p.mostra();
        Console.WriteLine(p.desempilha());
        Console.WriteLine(p.consultaTopo());
        p.empilha(8);
        p.empilha(9);
        p.mostra();
        Console.WriteLine(p.cheia());

        try
        {
            p.empilha(2);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine();
        Console.WriteLine("Parte 2");
        Pilha teste = new Pilha(4);
        teste.empilha(10);
        teste.mostra();
        Console.WriteLine(teste.tamanho());
        teste.empilha(20);
        teste.mostra();
        Console.WriteLine(teste.tamanho());
        teste.desempilha();
        teste.mostra();
        Console.WriteLine(teste.tamanho());
        teste.empilha(30);
        teste.mostra();
        Console.WriteLine(teste.tamanho());
        teste.empilha(40);
        teste.mostra();
        Console.WriteLine(teste.tamanho());
        teste.desempilha();
        teste.mostra();
        Console.WriteLine(teste.tamanho());
        teste.desempilha();
        teste.mostra();
        Console.WriteLine(teste.tamanho());
        teste.empilha(50);
        teste.mostra();
        Console.WriteLine(teste.tamanho());

        Console.WriteLine();
        Console.WriteLine("Parte 3.1");
        Console.WriteLine(inverte("PUCMINAS"));

        Console.WriteLine();
        Console.WriteLine("Parte 4.2");
        int[] vetor = { 5, 2, 9, 1, 7 };
        int comparacoes;
        int[] ordenado = bubblePilhas(vetor, out comparacoes);

        for (int i = 0; i < ordenado.Length; i++)
        {
            Console.Write(ordenado[i] + " ");
        }

        Console.WriteLine();
        Console.WriteLine("Comparacoes: " + comparacoes);

        int[] vetorOrdenado = { 1, 2, 5, 7, 9 };
        int[] outroTeste = bubblePilhas(vetorOrdenado, out comparacoes);

        for (int i = 0; i < outroTeste.Length; i++)
        {
            Console.Write(outroTeste[i] + " ");
        }

        Console.WriteLine();
        Console.WriteLine("Comparacoes: " + comparacoes);
    }
}
