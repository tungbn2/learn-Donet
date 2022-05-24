using System.Collections.Generic;
using System;
using System.Linq;

namespace CS30_LinQ
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // todo: Tạo Database giả
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

            // ! MethodArray
            Console.WriteLine("MethodArray:");
            Method();


            // ! câu truy vấn LINQ đầu tiên
            var query = from p in products
                        where p.Price == 400
                        select p;

            foreach (var product in query)
            {
                Console.WriteLine(product.ToString());
            }

            Console.WriteLine("----------------------------------");

            //  ! Mệnh đề from ...in ...
            //  ! mệnh đề select

            var resultSelect = from p in products
                               select p.Name;

            Console.WriteLine("resultSelect: ");
            foreach (var name in resultSelect)
            {
                Console.Write($"{name} - ");
            }


            Console.WriteLine();
            Console.WriteLine("----------------------------------");

            // ! Mệnh đề where lọc dữ liệu

            var resultWhere = from p in products
                              where p.Price > 100 && p.Price < 500
                              select p.Name;

            Console.WriteLine("resultWhere: ");
            foreach (var name in resultSelect) Console.Write($"{name} - ");

            Console.WriteLine();
            Console.WriteLine("----------------------------------");


            // ! from kết hợp
            var resultFromUni = from product in products
                                from color in product.Colors
                                where product.Price < 500
                                where color == "Vàng"
                                select product;

            Console.WriteLine("ketqua ket hop: ");
            foreach (var product in resultFromUni) Console.WriteLine(product.ToString());

            Console.WriteLine();
            Console.WriteLine("----------------------------------");

            // ! Mệnh đề orderby sắp xếp kết quả

            var resultOderBy = from product in products
                               where product.Price <= 300
                               orderby product.Price descending
                               select product;

            Console.WriteLine("ketqua order by: ");
            foreach (var product in resultOderBy) Console.WriteLine($"{product.Name} - {product.Price}");


            Console.WriteLine();
            Console.WriteLine("----------------------------------");

            // ! Mệnh đề group ... by
            var resultGroup = from product in products
                              where product.Price >= 400 && product.Price <= 500
                              group product by product.Price;

            Console.WriteLine("ketqua resultGroup: ");
            foreach (var group in resultGroup)
            {
                Console.WriteLine(group.Key);
                foreach (var product in group)
                {
                    Console.WriteLine($"    {product.Name} - {product.Price}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("----------------------------------");

            // ! let - dùng biến trong truy vấn

            var letQuery = from product in products                  // các sản phẩm trong products
                           group product by product.Price into gr     // ? nhóm thành gr theo giá
                           let count = gr.Count()                                // ? số phần tử trong nhóm
                           select new
                           {                                                                // trả về giá và số sản phầm có giá này
                               price = gr.Key,
                               number_product = count
                           };

            Console.WriteLine("ketqua letQuery: ");
            foreach (var item in letQuery)
            {
                Console.WriteLine($"{item.price} - {item.number_product}");
            }

            Console.WriteLine();
            Console.WriteLine("----------------------------------");

            // ! Mệnh đề join - khớp nối nguồn truy vấn 
            var resultJoin = from product in products
                             join brand in brands on product.Brand equals brand.ID
                             select new
                             {
                                 name = product.Name,
                                 brand = brand.Name,
                                 price = product.Price
                             };

            Console.WriteLine("ketqua resultJoin: ");
            foreach (var item in resultJoin)
            {
                Console.WriteLine($"{item.name,10} {item.price,4} {item.brand,12}");
            }





        }
    }
}
