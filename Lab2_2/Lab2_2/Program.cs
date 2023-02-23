using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
static void Main(string[] args)
{
    string filePath = @"C:\path\to\file.txt"; // путь к файлу
    List<string> data = GetDataFromFile(filePath); // получаем данные из файла
    SortData(data); // сортируем данные
    Console.ReadKey(); // ждем нажатия клавиши
}
static List<string> GetDataFromFile(string filePath)
{
    List<string> data = new List<string>(); // создаем список для хранения данных
    using (StreamReader reader = new StreamReader(filePath))
    {
        string line;
        while ((line = reader.ReadLine()) != null) // читаем файл построчно
        {
            data.Add(line); // добавляем строку в список
        }
    }
    return data;
}
static void SortData(List<string> data)
{
    // сортируем данные по длине строки с помощью лямбда-выражения
    List<string> sortedData = data.OrderBy(s => s.Length).ToList();

    // выводим отсортированные данные на экран
    foreach (string line in sortedData)
    {
        Console.WriteLine(line);
    }
}
