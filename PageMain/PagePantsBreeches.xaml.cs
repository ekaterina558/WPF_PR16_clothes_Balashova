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
using WPF_PR16_clothes_Balashova.ApplicationData;

namespace WPF_PR16_clothes_Balashova.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PagePantsBreeches.xaml
    /// </summary>
    public partial class PagePantsBreeches : Page
    {   
        public PagePantsBreeches()
        {
            InitializeComponent();
            DtGridTovar.ItemsSource = AlisaEntities1.GetContext().Clothes.ToList();

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new PagePantsBreechesAdd((sender as Button).DataContext as Clothes));
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var tovarForRemoving = DtGridTovar.SelectedItems.Cast<Clothes>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующее {tovarForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AlisaEntities1.GetContext().Clothes.RemoveRange(tovarForRemoving);
                    AlisaEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DtGridTovar.ItemsSource = AlisaEntities1.GetContext().Clothes.ToList();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message.ToString());
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new PagePantsBreechesAdd(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            AlisaEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DtGridTovar.ItemsSource = AlisaEntities1.GetContext().Clothes.ToList();

        }
    }
}
