using System;

namespace HttpApp.Models.Data
{
    public class Student
    {
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }

        public override string ToString()
        {
            return $"{StudentCode} - {LastName}, {FirstName}";
        }
    }
}
