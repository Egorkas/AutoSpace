using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Services
{
    public class FirstService
    {
        public int AddEvenNumbers(IEnumerable<int> array)
        {
            return array.Where(v => v % 2 == 0).Sum();
        }

    }
}
