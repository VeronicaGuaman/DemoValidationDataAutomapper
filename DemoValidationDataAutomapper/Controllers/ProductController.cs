using DemoValidationDataAutomapper.Application.Models.Product;
using DemoValidationDataAutomapper.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoValidationDataAutomapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("ValidationManual")]
        public IActionResult PostValidationManual([FromBody] ProductManualRequestModel productRequestModel)
        {
            try
            {
                _productService.AddValidationManual(productRequestModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DataAnnotations")]
        public IActionResult PostDataAnnotations([FromBody] ProductRequestModelOption productRequestModelOption)
        {
            try
            {
                _productService.AddDataAnnotations(productRequestModelOption);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("FluentValidation")]
        public IActionResult PostFluentValidation([FromBody] ProductRequestModel productRequestModel)
        {
            try
            {
                _productService.AddFluentValidation(productRequestModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("automapper")]
        public IActionResult PostAutoMapper([FromBody] ProductRequestModel productRequestModel)
        {
            try
            {
                _productService.AddWithAutoMapper(productRequestModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
