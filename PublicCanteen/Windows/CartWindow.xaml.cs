using PublicCanteen.Classes;
using PublicCanteen.DB;
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

namespace PublicCanteen.Windows
{
    /// <summary>
    /// Логика взаимодействия для CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        public CartWindow()
        {
            InitializeComponent();
            GetCartDisd();

        }

        void GetCartDisd()
        {
            LvDishCart.ItemsSource = CartListClass.dishesCart.ToList();
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            // получаем выбранную запись
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var dish = button.DataContext as DB.Dish; 

            // проверка на количество блюд 
            if (dish.CountDish > 0)
            {
                dish.CountDish--;
            }
            
            if (dish.CountDish == 0)
            {
                CartListClass.dishesCart.Remove(dish);
            }

            GetCartDisd();

        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            // получаем выбранную запись
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var dish = button.DataContext as DB.Dish;             
            dish.CountDish++;

            // обновляем список 
            GetCartDisd();

        }

        private void btnBackToList_Click(object sender, RoutedEventArgs e)
        {
            ListOfDishesWindow listOfDishesWindow = new ListOfDishesWindow();
            listOfDishesWindow.Show();
            this.Close();
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            //добавление нового заказа
            //var newOrder = new DB.Order();
            //newOrder.IdEmployee = UserDataClass.userAuth.IdEmployee;
            //newOrder.DateTimeOrder = DateTime.Now;
            //EFClass.entities.Order.Add(newOrder);
            //EFClass.entities.SaveChanges();


            // добавление купленных товаров 
            foreach (var item in CartListClass.dishesCart)
            {
                if (item != null)
                {
                    var newDishOrder = new DB.DishOrder();
                    newDishOrder.IdOrder = EFClass.entities.Order.ToList().LastOrDefault().IdOrder;
                    newDishOrder.IdDish = item.IdDish;
                    newDishOrder.CountDish = item.CountDish;

                    EFClass.entities.DishOrder.Add(newDishOrder);


                    EFClass.entities.SaveChanges();
                }
            }

            MessageBox.Show("Заказ оформлен!");

            //закрытие окна заказа
            ListOfDishesWindow listOfDishesWindow = new ListOfDishesWindow();
            listOfDishesWindow.Show();
            this.Close();

        }
    }
}
