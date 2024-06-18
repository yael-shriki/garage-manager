using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;
        
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base(string.Format("The value should be between {0} and {1}", i_MinValue, i_MaxValue))
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
        }

        public float Minimum
        {
            get { return r_MinValue; }
        }

        public float Maximum
        {
            get { return r_MaxValue; }
        }
    }
}

