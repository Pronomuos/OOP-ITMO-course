using System;
using ShopManager.Services.Interfaces;
using ShopManager.Repositories;

namespace ShopManager.Services
{
    public class ShopsService : ShopsRepository, IShopsService
    {}
}