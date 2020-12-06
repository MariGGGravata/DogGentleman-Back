using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogGentleman.Controllers.TransferObjects
{
    public class ProdutoTO
    {

        public int Id { get; set; }
        public double Preco { get; set; }

        public int Peso { get; set; }
        public string Nome { get; set; }


        
    }
}