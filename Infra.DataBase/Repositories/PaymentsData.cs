using Entities;

namespace Infra.DataBase.Repositories
{
    public class PaymentsData
    {
        public static List<Check> checks = new() { new Check((float)11.0), new Check((float)110.0) };
        public static List<Payment> payments = new() { new Check((float)11.0), new Check((float)110.0) 
                                                , new Money((float)110.0) };

    }
}
