namespace xofz.Research.Framework
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class PrimeManager
    {
        public virtual void Save(IEnumerable<long> currentSet, string location)
        {
            File.WriteAllLines(location, currentSet.Select(p => p.ToString()));
        }

        public virtual LinkedList<long> LoadSet(string location)
        {
            var ll = new LinkedList<long>();
            var lines = File.ReadAllLines(location);
            foreach (var line in lines)
            {
                ll.AddLast(long.Parse(line));
            }

            return ll;
        }
    }
}
