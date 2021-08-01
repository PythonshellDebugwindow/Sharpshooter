using System;
using System.Drawing;

namespace SharpShooter_MM.GameObjects.Weapons
{
    public class EnemyPistol : Weapon
    {
        public EnemyPistol(PointF location) : base("Images/Pistol.png", location)
        {
            this.bulletSpeed = 20;
            this.fireDelay = 500;
            this.bulletStartDistance = 10;
            this.ammo = 1;
            this.damage = 1;
        }
        
        public override Bullet CreateBullet(Soldier firer)
        {
            float xComponent = (float)Math.Cos(this.facingAngle / 180f * Math.PI);
            float yComponent = -(float)Math.Sin(this.facingAngle / 180f * Math.PI);
            Bullet b = new Bullet(new PointF(this.location.X + xComponent * this.bulletStartDistance,
                this.location.Y + yComponent * this.bulletStartDistance), firer, this.damage);
            if(firer == MainForm.player1)
                b.picture = new Picture("Images/Bullet3.png", b.location, 4, 25);
            return b;
        }
    }
}
