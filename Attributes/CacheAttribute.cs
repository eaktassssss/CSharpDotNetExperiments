using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{

    [AttributeUsage(AttributeTargets.Method , AllowMultiple = false)]
    public class CacheAttribute:Attribute
    {
        public int Duration { get; set; }
        public Type Type { get; set; }
        public CacheAttribute(int Duration, Type Type)
        {
            this.Duration = Duration;
            this.Type = Type;
        }
    }
}
