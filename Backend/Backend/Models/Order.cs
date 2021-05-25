using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public User Сlient { get; set; } // покупатель (не получается заполнить через постман)
        public string Address { get; set; } // адрес доставки
        public string DeliveryType { get; set; } = "Pickup";//по умалчанию самовывоз //Fragile-хрупкая доставка x2 //Express- доставка x3// Normal-обычная x1
        public float Price{
            get
            {
                float cost = 0;
                foreach (var element in Furnitures)
                {
                    cost = cost + element.Price;
                }
                return cost;
            }
        }//Цена без доставки
        public List<Furniture> Furnitures { get; set; } = new List<Furniture> ();//вся ммебель в заказе
        public int NumberOfFurnitures
        {
            get
            {
                return Furnitures.Count();
            }
        }
        public int PriceDelivery
        {
        get
            {
                int EndV = 0;//Конечный объём всех товаров в заказе
                int NetPrice;//Первоначальная цена, исходя из объёма груза
                //Создание объекта для генерации чисел
                Random rnd = new Random();
                //Получить случайное число (в диапазоне от 0 до 10)
                int distance= rnd.Next(1, 20);// от 1 до 20 км
                foreach (var element in Furnitures)
                {
                   int Velement= element.SizeX * element.SizeY * element.SizeZ;
                   EndV = EndV + Velement;
                }

                if (EndV <= 20)//20м^3
                {
                    NetPrice = 1000;
                }
                else if (EndV >= 20 && EndV <= 100)
                {
                    NetPrice = 5000;
                }
                else 
                {
                    NetPrice = 15000;//слишком много груза = слишком много денег
                }

                if (DeliveryType == "Pickup")
                {
                    return 0;//за самовывоз денег не берут
                }
                else if (DeliveryType == "Fragile")//x2
                {
                    return NetPrice * distance*2;
                }
                else if (DeliveryType == "Express")//x3
                {
                    return (NetPrice * distance* 3);
                }
                else if (DeliveryType == "Normal")//x1
                {
                    return NetPrice * distance;
                }
                else //если неправильно указана доставка тогда пусть забирают сами
                {
                    DeliveryType = "Pickup";
                    return 0;
                }

            }
        }


        public OrderInfo GetOrderInfo()
        {
            OrderInfo ordInf = new OrderInfo();
            ordInf.OrderId = OrderId;
            ordInf.NameOfClient = Сlient.Name;
            ordInf.Address = Address;
            ordInf.Price = Price;
            ordInf.NumberOfFurnitures = NumberOfFurnitures;
            ordInf.DeliveryType = DeliveryType;
            ordInf.PriceDelivery = PriceDelivery;
            return ordInf;
        }
        public OrderAndCost GetOrderInfoCost()
        {
            OrderAndCost ordcost = new OrderAndCost();
            ordcost.OrderId = OrderId;
            ordcost.Price = Price;
            return ordcost;
        }

    }

    public class OrderInfo
    {
        public int OrderId { get; set; }
        public string NameOfClient { get; set; }
        public string Address { get; set; }
        public float Price { get; set; }
        public int NumberOfFurnitures { get; set; }
        public string DeliveryType { get; set; }
        public int PriceDelivery { get; set; }
    }

    public class OrderAndCost
    {
        public int OrderId { get; set; }
        public float Price { get; set; }
    }


    
}
