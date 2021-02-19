using System;
using System.Collections.Generic;

namespace Components.DatesTimes
{
    public interface IEvent
    {
        string Name { get; }
        string Description { get; }
        DateTime Start { get; }
        DateTime End { get; }        
    }
}
