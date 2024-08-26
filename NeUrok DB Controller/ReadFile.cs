using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NeUrok_DB_Controller
{
    internal class ReadFile
    {
        public static string GetPath()
        {
            return $"{Environment.CurrentDirectory}\\ColorsFile.txt";
        }
        public static string Read()
        {

            // Получение потока из ресурсов
            if (File.Exists(GetPath()))
            {
                string content = (string)File.ReadAllText(GetPath());
                return content;
            }
            else
            {
                Write("");
                return "";
            }
        }

        public static void Write(string content)
        {
            if (!File.Exists(GetPath()))
            {
                using (StreamWriter sw = File.CreateText(GetPath()))
                {
                    sw.Write(content);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(GetPath()))
                {
                    sw.Write(content);
                }
            }
        }

        public static void ReWrite(string content)
        {
            using (StreamWriter sw = File.CreateText(GetPath()))
            {
                sw.Write(content);
            }
        }

        public static void RemoveLineFromFile(string valueToRemove)
        {
            try
            {
                // Чтение всех строк из файла
                string lines = File.ReadAllText(GetPath());
                Console.WriteLine(valueToRemove);
                // Создание нового списка строк без удаляемой строки
                if (lines.Contains(valueToRemove))
                    lines = lines.Replace(valueToRemove, "");
                else return;
                Console.Write(lines);
                // Перезапись файла
                File.WriteAllText(GetPath(), lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при удалении строки из файла: {ex.Message}");
            }
        }

        public static string FindByAddress(string address)
        {
            string[] lines = File.ReadAllText(GetPath()).Split(';');
            foreach (var line in lines)
            {
                if (line.Split(',')[0] == address)
                    return line;
            }
            return null;
        }

        public static TKey GetKeyByValue<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TValue value)
        {
            // Используем LINQ для поиска ключа по значению
            var keyValuePair = dictionary.FirstOrDefault(x => x.Value.Equals(value));

            // Если элемент найден, возвращаем ключ; иначе возвращаем значение по умолчанию для типа ключа
            return keyValuePair.Equals(default(KeyValuePair<TKey, TValue>)) ? default(TKey) : keyValuePair.Key;
        }
    }
}
