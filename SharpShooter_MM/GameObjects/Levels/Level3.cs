using System.Drawing;

namespace SharpShooter_MM.GameObjects.Levels
{
    public class Level3 : Level
    {
        public Level3()
        {
            this.playerLocation = new PointF(0, 0);
            borderX = -400;
            borderY = -400;
            borderWidth = 800;
            borderHeight = 800;
        }

        public override void CreateWalls()
        {
            _ = new Wall(-250, -100, 300, 50, "Blue");
            _ = new Wall(-250, 50, 300, 50, "Blue");
        }

        public override void CreateEnemies()
        {
            _ = new EnemySoldier(new PointF(-200, -150));
            _ = new EnemySoldier(new PointF(-150, -150));
            _ = new EnemySoldier(new PointF(-100, -150));
            _ = new EnemySoldier(new PointF(-50, -150));
            _ = new EnemySoldier(new PointF(0, -150));

            _ = new EnemySoldier(new PointF(-200, 150));
            _ = new EnemySoldier(new PointF(-150, 150));
            _ = new EnemySoldier(new PointF(-100, 150));
            _ = new EnemySoldier(new PointF(-50, 150));
            _ = new EnemySoldier(new PointF(0, 150));
        }

        public override void CreateWeapons()
        {
            Weapons.SniperGun sbl = new Weapons.SniperGun(new PointF(-100, -200));
            sbl.onGround = true;
            MainForm.weaponList.Add(sbl);
        }
    }
}