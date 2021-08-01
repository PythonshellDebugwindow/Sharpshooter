using System.Drawing;

namespace SharpShooter_MM.GameObjects
{
    public class NarcissistEnemy : EnemySoldier
    {
        public NarcissistEnemy(PointF location) : base("Images/NarcissistEnemy.png", location)
        {
            this.moveSpeed = 7;
            this.hp = 4;
            this.currentWeapon = new Weapons.EnemyPistol(this.location);
        }
    }
}