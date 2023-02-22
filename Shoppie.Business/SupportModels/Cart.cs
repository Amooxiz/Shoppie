using Newtonsoft.Json;

namespace Shoppie.Business.SupportModels
{
    public class Cart
    {
        public int ItemCount { get; set; }
        public List<CartProduct> Items { get; set; }

        public Cart()
        {

        }

        public Cart(string? jsonCart)
        {
            if (jsonCart is not null)
            {
                Cart cart = JsonConvert.DeserializeObject<Cart>(jsonCart);
                ItemCount = cart.ItemCount;
                Items = cart.Items;
            }
            else
            {
                ItemCount = 0;
                Items = new List<CartProduct>();
            }
        }

        private int GetNextNr()
        {
            return ItemCount + 1;
        }

        private void ChangeNr(int Nr)
        {
            for (int i = Nr - 1; i < ItemCount; i++)
            {
                Items[i].Nr = Items[i].Nr - 1;
            }
        }

        public void AddItem(CartProduct cartProduct)
        {
            cartProduct.Nr = GetNextNr();
            Items.Add(cartProduct);
            ItemCount++;
        }

        public void RemoveItem(int Nr)
        {
            Items.RemoveAt(Nr - 1);
            ChangeNr(Nr);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
