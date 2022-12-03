using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022
{
    public class ItemPrioritySummarizer
    {
        private IDataProvider _dataProvider;

        public ItemPrioritySummarizer(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public int GetSumOfPriorities()
        {
            return DuplicateItemPriorities().Sum();
        }

        public IEnumerable<int> DuplicateItemPriorities() 
        {
            char duplicateItem = ' ';
            foreach (var rucksackContent in _dataProvider.LoadData())
            {
                var halfSize = rucksackContent.Length/2;
                var firstCompartment = rucksackContent.Substring(0, halfSize);
                var secondCompartment = rucksackContent.Substring(halfSize, halfSize);

                duplicateItem = firstCompartment.First(item => secondCompartment.Contains(item));
                yield return ItemUtils.ItemPriority(duplicateItem);
            }
        }
    }
}
