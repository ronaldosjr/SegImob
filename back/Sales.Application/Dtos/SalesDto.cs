using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sales.Application.Dtos.Common;
using Sales.Domain.Entities;


namespace Sales.Application.Dtos
{
    public class SalesDto : BaseCrudDto
    {
        public SalesDto()
        {

        }       

        [Display(Name = "Vendedor")]
        [Required(ErrorMessage = "{0} deve ser informado")]
        public SellerDto Seller { get; set; }

        [Display(Name = "Items")]
        [Required(ErrorMessage = "{0} devem ser informados")]
        public IEnumerable<SalesItemDto> SalesItem { get; set; }
        public int SellerId { get; set; }
        public decimal Total { get; set; }
    }
}
