namespace Zadatak1
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }

        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        protected bool Equals(Student other)
        {
            return string.Equals(Name, other.Name) && string.Equals(Jmbag, other.Jmbag);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Student) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Jmbag != null ? Jmbag.GetHashCode() : 0);
            }
        }

        public static bool operator == (Student first, Student second)
        {
            if (ReferenceEquals(first, null))
            {
                return ReferenceEquals(second, null);
            }

            return first.Equals(second);
        }

        public static bool operator != (Student first, Student second)
        {
            return !(first == second);
        }
    }
}