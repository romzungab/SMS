using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem
{
    public class SchoolManagementSystem
    {
        static SchoolController controller = new SchoolController();
        static void Main(string[] args)
        {
            Console.WriteLine("\tWelcome to My School Management System\n");

            ShowMenu();

            Console.ReadKey();
        }

        static void ShowMenu()
        {
            string task;
            Console.WriteLine("\n\tSelect what item your will work at");
            Console.WriteLine("\t\tI\t-\tInstructor");
            Console.WriteLine("\t\tC\t-\tCourse");
            Console.WriteLine("\t\tS\t-\tStudent");
            Console.WriteLine("\t\tX\t-\tExit");
            Console.Write("\t\tEnter here:\t");
            task = Console.ReadLine();
            switch (task.ToUpper())
            {
                case "I":
                    ShowToDoForInstructor();
                    break;
                case "C":
                     ShowToDoForCourse();
                    break;
                case "S":
                    ShowToDoForStudent();
                    break;
                case "X":
                    Exit();
                    break;
                default:
                    Console.WriteLine("Please enter correct input");
                    break;
            }
            ShowMenu();
        }


        public static void ShowToDoForInstructor()
        {
            string task;
            Console.WriteLine("\n\t\tSelect from the following :");
            Console.WriteLine("\t\t\tC\t-\tAdd New Instructor");
           //Console.WriteLine("\t\t\tU\t-\tUpdate Instructor Information");
           //Console.WriteLine("\t\t\tD\t-\tDelete an Instructor");
           //Console.WriteLine("\t\t\tF\t-\tFind an Instructor");
            Console.WriteLine("\t\t\tV\t-\tView all Instructors and their Courses");
          //Console.WriteLine("\t\t\tA\t-\tAssign Instructor to Course");
            Console.WriteLine("\t\t\tE\t-\tEdit Course Assignment of Instructor");
            Console.WriteLine("\t\t\tB\t-\tGo Back to Main Menu");
            Console.Write("\t\t\tEnter here:\t");
            task = Console.ReadLine();
            switch (task.ToUpper())
            {
                case "C":
                    AddNewInstructor();
                    break;
                // "U":
                    //  UpdateInstructor();
               //     break;
               // case "D":
                    //  DeleteInstructor();
               //     break;
                //case "F":
                    //  FindInstructor();
               //     break;
                case "V":
                      ViewAllInstructorsAndCourse();
                    ShowToDoForInstructor();
                    break;
                case "A":
                    AssignCourseToInstructor(controller.GetInstructor(GetNumberInput("Enter Instructor ID:\t")));
                    break;
                case "E":
                      ChangeCourseAssignment();
                    break;
                case "B":
                    ShowMenu();
                    break;
                default:
                    Console.WriteLine("Please enter a correct input");
                    ShowToDoForInstructor();
                    break;
            }

        }

        public static void ChangeCourseAssignment()
        {
            ViewAllInstructorsAndCourse();
            int instructorId = GetNumberInput("\t\tEnter the instructor's Id:\t");
            ShowCoursesForInstructor(instructorId);
            var insCourses=controller.GetCoursesOfInstructor(instructorId);
            int courseId = GetNumberInput("\t\tEnter the course Id to be unassigned to instructor:\t");
            ShowCourses();
            int newCourse = GetNumberInput("\t\tEnter the new course to be assigned to the instructor");
            controller.ChangeCourseAssignment(instructorId, courseId, newCourse);
            Console.WriteLine("Courses Assigned to the Instructor:");
            ShowCoursesForInstructor(instructorId);
        }

        public static void ShowCoursesForInstructor(int id) {
            var courseInstructors = controller.GetCoursesOfInstructor(id);
            Console.WriteLine("\t\t\tCourse Id| Course");
            foreach (CourseInstructor ci in courseInstructors)
            {
                Console.WriteLine("\t\t\t{0}\t|\t{1}", ci.Course.CourseID,  ci.Course.Title);
            }

        }

        public static void ShowToDoForStudent()
        {
            string task;
            Console.WriteLine("\n\t\tSelect from the following :");
            Console.WriteLine("\t\t\tC\t-\tAdd New Student");
            Console.WriteLine("\t\t\tU\t-\tUpdate Student Information");
            Console.WriteLine("\t\t\tD\t-\tDelete Student");
          //  Console.WriteLine("\t\t\tF\t-\tFind a Student");
          //  Console.WriteLine("\t\t\tV\t-\tView all Students");
          //  Console.WriteLine("\t\t\tA\t-\tEnroll Student to Course");
         //   Console.WriteLine("\t\t\tE\t-\tView Student Grades");
            Console.WriteLine("\t\t\tB\t-\tGo Back to Main Menu");
            Console.Write("\t\t\tEnter here:\t");
            task = Console.ReadLine();
            switch (task.ToUpper())
            {
                case "C":
                    AddNewStudent();
                    break;
                case "U":
                      UpdateStudent();
                    break;
                case "D":
                      DeleteStudent();
                    break;
                case "F":
                    //  FindStudent();
                    break;
                case "V":
                    //  ViewAllStudentCourse();
                    break;
                case "A":
                    // EnrollStudentToCourse(controller.GetStudent(GetNumberInput("Enter Student ID:")));
                    break;
                //case "E":
                //    //  ChangeCourseAssignment();
                //    break;
                case "B":
                    ShowMenu();
                    break;
                default:
                    Console.WriteLine("Please enter a correct input");
                    ShowToDoForStudent();
                    break;
            }

        }

        public static void ShowToDoForCourse()
        {
            string task;
            Console.WriteLine("\n\t\tSelect from the following :");
            Console.WriteLine("\t\t\tC\t-\tAdd New Course");
            //    Console.WriteLine("\t\t\tU\t-\tUpdate Course Information");
            Console.WriteLine("\t\t\tD\t-\tDelete Course");
            //   Console.WriteLine("\t\t\tF\t-\tFind Course");
            Console.WriteLine("\t\t\tV\t-\tView Students Grades");
            Console.WriteLine("\t\t\tA\t-\tAssign Instructor to Course");
            //   Console.WriteLine("\t\t\tE\t-\tEdit Course Assignment of Instructor");
            Console.WriteLine("\t\t\tB\t-\tGo Back to Main Menu");
            Console.Write("\t\t\tEnter here:\t");
            task = Console.ReadLine();
            switch (task.ToUpper())
            {
                case "C":
                    AddNewCourse();
                    break;
                //case "U":
                //    //  UpdateCourse();
                //    break;
                case "D":
                    DeleteCourse();
                    break;
                //case "F":
                //    //  FindCourse();
                //    break;
                case "V":
                      ViewStudentGradesInCourse();
                    break;
                case "A":
                    AssignCourseToInstructor(controller.GetInstructor(GetNumberInput("Enter Instructor ID:\t")));
                    break;
                //case "E":
                //    //  ChangeCourseDepartment();
                //    break;
                case "B":
                    ShowMenu();
                    break;
                default:
                    Console.WriteLine("Please enter a correct input");
                    ShowToDoForCourse();
                    break;
            }

        }

        public static void ViewAllInstructorsAndCourse() {
            var courseInstructors = controller.GetAllInstructorCourses();
            Console.WriteLine("\n\t\t\tID | First Name | Last Name | Course");
            foreach (CourseInstructor ci in courseInstructors) {
                Console.WriteLine("\t\t\t{0} |\t{1}\t|\t{2}\t|\t{3}", ci.PersonID, ci.Person.FirstName, ci.Person.LastName,ci.Course.Title);
            }
           
        }

        public static void ViewStudentGradesInCourse() {
            
            ShowCourses();
            int courseId = GetNumberInput("Enter the course Id:\t");
            var studentsGrade = controller.GetStudentGrades(courseId);
            if (controller.CourseExists(courseId))
            {
                Console.WriteLine("\t\t\tStudent Name\t|\tCourse Title\t|\tGrade");
                foreach (StudentGrade sg in studentsGrade)
                {
                    Console.WriteLine("\t\t\t{0} {1}\t|\t{2}\t|\t{3}\t", sg.Person.FirstName, sg.Person.LastName, sg.Course.Title, sg.Grade);
                }
                ShowToDoForCourse();
            }
            else {
                Console.WriteLine("Please enter a valid course");
                ViewStudentGradesInCourse();
            }
        }
        public static void AddNewInstructor()
        {
            Console.WriteLine("\n\t\t\tEnter the following Instructor Information:");
            Console.Write("\t\t\t\tFirst Name:\t");
            string fname = Console.ReadLine();
            Console.Write("\t\t\t\tLast Name:\t");
            string lname = Console.ReadLine();
            DateTime hireDate = DateTime.Today;

            Person p = new Person();
            p.FirstName = fname;
            p.LastName = lname;
            p.HireDate = hireDate;
            controller.AddNewPerson(p);
            Console.Write("\t\t\t\tDo you want to assign courses to the new Instructor {0} {1}? (y/n)\t", p.FirstName, p.LastName);
            string ans = Console.ReadLine().ToUpper();
            if (ans.Equals("Y"))
            {
                AssignCourseToInstructor(p);
            }

        }

        public static void AddNewStudent()
        {
            Console.WriteLine("\t\t\tEnter the following Student Information:");
            Console.Write("\t\t\t\tFirst Name:\t");
            string fname = Console.ReadLine();
            Console.Write("\t\t\t\tLast Name:\t");
            string lname = Console.ReadLine();
            DateTime enrollmentDate = DateTime.Today;

            Person p = new Person();
            p.FirstName = fname;
            p.LastName = lname;
            p.EnrollmentDate = enrollmentDate;
            controller.AddNewPerson(p);
            Console.Write("\t\t\t\tDo you want to enroll {0} {1} to courses? (y/n)\t", p.FirstName, p.LastName);
            string ans = Console.ReadLine().ToUpper();
            if (ans.Equals("Y"))
            {
                EnrollStudentToCourse(p);
            }
        }


        public static void UpdateStudent() {
            ShowStudents();
            int studentId = GetNumberInput("Enter student id to update:\t");
            if (controller.StudentExists(studentId)) {
                var student = controller.GetStudent(studentId);
                Console.WriteLine("Enter the new values for the student, leave blank if value is the same");
                Console.WriteLine("Student Id: {0}", student.PersonID);
                Console.Write("First Name: {0}\t\t New First Name:\t", student.FirstName);
                string fname = Console.ReadLine();
                Console.Write("Last Name: {0}\t\t New Last Name:\t", student.LastName);
                string lname = Console.ReadLine();

                Console.Write("Enrollment Date:{0}\t\t New Enrollment Date:\t", student.EnrollmentDate);
                string enr = Console.ReadLine();
                DateTime d = new DateTime();
                if (enr!="")
                     d= Convert.ToDateTime(enr);

                if (!fname.Equals(""))
                    student.FirstName = fname;
                if (!lname.Equals(""))
                    student.LastName = lname;
                if (!enr.Equals(""))
                    student.EnrollmentDate = d;
                controller.UpdateStudent(student);
                Console.WriteLine("Student information updated");
                ShowStudentInfo(studentId);
            }
           
            ShowToDoForStudent();   
        }

        public static void ShowStudentInfo(int id) {
            Console.WriteLine("\t\t\tId | First Name  Last Name\t|\tEnrollment Date");
            var student = controller.GetStudent(id);
            Console.WriteLine("\t\t\t{0} | {1}  {2}\t|\t{3}", student.PersonID, student.FirstName, student.LastName, student.EnrollmentDate);
        }

        public static void DeleteStudent() {
            ShowStudents();
            int studentId = GetNumberInput("Enter student id to delete:\t");
            if (controller.StudentExists(studentId))
            {
                controller.DeleteStudent(studentId);
                Console.WriteLine("Student Deleted");
                ShowToDoForStudent();
            }
            else {
                Console.WriteLine("Student id does not exist");
                DeleteStudent();
            }
        }

        public static void ShowStudents() {
            var studentList = controller.GetAllStudents();
            Console.WriteLine("\t\t\tCourse Id | First Name | Last Name");
            foreach (StudentGrade sg in studentList) {
                Console.WriteLine("\t\t\t{0} | {1} |{2}", sg.StudentID, sg.Person.FirstName, sg.Person.LastName);
            }
        }
        public static void AddNewCourse()
        {
            Console.WriteLine("\n\t\t\tEnter the following Course Information:");
            int courseId = GetNumberInput("\t\t\t\tCourse ID:\t");
            Console.Write("\t\t\t\tCourse Title:\t");
            string courseTitle = Console.ReadLine();
            int credits = GetNumberInput("\t\t\t\tCourse Credits:\t");
            Console.WriteLine("\t\t\t\tSelect from the Departments. Enter the department id.");
            List<Department> deptList = controller.GetAllDepartments();
            Console.WriteLine("\tDept Id \t|\tName");
            foreach (Department d in deptList)
            {
                Console.WriteLine("\t{0}\t|\t{1}", d.DepartmentID, d.Name);
            }
            int deptId = GetNumberInput("\t\t\t\tDept ID:\t");

            Course c = new Course();
            c.CourseID = courseId;
            c.Title = courseTitle;
            c.Credits = credits;
            c.DepartmentID = deptId;
            controller.AddNewCourse(c);
            ShowCourses();
            Console.Write("\t\t\t\tDo you want to add another course? (y/n)\t");
            string ans = Console.ReadLine().ToUpper();
            if (ans.Equals("Y"))
            {
                AddNewCourse();
            }
        }

        public static void ShowCourses() {
            List<Course> courseList = controller.GetAllCourses();
            Console.WriteLine("\tCourse Code |Title|Credits|Dept");
            foreach (Course c in courseList)
            {
                Console.WriteLine("\t{0}\t|\t{1}\t|\t{2}\t|\t{3}", c.CourseID, c.Title, c.Credits, c.Department.Name);
            }
        }

        public static void DeleteCourse() {
            ShowCourses();
            int courseId = GetNumberInput("Enter course id to delete\t");
            if (controller.CourseExists(courseId))
            {
                controller.DeleteCourse(courseId);
                Console.WriteLine("Course Deleted");
                ShowToDoForCourse();
            }
            else
            {
                Console.WriteLine("Course id does not exist");
                DeleteCourse();
            }
        }
        public static int GetNumberInput(string msg)
        {
            int number = 0;
            try
            {
                Console.Write(msg);
                number = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("\t****Enter numbers only****");
                number = GetNumberInput(msg);
            }
            return number;
        }

        public static void AssignCourseToInstructor(Person p)
        {
            Console.WriteLine("Select from the Courses");
            ShowCourses();
            int courseId = GetNumberInput("Enter the course number:\t");
            CourseInstructor ci = new CourseInstructor();
            if (controller.CourseExists(courseId))
            {

                ci.PersonID = p.PersonID;
                ci.CourseID = courseId;
                controller.AssignCourseToInstructor(ci);
            }
            Console.Write("\nDo you want to assign more courses to the new Instructor {0} {1}? (y/n)\t", p.FirstName, p.LastName);
            string ans = Console.ReadLine().ToUpper();
            if (ans.Equals("Y"))
            {
                AssignCourseToInstructor(p);
            }

        }

        public static void EnrollStudentToCourse(Person p)
        {
            Console.WriteLine("Select from the Courses");
            ShowCourses();
            int courseId = GetNumberInput("Enter the course number:\t");
            if (controller.CourseExists(courseId))
            {
                StudentGrade sg = new StudentGrade();

                sg.StudentID = p.PersonID;
                sg.CourseID = courseId;
                controller.EnrollStudentToCourse(sg);

                Console.Write("\t\t\t\tDo you want to enroll more courses to the the student {0} {1}? (y/n)\t", p.FirstName, p.LastName);
                string ans = Console.ReadLine().ToUpper();
                if (ans.Equals("Y"))
                {
                    EnrollStudentToCourse(p);
                }
            }else
            {
                Console.WriteLine("You have entered an invalid input");
                EnrollStudentToCourse(p);
            }

        }
        public static void Exit()
        {
            Console.WriteLine("Thank you for using the MY School Management System. Have a nice day");
            Environment.Exit(0);
        }



    }
}
