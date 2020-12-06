using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogGentleman.Models
{
    public partial class Racao
    {
        public static Racao Consultar(int id)
        {
            Racao racao = null;
            using (EntitiesDogGentleman context = new EntitiesDogGentleman())
            {
                var racao_ = from Racao r in context.RacaoSet
                             where r.Id == id
                             select r;

                if(racao_.Count() > 0)
                {
                    racao = racao_.First();
                }
                else
                {
                    throw new NegocioException(NegocioExcCode.RACAOIDINEXISTENTE, id.ToString());
                }
            }

            return racao;

        }

        public static List<Racao> Listar()
        {
            List<Racao> racoes = new List<Racao>();
            using(EntitiesDogGentleman context = new EntitiesDogGentleman())
            {
                racoes.AddRange(context.RacaoSet);
            }

            return racoes;
        }

        public static int Inserir(int peso, string nome)
        {
            if(peso < 1)
            {
                throw new NegocioException(NegocioExcCode.RACAOPESOMENORQUEUM, "");
            }
            if(nome.Length == 0)
            {
                throw new NegocioException(NegocioExcCode.RACAOSEMNOME, "");
            }

            int idNovo = -1;

            using (EntitiesDogGentleman context = new EntitiesDogGentleman())
            {
                Racao r = new Racao();
                r.Peso = peso;
                r.Nome = nome;

                context.RacaoSet.Add(r);
                context.SaveChanges();
                idNovo = r.Id;

            }

            return idNovo;
        }

        public static void Atualizar(int id, int peso, string nome)
        {
            if (peso < 1)
            {
                throw new NegocioException(NegocioExcCode.RACAOPESOMENORQUEUM, "");
            }

            using (EntitiesDogGentleman context = new EntitiesDogGentleman())
            {
                var racao_ = from Racao r in context.RacaoSet
                             where r.Id == id
                             select r;

                if (racao_.Count() > 0)
                {

                    Racao r = racao_.First();
                    r.Peso = peso;
                    r.Nome = nome;
                    context.SaveChanges();

                }
                else
                {
                    throw new NegocioException(NegocioExcCode.RACAOIDINEXISTENTE, id.ToString());
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

                if(produto_.Count() > 0)
                {
                    throw new NegocioException(NegocioExcCode.RACAOCOMPRODUTO, id.ToString());
                }

                var racao_ = from Racao r in context.RacaoSet
                             where r.Id == id
                             select r;

                if (racao_.Count() > 0)
                {
                    context.RacaoSet.Remove(racao_.First());
                    context.SaveChanges();

                }
                else
                {
                    throw new NegocioException(NegocioExcCode.RACAOIDINEXISTENTE, id.ToString());
                }

            }
        }
    }
}