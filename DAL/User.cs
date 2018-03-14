using System;

namespace DAL
{
    public abstract class IdEntity<TId>
    {
        public TId Id { get; set; }
    }

    public abstract class NameAndIdEntity<TId> : IdEntity<TId>
    {
        public string Name { get; set; }
    }

    public class User : NameAndIdEntity<Guid>
    {
        public string Email { get; set; }
    }
}
