﻿using System;
using System.Collections.Generic;
namespace IntroUI
{
   public class Program
    {
        Random rnd = new Random();

        public char[] UserSetSymbols(string SetUserStr) {
            char[] symbols = SetUserStr.ToLower().ToCharArray();
            return symbols;
        }
        public List<string> RandomWords(int letters, int words, char[] symbols)
        {
            List<string> strCollection = new List<string>();
            if (letters <= 0 & words <= 0)
            {
                Console.WriteLine("Введённые параметры генератора должны быть больше 0!");
            }
            else
            {
                for (int i = 1; i <= words; i++)
                {
                    string strWords = "";
                    for (int j = 1; j <= letters; j++)
                    {
                        int indexletter = rnd.Next(0, symbols.Length - 1);
                        strWords += symbols[indexletter];
                    }
                    strCollection.Add(strWords);
                }
            }
            return strCollection;
        }

        public string GenerateStr(List<string> collStr)
        {
            string resStr = "";
            if (collStr.Count == 0)
            {
                Console.WriteLine("Строка не сгенерировалась!Проверить генератор слов.");
            }
            else
            {
                foreach (var tempWord in collStr)
                {
                    resStr += tempWord + " ";
                }
                resStr = resStr.Replace(' ', ',');
                resStr = resStr.TrimEnd(',');
                resStr += ".";
            }
            return resStr;
        }

        public void PrintFailedWords(List<string> failedwWords)
        {
            if (failedwWords.Count != 0)
            {
                foreach (var i in failedwWords)
                {
                    Console.WriteLine("Данное(ые) слово не прошло проверку по условиям: {0}", i);
                }
            }
            else
            {
                Console.WriteLine("Слов неудовлетворяющих условиям не обнаружено!");
            }
        }

        public void PrintResult(List<string> resWords, List<int> countOccurrences)
        {
            for (int i = 0; i < resWords.Count; i++)
            {
                Console.WriteLine("{0})Число вхождений слова {1}: {2}", i, resWords[i], countOccurrences[i]);
            }
        }
        static void Main(string[] args)
        {
            string strDef = "q,w,ee,rr,ttt,yyyy,uuuuu,q,o,p,uuuuu,ss,dd,f,g,h,j,xx,zz,xx,cc,vv,bb,nn,mm,q,rty,yui,asd,uuuuu.";
            List<string> failedwWords = new List<string>();
            List<int> Occurrences = new List<int>();
            List<string> wWords = new List<string>();
            Program InstanceProgram1 = new Program();
            Spliter InstanceSpliter1 = new Spliter();
            Program InstanceProgram2 = new Program();
            Spliter InstanceSpliter2 = new Spliter();
            Program InstanceProgram3 = new Program();
            Spliter InstanceSpliter3 = new Spliter();
            while(true){
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1.Выполнить программу с заданной строкой: " + strDef);
                Console.WriteLine("2.Выполнить программу при этом строка будет сгенерированна,введите символы из которых хотите сгенерировать строку.");
                Console.WriteLine("3.Выполнить программу строку вы вводите сами.");
                Console.WriteLine("4.Ознакомится с условиями ввода строки.");
                Console.WriteLine("5.Запустить тесты.");
                int sWarg = Convert.ToInt32(Console.ReadLine());
                switch(sWarg) 
                {
                    case 1:
                        Console.Clear();
                        Finder InstanceFinder1 = new Finder(strDef);
                        failedwWords = InstanceFinder1.FinderWords(InstanceSpliter1.SpliterWords(strDef), out Occurrences, out wWords);
                        InstanceProgram1.PrintFailedWords(failedwWords);
                        InstanceProgram1.PrintResult(wWords, Occurrences);
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Введите символы из которых хотели бы сгенерировать строку.");
                        string setUserStr = Console.ReadLine();
                        string str = InstanceProgram2.GenerateStr(InstanceProgram2.RandomWords(5, 10,InstanceProgram2.UserSetSymbols(setUserStr)));
                        Console.WriteLine("Сгенерированная строка: " + str);
                        Finder InstanceFinder2 = new Finder(str);
                        failedwWords = InstanceFinder2.FinderWords(InstanceSpliter2.SpliterWords(str), out Occurrences, out wWords);
                        InstanceProgram2.PrintFailedWords(failedwWords);
                        InstanceProgram2.PrintResult(wWords, Occurrences);
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Вводите строку:");
                        string strUser = Console.ReadLine();
                        Finder InstanceFinder3 = new Finder(strUser);
                        failedwWords = InstanceFinder3.FinderWords(InstanceSpliter3.SpliterWords(strUser), out Occurrences, out wWords);
                        InstanceProgram3.PrintFailedWords(failedwWords);
                        InstanceProgram3.PrintResult(wWords, Occurrences);
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Длина символа не должна быть меньше чем 1 или больше чем 5.");
                        Console.WriteLine("Слов в строке должно быть не больше чем 30.");
                        Console.WriteLine("Соседниеи слова разделены (,) а в конце (.).");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Тесты:");
                        Tests tests = new Tests();
                        Console.WriteLine(tests.RandomWordsTest());
                        Console.WriteLine(tests.GenerateStrTest());
                        Console.WriteLine(tests.SpliterWordsTest());
                        Console.WriteLine(tests.FinderWordsTest());
                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Вы ничего не выбрали!");
                        break;
                }
            }
        }
    }
}