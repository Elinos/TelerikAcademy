using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class TrailObject : GameObject
    {
        private int lifetime;
        private int elapsedTime = 0;

        public TrailObject(MatrixCoords topLeft, char[,] body, int lifetime)
            : base(topLeft, body)
        {
            this.lifetime = lifetime;
        }

        public override void Update()
        {
            if (elapsedTime == lifetime)
                this.IsDestroyed = true;

            elapsedTime++;
        }
    }
}
