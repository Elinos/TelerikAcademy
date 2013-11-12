using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class MeteoriteBall : Ball
    {
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> tObjects = new List<GameObject>();
            tObjects.Add(new TrailObject(base.TopLeft, new char[,] { { '`' } }, 3));
            return tObjects;
        }
    }
}
