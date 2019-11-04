namespace AmericaVirtualApi.Models
{
    public class NewProduct
    {
        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Imagen en base64
        /// </summary>
        public string Image { get; set; }

        public decimal Price { get; set; }
    }
}
