using PAUTA_MMVM_CRUD_1.ViewModels;

namespace PAUTA_MMVM_CRUD_1.Views;

public partial class ProductoMain : ContentPage
{
	private ProductoMainViewModel viewModel;
	public ProductoMain()
	{
		InitializeComponent();
		viewModel = new ProductoMainViewModel();
		BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.GetAll();
    }
}