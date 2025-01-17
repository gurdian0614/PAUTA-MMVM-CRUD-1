﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PAUTA_MMVM_CRUD_1.Models;
using PAUTA_MMVM_CRUD_1.Services;
using PAUTA_MMVM_CRUD_1.Views;
using System.Collections.ObjectModel;

namespace PAUTA_MMVM_CRUD_1.ViewModels
{
    public partial class ProductoMainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Producto> productoCollection = new ObservableCollection<Producto>();

        private readonly ProductoService service;

        public ProductoMainViewModel()
        {
            service = new ProductoService();
        }

        public void GetAll()
        {
            var getAll = service.GetAll();

            // Valido si la lista contiene registros
            if (getAll?.Count() > 0)
            {
                ProductoCollection.Clear();
                foreach (var empleado in getAll)
                {
                    ProductoCollection.Add(empleado);
                }
            }
        }

        [RelayCommand]
        private async Task goToAddProductoForm()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddProducto());
        }

        [RelayCommand]
        private async Task SelectProducto(Producto producto)
        {
            try
            {
                string res = await App.Current!.MainPage!.DisplayActionSheet("Opciones", "Cancelar", null, "Actualizar", "Eliminar");

                switch (res)
                {
                    case "Actualizar":
                        await App.Current.MainPage.Navigation.PushAsync(new AddProducto(producto));
                        break;
                    case "Eliminar":
                        bool respuesta = await App.Current!.MainPage!.DisplayAlert("ELIMINAR PRODUCTO", "¿Desea eliminar el registro de producto?", "Si", "No");

                        if (respuesta)
                        {
                            int del = service.Delete(producto);

                            if (del > 0)
                            {
                                ProductoCollection.Remove(producto);
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

        private void Alerta(String Titulo, String Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }
    }
}
