using System;
using System.Collections.Generic;

namespace ConsoleApp80
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employes = new List<Employee>();
            List<Student> students = new List<Student>();
            while (true)
            { 
                Helper.PrintLine("1. Add Student ");
                Helper.PrintLine("2.Add Emplloyee ");
                Helper.PrintLine("1.Searching");
                Helper.PrintLine("1.Exit");
                string chooseNum = Console.ReadLine();
                switch(chooseNum)
                {
                    #region case1
                    case "1":
                        Helper.Print("Include student name", ConsoleColor.Blue);
                        string stName = Console.ReadLine();
                        Helper.Print("Include student surname", ConsoleColor.Blue);
                        string stSurname = Console.ReadLine();

                        inputgrade:
                        Helper.Print("Include student grade", ConsoleColor.Blue);
                        string grade = Console.ReadLine();
                        bool isdoublegrade = double.TryParse(grade, out double g);
                        if (!isdoublegrade || g > 100 || g<0) 
                        {
                            Helper.PrintLine("please include correct grade", ConsoleColor.Red);
                            goto inputgrade;
                        }

                        inputage:
                        Helper.Print("Include student age", ConsoleColor.Blue);
                        string age = Console.ReadLine();
                        bool isintage = int.TryParse(age, out int a);
                        if (!isintage  && a>0   )
                        {
                            Helper.PrintLine("please include correct age", ConsoleColor.Red);
                            goto inputage;
                        }
                        Student student1 = new Student(stName, g);
                        student1.Age = a;
                        student1.Surname = stSurname;
                        students.Add(student1);
                        Helper.PrintLine("student successfully created", ConsoleColor.Green);
                        break;
                    #endregion
                    case "2":
                        #region case2
                        Helper.Print("Include employee name", ConsoleColor.Yellow);
                        string empname = Console.ReadLine();
                        Helper.Print("Include employee surname", ConsoleColor.Yellow);
                        string empsurname = Console.ReadLine();

                    inputposition:
                        Helper.Print("Include employee position", ConsoleColor.Yellow);
                        string position = Console.ReadLine();
                        
                    inputempage:
                        Helper.Print("Include student age", ConsoleColor.Yellow);
                        string empage = Console.ReadLine();
                        bool isintempage = int.TryParse(empage, out int empa);
                        if (!isintempage && empa > 0)
                        {
                            Helper.PrintLine("please include correct age", ConsoleColor.Red);
                            goto inputage;
                        }
                        Employee employe = new Employee(empname,position);
                        employe.Age = empa;
                        employe.Surname = empsurname;
                        employes.Add(employe);
                        Helper.PrintLine("employee successfully created", ConsoleColor.Green);
                        break;
                    #endregion
                    case "3":
                    inputmenu:
                        Helper.PrintLine("1.Search student");
                        Helper.PrintLine("2.Search employee");

                        string inputnum = Console.ReadLine();
                        switch (inputnum)
                        {
                            case "1":
                                Helper.Print("include position", ConsoleColor.Magenta);
                                string inputposition = Console.ReadLine();
                                List<Employee> result = employes.FindAll((emp) =>
                                emp.Position.Contains(inputposition));
                                foreach (var item in result)
                                {
                                    Helper.PrintLine($"{item.Name }   {item.Surname}   {item.Position}");
                                }
                                break;
                            case "2":
                                mingradeinput:
                                Helper.Print("include mingrade", ConsoleColor.Blue);
                                string mingrade = Console.ReadLine();
                                bool mingradeisdouble = double.TryParse(mingrade, out double mg);
                                if (!mingradeisdouble) goto mingradeinput;

                                maxgradeinput:
                                Helper.Print("include mingrade", ConsoleColor.Blue);
                                string maxgrade = Console.ReadLine();
                                bool maxgradeisdouble = double.TryParse(maxgrade, out double maxg);
                                if (!maxgradeisdouble) goto maxgradeinput;
                                List<Student> findstudent = students.FindAll(st => st.Grade >= mg && st.Grade <= maxg);
                                foreach (var item in findstudent)
                                {
                                    Helper.PrintLine($"{item.Name}   {item.Grade}", ConsoleColor.Magenta);
                                    goto inputmenu;
                                }
                                break;
                        }
                        break;
                    
                }
            }
        }
    }
}
