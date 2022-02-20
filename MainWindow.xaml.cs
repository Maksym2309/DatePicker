using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DatePicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ArrayList _yearNames;

        public MainWindow()
        {
            InitializeComponent();

            _yearNames = new ArrayList();
            _yearNames.Add("Обезьяны");
            _yearNames.Add("Петуха");
            _yearNames.Add("Собаки");
            _yearNames.Add("Свиньи");
            _yearNames.Add("Крысы");
            _yearNames.Add("Быка");
            _yearNames.Add("Тигра");
            _yearNames.Add("Кота");
            _yearNames.Add("Дракона");
            _yearNames.Add("Змеи");
            _yearNames.Add("Лошади");
            _yearNames.Add("Козы");

            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 12; j++)
                {
                    _yearNames.Add(_yearNames[j]);
                }
            }
        }

        private void inputButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime? selectedDate = ageDatePicker.SelectedDate;
            if (selectedDate == null)
            {
                MessageBox.Show("Сначала введите дату!");
                return;
            }

            long age = calculateAge(selectedDate);
            if (age < 0 || age > 135)
            {
                MessageBox.Show("Вы ввели неверный возраст!");
                return;
            }

            if (isTodayBirthday(selectedDate))
                ageLabel.Text = "Вам " + age + " лет. С днем рождения!!!!";
            else
                ageLabel.Text = "Вам " + age + " лет";

            zodiacLabel.Text = "Ваш знак зодиака: " + calculateZodiac(selectedDate);
            yearLabel.Text = "Вы года: " + calculateYear(selectedDate);
        }

        private long calculateAge(in DateTime? selectedDate)
        {
            if (selectedDate == null)
                return 0;

            return DateTime.Now.Year - selectedDate.Value.Year - (DateTime.Now.DayOfYear < selectedDate.Value.DayOfYear ? 1 : 0);
        }

        private string calculateZodiac(in DateTime? selectedDate)
        {
            if (selectedDate == null)
                return "Неизвестно";

            int month = selectedDate.Value.Month;
            int day = selectedDate.Value.Day;

            switch(month)
            {
                case 1:
                    if (day <= 20)
                        return "Козерог";
                    else 
                        return "Водолей";

                case 2:
                    if (day <= 19)
                        return "Водолей";
                    else 
                        return "Рыбы";

                case 3:
                    if (day <= 20)
                        return "Рыбы";
                    else
                        return "Овен";

                case 4:
                    if (day <= 20)
                        return "Овен";
                    else
                        return "Телец";

                case 5:
                    if (day <= 21)
                        return "Телец";
                    else 
                        return "Близнецы";

                case 6:
                    if (day <= 21)
                        return "Близнецы";
                    else
                        return "Рак";

                case 7:
                    if (day <= 22)
                        return "Рак";
                    else
                        return "Лев";

                case 8:
                    if (day <= 21)
                        return "Лев";
                    else
                        return "Дева";

                case 9:
                    if (day <= 23)
                        return "Дева";
                    else
                        return "Весы";

                case 10:
                    if (day <= 23)
                        return "Весы";
                    else
                        return "Скорпион";

                case 11:
                    if (day <= 22)
                        return "Скорпион";
                    else
                        return "Стрелец";

                case 12:
                    if (day <= 22)
                        return "Стрелец";
                    else
                        return "Козерог";
            }

            return "Неизвестно";
        }

        private string? calculateYear(in DateTime? selectedDate)
        {
            if (selectedDate == null)
                return "Неизвестно";

            string ? year = (string ?)_yearNames[selectedDate.Value.Year - 1920];

            return year;
        }

        private bool isTodayBirthday(in DateTime? selectedDate)
        {
            if (selectedDate == null)
                return false;

            return selectedDate.Value.Day == DateTime.Now.Day && selectedDate.Value.Month == DateTime.Now.Month;
        }
    }
}
