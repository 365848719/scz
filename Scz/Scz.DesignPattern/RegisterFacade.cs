using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scz.DesignPattern
{
    public class RegisterFacade
    {
        RegisterCourse registerCourse;
        NotifyStudent notifyStudent;

        public RegisterFacade()
        {
            registerCourse = new DesignPattern.RegisterCourse();
            notifyStudent = new NotifyStudent();
        }

        public bool RegisterCourse(string courseName, string studentName)
        {
            if (registerCourse.CheckAvailable(courseName))
            {
                notifyStudent.Notify(studentName);

                return true;
            }

            return false;
        }
    }
}