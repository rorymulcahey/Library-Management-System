using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public static class Utility
    {
        public static decimal LateFeeRate { get; set; } = 0.25m; // Fee is $0.25 per day

        public static decimal CalculateLateFee(DateTime dueDate, DateTime returnDate)
        {
            if (returnDate <= dueDate)
            {
                return 0;
            }

            int daysLate = (returnDate - dueDate).Days;            
            decimal totalLateFee = daysLate * LateFeeRate;

            return totalLateFee;
        }  

        public static string DisplayBookInfo(this Book book)
        {
            return $"Title: {book.Title} by: {book.Author}";
        }

    }
}
