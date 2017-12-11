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
            Card[] Pack3= Pack1.ToArray();
            for (int i = 0; i < Pack3.Length; i++)
            {
                Console.WriteLine(Pack1.Dequeue().ToString());
            }
            //Menu();
            while (Turn())
            {
                //put in if and break call Check
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
                    switch (row)
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
            for (int i = Pack.Length; i != 0; i--)
            {
                int x = rnd.Next(0, i);
                Spack.Enqueue(Pack[x]);
                for (int y = x; y < i - 1; y++)
                    Pack[y] = Pack[y + 1];
            }
            return Spack;
        }
        static Queue<Card> Scramble(Queue<Card> Pack, Queue<Card> Pack1)
        {
            Queue<Card> SPacks = new Queue<Card>();
            Card[] arrPack1 = Pack1.ToArray();
            Card[] arrPack = Pack.ToArray();
            for (int i = 0; i < arrPack.Length; i++)
                SPacks.Enqueue(arrPack[i]);
            for (int i = arrPack.Length - 1; i < arrPack.Length + arrPack1.Length-1; i++)
                SPacks.Enqueue(arrPack1[i-arrPack.Length+1]);
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
    
        static Card Draw(Queue<Card> Pack)
        {
            return Pack.Dequeue();
        }

        static bool Turn()
        {
            //Call ToString Func
            //Check if Key is pressed
            ConsoleKeyInfo Pressedkey = Console.ReadKey();
        WasntPressed:
            if (Pressedkey.Key == ConsoleKey.NumPad1)
            {
                //Call Draw Method

            }
            else if (Pressedkey.Key == ConsoleKey.NumPad2)
            {
                //call method
            }
            else
                goto WasntPressed;
            
            return true;
        }

        static void Menu()
        {
            Console.SetCursorPosition(0, 20); Console.WriteLine("Pick An Action:(Press The NumPad) ");
            Console.Write("Draw Card-1"+"      "+"End Turn -2 ");
        }
    }
}
