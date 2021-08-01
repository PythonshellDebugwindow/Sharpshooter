using System;
using System.Drawing;
using System.Collections.Generic;

namespace SharpShooter_MM.GameObjects
{
    public class WaterHazard : Wall
    {
        public List<Soldier> soldiersInside;

        public WaterHazard(int left, int top, int width, int height) : base(left, top, width, height, "Green")
        {
            this.image = new Bitmap("Images/WaterBox.png");
            this.soldiersInside = new List<Soldier>();
        }

        public bool IsTouching(Soldier s)
        {
            PointF pointNearestToWall = PointNearestTo(s.location);
            double diffX = pointNearestToWall.X - s.location.X;
            double diffY = pointNearestToWall.Y - s.location.Y;
            double distance = Math.Sqrt(diffX * diffX + diffY * diffY);
            return distance < s.radius;
        }

        public override void Update(int time)
        {
            foreach(EnemySoldier s in MainForm.enemyList)
                Check(s);
            Check(MainForm.player1);
        }

        public void Check(Soldier s)
        {
            if(IsTouching(s))
            {
                if(!this.soldiersInside.Contains(s))
                {
                    s.moveSpeed *= 0.5f;
                    this.soldiersInside.Add(s);
                }
            }
            else if(this.soldiersInside.Contains(s))
            {
                s.moveSpeed *= 2;
                this.soldiersInside.Remove(s);
            }

        }
    }
}