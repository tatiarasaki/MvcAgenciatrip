using MvcAgenciatrip.Models;
using System;
using System.Linq;

namespace MvcAgenciatrip.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MvcAgenciatripContext context)
        {
            context.Database.EnsureCreated();

            // Procura qualquer destino
            if (context.Destino.Any())
            {
                return;   // DB has been seeded
            }

            var destino = new Destino[]
            {
            new Destino{DestinoId=1,EspacoCod="975",Cidade="Guarulhos",UF="SP",Bairro="Cumbica",Descricao="Sobrado com 2 dormitórios sendo 1 suite, 3 banheiros, lavabo, sala de estar, cozinha planejada",Preco=57},
            new Destino{DestinoId=2,EspacoCod="8260",Cidade="Garanhuns",UF="PE",Bairro="Heliópols",Descricao=" 6816 m² Total · 3 Banheiros · 8 Vagas · 5 Quartos · 2 Suítes",Preco=68},
            new Destino{DestinoId=3,EspacoCod="4163",Cidade="Jaraguá do Sul",Bairro="Amizade",Descricao="Com 3 dormitórios, sendo 1 suíte, possui 2 banheiros",Preco=64},
            new Destino{DestinoId=4,EspacoCod="1196",Cidade="Ananindeua",Bairro="Distrito Industrial", Descricao="Casa de condomínio com 4 Quartos",Preco=50},
            new Destino{DestinoId=5,EspacoCod="2206",Cidade="Beberibe",Bairro="Centro",Descricao="Casa com 7 Quartos",Preco=55},
                        };
            foreach (Destino s in destino)
            {
                context.Destino.Add(s);
            }
            context.SaveChanges();

            var pedido = new Pedido[]
            {
            new Pedido{Nome="Mateus",Sobrenome="Fernandes",Email="mateus_fernandes@resource.com.br",CPF="44099939766",DestinoId=1,PedidoData=DateTime.Parse("2005-09-01")},
            new Pedido{Nome="Clara",Sobrenome="Rezende",Email="clara-rezende75@bluewash.com.br",CPF="27131995495",DestinoId=2,PedidoData=DateTime.Parse("2005-09-01")},
            new Pedido{Nome="Henry",Sobrenome="Rocha",Email="henryrocha@balloons.com.br",CPF="51417761741",DestinoId=3,PedidoData=DateTime.Parse("2005-09-01")},
            new Pedido{Nome="Maitê",Sobrenome="da Mata",Email="maitedamata@sigtechbr.com",CPF="46674588520",DestinoId=4,PedidoData=DateTime.Parse("2005-09-01")},
            new Pedido{Nome="Tânia",Sobrenome="Neves",Email="tanianeves@pig.com.br",CPF="92526415993",DestinoId=5,PedidoData=DateTime.Parse("2005-09-01")},
            };
            foreach (Pedido c in pedido)
            {
                context.Pedido.Add(c);
            }
            context.SaveChanges();

            var promocao = new Promocao[]
            {
            new Promocao{PromocaoId=1,DestinoId=2,Desconto=25},
            new Promocao{PromocaoId=2,DestinoId=3,Desconto=10},
            new Promocao{PromocaoId=3,DestinoId=5,Desconto=10},

            };
            foreach (Promocao e in promocao)
            {
                context.Promocao.Add(e);
            }
            context.SaveChanges();
        }
    }
}