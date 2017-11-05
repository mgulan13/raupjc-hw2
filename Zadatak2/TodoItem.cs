using System;

namespace Zadatak2
{
    public class TodoItem
    {
        public TodoItem(string text)
        {
            // Generates new unique identifier
            Id = Guid.NewGuid();

            // DateTime.Now returns local time, it wont always be what you expect (depending where the server is).
            // We want to use universal (UTC) time which we can easily convert to
            // local when needed.
            // ( usually done in browser on the client side )
            DateCreated = DateTime.UtcNow;
            Text = text;
        }

        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime? DateCompleted { get; set; }
        public DateTime DateCreated { get; set; }

        public bool IsCompleted => DateCompleted.HasValue;

        public bool MarkAsCompleted()
        {
            if (!IsCompleted)
            {
                DateCompleted = DateTime.Now;
                return true;
            }
            return false;
        }

        protected bool Equals(TodoItem other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((TodoItem) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}