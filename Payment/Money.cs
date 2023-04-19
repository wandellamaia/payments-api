namespace Entities
{
    public class Money : Payment
    {
        public float _quantity;
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
