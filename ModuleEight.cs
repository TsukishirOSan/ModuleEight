using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * Module Eight Assignment
For this assignment you will use your project from Module 7 and will use Generic collections in place of the existing collections.

**1/ Create a List<T>, of the proper data type, to replace the ArrayList and to hold students, inside the Course object.
**2/ Modify your code to use the List<T> collection as the replacement to the ArrayList. 
**3/ Create a Stack<T> object, of the proper data type, inside the Student object, called Grades, to store test scores.
*Create 3 student objects.
**4/ Add 5 grades to the the Stack<T>  in the each Student object. (this does not have to be inside the constructor because 
 *you may not have grades for a student when you create a new student.)
**5/ Add the three Student objects to the List<T>  inside the Course object.
**6/ Using a foreach loop, iterate over the Students in the List<T> and output their first and last names to the console window.
 *(For this exercise, casting is no longer required.  Also, place each student name on its own line)
**7/ Create a method inside the Course object called ListStudents() that contains the foreach loop.
**8/ Call the ListStudents() method from Main().
Grading Criteria:

**1/ Used a List<T> collection of the proper data type, inside the Course object.
**2/ Added a Stack<T> of the proper data type, called Grades, inside the Student object.
**3/ Added 3 Student objects to this List<T> using the List<T> method for adding objects.
**4/ Used a foreach loop to output the first and last name of each Student in the List<T>.
Challenge:  (NOT to be assessed in Peer Review)

--To simulate changing a grade for a student, remove the last entered grade and replace it with a new one.
--Research the Generic collections on http://msdn.microsoft.com and find a Generic collection to store grades in a sorted order. 
--Implement that Generic collection in place of the Stack<T> in the Student object.
--Iterate over the student collection and output the first and last name along with each of the 5 grades for that student.
 * */


namespace ModuleEight
{
    class CreateClassesInfo
    {
        static void Main(string[] args)
        {

            // Instanciate Student
            var student1 = new Student("Faïza", "Harbi", "faiza.harbi@mic.edu", new DateTime(1982, 3, 6), "797 code Avenue",
                "Residence bar", "Montpellier", "Hérault", "34070", "FRANCE", 'F', 3.9f, 100.02m, 4);
            Stack<double> Grades = new Stack<double>();
            List<double> g = new List<double>();
            var tmp = student1.generateListOfStudGrades(g);
            Grades = student1.listToStackGrades(Grades);
            student1.addStudentGrades(Grades);


            //grades = stud;
            // Create ArrayList of Student objects
            var students = new List<Student>();
            // instanciate a Course object
            var crse = new Course("", "", 80, students);

            // Adds student1 to the ArrayList of Student
            crse.addStudentToList(student1);

            // Instanciate Student
            var student2 = new Student("Julien", "Mazet", "julien.mazet@mic.edu", new DateTime(1982, 3, 6), "797 code Avenue",
                "Residence bar", "Montpellier", "Hérault", "34070", "FRANCE", 'F', 3.9f, 100.02m, 4);

            // Adds student2 to the ArrayList of Student
            crse.addStudentToList(student2);

            // Instanciate Student
            var student3 = new Student("Ivan", "Joule", "ivan.joule@foo.edu", new DateTime(1982, 9, 24), "2 Main Street",
                    "", "Stropia", "", "0407", "MACEDONIA", 'M', 3.8f, 500.60m, 3);

            // Adds student3 to the ArrayList of Student
            crse.addStudentToList(student3);

            // Instanciate Student
            var student4 = new Student("Ana", "Blake", "ana.blake@foo.edu", new DateTime(1989, 4, 17), "24 Bazinga Road", "Residence Cooper", "Moscow", "", "101000", "RUSSIA",
                    'F', 3.9f, 300.20m, 3);

            // Adds student4 to the ArrayList of Student
            crse.addStudentToList(student4);

            crse.ListStudents();

            int c = Student.Counter;

            var teacher1 = new Teacher("Julien", "Mazet", "julien.mazet@cs.mic.edu", new DateTime(1981, 3, 7), "33 Oxford Street",
                 "Building 50", "Cambridge", "MA", "3143",
                 "USA", 'M', "Computer Science DEV204", 80);

            var teachers = new List<Teacher>();
             teachers.Add(teacher1);

            var course1 = new Course("Programming with C#", "Computer Science DEV204", 80, students);
            var courses = new List<Course>();
            courses.Add(course1);

            var degree1 = new Degree("Bachelor Of Science", "Computer Science", 80, courses);
            var degrees = new List<Degree>();
            degrees.Add(degree1);

            var uprogram1 = new UProgram("Information Technology", "Dean Winchester", degrees);

            WriteProgramInfo(uprogram1, courses);
            Console.WriteLine("Press a key to continue.....");
            Console.ReadKey();
        }

        //method displaying the informations asked
        private static void WriteProgramInfo(UProgram uprogram1, List<Course> courses)
        {

            try
            {
                var deg = uprogram1.UDegreesProposed.First();
                var crs = courses.First().Cname;
                Console.WriteLine("The {0} contains the {1} degree.{2}", uprogram1.Uname, deg.Dname, Environment.NewLine);
                Console.WriteLine("The {0} degree contains the course {1}.{2}", deg.Dname, crs, Environment.NewLine);
                Console.WriteLine("The {0} course contains {1} student(s).{2}", crs, Student.Counter, Environment.NewLine);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine("Invalid type operation", ioe.Message);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("No input", ane.Message);
            }
        }

        #region dedicated to the abstract class Person inherited by the classes Student and Teacher
        abstract internal class Person
        {

            // this is the type of the encapsulated getter setter related to the first name
            private string first;
            public string First
            {
                get
                {
                    return first;
                }
                set
                {
                    if (value != null)
                        first = value;
                }
            }

            // this is the type of the encapsulated getter setter related to the last name same for below
            private string last;
            public string Last
            {
                get
                {
                    return last;
                }
                set
                {
                    if (value != null)
                        last = value;
                }
            }

            private string email;
            public string Email
            {
                get
                {
                    return email;
                }
                set
                {
                    if (value != null)
                        email = value;
                }
            }

            private DateTime birthdate;

            public DateTime Birthdate
            {
                get
                {
                    return birthdate;
                }

                private set
                {
                    if (value != null)
                        birthdate = value;
                }
            }


            private string addressLine1;
            public string AddressLine1
            {
                get
                {
                    return addressLine1;
                }
                set
                {
                    if (value != null)
                        addressLine1 = value;
                }
            }

            private string addressLine2;
            public string AddressLine2
            {
                get
                {
                    return addressLine2;
                }
                set
                {
                    if (value != null)
                        addressLine2 = value;
                }
            }

            private string city;
            public string City
            {
                get
                {
                    return city;
                }
                private set
                {
                    if (value != null)
                        city = value;
                }
            }

            private string stateOrProvince;
            public string StateOrProvince
            {
                get
                {
                    return stateOrProvince;
                }
                set
                {
                    if (value != null)
                        stateOrProvince = value;
                }
            }

            private string zipPostal;
            public string ZipPostal
            {
                get
                {
                    return zipPostal;
                }
                set
                {
                    if (value != null)
                        zipPostal = value;
                }
            }

            private string country;
            public string Country
            {
                get
                {
                    return country;
                }
                set
                {
                    if (value != null)
                        country = value;
                }
            }

            private char gender;
            public char Gender
            {
                get
                {
                    return gender;
                }
                set
                {
                    if (value != '\0')
                        gender = value;
                }
            }

            internal Person(string first, string last, string email, DateTime birthdate, string addressLine1,
                string addressLine2, string city, string stateOrProvince, string zipPostal,
                string country, char gender)
            {
                this.First = first;
                this.Last = last;
                this.Email = email;
                this.Birthdate = birthdate;
                this.AddressLine1 = addressLine1;
                this.AddressLine2 = addressLine2;
                this.City = city;
                this.StateOrProvince = stateOrProvince;
                this.ZipPostal = zipPostal;
                this.Country = country;
                this.Gender = gender;
            }

            public override string ToString()
            {
                return String.Format("{0}{1} {2}", Environment.NewLine, First, Last);
            }


        }
        #endregion
        //create and initialize the number of students counter
        #region dedicated to the class Student
        internal class Student : Person
        {
            private static int counter = 0;
            public static int Counter
            {
                get
                {
                    return counter;
                }
                set
                {
                    counter = value;
                }
            }

            private float OverallGPA;
            public float overallGPA
            {
                get
                {
                    return OverallGPA;
                }
                set
                {
                    if (value > 0.0)
                        OverallGPA = value;
                }
            }

            private Decimal AccountBalance;
            public Decimal accountBalance
            {
                get
                {
                    return AccountBalance;
                }
                set
                {
                    AccountBalance = value;
                }
            }

            private int NumCoursesTaken;
            public int numCoursesTaken
            {
                get
                {
                    return NumCoursesTaken;
                }
                set
                {
                    if (value >= 0)
                        this.NumCoursesTaken = value;
                }
            }


            // Stack of grades per student (LIFO)
            private Stack<double> Grades = new Stack<double>();


            // Method adding grades to a Student
            public void addStudentGrades(Stack<double> StudGrades)
            {
                //Console.WriteLine("Press a key to output informations: ");
                foreach (double g in StudGrades)
                {
                    this.Grades.Push(g);
                    //Console.Write("{0}{0:f2}", this.Grades.Peek() + ", ",Environment.NewLine);
                }
               // Console.WriteLine("\n");
            }

            private List<double> listOfStudGrades = new List<double>();

            // Generates using the Random Object 5 grades of type double between 50 and 100 and stores them in a List
            // of type double named listOfStudGrades 
            public List<double> generateListOfStudGrades(List<double> listOfStudGrades)
            {
                int i;
                for (i = 0; i < 5; i++)
                {
                    // Will allow to have int grades between the minValue 50 and maxValue 100
                    Random rand = new Random();
                    int s = DateTime.Now.Millisecond;
                    // generates random data type double and round it to 2 decimals after the floating point.
                    double g = Math.Round(rand.NextDouble() * ((100 - s) + s), 2);
                    this.listOfStudGrades.Add(g);
                }
                return (this.listOfStudGrades);
            }

            public Stack<double> listToStackGrades(Stack<double> StudGrades)
            {
                int i = 0;
                if (this.listOfStudGrades.Capacity != 0)
                {
                    foreach (double listg in this.listOfStudGrades)
                    {
                        while (i < 5)
                        {
                            StudGrades.Push(this.listOfStudGrades[i]);
                            i++;
                        }
                    }
                }
                return StudGrades;
            }

            
            
            internal Student(string first, string last, string email, DateTime birthdate, string addressLine1,
                string addressLine2, string city, string stateOrProvince, string zipPostal,
                string country, char gender, float overallGPA, Decimal accountBalance, int numCoursesTaken)
                : base(first, last, email, birthdate, addressLine1, addressLine2, city, stateOrProvince,
                    zipPostal, country, gender)
            {
                this.AccountBalance = accountBalance;
                this.OverallGPA = overallGPA;
                this.NumCoursesTaken = numCoursesTaken;
                // increment the number of Student instanciated
                counter++;
            }


            // override methode to output the proper fields according the class being handled
            public override string ToString()
            {
                return String.Format(
                "email: {0}{1}" +
                "Address  {2}{1}" + "{3}{1}" +
                "{4}, {5}{1}" +
                "{6}, {7}{1}{1}" +
                "------------{1}" +
                "Overall GPA: {8}{1}" +
                "Account Balance: {9}{1}" +
                "Gender: {10}{1}" +
                "Number of courses taken: {11}{1}" +
                "{1}Courses taken: {12}{1}{1}",
                Email, Environment.NewLine, AddressLine1, AddressLine2, City, StateOrProvince, ZipPostal, Country,
                overallGPA, accountBalance, Gender, numCoursesTaken
                );
            }
        }
        #endregion

        #region Dedicated to the class Teacher
        internal class Teacher : Person
        {
            private string pField;
            public string Pfield
            {
                get
                {
                    return pField;
                }
                set
                {
                    if (value != null)
                        pField = value;
                }
            }

            private int pNumOfCourses;
            public int PnumOfCourses
            {
                get
                {
                    return pNumOfCourses;
                }
                set
                {
                    if (value > 0)
                        pNumOfCourses = value;
                }
            }

            internal Teacher(string first, string last, string email, DateTime birthdate, string addressLine1,
                string addressLine2, string city, string stateOrProvince, string zipPostal,
                string country, char gender, string pField, int pNumOfCourses)
                : base(first, last, email, birthdate, addressLine1, addressLine2, city, stateOrProvince,
                    zipPostal, country, gender)
            {
                this.Pfield = pField;
                this.PnumOfCourses = pNumOfCourses;
            }

        }
        #endregion

        #region Dedicated to the class Course
        internal class Course
        {
            private string cName; // i.e. "DEV204x"
            public string Cname
            {
                get
                {
                    return cName;
                }
                set
                {
                    if (value != null)
                        cName = value;
                }
            }

            private string cField; // i.e. "Computer Science and Programming; Data processing" 
            public string Cfield
            {
                get
                {
                    return cField;
                }
                set
                {
                    if (value != null)
                        cField = value;
                }
            }



            private int cCredits;
            public int Ccredits
            {
                get
                {
                    return cCredits;
                }
                set
                {
                    if (value > 0)
                        cCredits = value;
                }
            }

            private double cGrade;
            public double Cgrade
            {
                get
                {
                    return cGrade;
                }
                set
                {
                    if (value >= 0)
                        this.cGrade = value;
                }
            }


            #region List of Students and the ListStudents method

            private List<Student> cStuds = new List<Student>();
            public List<Student> Cstuds
            {
                get
                {
                    return cStuds;
                }
                set
                {
                    if (Cstuds != null && value != null)
                        this.cStuds = value;
                }
            }

            public void addStudentToList(Student stud)
            {
                this.cStuds.Add(stud);
            }

            public void ListStudents()
            {
                Console.WriteLine("Press a key to start{0}", Environment.NewLine);
                Console.ReadKey();
                if (this.cStuds == null)
                    Console.WriteLine("The list of students is not initialized");
                else if (this.cStuds.Count == 0)
                    Console.WriteLine("The list of students is empty");
                else
                {
                    foreach (Student St in this.cStuds)
                    { 
                        Console.WriteLine("{0}Student's first and last name: "+St.First + " " + St.Last, Environment.NewLine);
                        
                    }
                }
                Console.WriteLine("\nPress a key to continue...");
                Console.ReadKey();
            }
            #endregion

            private List<Teacher> professorsArray = new List<Teacher>();

            public List<Teacher> getProfList()
            {
                return professorsArray;
            }

            public void setProfList(List<Teacher> professorsArray)
            {
                this.professorsArray = professorsArray;
            }

            public void addProfessorToProfessorsArray(Teacher teacher)
            {
                professorsArray.Add(teacher);
            }

            internal Course(string cName, string cField, int cCredits, List<Student> cStuds)
            {
                this.Cname = cName;
                this.Cfield = cField;
                this.Ccredits = cCredits;
                this.Cstuds = cStuds;
            }

            public override string ToString()
            {
                return String.Format("{0}Course's name: {1}" + "{0}Course's Field: {2}" + "{0}Number of credits needed: {3}{0}", Environment.NewLine,
                    Cname, Cfield, Ccredits);
            }
        }
        #endregion

        #region Dedicated to the class Degree
        internal class Degree
        {
            private string dName;
            public string Dname
            {
                get
                {
                    return dName;
                }
                set
                {
                    if (value != null)
                        dName = value;
                }
            }

            private string dField;
            public string Dfield
            {
                get
                {
                    return dField;
                }
                set
                {
                    if (value != null)
                        dField = value;
                }
            }

            private int dCredits;
            public int Dcredits
            {
                get
                {
                    return dCredits;
                }
                set
                {
                    if (value >= 0)
                        dCredits = value;
                }
            }

            private List<Course> dCourses = new List<Course>();
            public List<Course> Dcourses = new List<Course>();

            public List<Course> getCourseList()
            {
                return Dcourses;
            }
            public void setCourseList(List<Course> dCourses)
            {
                if (dCourses != null)
                    this.Dcourses = dCourses;
            }


            internal Degree(string dName, string dField, int dCredits, List<Course> dCourses)
            {
                this.Dname = dName;
                this.Dfield = dField;
                this.Dcredits = dCredits;
                this.Dcourses = getCourseList();
            }

            public void addCourseToDegree(Course course)
            {
                Dcourses.Add(course);
            }

            public override string ToString()
            {
                return String.Format("{0}Name of the degree: {1}" + "{0}Degree's field: {2}" +
                    "{0}Number of credits needed:  {3}" + "{0}List Of Courses: {4}", Environment.NewLine, Dname, Dfield, Dcredits, Dcourses);
            }

        }
        #endregion

        #region Dedicated to the class UProgram
        internal class UProgram
        {
            private string uName;
            public string Uname
            {
                get
                {
                    return uName;
                }
                set
                {
                    if (value != null)
                        uName = value;
                }
            }

            private string uDean;
            public string Udean
            {
                get
                {
                    return uDean;
                }
                set
                {
                    if (value != null)
                        uDean = value;
                }
            }

            private List<Degree> uDegreesProposed = new List<Degree>();
            public List<Degree> UDegreesProposed = new List<Degree>();
            List<Degree> getUDegreesProposed()
            {
                return uDegreesProposed;
            }

            public void setUDegrees(Degree degree)
            {
                UDegreesProposed.Add(degree);
            }

            public UProgram(string uName, string uDean, List<Degree> uDegreesProposed)
            {
                this.Uname = uName;
                this.Udean = uDean;
                this.UDegreesProposed = uDegreesProposed;
            }


            /*public override string ToString()
            {
                return String.Format("{0}University name: {1}"+"{0}University Dean: {2}"+
                    "{0}Degrees available: {3}", Environment.NewLine, Uname, Udean, UDegreesProposed);
            }*/
        }
        #endregion
    }

}