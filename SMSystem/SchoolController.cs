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
        public void AddNewCourse(Course course)
        {
            schoolDB = new SchoolEntities();
            schoolDB.Courses.Add(course);
            schoolDB.SaveChanges();
        }
        public List<Course> GetAllCourses()
        {
            schoolDB = new SchoolEntities();
            return schoolDB.Courses.ToList();
        }

        public List<Department> GetAllDepartments()
        {
            schoolDB = new SchoolEntities();
            return schoolDB.Departments.ToList();
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

        public List<StudentGrade> GetStudentGrades(int courseId) {
            schoolDB = new SchoolEntities();
            return schoolDB.StudentGrades.Where(sg => sg.CourseID == courseId).ToList();
        }

        public List<CourseInstructor> GetAllInstructorCourses() {
            schoolDB = new SchoolEntities();
            return schoolDB.CourseInstructors.ToList();
        }

        public List<StudentGrade> GetAllStudents() {
            schoolDB = new SchoolEntities();
            return schoolDB.StudentGrades.GroupBy(sg => new { sg.StudentID, sg.Person.FirstName, sg.Person.LastName })
                                         .Select(sg => sg.FirstOrDefault()).OrderBy(sg=>sg.StudentID).ToList();
        }

        public bool StudentExists(int studentId) {
            schoolDB = new SchoolEntities();
            return schoolDB.StudentGrades.Any(s => s.StudentID == studentId);
        }

        public void DeleteStudent(int studentId) {
            schoolDB = new SchoolEntities();
            var student = schoolDB.StudentGrades.Where(s => s.StudentID == studentId);

            schoolDB.StudentGrades.RemoveRange(student);
            var person = schoolDB.People.First(p => p.PersonID == studentId);
            schoolDB.People.Remove(person);
            schoolDB.SaveChanges();
        }

        public void DeleteCourse(int courseId)
        {
            schoolDB = new SchoolEntities(); 
                      
            var online = schoolDB.OnlineCourses.Find(courseId);
            if(online != null)
                schoolDB.OnlineCourses.Remove(online);
            var onSite = schoolDB.OnsiteCourses.Find(courseId);
            if(onSite != null)
                schoolDB.OnsiteCourses.Remove(onSite);
            var ciList = schoolDB.CourseInstructors.Where(s => s.CourseID == courseId).ToList();
            foreach (CourseInstructor c in ciList)
            {
                schoolDB.CourseInstructors.Remove(c);
            }
            var sgList = schoolDB.StudentGrades.Where(s => s.CourseID == courseId).ToList();
            foreach (StudentGrade sg in sgList)
            {
                schoolDB.StudentGrades.Remove(sg);
            }
            var course = schoolDB.Courses.First(s => s.CourseID == courseId);
            schoolDB.Courses.Remove(course);
            schoolDB.SaveChanges();
        }

        public Person GetStudent(int studentId) {
            schoolDB = new SchoolEntities();
            return schoolDB.People.First(s => s.PersonID == studentId);
        }

        public void UpdateStudent(Person newP) {
            schoolDB = new SchoolEntities();
            Person personInDB = schoolDB.People.First(s => s.PersonID == newP.PersonID);

            personInDB.FirstName = newP.FirstName;
            personInDB.LastName = newP.LastName;
            personInDB.EnrollmentDate = newP.EnrollmentDate;
            schoolDB.SaveChanges();
        }

        public List<CourseInstructor> GetCoursesOfInstructor(int id) {
            schoolDB = new SchoolEntities();
            return schoolDB.CourseInstructors.Where(ci => ci.PersonID == id).ToList();
        }

        public void ChangeCourseAssignment(int instId, int oldCourse, int newCourse) {
            schoolDB = new SchoolEntities();
            var oldCi = schoolDB.CourseInstructors.Find(oldCourse, instId);
            CourseInstructor newCi = new CourseInstructor();
            newCi.CourseID = newCourse;
            newCi.PersonID = instId;
            schoolDB.CourseInstructors.Remove(oldCi);
            schoolDB.CourseInstructors.Add(newCi);
            schoolDB.SaveChanges();
                
        }
    }
}
