using System;
using System.Linq;

namespace AdventOfCode2022
{
    public class CalorieCalculator
    {
        private IDataProvider _dataProvider;

        public CalorieCalculator(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public int GetMaxCalories()
        {
            var maximumSum = 0;

            var lastSum = _dataProvider.LoadData().Aggregate(0, (currentSum, calorieEntry) => {
                if (string.IsNullOrEmpty(calorieEntry))
                {
                    maximumSum = Math.Max(currentSum, maximumSum);
                    return 0;
                }
                return currentSum + int.Parse(calorieEntry);
            });

            return Math.Max(lastSum, maximumSum);
        }
    }
}
