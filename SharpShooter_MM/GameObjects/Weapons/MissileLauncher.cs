using System;
using System.Drawing;

namespace SharpShooter_MM.GameObjects.Weapons
{
    public class MissileLauncher : Weapon
    {
        public MissileLauncher(PointF location) : base("Images/MissileLauncher.png", location)
        {
            this.bulletSpeed = 30;
            this.fireDelay = 1500;
            this.bulletStartDistance = 30;
            this.ammo = 4;
            this.damage = 35;
        }

        public override Bullet CreateBullet(Soldier firer)
        {
            float xComponent = (float)Math.Cos(this.facingAngle / 180f * Math.PI);
            float yComponent = -(float)Math.Sin(this.facingAngle / 180f * Math.PI);
            Bullet b = new Bullet(new PointF(this.location.X + xComponent * this.bulletStartDistance,
                this.location.Y + yComponent * this.bulletStartDistance), firer, this.damage);
            if(firer == MainForm.player1)
                b.picture = new Picture("Images/Missile.png", b.location, 1, 1);
            return b;
        }
    }
}