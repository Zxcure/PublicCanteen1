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
        }


        void GetListDisd()
        {
            LvDish.ItemsSource = EFClass.entities.Dish.ToList();
        }

        void GetListCategoryDisd()
        {
            lvCategoryDish.ItemsSource = EFClass.entities.CategoryDish.ToList();
        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var dish = button.DataContext as DB.Dish; // получаем выбранную запись
                      

            CartListClass.dishes.Add(dish);

            GetListDisd();
            GetListCategoryDisd();
        }
    }
}
