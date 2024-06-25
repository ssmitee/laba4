using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ZNAKManagementApp
{
    public partial class MainWindow : Window
    {
        private List<ZNAK> people = new List<ZNAK>();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Метод для обработки события нажатия кнопки "Добавить"
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем валидность введенных данных
            if (!ValidateInput())
            {
                MessageBox.Show("Пожалуйста, введите корректные данные для даты рождения (день, месяц и год должны быть числами).");
                return;
            }

            // Считываем данные с элементов управления TextBox и ComboBox
            string lastName = txtLastName.Text;
            string firstName = txtFirstName.Text;
            string zodiacSign = cmbZodiacSign.Text;
            int day = int.Parse(txtDay.Text);
            int month = int.Parse(txtMonth.Text);
            int year = int.Parse(txtYear.Text);
            int[] birthDate = new int[] { day, month, year };
            object idNumber = txtIDNumber.Text;

            // Создаем новый объект ZNAK и добавляем его в список
            ZNAK person = new ZNAK(lastName, firstName, zodiacSign, birthDate, idNumber);
            people.Add(person);

            // Очищаем поля ввода после добавления
            ClearInputFields();

            // Пересортировываем список по знакам Зодиака
            people.Sort();

            // Обновляем ListBox с отсортированным списком
            UpdateListBox();
        }

        // Метод для обновления содержимого ListBox
        private void UpdateListBox()
        {
            listBoxPeople.Items.Clear();
            foreach (var person in people)
            {
                listBoxPeople.Items.Add(person.ToString());
            }
        }

        // Метод для очистки полей ввода
        private void ClearInputFields()
        {
            txtLastName.Text = "";
            txtFirstName.Text = "";
            cmbZodiacSign.SelectedIndex = -1;
            txtDay.Text = "";
            txtMonth.Text = "";
            txtYear.Text = "";
            txtIDNumber.Text = "";
        }

        // Метод для валидации введенных данных для даты рождения
        private bool ValidateInput()
        {
            int day, month, year;
            if (!int.TryParse(txtDay.Text, out day) || day < 1 || day > 31)
                return false;

            if (!int.TryParse(txtMonth.Text, out month) || month < 1 || month > 12)
                return false;

            if (!int.TryParse(txtYear.Text, out year) || year < 1900 || year > DateTime.Now.Year)
                return false;

            return true;
        }

        // Метод для обработки события нажатия кнопки "Найти по месяцу"
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            int searchMonth;
            if (!int.TryParse(txtSearchMonth.Text, out searchMonth) || searchMonth < 1 || searchMonth > 12)
            {
                MessageBox.Show("Введите корректный номер месяца (от 1 до 12).");
                return;
            }

            bool found = false;
            listBoxResults.Items.Clear();

            foreach (var person in people)
            {
                if (person.BirthDate[1] == searchMonth)
                {
                    found = true;
                    listBoxResults.Items.Add(person.ToString());
                }
            }

            if (!found)
            {
                listBoxResults.Items.Add($"Людей, родившихся в месяц {searchMonth}, не найдено.");
            }
        }
    }
}
