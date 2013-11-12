using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class Explosion : GameObject
    {
        public new const string CollisionGroupString = "explosion";

        public Explosion(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { ' ' } })
        {
        }

        public override void Update()
        {
            IsDestroyed = true;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override string GetCollisionGroupString()
        {
            return Explosion.CollisionGroupString;
        }
    }
}
