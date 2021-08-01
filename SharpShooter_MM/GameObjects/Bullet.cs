using System;
using System.Drawing;
using System.Collections.Generic;
namespace SharpShooter_MM.GameObjects
{
    public class Bullet
    {
        public PointF location;
        public PointF velocity;
        public Picture picture;
        public float bulletSpeed = 25;
        public float lifetime = 1.5f;
        public int radius;
        public Soldier parent;
        public int damage;
        public bool isNarcissist;

        public Bullet(PointF location, Soldier parent, int damage)
        {
            this.location = location;
            this.picture = new Picture("Images/bullet1.png", location, 4, 25);
            this.radius = this.picture.bitmap.Width / 2;
            this.velocity = new PointF();
            this.parent = parent;
            this.damage = damage;
            this.isNarcissist = this.parent is NarcissistEnemy;
            MainForm.bulletList.Add(this);
        }

        public void Draw(Graphics g)
        {
            this.picture.location.X = this.location.X - MainForm.viewOffset.X;
            this.picture.location.Y = this.location.Y - MainForm.viewOffset.Y;
            this.picture.Draw(g);
        }

        public void Update(int time)
        {
            this.lifetime -= (float)time / 1000;
            if(this.lifetime <= 0)
            {
                if(this.picture.fileName == "Images/Missile.png")
                    ExplodeMissile();
                else
                    MainForm.bulletList.Remove(this);
            }
            this.picture.Update(time);
            Move();
            for(int i = 0; i < MainForm.enemyList.Count; ++i)
            {
                if(!IsTouching(MainForm.enemyList[i]) || MainForm.enemyList[i].killed)
                    continue;

                if(this.parent == MainForm.player1)
                {
                    if(this.isNarcissist || !(MainForm.enemyList[i] is NarcissistEnemy) || this.picture.fileName == "Images/Missile.png")
                    {
                        if(this.picture.fileName == "Images/Missile.png")
                            ExplodeMissile();
                        else
                        {
                            MainForm.enemyList[i].TakeDamage(this.damage);
                            MainForm.bulletList.Remove(this);
                        }
                    }
                }
                else if(this.parent is NarcissistEnemy && MainForm.enemyList[i] is NarcissistEnemy)
                {
                    if(this.picture.fileName == "Images/Missile.png")
                        ExplodeMissile();
                    else
                    {
                        MainForm.enemyList[i].TakeDamage(this.damage);
                        MainForm.bulletList.Remove(this);
                    }
                }
            }
            if(IsTouching(MainForm.player1) && !MainForm.player1.killed && this.parent != MainForm.player1)
            {
                MainForm.player1.TakeDamage(this.damage);
                MainForm.bulletList.Remove(this);
            }
            foreach(Wall w in MainForm.wallList)
            {
                if(IsTouchingWall(w))
                {
                    if(this.picture.fileName == "Images/Missile.png")
                        ExplodeMissile();
                    else
                    {
                        BackUpPosition();
                        PointF normal = w.NormalAtNearestPoint(this.location);
                        BounceFrom(normal);
                    }
                }
            }
            if(Player.shield.active && IsTouchingWall(Player.shield))
            {
                BackUpPosition();
                PointF normal = Player.shield.NormalAtNearestPoint(this.location);
                BounceFrom(normal);
                this.parent = MainForm.player1;
                ++this.lifetime;
                if(this.picture.fileName == "Images/Bullet1.png")
                    this.picture = new Picture("Images/Bullet3.png", this.location, 4, 25);
            }
            foreach(MovingWall w in MainForm.movingWallList)
            {
                if(IsTouchingWall(w))
                {
                    if(this.picture.fileName == "Images/Missile.png")
                        ExplodeMissile();
                    else
                    {
                        BackUpPosition();
                        PointF normal = w.NormalAtNearestPoint(this.location);
                        BounceFrom(normal);
                    }
                }
            }
        }

        public void Move()
        {
            this.location.X += this.velocity.X;
            this.location.Y += this.velocity.Y;
        }

        public bool IsTouching(Soldier s)
        {
            double diffX = (double)(this.location.X - s.location.X);
            double diffY = (double)(this.location.Y - s.location.Y);
            double totalRad = (double)(this.radius + s.radius);
            return Math.Sqrt(diffX * diffX + diffY * diffY) < totalRad;
        }

        public bool IsTouchingWall(Wall wall)
        {
            if(wall is WaterHazard)
                return false;
            
            PointF pointNearestToWall = wall.PointNearestTo(this.location);
            double diffX = (double)(pointNearestToWall.X - this.location.X);
            double diffY = (double)(pointNearestToWall.Y - this.location.Y);
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

        public void ExplodeMissile()
        {
            MainForm.bulletList.Remove(this);
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
}