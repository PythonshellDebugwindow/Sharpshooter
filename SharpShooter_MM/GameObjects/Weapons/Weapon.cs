using System;
using System.Drawing;

namespace SharpShooter_MM.GameObjects.Weapons
{
    public abstract class Weapon
    {
        public PointF location;
        public Picture picture;
        public float bulletSpeed;
        public int fireDelay;
        public float bulletStartDistance;
        public float facingAngle;
        public int timeSinceLastShot;
        public bool onGround = false;
        public int radius;
        public int ammo;
        public int damage = 1;
        public Sound shootSound;
        
        public Weapon(string image, PointF location)
        {
            this.location = location;
            this.picture = new Picture(image, location, 1, 1);
            this.radius = this.picture.bitmap.Width / 2;
            this.shootSound = new Sound("Sounds/Shoot3.wav");
        }

        public void Draw(Graphics g)
        {
            this.picture.angle = this.facingAngle;
            this.picture.location.X = this.location.X - MainForm.viewOffset.X;
            this.picture.location.Y = this.location.Y - MainForm.viewOffset.Y;
            this.picture.Draw(g);
        }

        public void Update(int time)
        {
            this.timeSinceLastShot += time;
            if (this.onGround && IsTouching(MainForm.player1))
            {
                this.onGround = false;
                MainForm.weaponList.Remove(this);
                foreach(Weapon w in MainForm.player1.weapons)
                {
                    if(GetType() == w.GetType())
                    {
                        w.ammo += this.ammo;
                        return;
                    }
                }
                MainForm.player1.weapons.Add(this);
            }
        }

        public void Fire(Soldier firer)
        {
            if(this.timeSinceLastShot >= this.fireDelay && this.ammo > 0)
            {
                float xComponent = (float)Math.Cos(this.facingAngle / 180f * Math.PI);
                float yComponent = -(float)Math.Sin(this.facingAngle / 180f * Math.PI);
                Bullet b = CreateBullet(firer);
                b.velocity = new PointF(xComponent * b.bulletSpeed, yComponent * b.bulletSpeed);
                b.damage *= firer.damageModifier;
                if(firer == MainForm.player1 && !(this is EnemyPistol))
                {
                    --this.ammo;
                }
                this.timeSinceLastShot = 0;

                double diffX = this.location.X - MainForm.player1.location.X;
                double diffY = this.location.Y - MainForm.player1.location.Y;
                double dist = Math.Sqrt(diffX * diffX + diffY * diffY);
                if(dist < 400)
                    this.shootSound.Play();
            }
            if(this.ammo <= 0)
            {
                MainForm.player1.weapons.Remove(this);
                ++MainForm.player1.weaponIndex;
                if(MainForm.player1.weaponIndex >= MainForm.player1.weapons.Count)
                    MainForm.player1.weaponIndex = 0;
                MainForm.player1.currentWeapon = MainForm.player1.weapons[MainForm.player1.weaponIndex];
            }
        }

        public abstract Bullet CreateBullet(Soldier firer);

        public bool IsTouching(Soldier s)
        {
            double diffX = (double)(this.location.X - s.location.X);
            double diffY = (double)(this.location.Y - s.location.Y);
            double totalRad = (double)(this.radius + s.radius);
            return Math.Sqrt(diffX * diffX + diffY * diffY) < totalRad;
        }
    }
}