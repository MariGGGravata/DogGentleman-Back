using DogGentleman.Controllers.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogGentleman.Controllers.Response
{
    public class ProdutosResponse : BaseResponse
    {
        public List<ProdutoTO> Produtos { get; set; }
    }
}