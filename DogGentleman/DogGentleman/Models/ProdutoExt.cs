using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DogGentleman.Models
{
    public partial class Produto
    {

        public static Produto Consultar(int id)
        {
            Produto produto = null;
            using (EntitiesDogGentleman context = new EntitiesDogGentleman())
            {
                var produto_ = from Produto p in context.ProdutoSet.Include("Racao")
                               where p.Id == id
                               select p;


                if (produto_.Count() > 0)
                {
                    produto = produto_.First();
                }
                else
                {
                    throw new NegocioException(NegocioExcCode.PRODUTOIDINEXISTENTE, id.ToString());
                }
            }

            return produto;

        }

        public static List<Produto> Listar()
        {
            List<Produto> produtos = new List<Produto>();
            using (EntitiesDogGentleman context = new EntitiesDogGentleman())
            {
                produtos.AddRange(context.ProdutoSet);
            }

            return produtos;
        }

        public static int Inserir(double preço, int idRacao)
        {
            if (preço < 0)
            {
                throw new NegocioException(NegocioExcCode.PRODUTOPRECOVAZIO, "");
            }

            int idNovo = -1;
            
            using (EntitiesDogGentleman context = new EntitiesDogGentleman())
            {
                var racao_ = from Racao r in context.RacaoSet
                             where r.Id == idRacao
                             select r;

                if(racao_.Count() > 0)
                {

                    Produto p = new Produto();
                    p.Preço = preço;
                    p.Racao = racao_.First();

                    context.ProdutoSet.Add(p);
                    context.SaveChanges();
                    idNovo = p.Id;

                }
                else
                {
                    throw new NegocioException(NegocioExcCode.RACAOIDINEXISTENTE, idRacao.ToString());
                }

            }

            return idNovo;


        }

        public static void Atualizar(int id, double preço)
        {
            if (preço < 0)
            {
                throw new NegocioException(NegocioExcCode.PRODUTOPRECOVAZIO, "");
            }

            using (EntitiesDogGentleman context = new EntitiesDogGentleman())
            {
                var produto_ = from Produto p in context.ProdutoSet
                               where p.Id == id
                               select p;

                if (produto_.Count() > 0)
                {

                    Produto p = produto_.First();
                    p.Preço = preço;
                    context.SaveChanges();

                }
                else
                {
                    throw new NegocioException(NegocioExcCode.PRODUTOIDINEXISTENTE, id.ToString());
                }

            }
        }

        public static void Remover(int id)
        {
            using (EntitiesDogGentleman context = new EntitiesDogGentleman())
            {
                var produto_ = from Produto p in context.ProdutoSet
                               where p.Id == id
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