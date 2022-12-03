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

        public int GetSumOfGroupBadgePriorities()
        {
            return GroupBadgePriorities().Sum();
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

        public IEnumerable<int> GroupBadgePriorities() 
        {
            var skip = 0;
            var allGroups = _dataProvider.LoadData();
            do 
            {
                var groupItems = allGroups.Skip(skip).Take(3).ToList();
                var elf1Inventory = groupItems[0];
                var elf2Inventory = groupItems[1];
                var elf3Inventory = groupItems[2];

                var commonItem = elf1Inventory.First(
                    item => elf2Inventory.Contains(item) && elf3Inventory.Contains(item));
                yield return ItemUtils.ItemPriority(commonItem);
                
                skip+=3;
            } while(skip <= allGroups.Count()-3);
        }
    }
}
