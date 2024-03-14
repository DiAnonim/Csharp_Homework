using System;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Console;
 
namespace HelloApp
{
    class Program
    {
        static void Main(string[] args)
        {
                Foo.Boo.Baz baz = new Foo.Boo.Baz();
        }
    }
}
namespace Foo
{
    namespace Boo
    {
        class Baz
        {

        }
    }
}


