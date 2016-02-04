using System;
using System.Runtime.Serialization;

namespace ManagementStore_DataModel.Product
{
    [DataContract]
    public class ProductObject : BaseModel
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public Amount Amount { get; set; }
        [DataMember]
        public ExpirationDate ExpirationDate { get; set; }
        [DataMember]
        public TVA TVA { get; set; }
        [DataMember]
        public Unit Unit { get; set; }
        [DataMember]
        public Price Price { get; set; }
        [DataMember]
        public CurrencyProduct CurrencyProduct { get; set; }
        [DataMember]
        public Producer Producer { get; set; }
        [DataMember]
        public ProductType ProductType { get; set; }
        [DataMember]
        public Discount Discount { get; set; }
        [DataMember]
        public BarCode BarCode { get; set; }
    }
}
