using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.ClassSample
{   
    // 구조체는 값을 어느정도 포기하였음

    class Pigeon
    {
        public Pigeon(string name)
        {
            _name = name;
        }
        public Pigeon()
        {
        }
        public int AverageLifespan => _averageLifespan;
        public string Name => _name;

        int _averageLifespan;
        string _name;

        public void Fly()
        {
            Console.WriteLine("비둘기, 날다");
        }

        public void Walk()
        {
            Console.WriteLine("비둘기, 걷다");
        }
    }
}
