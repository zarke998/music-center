using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicCenter.EfDataAccess.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsActive", "IsDeleted", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 6, 3, 14, 16, 45, 193, DateTimeKind.Utc).AddTicks(2292), null, true, false, null, "Ratke and Sons" },
                    { 2, new DateTime(2021, 6, 3, 14, 16, 45, 205, DateTimeKind.Utc).AddTicks(4406), null, true, false, null, "Swift, Kulas and Cummings" },
                    { 3, new DateTime(2021, 6, 3, 14, 16, 45, 205, DateTimeKind.Utc).AddTicks(5280), null, true, false, null, "Rath - Runolfsson" },
                    { 4, new DateTime(2021, 6, 3, 14, 16, 45, 205, DateTimeKind.Utc).AddTicks(5409), null, true, false, null, "Zboncak, Schultz and Welch" },
                    { 5, new DateTime(2021, 6, 3, 14, 16, 45, 205, DateTimeKind.Utc).AddTicks(5570), null, true, false, null, "Nitzsche LLC" },
                    { 6, new DateTime(2021, 6, 3, 14, 16, 45, 205, DateTimeKind.Utc).AddTicks(5785), null, true, false, null, "Klocko Group" },
                    { 7, new DateTime(2021, 6, 3, 14, 16, 45, 205, DateTimeKind.Utc).AddTicks(5922), null, true, false, null, "Kassulke Inc" },
                    { 8, new DateTime(2021, 6, 3, 14, 16, 45, 205, DateTimeKind.Utc).AddTicks(6083), null, true, false, null, "Monahan, Mraz and Abbott" },
                    { 9, new DateTime(2021, 6, 3, 14, 16, 45, 205, DateTimeKind.Utc).AddTicks(6325), null, true, false, null, "Connelly Inc" },
                    { 10, new DateTime(2021, 6, 3, 14, 16, 45, 205, DateTimeKind.Utc).AddTicks(6442), null, true, false, null, "Goyette, Ward and Streich" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsActive", "IsDeleted", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 10, new DateTime(2021, 6, 3, 14, 16, 45, 212, DateTimeKind.Utc).AddTicks(2117), null, true, false, null, "Automotive" },
                    { 9, new DateTime(2021, 6, 3, 14, 16, 45, 212, DateTimeKind.Utc).AddTicks(2111), null, true, false, null, "Grocery" },
                    { 8, new DateTime(2021, 6, 3, 14, 16, 45, 212, DateTimeKind.Utc).AddTicks(2106), null, true, false, null, "Movies" },
                    { 7, new DateTime(2021, 6, 3, 14, 16, 45, 212, DateTimeKind.Utc).AddTicks(2101), null, true, false, null, "Kids" },
                    { 6, new DateTime(2021, 6, 3, 14, 16, 45, 212, DateTimeKind.Utc).AddTicks(2088), null, true, false, null, "Industrial" },
                    { 3, new DateTime(2021, 6, 3, 14, 16, 45, 212, DateTimeKind.Utc).AddTicks(2071), null, true, false, null, "Health" },
                    { 4, new DateTime(2021, 6, 3, 14, 16, 45, 212, DateTimeKind.Utc).AddTicks(2077), null, true, false, null, "Beauty" },
                    { 2, new DateTime(2021, 6, 3, 14, 16, 45, 212, DateTimeKind.Utc).AddTicks(2056), null, true, false, null, "Jewelery" },
                    { 1, new DateTime(2021, 6, 3, 14, 16, 45, 212, DateTimeKind.Utc).AddTicks(1106), null, true, false, null, "Baby" },
                    { 5, new DateTime(2021, 6, 3, 14, 16, 45, 212, DateTimeKind.Utc).AddTicks(2083), null, true, false, null, "Electronics" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Email", "FirstName", "Gender", "IsActive", "IsDeleted", "LastName", "ModifiedAt", "Password" },
                values: new object[,]
                {
                    { 4, new DateTime(2021, 6, 3, 14, 16, 45, 257, DateTimeKind.Utc).AddTicks(6366), null, "Diego.Rohan95@yahoo.com", "Ernestina", 0, true, false, "Roob", null, "s02wUjhIRv" },
                    { 1, new DateTime(2021, 6, 3, 14, 16, 45, 239, DateTimeKind.Utc).AddTicks(6063), null, "Kaden.Oberbrunner93@yahoo.com", "Barbara", 1, true, false, "Dibbert", null, "ipP82TpNJp" },
                    { 2, new DateTime(2021, 6, 3, 14, 16, 45, 257, DateTimeKind.Utc).AddTicks(5507), null, "Andrew.Hickle7@gmail.com", "Grady", 0, true, false, "Yost", null, "18xlBRh05I" },
                    { 3, new DateTime(2021, 6, 3, 14, 16, 45, 257, DateTimeKind.Utc).AddTicks(6214), null, "Kurtis_Zemlak26@gmail.com", "Anne", 0, true, false, "Rowe", null, "TPw7hlrFFQ" },
                    { 5, new DateTime(2021, 6, 3, 14, 16, 45, 257, DateTimeKind.Utc).AddTicks(6475), null, "Savanna_Mohr77@hotmail.com", "Benjamin", 0, true, false, "Jones", null, "ub6skoFWX0" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsActive", "IsDeleted", "ModifiedAt", "ShippingAdress", "UserId" },
                values: new object[,]
                {
                    { 9, new DateTime(2021, 6, 3, 14, 16, 45, 274, DateTimeKind.Utc).AddTicks(2217), null, true, false, null, "8526 Goodwin Island, Wilfredborough, Andorra", 5 },
                    { 2, new DateTime(2021, 6, 3, 14, 16, 45, 273, DateTimeKind.Utc).AddTicks(6281), null, true, false, null, "848 Walsh Knolls, Lueilwitzview, Burundi", 1 },
                    { 3, new DateTime(2021, 6, 3, 14, 16, 45, 274, DateTimeKind.Utc).AddTicks(1333), null, true, false, null, "45579 Kuvalis Vista, Otischester, Swaziland", 1 },
                    { 4, new DateTime(2021, 6, 3, 14, 16, 45, 274, DateTimeKind.Utc).AddTicks(1501), null, true, false, null, "827 Cristina Lock, Port Onaburgh, Brazil", 1 },
                    { 11, new DateTime(2021, 6, 3, 14, 16, 45, 274, DateTimeKind.Utc).AddTicks(2460), null, true, false, null, "3622 Kayli Trail, Lake Roslynport, Sri Lanka", 1 },
                    { 7, new DateTime(2021, 6, 3, 14, 16, 45, 274, DateTimeKind.Utc).AddTicks(1963), null, true, false, null, "95110 Guadalupe Meadow, Littleport, Marshall Islands", 2 },
                    { 8, new DateTime(2021, 6, 3, 14, 16, 45, 274, DateTimeKind.Utc).AddTicks(2094), null, true, false, null, "8803 Hackett Turnpike, Spinkachester, Uruguay", 2 },
                    { 5, new DateTime(2021, 6, 3, 14, 16, 45, 274, DateTimeKind.Utc).AddTicks(1647), null, true, false, null, "0513 McKenzie Ports, Helentown, Benin", 5 },
                    { 13, new DateTime(2021, 6, 3, 14, 16, 45, 274, DateTimeKind.Utc).AddTicks(2712), null, true, false, null, "9977 Halle Mountain, New Walkerhaven, Macedonia", 3 },
                    { 1, new DateTime(2021, 6, 3, 14, 16, 45, 264, DateTimeKind.Utc).AddTicks(9127), null, true, false, null, "759 Morgan Spur, Pfannerstillhaven, Malawi", 4 },
                    { 6, new DateTime(2021, 6, 3, 14, 16, 45, 274, DateTimeKind.Utc).AddTicks(1777), null, true, false, null, "31042 Meda Vista, Elainaview, Falkland Islands (Malvinas)", 4 },
                    { 10, new DateTime(2021, 6, 3, 14, 16, 45, 274, DateTimeKind.Utc).AddTicks(2339), null, true, false, null, "04251 Pagac Mountain, Port Mckenzie, Brazil", 4 },
                    { 14, new DateTime(2021, 6, 3, 14, 16, 45, 274, DateTimeKind.Utc).AddTicks(2841), null, true, false, null, "88187 Jerde Lakes, Lilianport, Argentina", 4 },
                    { 15, new DateTime(2021, 6, 3, 14, 16, 45, 274, DateTimeKind.Utc).AddTicks(2957), null, true, false, null, "7649 Stokes Junction, Danielmouth, Serbia", 4 },
                    { 12, new DateTime(2021, 6, 3, 14, 16, 45, 274, DateTimeKind.Utc).AddTicks(2590), null, true, false, null, "2911 Thompson Lake, Shanahanfurt, Slovakia (Slovak Republic)", 3 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreatedAt", "DeletedAt", "Description", "Discount", "ImageUrl", "IsActive", "IsDeleted", "ModifiedAt", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 6, 7, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(7499), null, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 25f, "https://picsum.photos/640/480/?image=305", true, false, null, "Intelligent Wooden Hat", 347.744737140715314m, 432 },
                    { 19, 7, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(8302), null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 7f, "https://picsum.photos/640/480/?image=262", true, false, null, "Tasty Concrete Mouse", 838.037106852530634m, 397 },
                    { 36, 7, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(9126), null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 1f, "https://picsum.photos/640/480/?image=919", true, false, null, "Handcrafted Steel Keyboard", 398.589159769746336m, 17 },
                    { 14, 8, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(7965), null, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 8f, "https://picsum.photos/640/480/?image=703", true, false, null, "Rustic Soft Mouse", 169.880611428003906m, 267 },
                    { 16, 8, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(8085), null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 17f, "https://picsum.photos/640/480/?image=824", true, false, null, "Fantastic Fresh Towels", 968.621729622884172m, 35 },
                    { 17, 8, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(8126), null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 10f, "https://picsum.photos/640/480/?image=359", true, false, null, "Gorgeous Concrete Chips", 813.970804718774916m, 51 },
                    { 30, 8, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(8859), null, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 0f, "https://picsum.photos/640/480/?image=754", true, false, null, "Handcrafted Cotton Shoes", 152.883736037594595m, 376 },
                    { 38, 9, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(9243), null, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 22f, "https://picsum.photos/640/480/?image=973", true, false, null, "Refined Wooden Bacon", 584.356442339884392m, 910 },
                    { 18, 9, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(8236), null, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 5f, "https://picsum.photos/640/480/?image=656", true, false, null, "Ergonomic Soft Table", 482.950619774847324m, 454 },
                    { 33, 9, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(9011), null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 20f, "https://picsum.photos/640/480/?image=887", true, false, null, "Sleek Steel Car", 111.19645485244494m, 723 },
                    { 42, 9, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(9438), null, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 15f, "https://picsum.photos/640/480/?image=148", true, false, null, "Fantastic Soft Table", 129.844105299489132m, 175 },
                    { 46, 9, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(9708), null, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 16f, "https://picsum.photos/640/480/?image=850", true, false, null, "Fantastic Concrete Shirt", 199.23018634330074m, 794 },
                    { 4, 10, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(7400), null, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 3f, "https://picsum.photos/640/480/?image=180", true, false, null, "Awesome Granite Keyboard", 497.62429471715571m, 807 },
                    { 50, 6, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(9868), null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 28f, "https://picsum.photos/640/480/?image=859", true, false, null, "Licensed Wooden Gloves", 326.564678468538423m, 321 },
                    { 44, 10, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(9515), null, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 5f, "https://picsum.photos/640/480/?image=244", true, false, null, "Generic Granite Hat", 697.414009986172719m, 422 },
                    { 39, 8, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(9282), null, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 27f, "https://picsum.photos/640/480/?image=37", true, false, null, "Refined Frozen Bike", 561.614251172455944m, 506 },
                    { 32, 10, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(8933), null, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 14f, "https://picsum.photos/640/480/?image=127", true, false, null, "Refined Plastic Salad", 271.068727557113262m, 85 },
                    { 37, 6, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(9163), null, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 3f, "https://picsum.photos/640/480/?image=761", true, false, null, "Handcrafted Concrete Pizza", 777.262769109225855m, 229 },
                    { 29, 6, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(8818), null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 3f, "https://picsum.photos/640/480/?image=543", true, false, null, "Handmade Steel Soap", 916.698467630286999m, 71 },
                    { 27, 1, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(8699), null, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 9f, "https://picsum.photos/640/480/?image=255", true, false, null, "Small Frozen Hat", 172.468770092571924m, 525 },
                    { 28, 1, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(8737), null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 26f, "https://picsum.photos/640/480/?image=559", true, false, null, "Refined Rubber Chicken", 638.181672001807698m, 207 },
                    { 41, 1, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(9355), null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 2f, "https://picsum.photos/640/480/?image=1069", true, false, null, "Handcrafted Frozen Shoes", 343.348519382694711m, 355 },
                    { 3, 2, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(7331), null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 23f, "https://picsum.photos/640/480/?image=432", true, false, null, "Small Granite Gloves", 341.479385220668904m, 799 },
                    { 12, 2, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(7884), null, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 4f, "https://picsum.photos/640/480/?image=491", true, false, null, "Small Rubber Salad", 836.146672313169861m, 368 },
                    { 24, 2, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(8539), null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 15f, "https://picsum.photos/640/480/?image=794", true, false, null, "Unbranded Granite Soap", 61.1327100326924709m, 757 },
                    { 26, 2, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(8661), null, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 3f, "https://picsum.photos/640/480/?image=59", true, false, null, "Intelligent Granite Hat", 967.673893069231164m, 866 },
                    { 35, 2, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(9089), null, "The Football Is Good For Training And Recreational Purposes", 29f, "https://picsum.photos/640/480/?image=240", true, false, null, "Intelligent Concrete Keyboard", 785.637414294125742m, 847 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreatedAt", "DeletedAt", "Description", "Discount", "ImageUrl", "IsActive", "IsDeleted", "ModifiedAt", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 43, 2, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(9478), null, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 23f, "https://picsum.photos/640/480/?image=606", true, false, null, "Practical Rubber Chicken", 692.461746687284127m, 321 },
                    { 1, 3, new DateTime(2021, 6, 3, 14, 16, 45, 217, DateTimeKind.Utc).AddTicks(8471), null, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 7f, "https://picsum.photos/640/480/?image=907", true, false, null, "Handcrafted Metal Hat", 245.386184629232322m, 496 },
                    { 2, 3, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(7033), null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 9f, "https://picsum.photos/640/480/?image=173", true, false, null, "Generic Frozen Fish", 948.037527468072945m, 461 },
                    { 9, 3, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(7677), null, "The Football Is Good For Training And Recreational Purposes", 27f, "https://picsum.photos/640/480/?image=648", true, false, null, "Tasty Steel Chair", 388.46765941915491m, 283 },
                    { 11, 3, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(7758), null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 17f, "https://picsum.photos/640/480/?image=577", true, false, null, "Handcrafted Granite Chicken", 839.484699811081083m, 465 },
                    { 23, 3, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(8502), null, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 17f, "https://picsum.photos/640/480/?image=124", true, false, null, "Sleek Fresh Shirt", 924.444818672000139m, 732 },
                    { 31, 3, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(8896), null, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 1f, "https://picsum.photos/640/480/?image=1051", true, false, null, "Handcrafted Frozen Pizza", 929.320791748967241m, 273 },
                    { 48, 3, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(9794), null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 28f, "https://picsum.photos/640/480/?image=835", true, false, null, "Sleek Concrete Chair", 11.7684166095072864m, 592 },
                    { 7, 4, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(7590), null, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 26f, "https://picsum.photos/640/480/?image=1006", true, false, null, "Licensed Metal Gloves", 987.550591756380732m, 118 },
                    { 40, 4, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(9318), null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 21f, "https://picsum.photos/640/480/?image=451", true, false, null, "Handcrafted Granite Chips", 655.522097618562543m, 261 },
                    { 45, 4, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(9552), null, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 17f, "https://picsum.photos/640/480/?image=142", true, false, null, "Fantastic Fresh Soap", 769.025823690475215m, 845 },
                    { 49, 4, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(9831), null, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 17f, "https://picsum.photos/640/480/?image=1032", true, false, null, "Gorgeous Plastic Bacon", 127.812609025190235m, 448 },
                    { 5, 5, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(7453), null, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 23f, "https://picsum.photos/640/480/?image=501", true, false, null, "Gorgeous Metal Ball", 477.944766870208731m, 672 },
                    { 8, 5, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(7636), null, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 24f, "https://picsum.photos/640/480/?image=209", true, false, null, "Rustic Concrete Table", 256.019755112947908m, 315 },
                    { 20, 5, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(8386), null, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 12f, "https://picsum.photos/640/480/?image=1076", true, false, null, "Unbranded Wooden Pizza", 205.330119350613381m, 567 },
                    { 21, 5, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(8426), null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 23f, "https://picsum.photos/640/480/?image=560", true, false, null, "Handmade Cotton Fish", 415.127395535878647m, 137 },
                    { 47, 5, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(9756), null, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 24f, "https://picsum.photos/640/480/?image=782", true, false, null, "Generic Metal Ball", 700.128203171365431m, 911 },
                    { 10, 6, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(7717), null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 6f, "https://picsum.photos/640/480/?image=1070", true, false, null, "Generic Cotton Mouse", 5.79944128813196337m, 438 },
                    { 13, 6, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(7927), null, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 12f, "https://picsum.photos/640/480/?image=534", true, false, null, "Handcrafted Plastic Ball", 498.427698728362284m, 602 },
                    { 22, 6, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(8465), null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 11f, "https://picsum.photos/640/480/?image=91", true, false, null, "Awesome Soft Shirt", 575.828275620391308m, 665 },
                    { 25, 6, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(8623), null, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 10f, "https://picsum.photos/640/480/?image=887", true, false, null, "Rustic Steel Bacon", 269.823701242834128m, 817 },
                    { 34, 6, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(9052), null, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 29f, "https://picsum.photos/640/480/?image=595", true, false, null, "Awesome Cotton Shirt", 528.772537356602202m, 106 },
                    { 15, 1, new DateTime(2021, 6, 3, 14, 16, 45, 221, DateTimeKind.Utc).AddTicks(8004), null, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 26f, "https://picsum.photos/640/480/?image=263", true, false, null, "Handmade Rubber Bike", 79.8066705487699242m, 610 }
                });

            migrationBuilder.InsertData(
                table: "OrderProducts",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsActive", "IsDeleted", "ModifiedAt", "Name", "OrderId", "Price", "Quantity" },
                values: new object[,]
                {
                    { 10, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(3806), null, true, false, null, "Refined Frozen Bike", 9, 561.614251172455944m, 1 },
                    { 30, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(4601), null, true, false, null, "Gorgeous Concrete Chips", 5, 813.970804718774916m, 9 },
                    { 7, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(3599), null, true, false, null, "Handcrafted Concrete Pizza", 2, 777.262769109225855m, 2 },
                    { 25, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(4418), null, true, false, null, "Sleek Steel Car", 2, 111.19645485244494m, 1 },
                    { 9, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(3771), null, true, false, null, "Licensed Metal Gloves", 3, 987.550591756380732m, 8 },
                    { 3, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(3439), null, true, false, null, "Awesome Cotton Shirt", 4, 528.772537356602202m, 9 },
                    { 24, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(4379), null, true, false, null, "Awesome Soft Shirt", 4, 575.828275620391308m, 8 },
                    { 5, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(3522), null, true, false, null, "Fantastic Fresh Towels", 11, 968.621729622884172m, 3 },
                    { 18, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(4109), null, true, false, null, "Intelligent Concrete Keyboard", 11, 785.637414294125742m, 9 },
                    { 23, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(4345), null, true, false, null, "Generic Frozen Fish", 11, 948.037527468072945m, 9 },
                    { 29, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(4562), null, true, false, null, "Awesome Granite Keyboard", 7, 497.62429471715571m, 6 },
                    { 6, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(3563), null, true, false, null, "Gorgeous Plastic Bacon", 8, 127.812609025190235m, 4 },
                    { 17, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(4069), null, true, false, null, "Handcrafted Concrete Pizza", 8, 777.262769109225855m, 10 },
                    { 13, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(3924), null, true, false, null, "Small Rubber Salad", 13, 836.146672313169861m, 2 },
                    { 20, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(4235), null, true, false, null, "Fantastic Fresh Towels", 13, 968.621729622884172m, 4 },
                    { 14, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(3960), null, true, false, null, "Sleek Steel Car", 3, 111.19645485244494m, 10 },
                    { 4, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(3486), null, true, false, null, "Unbranded Wooden Pizza", 1, 205.330119350613381m, 6 },
                    { 22, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(4306), null, true, false, null, "Awesome Cotton Shirt", 5, 528.772537356602202m, 2 },
                    { 21, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(4272), null, true, false, null, "Small Rubber Salad", 13, 836.146672313169861m, 9 },
                    { 15, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(3996), null, true, false, null, "Awesome Soft Shirt", 5, 575.828275620391308m, 5 },
                    { 1, new DateTime(2021, 6, 3, 14, 16, 45, 277, DateTimeKind.Utc).AddTicks(9370), null, true, false, null, "Small Rubber Salad", 5, 836.146672313169861m, 5 },
                    { 26, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(4452), null, true, false, null, "Fantastic Fresh Soap", 10, 769.025823690475215m, 6 },
                    { 27, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(4487), null, true, false, null, "Handcrafted Concrete Pizza", 6, 777.262769109225855m, 9 },
                    { 12, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(3882), null, true, false, null, "Sleek Fresh Shirt", 5, 924.444818672000139m, 6 },
                    { 16, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(4035), null, true, false, null, "Fantastic Fresh Towels", 6, 968.621729622884172m, 5 },
                    { 2, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(3314), null, true, false, null, "Unbranded Granite Soap", 6, 61.1327100326924709m, 7 },
                    { 28, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(4528), null, true, false, null, "Handcrafted Frozen Shoes", 1, 343.348519382694711m, 1 },
                    { 11, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(3847), null, true, false, null, "Handcrafted Plastic Ball", 1, 498.427698728362284m, 3 },
                    { 8, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(3638), null, true, false, null, "Licensed Wooden Gloves", 1, 326.564678468538423m, 1 },
                    { 19, new DateTime(2021, 6, 3, 14, 16, 45, 279, DateTimeKind.Utc).AddTicks(4144), null, true, false, null, "Handcrafted Cotton Shoes", 6, 152.883736037594595m, 3 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 27, 3, 13 },
                    { 36, 1, 6 },
                    { 48, 2, 13 },
                    { 8, 3, 22 },
                    { 7, 9, 25 },
                    { 31, 9, 25 },
                    { 14, 2, 29 },
                    { 20, 8, 6 },
                    { 43, 7, 6 },
                    { 35, 4, 46 },
                    { 44, 10, 36 },
                    { 46, 8, 36 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 37, 4, 17 },
                    { 42, 8, 17 },
                    { 11, 8, 30 },
                    { 10, 6, 4 },
                    { 47, 1, 4 },
                    { 1, 7, 32 },
                    { 25, 8, 44 },
                    { 28, 9, 47 },
                    { 30, 1, 19 },
                    { 29, 5, 20 },
                    { 12, 8, 15 },
                    { 2, 9, 8 },
                    { 32, 10, 40 },
                    { 34, 2, 1 },
                    { 16, 10, 7 },
                    { 41, 3, 43 },
                    { 23, 2, 43 },
                    { 22, 2, 35 },
                    { 5, 3, 45 },
                    { 21, 9, 2 },
                    { 50, 8, 2 },
                    { 38, 8, 26 },
                    { 9, 5, 26 },
                    { 49, 8, 1 },
                    { 45, 1, 24 },
                    { 26, 5, 41 },
                    { 6, 3, 5 },
                    { 24, 3, 15 },
                    { 4, 4, 5 },
                    { 15, 10, 27 },
                    { 40, 4, 45 },
                    { 33, 2, 8 },
                    { 19, 5, 7 },
                    { 18, 1, 49 },
                    { 13, 2, 23 },
                    { 3, 1, 12 },
                    { 17, 4, 12 },
                    { 39, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "UserCartProducts",
                columns: new[] { "Id", "ProductId", "Quantity", "UserId" },
                values: new object[,]
                {
                    { 6, 2, 2, 5 },
                    { 14, 1, 2, 1 },
                    { 3, 32, 1, 4 },
                    { 26, 9, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "UserCartProducts",
                columns: new[] { "Id", "ProductId", "Quantity", "UserId" },
                values: new object[,]
                {
                    { 45, 26, 3, 3 },
                    { 2, 43, 5, 2 },
                    { 48, 23, 3, 5 },
                    { 29, 26, 3, 3 },
                    { 23, 26, 2, 4 },
                    { 28, 12, 4, 5 },
                    { 22, 3, 1, 4 },
                    { 13, 41, 3, 4 },
                    { 33, 15, 5, 3 },
                    { 27, 43, 4, 5 },
                    { 9, 31, 1, 3 },
                    { 32, 33, 3, 2 },
                    { 10, 48, 1, 4 },
                    { 8, 47, 2, 5 },
                    { 49, 47, 1, 5 },
                    { 30, 49, 3, 1 },
                    { 17, 49, 3, 1 },
                    { 36, 22, 1, 4 },
                    { 38, 22, 2, 5 },
                    { 12, 45, 1, 3 },
                    { 1, 45, 1, 4 },
                    { 44, 25, 4, 5 },
                    { 43, 29, 3, 1 },
                    { 4, 34, 3, 3 },
                    { 21, 34, 5, 4 },
                    { 46, 34, 4, 3 },
                    { 24, 37, 1, 2 },
                    { 25, 37, 5, 4 },
                    { 42, 37, 1, 2 },
                    { 47, 40, 5, 1 },
                    { 20, 38, 5, 2 },
                    { 35, 33, 5, 2 },
                    { 40, 18, 1, 3 },
                    { 18, 18, 1, 5 },
                    { 16, 39, 5, 4 },
                    { 41, 30, 3, 3 },
                    { 15, 31, 3, 3 },
                    { 11, 48, 1, 2 },
                    { 50, 7, 5, 3 },
                    { 34, 19, 1, 2 },
                    { 7, 40, 3, 1 },
                    { 39, 6, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "UserCartProducts",
                columns: new[] { "Id", "ProductId", "Quantity", "UserId" },
                values: new object[,]
                {
                    { 37, 6, 4, 4 },
                    { 19, 40, 5, 5 },
                    { 31, 17, 3, 1 },
                    { 5, 25, 5, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "UserCartProducts",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
