// <summary>
// <copyright file="CatalogosController.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Example.Catalogos.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Example.Catalogos.Dtos.Catalogos;
    using Example.Catalogos.Facade.Catalogos;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class Catalogos Controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogosController : ControllerBase
    {
        private readonly ICatalogosFacade logicFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogosController"/> class.
        /// </summary>
        /// <param name="logicFacade">Catalogos Facade.</param>
        public CatalogosController(ICatalogosFacade logicFacade)
        {
            this.logicFacade = logicFacade ?? throw new ArgumentNullException(nameof(logicFacade));
        }

        /// <summary>
        /// Method to get all Catalogos.
        /// </summary>
        /// <returns>List of Catalogos.</returns>
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await this.logicFacade.GetListCatalogosActive();
            return this.Ok(response);
        }

        /// <summary>
        /// Method to get Catalogos By Id.
        /// </summary>
        /// <param name="catalogosId">Catalogos Id.</param>
        /// <returns>Catalogos Model.</returns>
        [Route("{CatalogosId}")]
        [HttpGet]
        public async Task<IActionResult> Get(int catalogosId)
        {
            CatalogosDto response = null;

            response = await this.logicFacade.GetListCatalogosActive(catalogosId);

            return this.Ok(response);
        }

        /// <summary>
        /// Method to Add Catalogos.
        /// </summary>
        /// <param name="dataToStore">Catalogos Model.</param>
        /// <returns>Success or exception.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CatalogosDto dataToStore)
        {
            var response = await this.logicFacade.InsertCatalogos(dataToStore);
            return this.Ok(response);
        }

        /// <summary>
        /// Method to Update Catalogos.
        /// </summary>
        /// <param name="dataToUpdate">Catalogos Model.</param>
        /// <returns>Success or exception.</returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CatalogosDto dataToUpdate)
        {
            var response = await this.logicFacade.UpdateCatalogos(dataToUpdate);
            return this.Ok(response);
        }

        /// <summary>
        /// Method to Delete Catalogos.
        /// </summary>
        /// <param name="dataToDelete">Catalogos Model.</param>
        /// <returns>Success or exception.</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteCatalogos(int dataToDelete)
        {
            var response = await this.logicFacade.DeleteCatalogos(dataToDelete);
            return this.Ok(response);
        }

        /// <summary>
        /// Method Ping.
        /// </summary>
        /// <returns>Pong.</returns>
        [Route("/ping")]
        [HttpGet]
        public IActionResult Ping()
        {
            return this.Ok("Pong");
        }
    }
}