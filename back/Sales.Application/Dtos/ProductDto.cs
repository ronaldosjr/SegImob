using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Sales.Application.Dtos.Common;
using Sales.Domain.Entities;

namespace Sales.Application.Dtos
{
    public class ProductDto : BaseCrudDto
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} do restaurante deve ser informado")]
        [StringLength(Product.NAME_LENGTH, ErrorMessage = "{0} do prato deve conter no máximo {1}")]
        public string Name { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "{0} do prato deve ser informado")]
        [Range(0.00000001, 999999999, ErrorMessage = "{0} deve ser maior que 0.00")]
        public decimal Price { get; set; }
    }

}
