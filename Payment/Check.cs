namespace Entities
{
    public class Check : Payment
    {
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
