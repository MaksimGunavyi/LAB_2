using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Открываем файл с данными
        using (var reader = new StreamReader("data.csv"))
        {
            // Читаем заголовок
            var header = reader.ReadLine();

            // Создаем список для хранения данных
            var data = new List<string[]>();

            // Читаем данные и сохраняем их в список
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                data.Add(values);
            }

            // Фильтруем данные по заданному условию (в данном случае, по возрасту > 25)
            var filteredData = data.Where(d => int.Parse(d[2]) > 25);

            // Выводим отфильтрованные данные в консоль
            Console.WriteLine(header);
            foreach (var row in filteredData)
            {
                Console.WriteLine(string.Join(',', row));
            }
        }
    }
}