#region Instructions
/*
 * You are tasked with writing an algorithm that determines the value of a used car, 
 * given several factors.
 *
 *    AGE:    Given the number of months of how old the car is, reduce its value one-half 
 *            (0.5) percent.
 *            After 10 years, it's value cannot be reduced further by age. This is not 
 *            cumulative.
 *            
 *    MILES:    For every 1,000 miles on the car, reduce its value by one-fifth of a
 *              percent (0.2). Do not consider remaining miles. After 150,000 miles, it's 
 *              value cannot be reduced further by miles.
 *            
 *    PREVIOUS OWNER:    If the car has had more than 2 previous owners, reduce its value 
 *                       by twenty-five (25) percent. If the car has had no previous  
 *                       owners, add ten (10) percent of the FINAL car value at the end.
 *                    
 *    COLLISION:        For every reported collision the car has been in, remove two (2) 
 *                      percent of it's value up to five (5) collisions.
 *
 *    RELIABILITY:      If the Make is Toyota, add 5%.  If the Make is Ford, subtract $500.
 *
 *
 *    PROFITABILITY:    The final calculated price cannot exceed 90% of the purchase price. 
 *    
 * 
 *    Each factor should be off of the result of the previous value in the order of
 *        1. AGE
 *        2. MILES
 *        3. PREVIOUS OWNER
 *        4. COLLISION
 *        5. RELIABILITY
 *        
 *    E.g., Start with the current value of the car, then adjust for age, take that  
 *    result then adjust for miles, then collision, previous owner, and finally reliability. 
 *    Note that if previous owner, had a positive effect, then it should be applied 
 *    AFTER step 5. If a negative effect, then BEFORE step 5.
 */
#endregion

using System;
using NUnit.Framework;

namespace CarPricer
{
    public class Car
    {
        public decimal PurchaseValue { get; set; }        
        public int AgeInMonths { get; set; }
        public int NumberOfMiles { get; set; }
        public int NumberOfPreviousOwners { get; set; }
        public int NumberOfCollisions { get; set; }
        public string Make { get; set; }       
    }
    public class PriceDeterminator
    {
        decimal _initialPurchaseValue;
        decimal _adjustedPurchaseValue;
        const decimal _profitabilityPercentage = .9m;

        public decimal DetermineCarPrice(Car car)
        {
            _initialPurchaseValue = car.PurchaseValue;

            if (car.NumberOfPreviousOwners == 0)                
                car.AdjustByAge()               ///1. Age
                    .AdjustByMileage()          ///2. Mileage
                    .AdjustByCollisions()       ///3. Collision
                    .AdjustByReliability()      ///4. Reliability
                    .AdjustByPreviousOwners();  ///5. Previous Owners - Positive Effect
            
            else
                car.AdjustByAge()               ///1. Age
                    .AdjustByMileage()          ///2. Mileage
                    .AdjustByPreviousOwners()   ///3. Previous Owners - Negative Effect
                    .AdjustByCollisions()       ///4. Collision
                    .AdjustByReliability();     ///5. Reliability

            _adjustedPurchaseValue = car.PurchaseValue;

            if (_adjustedPurchaseValue / _initialPurchaseValue > _profitabilityPercentage)
                car.PurchaseValue = _initialPurchaseValue * _profitabilityPercentage;

            return car.PurchaseValue;
        }
    }
    static class CarCalculationsExtensions
    {
        const int _maxMileage = 150000;
        const int _minNumberCollisions = 0;
        const int _maxNumberCollisions = 5;
        const int _fordPenaltyAmount = -500;
        const int _totalMonthsInTenYears = 120;
        const string _fordManufacture = "ford";
        const string _toyotaManufactuer = "toyota";
        const decimal _reliabilityPercentage = .05m;
        const decimal _previousOwnerPercentage = .1m;
        const decimal _ageDeductionPercentage = .005m;        
        const decimal _mileageDeductionPercentage = .002m;
        const decimal _collisionDeductionPercentage = .02m;        
        const decimal _previousOwnerDeductionPercentage = .25m;
        /// <summary>
        /// Value is from _maxMileage divided by 1000
        /// </summary>
        const decimal _maxMileageAdustmentPercentage = 150 * _mileageDeductionPercentage;        

        public static Car AdjustByAge(this Car c) => AdjustValueByAge(c);
        public static Car AdjustByMileage(this Car c) => AdjustValueByMileage(c);
        public static Car AdjustByReliability(this Car c) => AdjustValueByReliability(c);
        public static Car AdjustByPreviousOwners(this Car c) => AdjustValueByPreviousOwners(c);
        public static Car AdjustByCollisions(this Car c) => AdjustValueByCollisions(c);

        static readonly Func<Car, Car> AdjustValueByAge = (car) =>
        {
            if (car.AgeInMonths < _totalMonthsInTenYears)
                car.Adjust(CalcReduction(car, Multiply(car.AgeInMonths, _ageDeductionPercentage)));
            else
                car.Adjust(CalcReduction(car, _maxMileageAdustmentPercentage));

            return car;
        };
        static readonly Func<Car, Car> AdjustValueByMileage = (car) =>
        { 
            if (car.NumberOfMiles >= _maxMileage)
                car.Adjust(CalcReduction(car, _maxMileageAdustmentPercentage));
           
            else
            {
                var adjustPercentage = CalculateMultiplierPerThousandMiles(car.NumberOfMiles)
                .RoundMultiplierToZero()
                .CalculateMileageDeductionPercentageFromMultiplier();

                car.Adjust(CalcReduction(car, adjustPercentage));
            }

            return car;
        };
        static readonly Func<Car, Car> AdjustValueByPreviousOwners = (car) =>
        {
            if (car.NumberOfPreviousOwners > 2)
                car.Adjust(CalcReduction(car, _previousOwnerDeductionPercentage));

            else if (car.NumberOfPreviousOwners == 0)
                car.Adjust(CalcIncentive(car, _previousOwnerPercentage));

            return car;
        };
        static readonly Func<Car, Car> AdjustValueByReliability = (car) =>
        {
            if (!string.IsNullOrEmpty(car.Make))
            {
                var make = car.Make.ToLowerInvariant();

                if (make.Equals(_toyotaManufactuer))
                    car.Adjust(CalcIncentive(car, _reliabilityPercentage));

                else if (make.Equals(_fordManufacture))
                    car.Adjust(_fordPenaltyAmount);
            }

            return car;
        };
        static readonly Func<Car, Car> AdjustValueByCollisions = (car) =>
        {
            if (car.NumberOfCollisions > _minNumberCollisions && car.NumberOfCollisions <= _maxNumberCollisions)
                car.Adjust(CalcReduction(car, Multiply(car.NumberOfCollisions, _collisionDeductionPercentage)));

            return car;
        };

        /// <summary>
        /// Mutates the Purchase value of the provided Car
        /// </summary>
        /// <param name="c"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        static Car Adjust(this Car c, decimal value)
        {
            var currentValue = c.PurchaseValue;
            var newPurchaseValue = currentValue + value;

            c.PurchaseValue = newPurchaseValue;

            return c;
        }
        /// <summary>
        /// Calculate Incentive Amount. Left is the Car instance and Right is amout to be multiplied by
        /// </summary>
        static readonly Func<Car, decimal, decimal> CalcIncentive = (car, b) => car.PurchaseValue * b;
        /// <summary>
        /// Calculate Reduction Amount. Left is the Car instance and Right is amout to be multiplied by
        /// </summary>
        static readonly Func<Car, decimal, decimal> CalcReduction = (car, b) => (car.PurchaseValue * b) * -1;
        /// <summary>
        /// Multiplies left decimal to right decimal
        /// </summary>
        static readonly Func<decimal, decimal, decimal> Multiply = (a, b) => a * b;
        /// <summary>
        /// Calculate Mileage Multiplier
        /// </summary>
        static readonly Func<decimal, decimal> CalculateMultiplierPerThousandMiles = (miles) => miles / 1000;
        static decimal RoundMultiplierToZero(this decimal d) => Math.Round(d, 0, MidpointRounding.ToZero);        
        static decimal CalculateMileageDeductionPercentageFromMultiplier(this decimal d) => Multiply(d, _mileageDeductionPercentage);
    }

    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void CalculateCarValue()
        {
            AssertCarValue(24813.40m, 35000m, 3 * 12, 50000, 1, 1, "Ford");
            AssertCarValue(20672.61m, 35000m, 3 * 12, 150000, 1, 1, "Toyota");
            AssertCarValue(19688.20m, 35000m, 3 * 12, 250000, 1, 1, "Tesla");
            AssertCarValue(21094.5m, 35000m, 3 * 12, 250000, 1, 0, "toyota");
            AssertCarValue(21657.02m, 35000m, 3 * 12, 250000, 0, 1, "Acura");
            AssertCarValue(72000m, 80000m, 8, 10000, 0, 1, null);
        }

        private static void AssertCarValue(
            decimal expectValue,
            decimal purchaseValue,
            int ageInMonths,
            int numberOfMiles,
            int numberOfPreviousOwners,
            int numberOfCollisions,
            string make)
        {
            Car car = new()
            {
                AgeInMonths = ageInMonths,
                NumberOfCollisions = numberOfCollisions,
                NumberOfMiles = numberOfMiles,
                NumberOfPreviousOwners = numberOfPreviousOwners,
                PurchaseValue = purchaseValue,
                Make = make
            };

            PriceDeterminator priceDeterminator = new();
            var carPrice = priceDeterminator.DetermineCarPrice(car);
            Assert.AreEqual(expectValue, carPrice);
        }
    }
}  