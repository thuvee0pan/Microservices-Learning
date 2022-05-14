﻿using Catelog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catelog.API.Data
{
    public class CatelogContext : ICatelogContext
    {
        public CatelogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));

            CatelogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
