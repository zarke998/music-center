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
    public class DbSeeder
    {
        private readonly MusicCenterDbContext _context;

        public DbSeeder(MusicCenterDbContext context)
        {
            this._context = context;
        }

        public bool Seed()
        {
            if (!_context.DatabaseEmpty())
                return false;

            var brands = SeedBrands();
            var categories = SeedCategories();
            var products = SeedProducts(brands);
            var productCategories = SeedProductCategories(categories, products);
            var users = SeedUsers();
            var userCartProducts = SeedUserCartProducts(products, users);
            var orders = SeedOrders(users);
            var orderProducts = SeedOrderProducts(products, orders);

            return true;
        }

        private IEnumerable<Brand> SeedBrands()
        {
            var brandsFaker = new Faker<Brand>()
                .RuleFor(b => b.CreatedAt, () => DateTime.UtcNow)
                .RuleFor(b => b.IsActive, () => true)
                .RuleFor(b => b.Name, f => f.Company.CompanyName());

            var brands = brandsFaker.Generate(10);

            _context.Brands.AddRange(brands);
            _context.SaveChanges();

            return brands;
        }
        private IEnumerable<Category> SeedCategories()
        {
            var categoryNames = GenerateCategoryNames(10).ToList();
            var categoryFaker = new Faker<Category>()
                .RuleFor(b => b.CreatedAt, () => DateTime.UtcNow)
                .RuleFor(b => b.IsActive, () => true);

            var categories = categoryFaker.Generate(10);
            for (int i = 0; i < 10; i++)
            {
                categories[i].Name = categoryNames[i];
            }

            _context.Categories.AddRange(categories);
            _context.SaveChanges();

            return categories;
        }
        private IEnumerable<Product> SeedProducts(IEnumerable<Brand> brands)
        {
            var productsFaker = new Faker<Product>()
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

            _context.Products.AddRange(products);
            _context.SaveChanges();

            return products;
        }
        private IEnumerable<ProductCategory> SeedProductCategories(IEnumerable<Category> categories, IEnumerable<Product> products)
        {
            //Debugger.Launch();

            var prodCatFaker = new Faker<ProductCategory>()
                .RuleFor(x => x.ProductId, f => f.PickRandom(products).Id)
                .RuleFor(x => x.CategoryId, f => f.PickRandom(categories).Id);

            var productCategories = prodCatFaker.Generate(50).Distinct(new ProductCategoryComparer());

            _context.ProductCategories.AddRange(productCategories);
            _context.SaveChanges();

            return productCategories;
        }
        private IEnumerable<User> SeedUsers()
        {
            var usersFaker = new Faker<User>()
                .RuleFor(u => u.CreatedAt, () => DateTime.UtcNow)
                .RuleFor(u => u.IsActive, () => true)
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Password, f => f.Internet.Password())
                .RuleFor(u => u.Gender, f => f.PickRandom<Gender>());

            var users = usersFaker.Generate(5);

            _context.Users.AddRange(users);
            _context.SaveChanges();
            return users;
        }
        private IEnumerable<UserCartProduct> SeedUserCartProducts(IEnumerable<Product> products, IEnumerable<User> users)
        {
            var userCartProdFaker = new Faker<UserCartProduct>()
                .RuleFor(x => x.ProductId, f => f.PickRandom(products).Id)
                .RuleFor(x => x.UserId, f => f.PickRandom(users).Id)
                .RuleFor(x => x.Quantity, f => f.Random.Number(1, 5));

            var userCartProducts = userCartProdFaker.Generate(50).Distinct(new UserCartProductComparer());

            _context.UserCartProducts.AddRange(userCartProducts);
            _context.SaveChanges();

            return userCartProducts;
        }
        public IEnumerable<Order> SeedOrders(IEnumerable<User> users)
        {
            var ordersFaker = new Faker<Order>()
                .RuleFor(o => o.CreatedAt, () => DateTime.UtcNow)
                .RuleFor(o => o.IsActive, () => true)
                .RuleFor(o => o.ShippingAdress, f => f.Address.FullAddress())
                .RuleFor(o => o.UserId, f => f.PickRandom(users).Id);

            var orders = ordersFaker.Generate(15);

            _context.Orders.AddRange(orders);
            _context.SaveChanges();

            return orders;

        }
        private IEnumerable<OrderProduct> SeedOrderProducts(IEnumerable<Product> products, IEnumerable<Order> orders)
        {
            var orderProductsFaker = new Faker<OrderProduct>()
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

            _context.OrderProducts.AddRange(orderProducts);
            _context.SaveChanges();

            return orderProducts;
        }

        private IEnumerable<string> GenerateCategoryNames(int count)
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
