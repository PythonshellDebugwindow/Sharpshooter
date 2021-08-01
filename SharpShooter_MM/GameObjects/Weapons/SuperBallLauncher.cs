using System;
using System.Drawing;

namespace SharpShooter_MM.GameObjects.Weapons
{
    public class SuperBallLauncher : Weapon
    {
        public SuperBallLauncher(PointF location) : base("Images/SuperBallLauncher.png", location)
        {
            this.bulletSpeed = 30;
            this.fireDelay = 750;
            this.bulletStartDistance = 20;
            this.ammo = 5;
            this.damage = 15;
            this.shootSound = new Sound("Sounds/Cannon2.wav");
        }

        public override Bullet CreateBullet(Soldier firer)
        {
            float xComponent = (float)Math.Cos(this.facingAngle / 180f * Math.PI);
            float yComponent = -(float)Math.Sin(this.facingAngle / 180f * Math.PI);
            Bullet b = new Bullet(new PointF(this.location.X + xComponent * this.bulletStartDistance,
                                             this.location.Y + yComponent * this.bulletStartDistance), firer, this.damage);
            b.picture = new Picture("Images/SuperBall.png", b.location, 4, 25);
            b.lifetime = 1f;
            return b;
        }
    }
}