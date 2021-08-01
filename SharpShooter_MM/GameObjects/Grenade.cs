using System.Collections.Generic;
using System;
using System.Drawing;

namespace SharpShooter_MM.GameObjects
{
    public class Grenade
    {
        public PointF location;
        public PointF velocity;
        public Picture picture;
        public float grenadeSpeed = 25;
        public int radius;
        public int damage = 10;
        public bool onGround = false;
        public static float minVelocity = 1f;

        public Grenade(PointF location)
        {
            this.location = location;
            this.picture = new Picture("Images/Grenade.png", location, 1, 1);
            this.radius = this.picture.bitmap.Width / 2;
            this.velocity = new PointF();
            MainForm.grenadeList.Add(this);
        }

        public void Draw(Graphics g)
        {
            this.picture.location.X = this.location.X - MainForm.viewOffset.X;
            this.picture.location.Y = this.location.Y - MainForm.viewOffset.Y;
            this.picture.Draw(g);
        }

        public void Update(int time)
        {
            if(this.onGround)
            {
                if(IsTouching(MainForm.player1))
                {
                    MainForm.grenadeList.Remove(this);
                    ++MainForm.player1.grenades;
                }
                return;
            }
            
            foreach(Wall w in MainForm.wallList)
            {
                if(IsTouchingWall(w))
                {
                    BackUpPosition();
                    PointF normal = w.NormalAtNearestPoint(this.location);
                    BounceFrom(normal);
                }
            }
            foreach(Wall w in MainForm.wallList)
            {
                if(IsTouchingWall(w))
                {
                    BackUpPosition();
                    PointF normal = w.NormalAtNearestPoint(this.location);
                    BounceFrom(normal);
                }
            }
            Move();
            if(Math.Abs(this.velocity.X) < minVelocity && Math.Abs(this.velocity.Y) < minVelocity)
            {
                MainForm.grenadeList.Remove(this);
                Explosion e = new Explosion(this.location);
                e.picture = new Picture("Images/BigExplosion.png", e.location, 6, 40);
                e.radius = e.picture.bitmap.Width / 2;

                List<Soldier> soldiers = new List<Soldier>();
                foreach(Soldier s in MainForm.enemyList)
                    soldiers.Add(s);
                soldiers.Add(MainForm.player1);

                foreach(Soldier s in soldiers)
                {
                    double diffX = e.location.X - s.location.X;
                    double diffY = e.location.Y - s.location.Y;
                    double totalRad = e.radius + s.radius;
                    if(Math.Sqrt(diffX * diffX + diffY * diffY) < totalRad)
                    {
                        s.TakeDamage(this.damage);
                    }
                }
            }
        }

        public void Move()
        {
            this.velocity.X *= 0.93f;
            this.velocity.Y *= 0.93f;
            this.location.X += this.velocity.X;
            this.location.Y += this.velocity.Y;
        }

        public bool IsTouching(Soldier s)
        {
            double diffX = this.location.X - s.location.X;
            double diffY = this.location.Y - s.location.Y;
            double totalRad = this.radius + s.radius;
            return Math.Sqrt(diffX * diffX + diffY * diffY) < totalRad;
        }

        public bool IsTouchingWall(Wall wall)
        {
            PointF pointNearestToWall = wall.PointNearestTo(this.location);
            double diffX = pointNearestToWall.X - this.location.X;
            double diffY = pointNearestToWall.Y - this.location.Y;
            double distance = Math.Sqrt(diffX * diffX + diffY * diffY);
            return distance < this.radius;
        }

        public void BackUpPosition()
        {
            this.location.X -= this.velocity.X;
            this.location.Y -= this.velocity.Y;
        }

        public void BounceFrom(PointF normal)
        {
            float b = (this.velocity.X * normal.X + this.velocity.Y * normal.Y) * 2;
            PointF r = new PointF(this.velocity.X - normal.X * b, this.velocity.Y - normal.Y * b);
            this.velocity = r;
        }
    }
}