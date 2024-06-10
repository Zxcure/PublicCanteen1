using Microsoft.Win32;
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
    /// Логика взаимодействия для AddDishWindow.xaml
    /// </summary>
    public partial class AddDishWindow : Window
    {

        string pathImage;
        public AddDishWindow()
        {
            InitializeComponent();

            // заполнение категории
            cmbCategoryDish.ItemsSource = EFClass.entities.CategoryDish.ToList();
            cmbCategoryDish.DisplayMemberPath = "NameCategory";
            cmbCategoryDish.SelectedIndex = 0;
        }

        // добавление изображения
        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                imgImageDish.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                pathImage = openFileDialog.FileName;
            }
        }
        //добавление нового блюда 
        private void btnAddDish_Click(object sender, RoutedEventArgs e)
        {
            if (txtNameDish.Text == "Введите название блюда")
            {
                MessageBox.Show("Название блюда не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            DB.Dish newDish = new DB.Dish();
            newDish.NameDish = txtNameDish.Text;
            newDish.DiscrDish = txtDiscDish.Text;
            newDish.PriceDish = Decimal.Parse(txtPriceDish.Text);
            newDish.WeightDish = Int32.Parse(txtWeightDish.Text);

            if (pathImage != null)
            {
                newDish.PhotoDish = pathImage;
            }

            newDish.IdCategoryDish = (cmbCategoryDish.SelectedItem as DB.CategoryDish).IdCategory;
            EFClass.entities.Dish.Add(newDish);
            EFClass.entities.SaveChanges();
            MessageBox.Show("Блюдо успешно добавлено");
            this.Close();
        }
    }
}
