namespace WareHouse_WebApp.Models
{
    public class CbAll
    {
        public DeliveryNote deliveryNote { get; set; }
        public ProductDetail productDetail { get; set; }
        public List<Manufacturer>? manufacturers { get; set; }

    }
}
