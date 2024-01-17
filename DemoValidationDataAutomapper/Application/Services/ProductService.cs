using AutoMapper;
using Azure.Core;
using DemoValidationDataAutomapper.Application.Models.Product;
using DemoValidationDataAutomapper.Application.Validations;
using DemoValidationDataAutomapper.Infrastructure.Data.Data;
using Domain.Entities;

namespace DemoValidationDataAutomapper.Application.Services
{
    /// <summary>
    /// Clase que representa el servicio de productos.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly DataContext _data;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor de la clase ProductService.
        /// </summary>
        /// <param name="data">El contexto de datos.</param>
        /// <param name="mapper">El mapeador de objetos.</param>
        public ProductService(DataContext data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }

        #region Validations

        /// <summary>
        /// Agrega un nuevo producto a la base de datos y realiza validaciones manuales en los campos del modelo.
        /// </summary>
        /// <param name="productRequestModel">El modelo de solicitud del producto.</param>
        public void AddValidationManual(ProductManualRequestModel productRequestModel)
        {
            //Validate model campo por campo
            if (string.IsNullOrEmpty(productRequestModel.Name))
            {
                throw new Exception("El nombre es Requerido");
            }

            if (productRequestModel.Price <= 0 && productRequestModel.Price > 10000)
            {
                throw new Exception("El precio es requerido");
            }

            _data.Products.Add(new ProductEntity
            {
                Name = productRequestModel.Name,
                Description = productRequestModel.Description,
                Price = productRequestModel.Price,
                PersonId = productRequestModel.PersonId
            });

            _data.SaveChanges();
        }

        /// <summary>
        /// Agrega las anotaciones de datos a un modelo de solicitud de producto.
        /// </summary>
        /// <param name="productRequestModelOption">El modelo de solicitud de producto.</param>
        public void AddDataAnnotations(ProductRequestModelOption productRequestModelOption)
        {
            //Add product to database
            _data.Products.Add(new ProductEntity
            {
                Name = productRequestModelOption.Name,
                Description = productRequestModelOption.Description,
                Price = productRequestModelOption.Price,
                PersonId = productRequestModelOption.PersonId
            });

            _data.SaveChanges();
        }

        /// <summary>
        /// Agrega validación utilizando FluentValidation a un modelo de solicitud de producto y guarda el producto en la base de datos.
        /// </summary>
        /// <param name="productRequestModel">El modelo de solicitud de producto a validar y agregar a la base de datos.</param>
        public void AddFluentValidation(ProductRequestModel productRequestModel)
        {
            ProductValidation productValidator = new ProductValidation();
            var result = productValidator.Validate(productRequestModel);

            if (!result.IsValid)
            {
                //capturar todos los errores en un solo string
                string errors = string.Join(",", result.Errors.Select(x => x.ErrorMessage).ToArray());
                throw new Exception(errors);
            }

            //Add product to database
            _data.Products.Add(new ProductEntity
            {
                Name = productRequestModel.Name,
                Description = productRequestModel.Description,
                Price = productRequestModel.Price,
                PersonId = productRequestModel.PersonId
            });

            _data.SaveChanges();
        }

        #endregion Validations

        #region Autommaper

        /// <summary>
        /// Agrega un producto a la base de datos utilizando AutoMapper.
        /// </summary>
        /// <param name="productRequestModel">El modelo de solicitud del producto.</param>
        public void AddWithAutoMapper(ProductRequestModel productRequestModel)
        {

            /// <summary>
            /// Mapea un objeto de tipo ProductRequestModel a un objeto de tipo ProductEntity.
            /// </summary>
            /// <param name="productRequestModel">El objeto de tipo ProductRequestModel a mapear.</param>
            /// <returns>El objeto de tipo ProductEntity mapeado.</returns>
            ProductEntity productEntity = _mapper.Map<ProductEntity>(productRequestModel);

            _data.Products.Add(productEntity);
            _data.SaveChanges();
        }

        public void UpdateWithAutoMapper(ProductRequestModel productRequestModel, int id)
        {

            ProductEntity catalogFind = _data.Products.Find(id) ?? throw new Exception("Producto no encontrado");
            ProductEntity mappedEntity = this._mapper.Map(productRequestModel, catalogFind);
            mappedEntity.Id = catalogFind.Id;
            _data.Update(mappedEntity);
            _data.SaveChangesAsync();
        }

        #endregion Autommaper
    }
}
