using Bogus;
using Microsoft.EntityFrameworkCore;
using MusicCenter.Domain.Comparers;
using MusicCenter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.EfDataAccess
{
    public static class DbSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var brands = GenerateBrands();
            var categories = GenerateCategories();
            var products = GenerateProducts(brands);
            var productCategories = GenerateProductCategories(categories, products);
            var users = GenerateUsers();
            var userCartProducts = GenerateUserCartProducts(products, users);
            var orders = GenerateOrders(users);
            var orderProducts = GenerateOrderProducts(products, orders);

            modelBuilder.Entity<Brand>().HasData(brands);
            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<ProductCategory>().HasData(productCategories);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<UserCartProduct>().HasData(userCartProducts);
            modelBuilder.Entity<Order>().HasData(orders);
            modelBuilder.Entity<OrderProduct>().HasData(orderProducts);
        }

        private static IEnumerable<OrderProduct> GenerateOrderProducts(IEnumerable<Product> products, IEnumerable<Order> orders)
        {
            var orderProductIds = 1;
            var orderProductsFaker = new Faker<OrderProduct>()
                .RuleFor(b => b.Id, f => orderProductIds++)
                .RuleFor(b => b.CreatedAt, () => DateTime.UtcNow)
                .RuleFor(b => b.IsActive, () => true)
                .Rules((f, op) =>
                {
                    var randomProduct = f.PickRandom(products);
                    op.Name = randomProduct.Name;
                    op.Price = randomProduct.Price;
                })
                .RuleFor(op => op.Quantity, f => f.Random.Number(1, 10))
                .RuleFor(op => op.OrderId, f => f.PickRandom(orders).Id);

            var orderProducts = orderProductsFaker.Generate(30);
            return orderProducts;
        }

        private static IEnumerable<UserCartProduct> GenerateUserCartProducts(IEnumerable<Product> products, IEnumerable<User> users)
        {
            var userCartProdIds = 1;
            var userCartProdFaker = new Faker<UserCartProduct>()
                .RuleFor(x => x.Id, () => userCartProdIds++)
                .RuleFor(x => x.ProductId, f => f.PickRandom(products).Id)
                .RuleFor(x => x.UserId, f => f.PickRandom(users).Id)
                .RuleFor(x => x.Quantity, f => f.Random.Number(1, 5));

            var userCartProducts = userCartProdFaker.Generate(50).Distinct(new UserCartProductComparer());
            return userCartProducts;
        }
        private static IEnumerable<User> GenerateUsers()
        {
            var userIds = 1;
            var usersFaker = new Faker<User>()
                .RuleFor(u => u.Id, () => userIds++)
                .RuleFor(u => u.CreatedAt, () => DateTime.UtcNow)
                .RuleFor(u => u.IsActive, () => true)
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Password, f => f.Internet.Password())
                .RuleFor(u => u.Gender, f => f.PickRandom<Gender>());

            var users = usersFaker.Generate(5);
            return users;
        }
        private static IEnumerable<ProductCategory> GenerateProductCategories(IEnumerable<Category> categories, IEnumerable<Product> products)
        {
            //Debugger.Launch();

            var productCategoryIds = 1;
            var prodCatFaker = new Faker<ProductCategory>()
                .RuleFor(x => x.Id, () => productCategoryIds++)
                .RuleFor(x => x.ProductId, f => f.PickRandom(products).Id)
                .RuleFor(x => x.CategoryId, f => f.PickRandom(categories).Id);

            var productCategories = prodCatFaker.Generate(50).Distinct(new ProductCategoryComparer());
            return productCategories;
        }
        private static IEnumerable<Product> GenerateProducts(IEnumerable<Brand> brands)
        {
            var productIds = 1;
            var productsFaker = new Faker<Product>()
                .RuleFor(b => b.Id, f => productIds++)
                .RuleFor(b => b.CreatedAt, () => DateTime.UtcNow)
                .RuleFor(b => b.IsActive, () => true)
                .RuleFor(b => b.Name, f => f.Commerce.ProductName())
                .RuleFor(b => b.Description, f => f.Commerce.ProductDescription())
                .RuleFor(b => b.Price, f => f.Random.Decimal(0, 999))
                .RuleFor(b => b.Discount, f => f.Random.Number(30))
                .RuleFor(b => b.Quantity, f => f.Random.Number(10, 1000))
                .RuleFor(b => b.ImageUrl, f => f.Image.PicsumUrl())
                .RuleFor(b => b.BrandId, f => f.PickRandom(brands).Id);

            var products = productsFaker.Generate(50).Distinct(new ProductComparer());
            return products;
        }
        private static IEnumerable<Category> GenerateCategories()
        {
            var categoryIds = 1;
            var categoryNames = GenerateCategoryNames(10).ToList();
            var categoryFaker = new Faker<Category>()
                .RuleFor(b => b.Id, f => categoryIds++)
                .RuleFor(b => b.CreatedAt, () => DateTime.UtcNow)
                .RuleFor(b => b.IsActive, () => true);

            var categories = categoryFaker.Generate(10);
            for (int i = 0; i < 10; i++)
            {
                categories[i].Name = categoryNames[i];
            }

            return categories;
        }
        private static IEnumerable<Brand> GenerateBrands()
        {
            var brandIds = 1;
            var brandsFaker = new Faker<Brand>()
                .RuleFor(b => b.Id, f => brandIds++)
                .RuleFor(b => b.CreatedAt, () => DateTime.UtcNow)
                .RuleFor(b => b.IsActive, () => true)
                .RuleFor(b => b.Name, f => f.Company.CompanyName());

            var brands = brandsFaker.Generate(10);
            return brands;
        }
        public static IEnumerable<Order> GenerateOrders(IEnumerable<User> users)
        {
            var orderIds = 1;
            var ordersFaker = new Faker<Order>()
                .RuleFor(o => o.Id, f => orderIds++)
                .RuleFor(o => o.CreatedAt, () => DateTime.UtcNow)
                .RuleFor(o => o.IsActive, () => true)
                .RuleFor(o => o.ShippingAdress, f => f.Address.FullAddress())
                .RuleFor(o => o.UserId, f => f.PickRandom(users).Id);

            var orders = ordersFaker.Generate(15);
            return orders;

        }

        private static IEnumerable<string> GenerateCategoryNames(int count)
        {
            var categories = new List<string>();

            var faker = new Faker();
            var retryAttempts = 0;
            while (categories.Count < count)
            {
                if (retryAttempts > 20)
                    return null;

                var randomNewCategories = faker.Commerce.Categories(count).Distinct().Except(categories);
                // If no new categories are generated
                if (randomNewCategories.Count() == 0)
                {
                    retryAttempts++;
                    continue;
                }

                categories.AddRange(randomNewCategories);
            }

            return categories.Take(count);
        }
    }

}
