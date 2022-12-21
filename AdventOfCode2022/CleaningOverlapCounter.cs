using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022
{
    public class CleaningOverlapCounter
    {
        private IDataProvider _dataProvider;

        public CleaningOverlapCounter(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public int GetNumberOfOverlaps()
        {
            return _dataProvider.LoadData().Count(Utils.DetectOverlap);
        }

        public int GetNumberOfIntersections()
        {
            return _dataProvider.LoadData().Count(Utils.DetectIntersection);
        }
    }
}
