namespace WareHouse_WebApp.Models
{
    public class CbDeliModel
    {
        public List<Customer>? customers { get; set; }
        public List<ProductDetail>? products { get; set; }
        public DeliveryNote? deliveryNotes { get; set; }
        // Thêm các model khác nếu cần
    }

}
