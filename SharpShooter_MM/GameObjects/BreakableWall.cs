using System;
using System.Drawing;

namespace SharpShooter_MM.GameObjects
{
    public class BreakableWall : Wall
    {
        public BreakableWall(int left, int top, int width, int height, string colour) : base(left, top, width, height, "Cracked" + colour)
        {}

        public override void Update(int time)
        {
            foreach(Explosion e in MainForm.explosionList)
            {
                if(IsTouching(e))
                {
                    MainForm.wallList.Remove(this);
                }
            }
        }

        public bool IsTouching(Explosion e)
        {
            PointF pointNearestToWall = PointNearestTo(e.location);
            double diffX = (double)(pointNearestToWall.X - e.location.X);
            double diffY = (double)(pointNearestToWall.Y - e.location.Y);
            double distance = Math.Sqrt(diffX * diffX + diffY * diffY);
            return distance < e.radius;
        }
    }
}