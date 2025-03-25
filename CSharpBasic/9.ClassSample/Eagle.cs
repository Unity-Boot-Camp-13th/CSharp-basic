using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.ClassSample
{   
    // 구조체는 값을 어느정도 포기하였음

    class Eagle
    {
        public Eagle(string name)
        {
            _name = name;
        }
        public Eagle()
        {
        }

        public int AverageLifespan => _averageLifespan;

        public string Name => _name;

        int _averageLifespan;
        string _name;


        public void Fly()
        {
            Console.WriteLine("독수리, 날다");
        }

        public void Walk()
        {
            Console.WriteLine("독수리, 걷다");
        }
    }
}
