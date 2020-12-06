using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogGentleman.Models
{

    public partial class Carrinho 
    {
        public static Carrinho Consultar(int id)
        {
            Carrinho carrinho = null;
            using (EntitiesDogGentleman context = new EntitiesDogGentleman())
            {
                var carrinho_ = from Carrinho c in context.CarrinhoSet.Include("Produtos")
                             where c.Id == id
                             select c;

                if (carrinho_.Count() > 0)
                {
                    carrinho = carrinho_.First();
                }
                else
                {
                    throw new NegocioException(NegocioExcCode.CARRINHOIDINEXISTENTE, id.ToString());
                }
            }

            return carrinho;

        }

        public static List<Carrinho> Listar()
        {
            List<Carrinho> carrinhos = new List<Carrinho>();
            using (EntitiesDogGentleman context = new EntitiesDogGentleman())
            {
                carrinhos.AddRange(context.CarrinhoSet);
            }

            return carrinhos;
        }

        public static int Inserir(int quantidade, int idProduto)
        {
            if (quantidade < 0)
            {
                throw new NegocioException(NegocioExcCode.CARRINHOQUANTIDADEVAZIO, "");
            }

            if (quantidade > 9)
            {
                throw new NegocioException(NegocioExcCode.CARRINHOQUANTIDADEMAIORQUENOVE, "");
            }

            int idNovo = -1;

            using (EntitiesDogGentleman context = new EntitiesDogGentleman())
            {
                var produto_ = from Produto p in context.ProdutoSet
                             where p.Id == idProduto
                             select p;

                if (produto_.Count() > 0)
                {
                    Carrinho c = new Carrinho();
                    c.Quantidade = quantidade;
                    c.Produtos = produto_.First();

                    context.CarrinhoSet.Add(c);
                    context.SaveChanges();
                    idNovo = c.Id;
                }
                else
                {
                    throw new NegocioException(NegocioExcCode.PRODUTOIDINEXISTENTE, idProduto.ToString());
                }

            }

            return idNovo;
        }

        public static void Atualizar(int id, int quantidade)
        {
            if (quantidade < 0)
            {
                throw new NegocioException(NegocioExcCode.CARRINHOQUANTIDADEVAZIO, "");
            }

            if (quantidade > 9)
            {
                throw new NegocioException(NegocioExcCode.CARRINHOQUANTIDADEMAIORQUENOVE, "");
            }

            using (EntitiesDogGentleman context = new EntitiesDogGentleman())
            {
                var carrinho_ = from Carrinho c in context.CarrinhoSet
                             where c.Id == id
                             select c;

                if (carrinho_.Count() > 0)
                {

                    Carrinho c = carrinho_.First();
                    c.Quantidade = quantidade;
                    context.SaveChanges();

                }
                else
                {
                    throw new NegocioException(NegocioExcCode.CARRINHOIDINEXISTENTE, id.ToString());
                }

            }
        }

        public static void Remover(int id)
        {
            using (EntitiesDogGentleman context = new EntitiesDogGentleman())
            {
                var produto_ = from Produto p in context.ProdutoSet
                               where p.Racao.Id == id
                               select p;

                if (produto_.Count() > 0)
                {
                    throw new NegocioException(NegocioExcCode.RACAOCOMPRODUTO, id.ToString());
                }

                var carrinho_ = from Carrinho c in context.CarrinhoSet
                             where c.Id == id
                             select c;
                
                if (carrinho_.Count() > 0)
                {
                    context.CarrinhoSet.Remove(carrinho_.First());
                    context.SaveChanges();

                }
                else
                {
                    throw new NegocioException(NegocioExcCode.CARRINHOIDINEXISTENTE, id.ToString());
                }

            }
        }

    }
}