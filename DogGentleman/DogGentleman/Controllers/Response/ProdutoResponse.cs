using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DogGentleman.Controllers.TransferObjects;

namespace DogGentleman.Controllers.Response
{
    public class ProdutoResponse : BaseResponse
    {
        public ProdutoTO Produto { get; set; }
    }
}