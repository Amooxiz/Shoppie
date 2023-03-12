﻿using Shoppie.DataAccess.Entities;

namespace Shoppie.DataAccess.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart> GetCartAsync(string userId);
    }
}
