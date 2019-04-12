using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBLCopos.Models
{
    public enum StatusCopo  { Tem,NaoTem }
    public class Bebedouro
    {
        public int BebedouroId { get; set; }
        public string Localizacao { get; set; }
        public StatusCopo StatusCopo { get; set; }
        public int EstoqueId { get; set; }
        public Estoque Estoque { get; set; }



        public Bebedouro()
        {
            StatusCopo = StatusCopo.Tem;
        }



    }
}