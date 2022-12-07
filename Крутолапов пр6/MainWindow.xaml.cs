using System;
using System.Collections.Generic;
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


namespace Практическая_6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<Car> carsList = new List<Car>();//список тачек

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Крутолапов Валерий Исп-31 Вариант - 1");
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = 1;
                string brand = tbBrand.Text;
                int power = int.Parse(tbPwr.Text);
                int numberOfCylinders = int.Parse(tbNOC.Text);

                Car tempCar = new Car(brand, numberOfCylinders, power);
                carsList.Add(tempCar);

                tbRes.Text = string.Empty;

                foreach (var item in carsList)
                {
                    tbRes.Text += " Название автомобиля номер " + i++ + '-' + item.Brand + '\n' +
                              " Мощность " + item.Power + '\n' +
                              " Кол-во цилиндров " + item.NumberOfCylinders + "\n\n";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Данные указаны не верно или отсутствуют");
                return;
            }

        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = 1;
                int autoNumber = int.Parse(tbDelete.Text);
                carsList.Remove(carsList[autoNumber - 1]);

                tbRes.Text = string.Empty;

                foreach (var item in carsList)
                {
                    tbRes.Text += " Название автомобиля номер " + i++ + '-' + item.Brand + '\n' +
                              " Мощность " + item.Power + '\n' +
                              " Кол-во цилиндров " + item.NumberOfCylinders + "\n\n";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Данные указаны неверно или объект не создан");
                return;
            }
        }

        private void ButtonChange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = 1;
                string brand = tbBrand.Text;
                int power = int.Parse(tbPwr.Text);
                int numberOfCylinders = int.Parse(tbNOC.Text);
                int autoNumber = int.Parse(tbDelete.Text);

                carsList[autoNumber - 1].SetParams(numberOfCylinders, power, brand);

                tbRes.Text = string.Empty;

                foreach (var item in carsList)
                {
                    tbRes.Text += " Название автомобиля номер " + i++ + '-' + item.Brand + '\n' +
                              " Мощность " + item.Power + '\n' +
                              " Кол-во цилиндров " + item.NumberOfCylinders + "\n\n";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Данные указаны неверно или объект не создан");
                return;
            }
        }

        private void ButtonIncrease(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = 1;
                int autoNumber = int.Parse(tbDelete.Text);

                Car tempcar = carsList[autoNumber - 1]++;

                carsList[autoNumber - 1] = tempcar;

                tbRes.Clear();

                foreach (var item in carsList)
                {
                    tbRes.Text += " Название автомобиля номер " + i++ + '-' + item.Brand + '\n' +
                              " Мощность " + item.Power + '\n' +
                              " Кол-во цилиндров " + item.NumberOfCylinders + "\n\n";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Данные указаны неверно или объект не создан");
                return;
            }
        }

        private void ButtonCompare(object sender, RoutedEventArgs e)
        {
            try
            {
                int car1 = int.Parse(tbFirstCar.Text);
                int car2 = int.Parse(tbSecondCar.Text);

                if (carsList[car1 - 1] > carsList[car2 - 1])
                {
                    tbRes.Text += "Первая тачка круче\n";
                }
                else if (carsList[car1 - 1] < carsList[car2 - 1])
                {
                    tbRes.Text += "Вторая тачка круче\n";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Данные указаны не верно или объект не создан");                
            }
        }
    }
}
