using AdventOfCode2022;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022Tests
{
    internal class ResourceDataProvider : IDataProvider
    {
        private readonly string _resource;

        public ResourceDataProvider(string resource)
        {
            _resource = resource;
        }

        public IEnumerable<string> LoadData()
        {
            var naems = GetType().Assembly.GetManifestResourceNames();
            using var stream = GetType().Assembly.GetManifestResourceStream(_resource);
            using var streamReader = new StreamReader(stream);
            return ReadAllLines(streamReader).ToList();
        }

        private static IEnumerable<string> ReadAllLines(TextReader reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}
