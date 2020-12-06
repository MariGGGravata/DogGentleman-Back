using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DogGentleman.Controllers.TransferObjects;

namespace DogGentleman.Controllers.Response
{
    public class CarrinhosResponse : BaseResponse
    {

        public List<CarrinhoTO> Carrinhos { get; set; }

    }
}