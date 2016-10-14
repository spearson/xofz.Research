namespace xofz.Research.Framework
{
    using System.IO;
    using System.Numerics;

    public class FactorialSaver
    {
        public virtual void Save(BigInteger input, string factorial)
        {
            File.WriteAllText(
                "Factorial of " + input + ".txt",
                factorial);
        }
    }
}
