using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvendOfCode2k7_console
{
    enum Reader { BOTH, ONE, TWO};

    interface DayInterface
    {

        void initialize(string[] lines, Reader toLoadFor );
        void initialize(string[] lines);

        void runTask1();
        void runTestTask1();

        void runTask2();
        void runTestTask2();

    }

}
