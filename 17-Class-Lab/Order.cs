namespace _17_Class_Lab
{
    public class Order
    {
        private ICollection<Product> _products; //constructorda newlemeyi unutma yoksa null hatası verir

        public Order(int orderId)
        {
            OrderId = orderId;
            _products = new HashSet<Product>();
            OrderDate = DateTime.Now;
        }

        public int OrderId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public IReadOnlyList<Product> Products => _products.ToList().AsReadOnly();

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            _products.Remove(product);
        }

        public double CalculateTotal() => _products.Sum(p => p.Price);
        //Sumdaki yapı aşağıdakini ifade eder
        //public double Total (Product p)
        //{
        //    return p.Price;
        //}

        public string DisplayOrderSummary()
        {
            string baslik = $"Sipariş No: {OrderId} Tarih: {OrderDate} \nÜrün Listesi:";
            foreach (var item in _products)
            {
                baslik += item.DisplayInfo() + "\n";
            }
            return baslik;
        }
    }
}
