using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOP
{
    abstract class GameObject
    {
        public abstract char Symbol { get; }
        public abstract ConsoleColor SymbolColor { get; }
    }
}
