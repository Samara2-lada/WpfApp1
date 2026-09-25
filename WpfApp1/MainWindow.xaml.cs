using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using Lib_Mas;   // Библиотека базовых операций
using Lib_3;  // Библиотека вычислителения

namespace WpfApp1
{
    /// <summary>
    /// Главное окно приложения для работы с массивом.
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[] mas;
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Заполнение массива случайными числами.
        /// </summary>
        private void btnFill_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtColumCount.Text, out int column) && column > 0)
            {
                mas = Mas.InitMas(column, 10);
                UpdateGrid();
            }
            else
            {
                MessageBox.Show("Введите корректное положительное число!");
            }
        }

        /// <summary>
        /// Ручной ввод массива через строку.
        /// </summary>
        private void btnManualInput_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtManualArray.Text))
            {
                MessageBox.Show("Введите числа через пробел или запятую!");
                return;
            }

            string[] parts = txtManualArray.Text.Split(new char[] { ' ', ',', ';' },
                                                        StringSplitOptions.RemoveEmptyEntries);
            mas = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                if (int.TryParse(parts[i], out int number))
                    mas[i] = number;
                else
                {
                    MessageBox.Show($"Ошибка: '{parts[i]}' не является числом!");
                    return;
                }
            }

            txtColumCount.Text = mas.Length.ToString();
            UpdateGrid();
        }

        /// <summary>
        /// Расчет разности элементов массива.
        /// </summary>
        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            if (mas != null && mas.Length > 0)
            {
                int raz = Calc.RazMas(mas);
                Rezult.Text = raz.ToString();
            }
            else
            {
                MessageBox.Show("Сначала заполните массив!");
            }
        }
        /// <summary>
        /// Сохранение массива в файл.
        /// </summary>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (mas == null || mas.Length == 0)
            {
                MessageBox.Show("Массив пуст, нечего сохранять.");
                return;
            }

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "*.txt";
            saveFile.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFile.Title = "Сохранение файла";

            if (saveFile.ShowDialog() == true)
            {
                Mas.SaveMas(mas, saveFile.FileName);
                MessageBox.Show("Файл успешно сохранен!");
            }
        }
        /// <summary>
        /// Открытие массива из файла.
        /// </summary>
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = "*.txt";
            openFile.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFile.Title = "Открытие файла";

            if (openFile.ShowDialog() == true)
            {
                try
                {
                    mas = Mas.OpenMas(openFile.FileName);
                    txtColumCount.Text = mas.Length.ToString();
                    UpdateGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка чтения файла: " + ex.Message);
                }
            }
        }
        /// <summary>
        /// Очистка всех полей и таблицы.
        /// </summary>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtColumCount.Clear();
            txtManualArray.Clear();
            Rezult.Clear();
            dataGrid1.ItemsSource = null;
            mas = null;
            txtColumCount.Focus();
        }
        /// <summary>
        /// Закрытие окна.
        /// </summary>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Информация о программе.
        /// </summary>
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Пратическая работа 1 Афонин Михаил Денисович Задание Ввести  n целых чисел. Найти разницу чисел. Результат вывести на экран.");
        }
        /// <summary>
        /// Вспомогательный метод для обновления DataGrid.
        /// </summary>
        private void UpdateGrid()
        {
            dataGrid1.ItemsSource = null;
            dataGrid1.ItemsSource = mas.Select(x => new { Значение = x }).ToList(); ;
        }
    }
}