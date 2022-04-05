using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcAgenciatrip.Models
{
    public class Destino
    {
        public int DestinoId { get; set; }
        public string EspacoCod { get; set; }
        
        [StringLength(50)] 
        public string Cidade { get; set; }
        
        [StringLength(50)] 
        public string UF { get; set; }
        
        [StringLength(50)] 
        public string Bairro { get; set; }
        
        [StringLength(250)] 
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public ICollection<Promocao> Promocaos { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
    }
}
