namespace _52_SwaggerOpenAPI.Models.Product
{
    public class ProductSaveDto
    {
        //Swagger UI'da Name property'si için "Macbook Pro" örneği gösterilir.
        /// <example>Macbook Pro</example>
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
