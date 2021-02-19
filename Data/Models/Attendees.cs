using Components.DatesTimes;
using Data.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table(nameof(Attendees))]
    public class Attendees : DataModelBase, IAttendee
    {
        [Column(nameof(Assigned))]
        public bool Assigned { get; set; }

        [Column(nameof(EventId))]
        public string EventId { get; set; }

        [Column(nameof(AssignedUserId))]
        public string AssignedUserId { get; set; }       

        [ForeignKey(nameof(EventId))]
        public ScheduledEvents ScheduledEvent { get; set; }

        [ForeignKey(nameof(AssignedUserId))]
        public ApplicationUser AssignedUser { get; set; }
    }
}
