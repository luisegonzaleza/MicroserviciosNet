// <summary>
// <copyright file="CatalogosDao.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Example.Catalogos.DataAccess.DAO.Catalogos
{
    using Example.Catalogos.Entities.Context;
    using Example.Catalogos.Entities.Model;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Example.Catalogos.Resources;

    /// <summary>
    /// Class Catalogos Dao
    /// </summary>
    public class CatalogosDao : ICatalogosDao
    {
        private readonly IDatabaseContext databaseContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogosDao"/> class.
        /// </summary>
        /// <param name="databaseContext">DataBase Context</param>
        public CatalogosDao(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CatalogosModel>> GetAllCatalogosAsync()
        {
            return BaseDatos.ListaBaseDatos;
        }

        /// <inheritdoc/>
        public async Task<CatalogosModel> GetCatalogosAsync(int id)
        {
            return BaseDatos.ListaBaseDatos.FirstOrDefault(p => p.Id.Equals(id));
        }

        /// <inheritdoc/>
        public async Task<bool> InsertCatalogos(CatalogosModel model)
        {
            BaseDatos.ListaBaseDatos.Add(model);
            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateCatalogos(CatalogosModel catalogosModel) {
            CatalogosModel user = BaseDatos.ListaBaseDatos.FirstOrDefault(p => p.Id.Equals(catalogosModel.Id));
            user.Id = catalogosModel.Id;
            user.FirstName = catalogosModel.FirstName;
            user.LastName  = catalogosModel.LastName;
            user.Email = catalogosModel.Email;
            user.Birthdate = catalogosModel.Birthdate;
            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteCatalogos(int id) {
            CatalogosModel user = BaseDatos.ListaBaseDatos.FirstOrDefault(p => p.Id.Equals(id));
            return BaseDatos.ListaBaseDatos.Remove(user);
        }
    }
}
