using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem
{
    class SchoolController
    {
        SchoolEntities schoolDB;

        public int AddNewPerson(Person person)
        {
            schoolDB = new SchoolEntities();
            schoolDB.People.Add(person);
            schoolDB.SaveChanges();
            return person.PersonID;
        }
        public void AddNewOfficeAssignment(OfficeAssignment instructor)
        {
            schoolDB = new SchoolEntities();
            schoolDB.OfficeAssignments.Add(instructor);
            schoolDB.SaveChanges();
        }

        public List<Course> GetAllCourses()
        {
            schoolDB = new SchoolEntities();
            return schoolDB.Courses.ToList();
        }

        public bool CourseExists(int courseId)
        {
            schoolDB = new SchoolEntities();
            return schoolDB.Courses.Any(c => c.CourseID == courseId);
        }

        public void AssignCourseToInstructor(CourseInstructor ci)
        {
            schoolDB = new SchoolEntities();
            schoolDB.CourseInstructors.Add(ci);
            schoolDB.SaveChanges();
        }

        public Person GetInstructor(int pid)
        {
            schoolDB = new SchoolEntities();
            return schoolDB.People.Find(pid);
        }

        public void EnrollStudentToCourse(StudentGrade sg)
        {
            schoolDB = new SchoolEntities();
            schoolDB.StudentGrades.Add(sg);
            schoolDB.SaveChanges();
        }
    }
}
