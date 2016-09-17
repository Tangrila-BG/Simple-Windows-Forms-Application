
namespace Students
{
    public class Student : StudentsApplication
    {
        internal Student()
        {
            Id = _freeId;
            _freeId++;
        }

        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        private static int _freeId = 
            StudentRecord.Count > 0 ? StudentRecord.Count + 1 : 1;
    }

}
