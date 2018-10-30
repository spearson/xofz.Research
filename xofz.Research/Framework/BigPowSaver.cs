namespace xofz.Research.Framework
{
    using System.IO;
    using System.Numerics;

    public class BigPowSaver
    {
        public virtual void Save(
            BigInteger number,
            BigInteger exponent,
            string power)
        {
            File.WriteAllText(
                number
                + " raised to the "
                + exponent
                + " power.txt",
                power);
        }
    }
}
