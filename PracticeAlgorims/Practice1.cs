using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PracticeAlgorims
{
    internal class Practice1
    {
        static void Main(string[] args)
        {
            int numVertices = 0; // количество вершин
            int numEdges = 0; // количество ребер
            int numloops = 0; // количество петель
            String line; //объявление пустой строки для перезаписи строк при создании массива

            //определение размерности массива
            //Передача пути и имени файла
            StreamReader text = new StreamReader("E:\\STUDY\\University\\Второе высшее\\4й курс\\Структуры и алгоритмы обработки данных\\spiski_smeznosti1.txt");
            //чтение первой строки
            line = text.ReadLine();
            //Продолжение чтения строк до окончания файла
            while (line != null)
            {
                numVertices = numVertices + 1; //счет количества вершин
                //вывод строки в консоль
                Console.WriteLine(line);
                //чтение следующей строки
                line = text.ReadLine();
            }
            //закрытие файла
            text.Close();
            Console.WriteLine("Количество вершин в графе равно {0}", numVertices);


            //Инициализация массива смежности и запись данных в массив
            int[,] graph = new int[numVertices, numVertices];
            int indexList = 0;
            Console.WriteLine("Массив по умолчанию: ");
            for (int i = 0; i < numVertices; i++)
            {
                for (int j = 0; j < numVertices; j++)
                {
                    if (indexList == 0)
                    {
                        graph[i, j] = 0;
                    }
                    else { graph[i, j] = 1; }

                    Console.Write("{0} ", graph[i, j]);
                }
                Console.WriteLine();
            }


            //Передача пути и имени файла
            StreamReader text1 = new StreamReader("E:\\STUDY\\University\\Второе высшее\\4й курс\\Структуры и алгоритмы обработки данных\\spiski_smeznosti1.txt");
            line = text1.ReadLine();
            //чтение первой строки
            int iteration = 0;
            int indexFromList = 0;
            Console.WriteLine("Массив c изменениями: ");
            while (iteration != numVertices)
            {
                for (int a = 0 + iteration; a < numVertices; a++)
                {
                    Console.WriteLine("line = " + line);
                    string basic_words = line;
                    char ch = '=';
                    int indexOfChar = basic_words.IndexOf(ch);
                    string discarded = basic_words.Substring(0, indexOfChar); // то что до "=" хранится здесь и откидывается
                    string words = basic_words.Substring(indexOfChar + 1); // то что после "=" хранится здесь и нужно для дальнейшей работы, с ","
                    Console.WriteLine("words = " + words);
                    string[] slovo = words.Split(new char[] { ',' });

                    for (int b = 0; b < numVertices; b++)
                    {
                        Console.WriteLine("Цикл {0}, столбик {1}", a, b);
                        foreach (string s in slovo)
                        {
                            indexFromList = Int32.Parse(s);
                            Console.WriteLine("s = " + s);
                            Console.WriteLine("indexFromList = ", indexFromList);

                            if (indexFromList == 0)
                            {
                                graph[a, b] = 0;
                            }
                            else
                            {
                                graph[a, b] = 1;
                            }
                        }
                        Console.Write("{0} ", graph[a, b]);
                        b = b + 1;
                    }
                    Console.WriteLine();
                    line = text1.ReadLine();
                    iteration += 1;
                }
            }
            //закрытие файла
            text1.Close();
            Console.ReadLine();
        }
    }
}



/*

for (int i = 0; i < 5; i++)
{
    if (graph[i, i] == 1)
    {
        numloops = numloops + 1; // счет количества петель
    }

    for (int j = 0; j < 5; j++)
    {

        if (graph[i, j] != 0)
        {
            numEdges = numEdges + 1; //счет количества ребер

        }
    }
}
numEdges = numEdges / 2 + numloops;
Console.WriteLine("Количество вершин в графе равно {0}, количество ребер в графе равно {1}, количество петель равно {2}", numVertices, numEdges, numloops);


for(int i = 0; i < 5; i++)
{

}
/* List<int> cheklist = new List<int>(numVertices); //объявление списка для добавления вершин графа в порядке убывания
 for (int i = 0; i < 5; i++)
 {
     for (int j = 0; j < 5; j++) // создание списка вершин графа в порядке убывания
     {
         cheklist.add(graph[i,j]);
     }
 }*/
