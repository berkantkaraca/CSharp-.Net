using System.Globalization;

namespace _17_Class_Lab
{
    public static class OrderExtension
    {
        //Siparişin toplam fiyatını para formatına döndür
        public static double CalculateTotalPrice(this Order order)
        {
            return order.CalculateTotal();
        }

        //Sipariş listesindeki en pahalı ürünü bulun
        public static double GetMaxPrice(this Order order)
        {
            return order.Products.Max(x => x.Price);
        }

        public static Product GetMostExpensive(this Order order)
        {
            return order.Products.OrderByDescending(p => p.Price).FirstOrDefault();
        }

        //belirli bir oranda indirim uygulayan metot(%10)
        public static double ApplyDiscount(this Order order, int rate)
        {
            double totalPrice = order.CalculateTotalPrice();

            return totalPrice - totalPrice * rate / 100;
        }

        /// <summary>
        /// İndirim uygular
        /// </summary>
        /// <param name="order"></param>
        /// <param name="rate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Aralık dışındaysa hata fırlatır</exception>
        public static double ApplyDiscount2(this Order order, int rate)
        {
            if (rate < 0 || rate > 100)
                throw new ArgumentException("Indirim oranı 0-100 arasında olmalı");

            return order.CalculateTotal() * (100 - rate) / 100;
        }

        public static void ApplyDiscount3(this Order order, int rate)
        {
            if (rate < 0 || rate > 100)
                throw new ArgumentException("Indirim oranı 0-100 arasında olmalı");

            //reflection işlemi
            foreach (var product in order.Products)
            {
                typeof(Product)
                .GetProperty("Price")
                ?.SetValue(product, product.Price * (1-rate) / 100);
            }

            Console.WriteLine(rate + " indirim uygulandı");
        }
    }
}
