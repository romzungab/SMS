using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem
{
    public class SchoolManagementSystem
    {
        static SMSController controller = new SMSController();
        static void Main(string[] args)
        {
            Console.WriteLine("\tWelcome to My School Management System\n");

            ShowMenu();

            Console.ReadKey();
        }

        static void ShowMenu()
        {
            string task;
            Console.WriteLine("\tSelect what item your will work at");
            Console.WriteLine("\t\tI\t-\tInstructor");
            Console.WriteLine("\t\tC\t-\tCourse");
            Console.WriteLine("\t\tS-\tStudent");
            Console.WriteLine("\t\tX-\tExit");

            task = Console.ReadLine();
            switch (task.ToUpper())
            {
                case "I":
                    ShowToDoForInstructor();
                    break;
                case "C":
                    //  ShowToDoForCourse();
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
            Console.WriteLine("\t\tSelect from the following :");
            Console.WriteLine("\t\t\tC\t-\tAdd New Instructor");
            Console.WriteLine("\t\t\tU\t-\tUpdate Instructor Information");
            Console.WriteLine("\t\t\tD\t-\tDelete an Instructor");
            Console.WriteLine("\t\t\tF\t-\tFind an Instructor");
            Console.WriteLine("\t\t\tV\t-\tView all Instructors");
            Console.WriteLine("\t\t\tA\t-\tAssign Instructor to Course");
            Console.WriteLine("\t\t\tE\t-\tEdit Course Assignment of Instructor");
            Console.WriteLine("\t\t\tB\t-\tGo Back to Main Menu");

            task = Console.ReadLine();
            switch (task.ToUpper())
            {
                case "C":
                    AddNewInstructor();
                    break;
                case "U":
                    //  UpdateInstructor();
                    break;
                case "D":
                    //  DeleteInstructor();
                    break;
                case "F":
                    //  FindInstructor();
                    break;
                case "V":
                    //  ViewInstructorsCourse();
                    break;
                case "A":
                    AssignCourseToInstructor(controller.GetInstructor(GetNumberInput("Enter Instructor ID:")));
                    break;
                case "E":
                    //  ChangeCourseAssignment();
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

        public static void ShowToDoForStudent()
        {
            string task;
            Console.WriteLine("\t\tSelect from the following :");
            Console.WriteLine("\t\t\tC\t-\tAdd New Student");
            Console.WriteLine("\t\t\tU\t-\tUpdate Student Information");
            Console.WriteLine("\t\t\tD\t-\tDelete Student");
            Console.WriteLine("\t\t\tF\t-\tFind a Student");
            Console.WriteLine("\t\t\tV\t-\tView all Students");
            Console.WriteLine("\t\t\tA\t-\tEnroll Student to Course");
            Console.WriteLine("\t\t\tE\t-\tView Student Grades");
            Console.WriteLine("\t\t\tB\t-\tGo Back to Main Menu");

            task = Console.ReadLine();
            switch (task.ToUpper())
            {
                case "C":
                    AddNewStudent();
                    break;
                case "U":
                    //  UpdateStudent();
                    break;
                case "D":
                    //  DeleteStudent();
                    break;
                case "F":
                    //  FindStudent();
                    break;
                case "V":
                    //  ViewAllStudentCourse();
                    break;
                case "A":
                    // EnrollStudent(controller.GetStudent(GetNumberInput("Enter Student ID:")));
                    break;
                case "E":
                    //  ChangeCourseAssignment();
                    break;
                case "B":
                    ShowMenu();
                    break;
                default:
                    Console.WriteLine("Please enter a correct input");
                    ShowToDoForStudent();
                    break;
            }

        }

        public static void AddNewInstructor()
        {
            Console.WriteLine("\t\t\tEnter the following Instructor Information:");
            Console.WriteLine("\t\t\t\tFirst Name:");
            string fname = Console.ReadLine();
            Console.WriteLine("\t\t\t\tLast Name");
            string lname = Console.ReadLine();
            DateTime hireDate = DateTime.Today;

            Person p = new Person();
            p.FirstName = fname;
            p.LastName = lname;
            p.HireDate = hireDate;
            controller.AddNewPerson(p);
            Console.WriteLine("\t\t\t\tDo you want to assign courses to the new Instructor {0} {1}? (y/n)", p.FirstName, p.LastName);
            string ans = Console.ReadLine().ToUpper();
            if (ans.Equals("Y"))
            {
                AssignCourseToInstructor(p);
            }

        }

        public static void AddNewStudent()
        {
            Console.WriteLine("\t\t\tEnter the following Student Information:");
            Console.WriteLine("\t\t\t\tFirst Name:");
            string fname = Console.ReadLine();
            Console.WriteLine("\t\t\t\tLast Name");
            string lname = Console.ReadLine();
            DateTime enrollmentDate = DateTime.Today;

            Person p = new Person();
            p.FirstName = fname;
            p.LastName = lname;
            p.EnrollmentDate = enrollmentDate;
            controller.AddNewPerson(p);
            Console.WriteLine("\t\t\t\tDo you want to enroll {0} {1} to courses? (y/n)", p.FirstName, p.LastName);
            string ans = Console.ReadLine().ToUpper();
            if (ans.Equals("Y"))
            {
                EnrollStudentToCourse(p);
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
                Console.WriteLine("\tEnter numbers only");
                number = GetNumberInput(msg);
            }
            return number;
        }

        public static void AssignCourseToInstructor(Person p)
        {
            Console.WriteLine("Select from the Courses");
            var courseList = controller.GetAllCourses();
            Console.WriteLine("\tCourse Code |Title|Credits|Dept");
            foreach (Course c in courseList)
            {
                Console.WriteLine("\t{0}\t|\t{1}\t|\t{2}\t|\t{3}", c.CourseID, c.Title, c.Credits, c.Department.Name);
            }
            int courseId = GetNumberInput("Enter the course number:");
            CourseInstructor ci = new CourseInstructor();
            if (controller.CourseExists(courseId))
            {

                ci.PersonID = p.PersonID;
                ci.CourseID = courseId;
                controller.AssignCourseToInstructor(ci);
            }
            Console.WriteLine("\t\t\t\tDo you want to assign more courses to the new Instructor {0} {1}? (y/n)", p.FirstName, p.LastName);
            string ans = Console.ReadLine().ToUpper();
            if (ans.Equals("Y"))
            {
                AssignCourseToInstructor(p);
            }

        }

        public static void EnrollStudentToCourse(Person p)
        {
            Console.WriteLine("Select from the Courses");
            var courseList = controller.GetAllCourses();
            Console.WriteLine("\tCourse Code |Title|Credits|Dept");
            foreach (Course c in courseList)
            {
                Console.WriteLine("\t{0}\t|\t{1}\t|\t{2}\t|\t{3}", c.CourseID, c.Title, c.Credits, c.Department.Name);
            }
            int courseId = GetNumberInput("Enter the course number:");
            StudentGrade sg = new StudentGrade();
            if (controller.CourseExists(courseId))
            {

                sg.StudentID = p.PersonID;
                sg.CourseID = courseId;
                controller.EnrollStudentToCourse(sg);
            }
            Console.WriteLine("\t\t\t\tDo you want to assign more courses to the new Instructor {0} {1}? (y/n)", p.FirstName, p.LastName);
            string ans = Console.ReadLine().ToUpper();
            if (ans.Equals("Y"))
            {
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
