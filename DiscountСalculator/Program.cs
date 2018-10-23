using System;

namespace DiscountСalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вы хотите добавить новый продукт? 1 - да, 2 - нет");

            int.TryParse(Console.ReadLine(), out var answer);

            if (answer != 1)
                return;

            CreateProduct();

            Console.ReadLine();
        }

        private static void CreateProduct()
        {
            var product = new Product();

            Console.WriteLine("Введите название продукта");

            product.Name = Console.ReadLine();

            Console.WriteLine("Введите стоимость продукта");

            int.TryParse(Console.ReadLine(), out var price);

            while (price == 0)
            {
                Console.WriteLine("Стоимость продукта не была введена или она была введена с ошибкой. Пожалуйста, введите стоимость продукта ещё раз");

                int.TryParse(Console.ReadLine(), out price);
            }

            product.Price = price;

            Console.WriteLine("Введите тип скидки: 1 - подарочная карта, 2 - % от стоимости, 3 - сумма от стоимости)");

            int.TryParse(Console.ReadLine(), out int discount_type);

            switch (discount_type)                                          //выбираем тип нашей скидки и передаем туда указатель на экземпляр продукта
            {
                case 1: make_discount1(product);  break;                           //подарочная карта
                        
                case 2: make_discount2(product); break;                            //% от стоимости товара

                case 3: make_discount3(product); break;                            //сумма от стоимости товара

            }

            Console.WriteLine($"Вы успешно добавили новый продукт: {product.Name}, стоимость - {product.Price}р. {product.GetSellInformation()}");
        }


        private static void make_discount1(Product product)
        //функция создания скидки вида подарочная карта
        {
            Console.WriteLine("Введите сумму скидки подарочной карты");     
            int.TryParse(Console.ReadLine(), out int card_money_count);
            product.DiscountValue = card_money_count;                               //записываем скидку в наш продукт

            Console.WriteLine("Введите дату окончания действия подарочной карты");
            DateTime.TryParse(Console.ReadLine(), out DateTime end_card_date);
            product.EndSellDate = end_card_date;                                    //записываем дату окончания действия подарочной карты
        }

        private static void make_discount2(Product product)
         //функция создания скидки вида % от стоимости товара
        { 
            Console.WriteLine("Введите значение скидки на товар (в % от общей стоимости)");

            int.TryParse(Console.ReadLine(), out var discount_percent);

            while (discount_percent > 100)
            {
                Console.WriteLine("Значение скидки не может быть больше 100");

                int.TryParse(Console.ReadLine(), out discount_percent);
            }

            product.DiscountValue = (product.Price / 100) *  discount_percent;      //рассчитываем сумму скидки из процентов в рубли

            Console.WriteLine("Введите дату начала действия скидки");

            DateTime.TryParse(Console.ReadLine(), out var startSellDate);

            if (startSellDate != DateTime.MinValue)
            {
                product.StartSellDate = startSellDate;
            }

            Console.WriteLine("Введите дату окончания действия скидки");

            DateTime.TryParse(Console.ReadLine(), out var endSellDate);

            if (endSellDate != DateTime.MinValue)
            {
                product.EndSellDate = endSellDate;
            }

        }


        private static void make_discount3(Product product)
        //функция создания скидки вида сумма от стоимости
        {
            Console.WriteLine("Введите сумму скидки от стоимости товара");
            int.TryParse(Console.ReadLine(), out int card_money_count);
            product.DiscountValue = card_money_count;                               //записываем скидку в наш продукт
        }



    }
}
