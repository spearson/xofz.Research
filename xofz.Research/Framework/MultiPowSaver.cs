namespace xofz.Research.Framework
{
    using System.IO;
    using System.Linq;
    using System.Numerics;
    using System.Text;

    public class MultiPowSaver
    {
        public virtual void Save(Lot<BigInteger> powers, string multiPow)
        {
            if (powers == null)
            {
                return;
            }

            if (powers.Count < 2)
            {
                return;
            }

            var fileNameBuilder = new StringBuilder();
            fileNameBuilder.Append(powers.First());

            foreach (var power in powers.Skip(1))
            {
                fileNameBuilder.Append(" to the " + power);
            }
            fileNameBuilder.Append(".txt");

            File.WriteAllText(
                fileNameBuilder.ToString(),
                multiPow);
        }
    }
}
