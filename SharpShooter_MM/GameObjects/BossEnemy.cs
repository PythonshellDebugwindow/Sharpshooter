using System.Drawing;

namespace SharpShooter_MM.GameObjects
{
    public class BossEnemy : EnemySoldier
    {
        public BossEnemy(PointF location) : base("Images/Boss.png", location)
        {
            this.facingAngle = 270;
            this.moveSpeed = 3;
            this.hp = 100;
            this.randomMoveDelay = 5000;
            this.currentWeapon = new Weapons.SuperBallLauncher(this.location);
            this.currentWeapon.fireDelay = 500;
            this.currentWeapon.damage = 25;
        }
    }
}