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
using System.Windows.Shapes;

using PublicCanteen.Windows;
using PublicCanteen.DB;
using PublicCanteen.Classes;

namespace PublicCanteen.Windows
{
    /// <summary>
    /// Логика взаимодействия для ListOfDishesWindow.xaml
    /// </summary>
    public partial class ListOfDishesWindow : Window
    {
        public ListOfDishesWindow()
        {
            InitializeComponent();

            GetListDisd();
            GetListCategoryDisd();

            tbNameEmpl.Text = UserDataClass.userAuth.LastNameEmployee + " " + UserDataClass.userAuth.FirstNameEmployee + " " + UserDataClass.userAuth.PatronymicName;
        }

        // метод получения списка категорий блюд
        void GetListDisd()
        {
            LvDish.ItemsSource = EFClass.entities.Dish.ToList();
        }

        // метод получения списка категорий блюд
        void GetListCategoryDisd()
        {
            lvCategoryDish.ItemsSource = EFClass.entities.CategoryDish.ToList();
        }

        // добавление блюда в корзину
        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var dish = button.DataContext as DB.Dish; // получаем выбранную запись

            foreach (var item in CartListClass.dishesCart)
            {
                if (dish == item)
                {
                    item.CountDish++;
                    return;
                }
            }
            CartListClass.dishesCart.Add(dish);
        }

        // переход в корзину
        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
            CartWindow cartWindow = new CartWindow();   
            cartWindow.Show();
            this.Close();
        }

        //Переход на окно добавления блюда
        private void btnAddDish_Click(object sender, RoutedEventArgs e)
        {
            AddDishWindow addDishWindow = new AddDishWindow();  
            addDishWindow.ShowDialog();

            GetListDisd();
        }

        // изменение выбранного блюда
        private void btnEditDish_Click(object sender, RoutedEventArgs e)
        {
            // получаем выбранную запись
            if (LvDish.SelectedItem is DB.Dish)
            {
                EditDishWindow editDishWindow = new EditDishWindow(LvDish.SelectedItem as Dish);
                editDishWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
            }

            GetListDisd();

           
        }

        // удаление блюда
        private void btnDelDish_Click(object sender, RoutedEventArgs e)
        {
            // получаем выбранную запись
            if (LvDish.SelectedItem is DB.Dish)
            {
                EFClass.entities.Dish.Remove(LvDish.SelectedItem as Dish);
                EFClass.entities.SaveChanges();
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
            }

            MessageBox.Show("Удаление прошло успешно");

            GetListDisd();
        }


        private void txbSerch_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var dish = button.DataContext as DB.CategoryDish; // получаем выбранную запись

            LvDish.ItemsSource = EFClass.entities.Dish.Where(p => p.CategoryDish.NameCategory == dish.NameCategory.ToString()).ToList();
        }

        private void btnRes_Click(object sender, RoutedEventArgs e)
        {
            GetListDisd();
        }
    }
}
