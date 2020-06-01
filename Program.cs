

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
            int OrderTotalValue = 0;
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
            orderSkuDetails.Add(skus);

            OrderTotalValue = findOrderValue(orderSkuDetails);
        }
        static int findOrderValue(List<OrderSkuDetails> orderSkuDetails)
        {
            int skuAQuantity = 0, skuBQuantity = 0;
            int skuCQuantity =0, skuDQuantity = 0;
            int Aset = 0;int BSet = 0;
            int CDSet = 0, CSet = 0, DSet = 0;
            int reminder = 0;
            int skuAtotal = 0, skuBTotal = 0, skuCDTotal = 0, skuCTotal = 0, skuDTotal = 0, orderTotal = 0;
            if (skuAQuantity > 3)
            {
                Aset = (skuAQuantity / 3) * 130;
                reminder = (skuAQuantity % 3) * 50;
                skuAtotal = Aset + reminder;
            }
            else
                skuAtotal = skuAQuantity * 50;
            reminder = 0;
            if (skuBQuantity > 2)
            {
                BSet = (skuAQuantity / 2) * 45;
                reminder = (skuAQuantity % 2) * 30;
                skuAtotal = Aset + reminder;
            }
            else
                skuBTotal = skuBQuantity * 30;
            if(skuCQuantity >=1 && skuDQuantity >= 1)
            {
                skuCDTotal = skuCQuantity * 30;
            }
            else
            {
                if (skuCQuantity >=1 )
                {
                    skuCTotal = skuCQuantity * 20;
                }
                else if(skuDQuantity >=1)
                    skuDTotal = skuDQuantity * 15;
            }
            orderTotal = skuAtotal + skuBTotal + skuCDTotal + skuCTotal + skuDTotal;
            return 0;
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
