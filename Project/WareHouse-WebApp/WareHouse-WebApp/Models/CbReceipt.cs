namespace WareHouse_WebApp.Models
{
    public class CbReceipt
    {
        public GoodsReceipt? goodsReceipt { get; set; }
        public List<Manufacturer>? manufacturers { get; set; }
        public List<ProductDetail>? products { get; set; }
    }
}
