using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogGentleman.Models
{
    public enum NegocioExcCode
    {
        ERRODESCONHECIDO = 1,
        RACAOPESOMENORQUEUM = 101,
        RACAOIDINEXISTENTE = 102,
        RACAOCOMPRODUTO = 103,
        RACAOSEMNOME = 104,
        PRODUTONOMEVAZIO = 201,
        PRODUTOPRECOVAZIO = 202,
        PRODUTOIDINEXISTENTE = 203,
        CARRINHOQUANTIDADEVAZIO = 301,
        CARRINHOQUANTIDADEMAIORQUENOVE = 302,
        CARRINHOIDINEXISTENTE = 303,
        CARRINHOCOMPRODUTO =304


    }

    public class NegocioException : Exception
    {
        
        private string Detalhe { get; }
        public NegocioExcCode Codigo { get; }

        public NegocioException(NegocioExcCode codigo, string detalhe)
            : base(detalhe)
        {
            this.Codigo = codigo;
            this.Detalhe = detalhe;
        }

        public override string Message
        {
            get
            {
                switch(Codigo)
                {
                    case NegocioExcCode.ERRODESCONHECIDO:
                        return "Erro Desconhecido: " + Detalhe;
                    case NegocioExcCode.RACAOPESOMENORQUEUM:
                        return "Ração sem peso.";
                    case NegocioExcCode.RACAOIDINEXISTENTE:
                        return "Id da ração não localizada: " + Detalhe;
                    case NegocioExcCode.RACAOCOMPRODUTO:
                        return "Ração possui produtos cadastrados: " + Detalhe;
                    case NegocioExcCode.RACAOSEMNOME:
                        return "Ração não possui nome.";
                    case NegocioExcCode.PRODUTONOMEVAZIO:
                        return "Produto está em branco.";
                    case NegocioExcCode.PRODUTOPRECOVAZIO:
                        return "Produto está sem preço.";
                    case NegocioExcCode.PRODUTOIDINEXISTENTE:
                        return "Id do produto não localizado: " + Detalhe;
                    case NegocioExcCode.CARRINHOQUANTIDADEVAZIO:
                        return "Quantidade está vazia.";
                    case NegocioExcCode.CARRINHOQUANTIDADEMAIORQUENOVE:
                        return "Não é possível comprar mais de 9 deste produto: " + Detalhe;
                    case NegocioExcCode.CARRINHOIDINEXISTENTE:
                        return "Id do carrinho não localizada: " + Detalhe;
                    case NegocioExcCode.CARRINHOCOMPRODUTO:
                        return "Carrinho possui produto cadastrado: " + Detalhe;
                    default: return "Erro Desconhecido.";

                }
            }
        }

    }
}