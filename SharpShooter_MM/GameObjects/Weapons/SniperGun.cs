using System;
using System.Drawing;

namespace SharpShooter_MM.GameObjects.Weapons
{
    public class SniperGun : Weapon
    {
        public SniperGun(PointF location) : base("Images/SniperGun.png", location)
        {
            this.bulletSpeed = 80;
            this.fireDelay = 1000;
            this.bulletStartDistance = 20;
            this.ammo = 15;
            this.shootSound = new Sound("Sounds/Cannon2.wav");
            this.damage = 10;
        }

        public override Bullet CreateBullet(Soldier firer)
        {
            float xComponent = (float)Math.Cos(this.facingAngle / 180f * Math.PI);
            float yComponent = -(float)Math.Sin(this.facingAngle / 180f * Math.PI);
            Bullet b = new Bullet(new PointF(this.location.X + xComponent * this.bulletStartDistance,
                                             this.location.Y + yComponent * this.bulletStartDistance), firer, this.damage);
            b.picture = new Picture("Images/SniperBullet.png", b.location, 4, 25);
            b.lifetime = 5f;
            return b;
        }
    }
}