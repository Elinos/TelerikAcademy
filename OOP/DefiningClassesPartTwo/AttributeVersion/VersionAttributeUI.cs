using System;
using System.Linq;
using System.Reflection;

namespace AttributeVersion
{
    [Version("0.1")]
    class VersionAttributeUI
    {
        static void Main()
        {
            dynamic[] versions = typeof(VersionAttributeTest).GetCustomAttributes(false);
            Console.WriteLine("Version of class VersionAttributeUI2 is {0}.{1}", versions[0].Major, versions[0].Minor);
        }
    }

    [Version("0.2")]
    class VersionAttributeTest
    {

    }
}
