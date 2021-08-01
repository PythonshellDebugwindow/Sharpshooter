using System;
using System.Drawing;

namespace SharpShooter_MM.GameObjects
{
    public class FastEnemy : EnemySoldier
    {
        public FastEnemy(PointF location) : base("Images/Enemy3.png", location)
        {
            this.moveSpeed = 15;
            this.hp = 4;
            this.currentWeapon = new Weapons.SniperGun(this.location);
            this.currentWeapon.fireDelay = 500;
        }
    }
}