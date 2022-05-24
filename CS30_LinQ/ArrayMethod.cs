using System.Collections.Generic;
using System;
using System.Linq;

namespace CS30_LinQ
{
    public partial class Program
    {
        public static void Method()
        {
            var brands = new List<Brand>() {
                new Brand{ID = 1, Name = "Công ty AAA"},
                new Brand{ID = 2, Name = "Công ty BBB"},
                new Brand{ID = 4, Name = "Công ty CCC"},
            };

            var products = new List<Product>()
            {
                new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
                new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
                new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
                new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
                new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
                new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
                new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
            };

            //  ! Method Select
            Console.ForegroundColor = ConsoleColor.Yellow;

            var brandsNameSelect = brands.Select(b => { return b.Name; });
            Console.WriteLine("brandsNameSelect: ");
            foreach (var name in brandsNameSelect) Console.Write($"{name} -");

            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("----------------------------------");


            //  ! Method SelectMany => trả về một mảng chia nhỏ các kết quả thành list
            Console.ForegroundColor = ConsoleColor.Red;

            var brandsNameSelectMany = brands.SelectMany(b => { return b.Name; });
            Console.WriteLine("brandsNameSelectMany: ");
            foreach (var name in brandsNameSelectMany) Console.Write($"{name} -");

            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("----------------------------------");


            // ! methodWhere
            var methodWhere = brands.Where(b => b.ID >= 2);

            Console.WriteLine("methodWhere: ");
            foreach (var b in methodWhere) Console.Write($"{b.Name} - ");

            Console.WriteLine();
            Console.WriteLine("----------------------------------");


            // ! Method Min, Max, Sum, Average
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine(numbers.Where(n => n % 2 == 0).Max());
            Console.WriteLine(numbers.Average());

            // ! Method join
            Console.WriteLine("Method join");
            var joinMethod = products.Join(brands, p => p.Brand, b => b.ID, (p, b) =>
            {
                return new
                {
                    Ten = p.Name,
                    Brand = b.Name
                };
            });

            foreach (var i in joinMethod) Console.WriteLine($"{i.Ten} - {i.Brand}");

            Console.WriteLine();
            Console.WriteLine("----------------------------------");

            // ! GroupJoin
            Console.WriteLine("Method GroupJoin");

            var GroupJoinMethod = brands.GroupJoin(products, b => b.ID, p => p.Brand, (b, prods) =>
            {
                return new
                {
                    Products = prods,
                    Brand = b.Name
                };
            });

            foreach (var gr in GroupJoinMethod)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{gr.Brand}: ");
                Console.ResetColor();

                foreach (var item in gr.Products)
                {
                    Console.WriteLine($"    - {item.Name}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("----------------------------------");

            //  ! Method Take - lấy 1 số phần tử đầu
            Console.WriteLine("Method Take");

            products.Take(2).ToList().ForEach(item => Console.WriteLine(item));

            Console.WriteLine();
            Console.WriteLine("----------------------------------");


            //  ! Method Skip - bỏ qua 1 số phần tử
            Console.WriteLine("Method Skip");

            products.Skip(2).ToList().ForEach(item => Console.WriteLine(item));

            Console.WriteLine();
            Console.WriteLine("----------------------------------");


            // ! OrderBy / OrderByDescending
            Console.WriteLine("Method OrderBy");

            products.OrderBy(p => p.Price).ToList().ForEach(item => Console.WriteLine(item));
            products.OrderByDescending(p => p.Brand).ToList().ForEach(item => Console.WriteLine(item));

            Console.WriteLine();
            Console.WriteLine("----------------------------------");


            // ! Reverse - Đảo ngược
            Console.WriteLine("Method Reverse");

            products.Reverse();
            products.ToList().ForEach(item => Console.WriteLine(item));

            Console.WriteLine();
            Console.WriteLine("----------------------------------");


            // ! GroupBy
            Console.WriteLine("Method GroupBy");

            var GroupByResult = products.GroupBy(p => p.Brand);

            GroupByResult.ToList().ForEach(item =>
            {
                Console.WriteLine(item.Key);
                item.ToList().ForEach(i => Console.WriteLine(i));
            });



            Console.WriteLine();
            Console.WriteLine("----------------------------------");


            // ! Distinct => lọc phần tử trùng nhau
            Console.WriteLine("Method Distinct");

            products.Select(i => i.Colors).Distinct().ToList().ForEach(item => Console.WriteLine(item));

            Console.WriteLine();
            Console.WriteLine("----------------------------------");


            // ! Single / SingleOrDefault => kiểm tra xem có thỏa mãn điều kiện không
            Console.WriteLine("Method Single");

            Console.WriteLine(products.Single(p => p.Price == 600));
            //    ?  Single  sẽ trả về Exception nếu trong list có nhiều hoặc không có phần tử thỏa mãn
            // ? => nên dùng SingleOrDefault => nếu không thấy trả về null, còn nhiều thì vẫn ra Excption

            // ! Any => có bất kỳ sản phẩm nào thỏa mãn không
            // ! All => tất cả sản phẩm nào thỏa mãn không

            Console.WriteLine(products.Any(p => p.Price == 600));
            Console.WriteLine(products.All(p => p.Price == 600));

            // ! Count => đếm tất cả phần tử
            Console.WriteLine(products.Count(p => p.Price > 100));

            Console.WriteLine();
            Console.WriteLine("----------------------------------");

            // ! Tổng hợp
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("All Method ");

            products.Where(p => p.Price >= 300)
            .OrderBy(p => p.Price)
            .Join(brands, p => p.Brand, b => b.ID, (p, b) =>
            {
                return new
                {
                    TenSP = p.Name,
                    Gia = p.Price,
                    ThuongHieu = b.Name
                };
            })
            .ToList().ForEach(item =>
            {
                Console.WriteLine($"{item.TenSP,15} - {item.Gia,5} - {item.ThuongHieu,10}");
            });



            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("----------------------------------");

        }

    }
}