namespace xofz.Research.Framework
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using xofz.Framework.Lots;

    public class PrimeManager
    {
        public virtual void Save(
            IEnumerable<long> currentSet, 
            string location)
        {
            File.WriteAllLines(location, currentSet.Select(p => p.ToString()));
        }

        public virtual Lot<long> LoadSet(
            string location)
        {
            var lot = new LinkedListLot<long>();
            var lines = File.ReadAllLines(location);
            foreach (var line in lines)
            {
                lot.AddLast(long.Parse(line));
            }

            return lot;
        }
    }
}
