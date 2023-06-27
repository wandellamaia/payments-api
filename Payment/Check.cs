using System.Xml.Linq;

namespace Entities
{
    public class Check : Payment
    {
        public string _paymentType
        {
            get { return "Check"; }
        }
        public float _quantity { get; set; }
        public Check(float quantity)
        {
            this._quantity = quantity;
        }
        public override float Value()
        {
            return _quantity;
        }
    }
}
