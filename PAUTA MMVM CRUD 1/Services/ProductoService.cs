﻿using PAUTA_MMVM_CRUD_1.Models;
using SQLite;

namespace PAUTA_MMVM_CRUD_1.Services
{
    public class ProductoService
    {
        private readonly SQLiteConnection dbConnection;

        public ProductoService() {
            // Construir ruta
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Producto.db3");

            //Inicializamos el objeto
            dbConnection = new SQLiteConnection(dbPath);

            //Creamos la tabla Producto
            dbConnection.CreateTable<Producto>();
        }

        public List<Producto> GetAll()
        {
            var res = dbConnection.Table<Producto>().ToList();
            return res;
        }

        public int Insert(Producto producto)
        {
            return dbConnection.Insert(producto);
        }

        public int Update(Producto producto)
        {
            return dbConnection.Update(producto);
        }

        public int Delete(Producto producto)
        {
            return dbConnection.Delete(producto);
        }
    }
}
