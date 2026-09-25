using System;
using System.IO;   
using System.Linq; 
namespace Lib_Mas
{
    /// <summary>
    /// Класс для базовых операций с одномерным массивом.
    /// </summary>
    public class Mas
    {
        /// <summary>
        /// Заполнение массива случайными числами.
        /// </summary>
        /// <param name="column">Количество элементов массива</param>
        /// <param name="randMax">Максимальное значение случайного числа</param>
        /// <returns>Массив, заполненный случайными числами</returns>
        public static int[] InitMas(int column, int randMax)
        {
            Random rnd = new Random();
            int[] mas = new int[column];
            for (int i = 0; i < column; i++)
            {
                mas[i] = rnd.Next(randMax);
            }
            return mas;
        }
        /// <summary>
        /// Сохранение массива в текстовый файл.
        /// </summary>
        /// <param name="mas">Массив для сохранения</param>
        /// <param name="fileName">Путь к файлу</param>
        public static void SaveMas(int[] mas, string fileName)
        {
            if (mas == null) return;
            string[] lines = mas.Select(x => x.ToString()).ToArray();
            File.WriteAllLines(fileName, lines);
        }
        /// <summary>
        /// Открытие массива из текстового файла.
        /// </summary>
        /// <param name="fileName">Путь к файлу</param>
        /// <returns>Массив, прочитанный из файла</returns>
        public static int[] OpenMas(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            int[] mas = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                int.TryParse(lines[i], out mas[i]);
            }
            return mas;
        }
        /// <summary>
        /// Очистка массива (обнуление всех элементов).
        /// </summary>
        /// <param name="mas">Массив для очистки</param>
        public static void ClearMas(int[] mas)
        {
            if (mas == null) return;
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = 0;
            }
        }
    }
}