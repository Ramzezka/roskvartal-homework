using System;

namespace DiscountСalculator
{
    public class Product : IDiscount
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int DiscountValue { get; set; }
        public DateTime? StartSellDate { get; set; }
        public DateTime? EndSellDate { get; set; }


        public string GetSellInformation()
        {
            if(     DiscountValue == 0 ||                                                       //скидки нет
                    (StartSellDate.HasValue && (StartSellDate > DateTime.UtcNow))  ||           //действие скидки еще не началось
                    (EndSellDate.HasValue && (EndSellDate < DateTime.UtcNow)) )                 //действие скидки уже закончилось
            {
                return "В настоящий момент на данный товар нет скидок."; 
            }
            else 
            {
                int end_price = Price - DiscountValue;              //итоговая ценв

                string end_string = "";                             //итоговая строка

                //формируем итоговую строку
                end_string += " На данный товар действует скидка " + DiscountValue.ToString() + "р. ";
                if (StartSellDate.HasValue) end_string += " в период с " + StartSellDate.Value.ToShortDateString();
                if (EndSellDate.HasValue) end_string += " по " + EndSellDate.Value.ToShortDateString() + ". ";
                end_string += " Сумма с учётом скидки - " + end_price.ToString() + "р.";


                return end_string;
                        
            }
        }
    }        
}
