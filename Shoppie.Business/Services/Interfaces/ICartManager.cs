using Microsoft.Data.SqlClient.DataClassification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppie.Business.Services.Interfaces
{
    public interface ICartManager
    {
        public void AddToCart(int offerId);
        public void RemoveFromCart();
    }
}
