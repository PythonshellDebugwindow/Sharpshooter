using System;
using System.Drawing;

namespace SharpShooter_MM.GameObjects
{
    public class StrongEnemy : EnemySoldier
    {
        public StrongEnemy(PointF location) : base("Images/Enemy2.png", location)
        {
            this.moveSpeed = 0;// 10
            this.hp = 12;
            this.currentWeapon = new Weapons.SniperGun(this.location);
        }
    }
}