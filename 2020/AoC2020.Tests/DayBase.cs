using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace AoC2020.Tests
{
    public abstract class DayBase
    {
        protected ITestOutputHelper Output;
        protected string Day => this.GetType().Name.Substring(0, 4);

        public DayBase(ITestOutputHelper output)
        {
            Output = output;
        }
    }
}
