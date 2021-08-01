using System.Drawing;

namespace SharpShooter_MM.GameObjects.Levels
{
    public class Level4 : Level
    {
        public Level4()
        {
            this.playerLocation = new PointF(0, 100);
            borderX = -400;
            borderY = -400;
            borderWidth = 800;
            borderHeight = 800;
        }

        public override void CreateWalls()
        {
            //Outer
            _ = new MovingWall(-600, 20, -400, 20, 400, 40, "Green", 20, 0);
            _ = new MovingWall(200, 20, 0, 20, 200, 20, 400, 40, "Green", -20, 0);

            //Inner
            _ = new MovingWall(-500, -200, -400, -200, 400, 40, "Green", 20, 0);
            _ = new MovingWall(100, -200, 0, -200, 100, 20, 400, 40, "Green", -20, 0);
        }

        public override void CreateEnemies()
        {
            _ = new EnemySoldier(new PointF(-350, -120));
            _ = new EnemySoldier(new PointF(-350, -60));
            _ = new EnemySoldier(new PointF(-350, 0));
            
            _ = new EnemySoldier(new PointF(350, -120));
            _ = new EnemySoldier(new PointF(350, -60));
            _ = new EnemySoldier(new PointF(350, 0));

            //Inner
            _ = new StrongEnemy(new PointF(-350, -360));
            _ = new StrongEnemy(new PointF(-350, -300));
            _ = new StrongEnemy(new PointF(-350, -240));

            _ = new StrongEnemy(new PointF(350, -360));
            _ = new StrongEnemy(new PointF(350, -300));
            _ = new StrongEnemy(new PointF(350, -240));
        }

        public override void CreateWeapons()
        {}
        
        public void CreateTeleporters()
        {
            _ = new Teleporter(new PointF(-100, 200), new PointF(300, 300));
        }

        public new void CreateLevel()
        {
            base.CreateLevel();
            CreateTeleporters();
            Weapons.SniperGun sniperGun = new Weapons.SniperGun(playerLocation);
            MainForm.player1.weapons.Add(sniperGun);
            ++MainForm.player1.weaponIndex;
            MainForm.player1.currentWeapon = sniperGun;
            MainForm.player1.weapons.Add(new Weapons.SuperBallLauncher(playerLocation));

            MainForm.player1.hp = 1000;
        }
    }
}