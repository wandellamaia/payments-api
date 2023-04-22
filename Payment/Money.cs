namespace Entities
{
    public class Money : Payment
    {
        public string _paymentType
        {
            get { return "Money"; }
        }
        public float _quantity { get; set; }
        public Money(float quantity)
        {
            this._quantity = quantity;
        }

        public override float Value()
        {
            return _quantity;
        }
    }
}
