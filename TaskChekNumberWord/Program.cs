using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskChekNumberWord
{
    class Program
    {
        static void Main(string[] args)
        {
            //вызов текстового файла
            string text = File.ReadAllText("C:\\Users\\alexandr\\OneDrive\\Рабочий стол\\trening\\Text1.txt");
            //приобразуем в массив символов
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            StringBuilder textFormat = new StringBuilder();

            foreach (var value in noPunctuationText)
                textFormat.Append(value);

            string textTwo = textFormat.ToString();

            char[] delimiters = new char[] { ' ', '\r', '\n' };
            //Создаем масив строк
            string[] words = textTwo.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            //создаем колекцию
            Dictionary<string, int> wordDic = new Dictionary<string, int>();

            foreach (var key in words)
            {
                if (wordDic.TryGetValue(key, out int value))
                {
                    wordDic[key] = value + 1;
                }
                else
                {
                    wordDic.Add(key, 1);
                }

            }


            var numberWord = new List<int>();
            int l = 0;

            foreach (int w in wordDic.Values)
            {
                numberWord.Add(w);
            }

            numberWord.Sort();
            numberWord.Reverse();

            //for (int d = 0; d < 10; d++)
            //{
            //    Console.WriteLine(numberWord[d]);
            //}

            for (int d = 0; d < 10; d++)
            {
                foreach (var wk in wordDic)
                {
                    if (wk.Value == numberWord[d])
                    {
                        Console.WriteLine($"{d + 1} Слово '0' {wk.Key} встречается в тексте {wk.Value} раз(а)");
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
