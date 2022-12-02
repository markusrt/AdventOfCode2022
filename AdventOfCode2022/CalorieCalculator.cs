using System;
using System.Collections.Generic;
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

        public int GetSumOfMaxCalories(int numberOfTopCalories = 1)
        {
            return AllCalorieSums().OrderDescending().Take(numberOfTopCalories).Sum();
        }

        public IEnumerable<int> AllCalorieSums() 
        {
            var currentSum = 0;
            foreach (var calorieEntry in _dataProvider.LoadData())
            {
                if (string.IsNullOrEmpty(calorieEntry))
                {
                    yield return currentSum; 
                    currentSum = 0;
                    continue;
                }
                currentSum+=int.Parse(calorieEntry);
            }
            yield return currentSum;
        }
    }
}
