namespace Lib_3
{
    /// <summary>
    /// Класс с вычислительными модулями по варианту задания.
    /// Вариант: найти разность элементов массива.
    /// </summary>
    public class Calc
    {
        /// <summary>
        /// Расчет разности элементов массива.
        /// Первый элемент минус все последующие.
        /// </summary>
        /// <param name="mas">Исходный массив</param>
        /// <returns>Разность элементов массива</returns>
        public static int RazMas(int[] mas)
        {
            if (mas == null || mas.Length == 0)
                return 0;

            int raz = mas[0];
            for (int i = 1; i < mas.Length; i++)
            {
                raz = raz - mas[i];
            }
            return raz;
        }
    }
}