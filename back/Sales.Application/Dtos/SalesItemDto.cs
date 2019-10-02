using Sales.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sales.Application.Dtos
{
    public class SalesItemDto : BaseCrudDto
    {
        [Display(Name = "Produto")]
        [Required(ErrorMessage = "{0} deve ser informado")]
        public ProductDto Product { get; set; }

        public int ProductId { get; set; }
        public decimal Amount { get; set; }
        public SalesDto Sales { get; set; }
        public int SalesId { get; set; }
        public decimal Total { get; set; }
    }
}
