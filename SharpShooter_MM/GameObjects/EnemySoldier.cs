using System;
using System.Drawing;

namespace SharpShooter_MM.GameObjects
{
    public class EnemySoldier : Soldier
    {
        public int randomMoveDelay;
        public int timeSinceLastRandomMove = 0;
        public float angleInterval = 22.5f;
        public double trackingDistance = 400d;

        public EnemySoldier(PointF location) : this("Images/Enemy1.png", location)
        {}
        
        protected EnemySoldier(string image, PointF location) : base(image, location)
        {
            MainForm.enemyList.Add(this);
            this.isFiring = true;
            Random r = new Random((int)DateTime.Now.Ticks);
            this.facingAngle = r.Next(360);
            this.walkDirection = 1;
            this.moveSpeed = 5;// 0;
            r = new Random((int)this.location.X);
            this.randomMoveDelay = r.Next(1500) + 500;
        }

        public override void Update(int time)
        {
            base.Update(time);
            
            this.timeSinceLastRandomMove += time;
            if(this.timeSinceLastRandomMove >= this.randomMoveDelay)
            {
                double diffX = (double)(this.location.X - MainForm.player1.location.X);
                double diffY = (double)(this.location.Y - MainForm.player1.location.Y);
                double dist = Math.Sqrt(diffX * diffX + diffY * diffY);
                
                if(dist < this.trackingDistance)
                {
                    this.facingAngle = (float)Math.Atan2(MainForm.player1.location.Y - this.location.Y, MainForm.player1.location.X - this.location.X);
                    this.facingAngle *= -(float)(180d / Math.PI);
                    this.facingAngle = InRangePlusMinus(this.facingAngle, this.angleInterval);
                    if(this.facingAngle < 0)
                        this.facingAngle += 360;
                    else if(this.facingAngle >= 360)
                        this.facingAngle -= 360;
                }
                else
                {
                    Random r = new Random((int)DateTime.Now.Ticks);
                    this.facingAngle = r.Next(360);
                }

                this.timeSinceLastRandomMove = 0;
            }
            if(this.killed)
            {
                MainForm.enemyList.Remove(this);
            }
        }

        float InRangePlusMinus(float n, float range)
        {
            return (float)(n + (new Random().NextDouble() * 2 - 1) * range);
        }
    }
}