using PAUTA_MMVM_CRUD_1.Models;
using PAUTA_MMVM_CRUD_1.ViewModels;

namespace PAUTA_MMVM_CRUD_1.Views;

public partial class AddProducto : ContentPage
{
	private AddProductoViewModel viewModel;
	public AddProducto()
	{
		InitializeComponent();
		viewModel = new AddProductoViewModel();
		BindingContext = viewModel;
	}

	public AddProducto(Producto producto)
	{
		InitializeComponent();
		viewModel = new AddProductoViewModel(producto);
		BindingContext = viewModel;
	}
}