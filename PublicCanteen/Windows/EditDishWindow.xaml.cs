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
    /// Логика взаимодействия для EditDishWindow.xaml
    /// </summary>
    public partial class EditDishWindow : Window
    {
        string pathImage;
        DB.Dish editDish;
        public EditDishWindow(DB.Dish dish)
        {
            editDish = dish;
            InitializeComponent();
            GetDishData();
        }

        private void GetDishData()
        {
            // заполнение категории
            cmbCategoryDish.ItemsSource = EFClass.entities.CategoryDish.ToList();
            cmbCategoryDish.DisplayMemberPath = "NameCategory";
            cmbCategoryDish.SelectedIndex = 0;

            // заполнение полей блюда

            txtNameDish.Text = editDish.NameDish;
            txtDiscDish.Text = editDish.DiscrDish;
            txtPriceDish.Text = editDish.PriceDish.ToString();
            txtWeightDish.Text = editDish.WeightDish.ToString();
            cmbCategoryDish.SelectedItem = editDish.CategoryDish;

        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                imgImageDish.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                pathImage = openFileDialog.FileName;
            }
        }

        private void btnAddDish_Click(object sender, RoutedEventArgs e)
        {
            
            editDish.NameDish = txtNameDish.Text;
            editDish.DiscrDish = txtDiscDish.Text;
            editDish.PriceDish = Int32.Parse(txtPriceDish.Text);
            editDish.WeightDish = Int32.Parse(txtWeightDish.Text);

            if (pathImage != null)
            {
                editDish.PhotoDish = pathImage;
            }

            editDish.IdCategoryDish = (cmbCategoryDish.SelectedItem as DB.CategoryDish).IdCategory;
           
            EFClass.entities.SaveChanges();
            MessageBox.Show("Изменение прошло успешно");
            this.Close();
        }

       
    }
}
