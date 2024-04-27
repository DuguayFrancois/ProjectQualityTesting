using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

namespace Project
{
    class Program
    {
        static int Main(string[] args)
        {
            var test = new InsuranceServiceTests();
            test.RuralAgeLessThan18_ReturnsZero();
            test.RuralAgeBetween18And30_ReturnsCorrect();
            test.RuralAgeGreaterThan30_ReturnsCorrect();
            test.UrbanAgeLessThan18_ReturnsZero();
            test.UrbanAgeBetween18And30_ReturnsCorrect();
            test.UrbanAgeGreaterThan30_ReturnsCorrect();
            test.UnknownLocation_ReturnsZero();
            test.RuralAgeGreaterThan50_ReturnsCorrect();
            test.UrbanAgeGreaterThan50_ReturnsCorrect();
            return 0;
        }
    }

    public class InsuranceService
    {
        private readonly DiscountService discountService;

        public InsuranceService(DiscountService discountService)
        {
            this.discountService = discountService;
        }

        public double CalcPremium(int age, string location)
        {
            double premium;

            if (location == "rural")
            {
                if (age >= 18 && age < 30)
                    premium = 5.0;
                else if (age >= 31)
                    premium = 2.50;
                else
                    premium = 0.0;
            }
            else if (location == "urban")
            {
                if (age >= 18 && age <= 35)
                    premium = 6.0;
                else if (age >= 36)
                    premium = 5.0;
                else
                    premium = 0.0;
            }
            else
            {
                premium = 0.0;
            }

            double discount = discountService.GetDiscount();
            if (age >= 50)
                premium *= discount;

            return premium;
        }
    }

    public class DiscountService()
    {
        public virtual double GetDiscount()
        {
            return 0.8;
        }
}
    }