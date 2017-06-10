using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer
{
   static class MixStringList
    {
        //public static IEnumerable<string> GetMix(IEnumerable<string> list)
        //{
        //    var rnd = new Random();

        //    var result = list.OrderBy(item => rnd.Next());
        //    return result;
        //}

        public static Random random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);


        public static void GetMix(IList<string> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }


    }
}
