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
using WPF_PR16_clothes_Balashova.PageMain;

namespace WPF_PR16_clothes_Balashova
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppConnect.modelObd = new AlisaEntities1(); //соединение с БД
            AppFrame.FrameMain = FrmMain; //загрузка фрейма
            FrmMain.Navigate(new PagePantsBreeches()); //страница PageToster
        }
    }
}
