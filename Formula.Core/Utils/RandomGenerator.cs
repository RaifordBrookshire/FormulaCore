using System;
using System.Text;

namespace Formula.Core.Utils
{
    /// <summary>
    /// This can be useful for simple randomness especially in Unit Tests to create data.
    /// IMPORTANT / WARNING: This is not random enough for secure cryptography operations. There are other classes specifically
    /// suited for crypto random generator.
    /// </summary>
    public class RandomGenerator
    {
        private Random _random = new Random(); 
        
        public RandomGenerator()
        {
        }

        /// <summary>
        /// Returns a random number within a specified range.
        /// </summary>
        /// <param name="minVal">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxVal">The exclusive upper bound of the random number returned.maxValue must begreater than or equal to minValue.</param>
        /// <returns>A 32-bit signed integer greater than or equal to minValue and less than maxValue
        /// that is, the range of return values includes minValue but not maxValue. If minValue equals maxValue, minValue is returned.</returns>
        public int GetInt(int minVal, int maxVal)
        {
            return _random.Next(minVal, maxVal);
        }


        /// <summary>
        /// Return a random double number between 0.0 and 1.00
        /// </summary>
        /// <returns></returns>
        public double GetDouble()
        {
            return _random.NextDouble();
        }

       /// <summary>
       /// Returns a random / new Guid. This just return a new Guid via Guid.NewGuid();
       /// </summary>
       /// <returns></returns>
        public Guid GetGuid()
        {
             return Guid.NewGuid();
        }       
    }
}

