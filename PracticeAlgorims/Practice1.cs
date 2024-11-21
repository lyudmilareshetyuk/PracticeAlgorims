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
            Console.WriteLine("Вывод списков смежности из файла: ");
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
            //Передача пути и имени файла
            StreamReader text1 = new StreamReader("E:\\STUDY\\University\\Второе высшее\\4й курс\\Структуры и алгоритмы обработки данных\\spiski_smeznosti1.txt");
            line = text1.ReadLine();
            //чтение первой строки
            int iteration = 0;
            int indexFromList = 0;
            Console.WriteLine();
            Console.WriteLine("Массив смежности: ");
            while (iteration != numVertices)
            {
                for (int a = 0 + iteration; a < numVertices; a++)
                {
                    string basic_words = line;
                    char ch = '=';
                    int indexOfChar = basic_words.IndexOf(ch);
                    string discarded = basic_words.Substring(0, indexOfChar); // то что до "=" хранится здесь и откидывается
                    string words = basic_words.Substring(indexOfChar + 1); // то что после "=" хранится здесь и нужно для дальнейшей работы, с ","
                    string[] slovo = words.Split(new char[] { ',' });
                    for (int b = 0; b < numVertices; b++)
                    {
                        foreach (string s in slovo)
                        {
                            indexFromList = Int32.Parse(s);
                            if (indexFromList != -1)
                            {
                                graph[a, indexFromList] = 1;
                            }
                            else
                            {
                                graph[a, b] = 0;
                            }
                        }
                        Console.Write(graph[a, b] + " ");
                        indexFromList = -1;
                    }
                    Console.WriteLine();
                    line = text1.ReadLine();
                    iteration += 1;
                }
            }
            //закрытие файла
            text1.Close();
            int sumEdges = 0;
            int count = 0;
            int[] stepsort = new int[numVertices]; 
            for (int c = 0; c < numVertices ; c++)
            {
                if (graph[c, c] == 1)
                {
                    numloops = numloops + 1; // счет количества петель
                }

                for (int d = 0; d < numVertices ; d++)
                {

                    if (graph[c, d] != 0)
                    {
                        numEdges = numEdges + 1; //счет количества ребер
                    }
                    sumEdges = sumEdges + graph[c, d]; // счет ребер в пределах строки
                    stepsort[c] = sumEdges;
                }
                if (sumEdges == 0)
                {
                    count += 1; // поиск изолированных вершин
                }
                sumEdges = 0;
            }
            numEdges = numEdges / 2 + numloops;
            Console.WriteLine("Количество ребер в графе равно {0}, количество петель равно {1}", numEdges, numloops);
            if (count == 0)
            {
                Console.WriteLine("Изолированных вершин нет");
            }
            else
            {
                Console.WriteLine("Количество изолированных вершин в графе {0}", count);
            }
            Console.Write("Список степеней вершин в порядке убывания: ");
            var orderedForDescending = from v in stepsort
                                 orderby v descending
                                 select v;
            foreach (int v in orderedForDescending)
            {
                Console.Write(v + " ");
            }
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
