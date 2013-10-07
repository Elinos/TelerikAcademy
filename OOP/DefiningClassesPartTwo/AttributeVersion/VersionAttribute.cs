using System;

namespace AttributeVersion
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface | 
                    AttributeTargets.Enum | AttributeTargets.Method)]
    class VersionAttribute : Attribute
    {
        public int Major { get; private set; }
        public int Minor { get; private set; }

        public VersionAttribute(string ver)
        {
            this.Major = int.Parse(ver.Split('.')[0]);
            this.Minor = int.Parse(ver.Split('.')[1]);
        }
    }
}
