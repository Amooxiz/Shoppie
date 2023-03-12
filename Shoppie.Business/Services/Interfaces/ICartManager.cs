using Microsoft.Data.SqlClient.DataClassification;
using Shoppie.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace Shoppie.Business.Services.Interfaces
{
    public interface ICartManager
    {
        Task AddToCart(int offerId);
        Task RemoveFromCart();
        Task<Cart?> FindCart();
        Task<Cart?> GetCart();
    }
}
