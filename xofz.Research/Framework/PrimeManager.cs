namespace xofz.Research.Framework
{
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class PrimeManager
    {
        public virtual void Save(IEnumerable<long> currentSet, string location)
        {
            File.WriteAllLines(location, currentSet.Select(p => p.ToString()));
        }

        public virtual ICollection<long> LoadSet(string location)
        {
            ICollection<long> primes = new LinkedList<long>();
            var lines = File.ReadAllLines(location);
            foreach (var line in lines)
            {
                primes.Add(long.Parse(line));
            }

            return primes;
        }
    }
}
