using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Domain.Services;

namespace Infra.DataBase.Repositories
{
    [DbContext(typeof(Payment))]
    public class PaymentsData
    {
        public static List<Check> checks = new() { new Check((float)11.0), new Check((float)110.0) };
        public static List<Payment> payments = new() { new Check((float)11.0), new Check((float)110.0) 
                                                , new Money((float)110.0) };

    }
}
