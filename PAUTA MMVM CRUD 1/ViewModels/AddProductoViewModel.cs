
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PAUTA_MMVM_CRUD_1.Models;
using PAUTA_MMVM_CRUD_1.Services;

namespace PAUTA_MMVM_CRUD_1.ViewModels
{
    public partial class AddProductoViewModel : ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private string descripcion;

        private readonly ProductoService service;

        public AddProductoViewModel()
        {
            service = new ProductoService();
        }

        public AddProductoViewModel(Producto producto)
        {
            Id = producto.Id;
            Nombre = producto.Nombre;
            Descripcion = producto.Descripcion;
            service = new ProductoService();
        }

        private void Alerta(String Titulo, String Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]
        private async Task AddUpdate()
        {
            try
            {
                Producto producto = new Producto
                {
                    Id = Id,
                    Nombre = Nombre,
                    Descripcion = Descripcion
                };

                if (producto.Nombre != null || producto.Nombre != "")
                {
                    if (Id == 0)
                    {
                        service.Insert(producto);
                    }
                    else
                    {
                        service.Update(producto);
                    }
                    await App.Current!.MainPage!.Navigation.PopAsync();
                } else
                {
                    Alerta("ADVERTENCIA", "Ingrese el nombre completo");
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }
    }
}
