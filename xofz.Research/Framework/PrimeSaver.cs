namespace xofz.Research.Framework
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class PrimeSaver
    {
        public virtual void Save(IEnumerable<long> currentSet, string location)
        {
            File.WriteAllLines(location, currentSet.Select(p => p.ToString()));
        }
    }
}
