using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;

namespace ConsoleApplication4
{


    class Translator
    {
        Dictionary<string, string> dict = new Dictionary<string, string>();
        public Translator(int direction) 
        {
            string[] dictionary = File.ReadAllLines(@"Dictionary.txt", Encoding.Default);
            foreach (string line in dictionary)
            {
                string[] words = line.Split(' ');
                if (direction == 1)
                    dict.Add(words[0], words[1]);
                else
                    dict.Add(words[1], words[0]);
            }
        }
        public string Translate(string text) 
        {
            string[] textArray = text.Split(' ');
            string result = string.Empty;
            foreach (string word in textArray)
            {
                if (dict.ContainsKey(word))
                    result += dict[word] + " ";
                else
                    result += "<the word is missing> "; 
            }
            return result;
        }

        public static void addword()
        {
            Console.WriteLine("Enter an english word and its translation separated by a space: ");
            FileStream Dic = new FileStream(@"Dictionary.txt", FileMode.Append);
            StreamWriter writer = new StreamWriter(Dic, Encoding.Default);
            writer.WriteLine(Console.ReadLine());
            writer.Close();
            Console.WriteLine();
        }
       
        public static void slovar()
        {
            string[] Slovar = File.ReadAllLines(@"Dictionary.txt", Encoding.Default);
            for (int i = 0; i < Slovar.Length; i++)
            {
                Console.WriteLine(Slovar[i]);
            }
            Console.WriteLine();


        }

        public static void Vvodrus()
        {
            Console.WriteLine("Enter text in ukrainian:");
            Translator ruen = new Translator(2);
            string text2 = Console.ReadLine();
            Console.WriteLine(ruen.Translate(text2));
            Console.WriteLine();
        }
        public static void VvodEng()
        {
            Console.WriteLine("Enter text in english");
            Translator enru = new Translator(1);
            string text = Console.ReadLine();
            Console.WriteLine(enru.Translate(text));
            Console.WriteLine();
        }
    }
    public class Support
    {
        static public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Select the desired option and enter its number");
            Console.WriteLine("1) Translation from english to ukrainian\n2) Translation from ukrainian to english\n3) Add new word\n4) View dictionary\n5) Help\n6) Exit\n\n");
            Console.WriteLine();
        }
        static public void spravka()
        {
            Console.WriteLine("This program is designed to translate words and phrases from English into Ukrainian and vice versa.");
            Console.WriteLine();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Support.Menu();

            uint n = 0;
            while (n != 6)
            {


                do
                {
                    try
                    {
                        n = uint.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        n = 0;
                    }
                }
                while (n == 0);

                switch (n)
                {

                    case 1:

                        Console.Clear();
                        Translator.VvodEng();
                        Support.Menu();
                        break;

                    case 2:
                        Console.Clear();
                        Translator.Vvodrus();
                        Support.Menu();
                        break;
                    case 3:
                        Console.Clear();
                        Translator.addword();
                        Support.Menu();
                        break;
                    case 4:
                        Console.Clear();
                        Translator.slovar();
                        Support.Menu();
                        break;
                   
                    case 5:
                        Console.Clear();
                        Support.spravka();
                        Support.Menu();
                        break;
                    case 6:
                        Console.Clear();
                        Environment.Exit(0);
                        break; ;


                }
            }
        }


    }
}
