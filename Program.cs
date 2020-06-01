using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionENgine
{
    class Program
    {
        static void Main(string[] args)
        {
            List<OrderSkuDetails> orderSkuDetails = new List<OrderSkuDetails>();
            OrderSkuDetails skus = new OrderSkuDetails();
            skus.orderSetId = 1;
            skus.skuAQuantity = 1;
            skus.skuBQuantity = 1;
            skus.skuCQuantity = 1;
            orderSkuDetails.Add(skus);
            skus = new OrderSkuDetails();
            skus.orderSetId = 2;
            skus.skuAQuantity = 5;
            skus.skuBQuantity = 5;
            skus.skuCQuantity = 1;
            orderSkuDetails.Add(skus);
            skus = new OrderSkuDetails();
            skus.orderSetId = 3;
            skus.skuAQuantity = 3;
            skus.skuDQuantity = 1;
            skus.skuBQuantity = 5;
            skus.skuCQuantity = 1;
            orderSkuDetails.Add(skus);

            orderSkuDetails = findOrderValue(orderSkuDetails);

            //printing order total value for each set
            foreach(var orderValue in orderSkuDetails)
            {
                Console.WriteLine("Total Order value of OrderSet {0} is {1}",orderValue.orderSetId, orderValue.totalOderValue);
            }
            Console.ReadLine();
        }
        static  List<OrderSkuDetails> findOrderValue(List<OrderSkuDetails> orderSkuDetails)
        {
            int skuAQuantity = 0, skuBQuantity = 0;
            int skuCQuantity =0, skuDQuantity = 0;

            int skuAtotal = 0, skuBTotal = 0, skuCDTotal = 0, skuCTotal = 0, skuDTotal = 0, orderTotal = 0;
            foreach(var orders in orderSkuDetails)
            {
                skuAQuantity = orders.skuAQuantity;
                skuBQuantity = orders.skuBQuantity;
                skuCQuantity = orders.skuCQuantity;
                skuDQuantity = orders.skuDQuantity;

                if (skuAQuantity >= 3)
                {
                    skuAtotal = (skuAQuantity / 3) * 130;
                    skuAtotal = skuAtotal + ((skuAQuantity % 3) * 50);
                }
                else
                    skuAtotal = skuAQuantity * 50;

                if (skuBQuantity >= 2)
                {
                    skuBTotal = (skuBQuantity / 2) * 45;
                    skuBTotal = skuBTotal + ((skuBQuantity % 2) * 30);
                }
                else
                    skuBTotal = skuBQuantity * 30;

                if (skuCQuantity >= 1 && skuDQuantity >= 1)
                {
                    skuCDTotal = skuCQuantity * 30;
                }
                else
                {
                    if (skuCQuantity >= 1)
                    {
                        skuCTotal = skuCQuantity * 20;
                    }
                    else if (skuDQuantity >= 1)
                        skuDTotal = skuDQuantity * 15;
                }
                orderTotal = skuAtotal + skuBTotal + skuCDTotal + skuCTotal + skuDTotal;

                //Reset total value of each item at end of iteration
                skuAtotal = 0;
                skuBTotal = 0;
                skuCTotal = 0;
                skuDTotal = 0;
                orders.totalOderValue = orderTotal;
            }

           
            return orderSkuDetails;
        }
    }
    public class OrderSkuDetails
    {
        public int orderSetId { get; set; }
        public int skuAQuantity { get; set; }
        public int skuBQuantity { get; set; }
        public int skuCQuantity { get; set; }
        public int skuDQuantity { get; set; }
        public int totalOderValue { get; set; }
    }
}
