using Sales.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Application.Dtos
{
    public class SellerDto : BaseCrudDto
    {
        public string Name { get; set; }
    }
}
