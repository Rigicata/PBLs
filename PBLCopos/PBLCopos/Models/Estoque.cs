using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBLCopos.Models
{
    public class Estoque
    {
        public int EstoqueId { get; set; }
        public int SacosdeCopo { get; set; }
        public int Qtd_ML { get; set; }
        public virtual ICollection<Bebedouro>Bebedouros{ get; set; }


        public void diminuiSacos()
        {
            SacosdeCopo = SacosdeCopo - 1;
        }
    }
}