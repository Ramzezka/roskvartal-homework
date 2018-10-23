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
        
        public int CalculateDiscountPrice()
        {

            //переделано на IF + DiscountValue теперь хранит не % , а сумму скидки (унифицировано под все типы скидок)
            if (     DiscountValue != 0 &&
                    StartSellDate.HasValue &&
                    EndSellDate.HasValue &&
                    StartSellDate <= DateTime.UtcNow &&
                    EndSellDate >= DateTime.UtcNow  )
            {
                return Price - DiscountValue;
            }
            else
            {
                return Price;
            }



            //return DiscountValue != 0 &&
            //        StartSellDate.HasValue &&
            //        EndSellDate.HasValue &&
            //        StartSellDate <= DateTime.UtcNow &&
            //        EndSellDate >= DateTime.UtcNow
            //    ? Price - (Price * DiscountValue / 100)
            //    : Price;
        }

        public string GetSellInformation()
        {
            if(DiscountValue != 0 && (StartSellDate.HasValue && EndSellDate.HasValue)
            {
                wtf
            }


            return DiscountValue != 0 && StartSellDate.HasValue && EndSellDate.HasValue
                ? $"На данный товар действует скидка {DiscountValue}% в период с {StartSellDate.Value.ToShortDateString()} по {EndSellDate.Value.ToShortDateString()}. " +
                    $"Сумма с учётом скидки - {CalculateDiscountPrice()}р."
                : "В настоящий момент на данный товар нет скидок.";
        }
    }        
}
