using God.Helpers;

namespace God
{
    public class Girl : Human
    {
        public Girl(string name) : base(name, (new CreationHelper()).GetStudentRandomAge(), Gender.Female)
        {
        }

    }
}
