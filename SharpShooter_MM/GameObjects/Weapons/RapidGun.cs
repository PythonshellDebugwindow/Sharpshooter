using System;
using System.Drawing;

namespace SharpShooter_MM.GameObjects.Weapons
{
    public class RapidGun : Weapon
    {
        public RapidGun(PointF location) : base("Images/RapidGun.png", location)
        {
            this.bulletSpeed = 40;
            this.fireDelay = 25;
            this.bulletStartDistance = 10;
            this.ammo = 40;
            this.damage = 1;
        }

        public override Bullet CreateBullet(Soldier firer)
        {
            float xComponent = (float)Math.Cos(this.facingAngle / 180f * Math.PI);
            float yComponent = -(float)Math.Sin(this.facingAngle / 180f * Math.PI);
            Bullet b = new Bullet(new PointF(this.location.X + xComponent * this.bulletStartDistance,
                                             this.location.Y + yComponent * this.bulletStartDistance), firer, this.damage);
            b.picture = new Picture("Images/Bullet2.png", b.location, 4, 25);
            b.lifetime = 0.9f;
            return b;
        }
    }
}
