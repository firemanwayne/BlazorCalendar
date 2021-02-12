using System;
using System.Collections.Generic;
using System.Linq;

namespace Components.DatesAndTimes
{
    public class Quarter
    {               
        public Quarter(int Number)
        {           
            this.Number = Number;
            var Today = DateTime.UtcNow;           
        }       

        /// <summary>
        /// Quarter Number of the Year
        /// </summary>
        public int Number { get; }
    }
}
