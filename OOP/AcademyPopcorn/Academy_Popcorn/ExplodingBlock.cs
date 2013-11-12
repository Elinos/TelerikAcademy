using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class ExplodingBlock : Block
    {
        public const char Symbol = '@';
        public new const string CollisionGroupString = "explodingBlock";

        public ExplodingBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = ExplodingBlock.Symbol;
        }

        public override string GetCollisionGroupString()
        {
            return ExplodingBlock.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> eObjects = new List<GameObject>();
            if (IsDestroyed)
            {
                eObjects.Add(new Explosion(new MatrixCoords(base.topLeft.Row - 1, base.TopLeft.Col)));
                eObjects.Add(new Explosion(new MatrixCoords(base.topLeft.Row + 1, base.TopLeft.Col)));
                eObjects.Add(new Explosion(new MatrixCoords(base.topLeft.Row, base.TopLeft.Col - 1)));
                eObjects.Add(new Explosion(new MatrixCoords(base.topLeft.Row, base.TopLeft.Col + 1))); 
            }
            
            return eObjects;
        }
    }
}
