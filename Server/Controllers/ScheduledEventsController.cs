using Calendar.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Calendar.Server
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ScheduledEventsController : ApiControllerBase<ScheduledEvents>
    {       
        public ScheduledEventsController(IRepository<ScheduledEvents> Repo) : base(Repo)
        { }
    }

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AttendeesController : ApiControllerBase<Attendees>
    {
        public AttendeesController(IRepository<Attendees> Repo) : base(Repo)
        { }
    }
}
