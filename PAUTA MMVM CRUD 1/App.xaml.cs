using PAUTA_MMVM_CRUD_1.Views;

namespace PAUTA_MMVM_CRUD_1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ProductoMain());
        }
    }
}
