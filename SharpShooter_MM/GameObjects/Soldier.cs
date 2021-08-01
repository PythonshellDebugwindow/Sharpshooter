using System;
using System.Drawing;

namespace SharpShooter_MM.GameObjects
{
    public class Soldier
    {
        public PointF location;
        public Picture picture;
        public float facingAngle = 0;
        public float turnDirection = 0;
        public int walkDirection = 0;
        public PointF velocity;
        public float moveSpeed = 20;
        public bool isFiring = false;
        public int radius;
        public int hp = 5;
        public bool killed = false;
        public bool hitFlicker = false;
        public int hitFlickerCount = 0;
        public Weapons.Weapon currentWeapon;
        public bool isThrowingGrenade = false;
        public int timeSinceLastThrow = 0;
        public int throwDelay = 2000;
        public int grenades = 5;
        public int grenadeStartDistance = 10;
        public bool invincible = false;
        public int damageModifier = 1;

        public Soldier(string image, PointF location)
        {
            this.location = location;
            this.picture = new Picture(image, location, 4, 60);
            this.radius = this.picture.bitmap.Width / 2;
            this.velocity = new PointF();
            this.currentWeapon = new Weapons.EnemyPistol(this.location);
        }
        
        public void Draw(Graphics g)
        {
            if(this.killed)
            {
                this.currentWeapon.onGround = true;
                MainForm.weaponList.Add(this.currentWeapon);
                return;
            }
            if(!this.hitFlicker)
            {
                this.picture.angle = this.facingAngle;
                this.picture.location.X = this.location.X - MainForm.viewOffset.X;
                this.picture.location.Y = this.location.Y - MainForm.viewOffset.Y;
                this.currentWeapon.Draw(g);
                this.picture.Draw(g);
            }
        }

        public virtual void Update(int time)
        {
            if(this.hp <= 0 && !this.killed)
            {
                this.killed = true;
                if(!(this.currentWeapon is Weapons.EnemyPistol))
                {
                    this.currentWeapon.onGround = true;
                    MainForm.weaponList.Add(this.currentWeapon);
                }
                if(this is Player)
                    Explosion.explosionSound = new Sound("Sounds/Explosion1Long.wav");
                _ = new Explosion(this.location);
                return;
            }

            this.timeSinceLastThrow += time;

            if(this.hitFlickerCount > 0)
            {
                --this.hitFlickerCount;
                this.hitFlicker = !this.hitFlicker;
            }
            else
            {
                this.hitFlicker = false;
            }
            if(this.velocity.X != 0 && this.velocity.Y != 0)
            {
                this.picture.Update(time);
            }
            this.facingAngle += (float)time * this.turnDirection;
            this.velocity.X = (float)Math.Cos(this.facingAngle / 180f * Math.PI) * this.walkDirection;
            this.velocity.X *= this.moveSpeed;
            this.velocity.Y = -(float)Math.Sin(this.facingAngle / 180f * Math.PI) * this.walkDirection;
            this.velocity.Y *= this.moveSpeed;
            Move();
            
            if(this.isFiring)
            {
                this.currentWeapon.Fire(this);
            }

            if(isThrowingGrenade)
            {
                FireGrenade();
                this.isThrowingGrenade = false;
            }

            foreach(Wall w in MainForm.wallList)
            {
                if(w is Shield)
                {
                    continue;
                }
                PointF touchPoint = new PointF();
                if(IsTouchingWall(w, ref touchPoint))
                {
                    PushFrom(touchPoint);
                }
            }

            UpdateWeapon(time);
        }

        public void Move()
        {
            this.location.X += this.velocity.X;
            this.location.Y += this.velocity.Y;
        }

        public void TakeDamage(int damage)
        {
            if(!this.invincible)
            {
                this.hp -= damage;
                this.hitFlickerCount = 3;
            }
        }

        public bool IsTouchingWall(Wall wall, ref PointF touchPoint)
        {
            if(wall is WaterHazard)
                return false;

            PointF pointNearestToWall = wall.PointNearestTo(this.location);
            double diffX = (double)(pointNearestToWall.X - this.location.X);
            double diffY = (double)(pointNearestToWall.Y - this.location.Y);
            double distance = Math.Sqrt(diffX * diffX + diffY * diffY);

            if(distance < this.radius)
            {
                touchPoint = pointNearestToWall;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PushFrom(PointF p)
        {
            double diffX = (double)(p.X - this.location.X);
            double diffY = (double)(p.Y - this.location.Y);
            float distance = (float)Math.Sqrt(diffX * diffX + diffY * diffY);
            if(distance == 0)
            {
                return;
            }

            float desiredDistance = this.radius + 1;
            float proportion = desiredDistance / distance;
            PointF move = new PointF(this.location.X - p.X, this.location.Y - p.Y);
            move.X *= proportion;
            move.Y *= proportion;
            this.location.X = p.X + move.X;
            this.location.Y = p.Y + move.Y;
        }

        public void UpdateWeapon(int time)
        {
            float xOff = (float)Math.Cos(this.facingAngle / 180f * Math.PI) * 32;
            float yOff = -(float)Math.Sin(this.facingAngle / 180f * Math.PI) * 32;
            this.currentWeapon.location.X = this.location.X + xOff;
            this.currentWeapon.location.Y = this.location.Y + yOff;
            this.currentWeapon.facingAngle = this.facingAngle;
            this.currentWeapon.Update(time);
        }

        public void FireGrenade()
        {
            if(this.timeSinceLastThrow < this.throwDelay || this.grenades == 0)
            {
                return;
            }

            float xComponent = (float)Math.Cos(this.facingAngle / 180f * Math.PI);
            xComponent *= (this.velocity.X / 10f != 0) ? Math.Abs(this.velocity.X) / 10f : 1;
            float yComponent = -(float)Math.Sin(this.facingAngle / 180f * Math.PI);
            yComponent *= (this.velocity.Y / 10f != 0) ? Math.Abs(this.velocity.Y) / 10f : 1;
            Grenade g = CreateGrenade();
            g.velocity = new PointF(xComponent * g.grenadeSpeed, yComponent * g.grenadeSpeed);
            if(this == MainForm.player1)
            {
                --this.grenades;
            }
            this.timeSinceLastThrow = 0;

            /*double diffX = this.location.X - MainForm.player1.location.X;
            double diffY = this.location.Y - MainForm.player1.location.Y;
            double dist = Math.Sqrt(diffX * diffX + diffY * diffY);
            if(dist < 400)
                this.shootSound.Play();*/
        }
        public Grenade CreateGrenade()
        {
            float xComponent = (float)Math.Cos(this.facingAngle / 180f * Math.PI);
            float yComponent = -(float)Math.Sin(this.facingAngle / 180f * Math.PI);
            return new Grenade(new PointF(this.location.X + xComponent * this.grenadeStartDistance,
                this.location.Y + yComponent * this.grenadeStartDistance));
        }
    }
}