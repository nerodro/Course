using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beatch.Models.Sample
{
    public static class Students
    {
        public static void Initialize(StudentContext context)
        {
            if (!context.Students.Any())
            {
                context.Students.AddRange(
                    new StudentModel
                    {
                        Name = "Илья",
                        Surname = "Капралов",
                        Motherland = "Максимович",
                        Speciality = "Тракторостроительный факультет, он же главный магосфабрикатор",
                        State = "Учащийся",
                        Course = "Т-1А"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
