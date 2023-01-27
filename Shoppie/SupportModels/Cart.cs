﻿using Newtonsoft.Json;
using Shoppie.ViewModels;

namespace Shoppie.SupportModels
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
                this.ItemCount = cart.ItemCount;
                this.Items = cart.Items;
            }
            else
            {
                this.ItemCount = 0;
                this.Items = new List<CartProduct>();
            }
        }
        
        private int GetNextNr()
        {
            return this.ItemCount + 1;
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
            cartProduct.Nr = this.GetNextNr();
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
