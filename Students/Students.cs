using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Students
    {
        public Students(StudentsNames name, double height, double weight)
        {
            EnumNames = name;
            Height = height;
            Weight = weight;
        }
        public StudentsNames EnumNames { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public override string ToString()
        {
            return $"Name: {EnumNames}, Height: {Height}, Weight: {Weight}";
        }
    }

    public enum StudentsNames
    {
        Roman = 1,
        Daria,
        Dima,
        Sasha,
        Vova,
        Vika,
        Oleg,
        Olya,
        Kolya,
    }
}
