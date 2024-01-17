using DemoValidationDataAutomapper.Application.Models.Product;

namespace DemoValidationDataAutomapper.Application.Services
{
    /// <summary>
    /// Define los métodos para el servicio de productos.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Realiza la validación manual de un modelo de solicitud de producto.
        /// </summary>
        /// <param name="productRequestModel">El modelo de solicitud de producto.</param>
        void AddValidationManual(ProductManualRequestModel productRequestModel);

        /// <summary>
        /// Realiza la validación utilizando anotaciones de datos en un modelo de solicitud de producto.
        /// </summary>
        /// <param name="productRequestModelOption">El modelo de solicitud de producto con opciones.</param>
        void AddDataAnnotations(ProductRequestModelOption productRequestModelOption);

        /// <summary>
        /// Realiza la validación utilizando FluentValidation en un modelo de solicitud de producto.
        /// </summary>
        /// <param name="productRequestModel">El modelo de solicitud de producto.</param>
        void AddFluentValidation(ProductRequestModel productRequestModel);

        /// <summary>
        /// Agrega un producto utilizando AutoMapper para mapear el modelo de solicitud de producto.
        /// </summary>
        /// <param name="productRequestModel">El modelo de solicitud de producto.</param>
        void AddWithAutoMapper(ProductRequestModel productRequestModel);
        void UpdateWithAutoMapper(ProductRequestModel productRequestModel, int id);
    }
}
