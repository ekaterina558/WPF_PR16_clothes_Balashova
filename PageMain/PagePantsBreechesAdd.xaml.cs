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
    /// Логика взаимодействия для PagePantsBreechesAdd.xaml
    /// </summary>
    public partial class PagePantsBreechesAdd : Page
    {
        private Clothes _currentClothes = new Clothes ();
        public PagePantsBreechesAdd(Clothes selectedClothes)
        {
            InitializeComponent();
            if (selectedClothes != null)
                _currentClothes = selectedClothes;
            DataContext = _currentClothes;
            ComboStrana.ItemsSource = AlisaEntities1.GetContext().Strana.ToList();
            ComboRazmer.ItemsSource = AlisaEntities1.GetContext().Razmer.ToList();
            ComboCvet.ItemsSource = AlisaEntities1.GetContext().Cvet.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder err0rs = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentClothes.naimenov))
                err0rs.AppendLine("Укажите название товара");
            if (_currentClothes.kolichestvo <= 0)
                err0rs.AppendLine("Количество товара не может быть меньше или равно 0");
            if (_currentClothes.cena <= 0)
                err0rs.AppendLine("Цена не может быть меньше или равно 0");
            if (_currentClothes.Strana == null)
                err0rs.AppendLine("Выберите страну");
            if (_currentClothes.Razmer == null)
                err0rs.AppendLine("Выберите размер");
            if (_currentClothes.Cvet == null)
                err0rs.AppendLine("Выберите цвет");


            if (err0rs.Length > 0)
            {
                MessageBox.Show(err0rs.ToString());
                return;
            }
            //добавление
            if (_currentClothes.id == 0)
                AlisaEntities1.GetContext().Clothes.Add(_currentClothes);

            //обработка вариант выпада/записи данных
            try
            {
                AlisaEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
