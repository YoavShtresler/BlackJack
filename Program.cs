using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        enum Symbol
        {
            heart = '♥',
            diamond = '♦',
            clover = '♣',
            leaf = '♠'
        }

        static void Main(string[] args)
        {
            Queue<Card> Pack1 = CreatePack();
            Queue<Card> Pack2 = CreatePack();
            Pack1 = Scramble(Pack1, Pack2);
           // for (int i = 0; i < 52; i++)
           // {
            //    Console.WriteLine(Pack1.Dequeue().ToString());
           // }
            Console.ReadLine();
            for (int i = 0; i < Pack1.ToArray().Length; i++)
            {
                Console.WriteLine(Pack1.Dequeue().ToString());
            }

        }
        static Queue<Card> CreatePack()
        {
            Card[] Pack1 = new Card[52];
            Symbol cardSymbol = Symbol.heart;
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 13; col++)
                {
                    switch(row)
                    {
                        case 0:
                            cardSymbol = Symbol.heart;
                            break;
                        case 1:
                            cardSymbol = Symbol.diamond;
                            break;
                        case 2:
                            cardSymbol = Symbol.clover;
                            break;
                        case 3:
                            cardSymbol = Symbol.leaf;
                            break;
                    }
                    Pack1[col + row * 13] = new Card(col + 1, (char)cardSymbol);
                }
            }
            return Scramble(Pack1);
        }

        static Queue<Card> Scramble(Card[] Pack)
        {
            Random rnd = new Random();
            Queue<Card> Spack = new Queue<Card>();
            for (int i = Pack.Length; i !=0; i--)
            {
                int x = rnd.Next(0, i);
                Spack.Enqueue(Pack[x]);
                for (int y = x; y < i-1; y++)
                    Pack[y] = Pack[y + 1]; 
            }
            return Spack;
        }
        static Queue<Card> Scramble(Queue<Card> Pack,Queue<Card> Pack1)
        {
            Queue<Card> SPacks = new Queue<Card>();
            Card[] arrPack1 = Pack1.ToArray();
            Card[] arrPack = Pack.ToArray();
            for (int i = 0; i < arrPack.Length; i++)
                SPacks.Enqueue(arrPack[i]);
            for (int i = arrPack.Length-1; i < arrPack1.Length; i++)
                SPacks.Enqueue(arrPack1[i]);   
            Random rnd = new Random();
            Card[] arrSpacks = SPacks.ToArray();
            Queue<Card> Spack = new Queue<Card>();
            for (int i = arrSpacks.Length; i != 0; i--)
            {
                int x = rnd.Next(0, i);
                Spack.Enqueue(arrSpacks[x]);
                for (int y = x; y < i - 1; y++)
                    arrSpacks[y] = arrSpacks[y + 1];
            }
            return Spack;
        }

    }
}
