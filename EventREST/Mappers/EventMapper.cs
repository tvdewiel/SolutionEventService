using EventBL;
using EventREST.Model;

namespace EventREST.Mappers
{
    public static class EventMapper
    {
        public static EventOutputDTO MapFromDomain(Event e)
        {
            List<string> visitors=e.Visitors.Select(v=>$"/api/visitor/{v.Id}").ToList();
            return new EventOutputDTO(e.Name, e.Date, e.Location, e.MaxVisitors,visitors);
        }
    }
}
