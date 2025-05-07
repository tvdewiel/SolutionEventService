using EventBL;
using EventREST.Model;

namespace EventREST.Mappers
{
    public static class VisitorMapper
    {
        public static Visitor MapToDomain(VisitorInputDTO dto)
        {
            return new Visitor(dto.Name, dto.BirthDay);
        }
    }
}
