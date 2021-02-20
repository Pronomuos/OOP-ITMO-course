using ShopManager.Models;
using ShopManager.Repositories;
using ShopManager.Services.Interfaces;
using System;

namespace ShopManager.Services
{
    public class ProductTypesService : ProductTypesRepository, IProductTypesService
    {}
}