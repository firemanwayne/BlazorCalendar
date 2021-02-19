using Components.DatesTimes;
using Data.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table(nameof(ScheduledEvents))]
    public class ScheduledEvents : DataModelBase, IEvent
    {
        public ScheduledEvents()
        {
            CreatedDate = DateTime.UtcNow;
            ModifiedDate = DateTime.UtcNow;
        }

        [Column(nameof(Name))]
        public string Name { get; set; }

        [Column(nameof(Description))]
        public string Description { get; set; }

        [Column(nameof(Start))]
        public DateTime Start { get; set; }

        [Column(nameof(End))]
        public DateTime End { get; set; }       

        [InverseProperty("ScheduledEvent")]
        public ICollection<Attendees> Attendees { get; set; } = new List<Attendees>();
    }
}
