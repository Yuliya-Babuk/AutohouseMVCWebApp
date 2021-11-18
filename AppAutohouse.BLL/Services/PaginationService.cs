using System;

namespace AppAutohouse.BLL.Services
{
    public class PaginationService

    {
        public static int PagesAmountCalculation(int itemsAmount, int itemsPerPage)
        {
            return (int)Math.Ceiling((double)itemsAmount / itemsPerPage);
        }
    }
}
