using System.Drawing;

namespace SharpShooter_MM.GameObjects.Levels
{
    public class TestLevel : Level
    {
        public TestLevel()
        {
            this.playerLocation = new PointF(0, 100);
            borderX = -800;
            borderY = -800;
            borderWidth = 1600;
            borderHeight = 1600;
        }

        public override void CreateWalls()
        {
            //Outer
            _ = new BreakableWall(-600, 20, 400, 40, "Green");
            _ = new BreakableWall(200, 20, 200, 20, "Blue");

            //Inner
            _ = new BreakableWall(-500, -200, 400, 40, "Orange");
            _ = new BreakableWall(100, -200, 100, 20, "Green");

            _ = new WaterHazard(200, 200, 200, 200);
        }

        public override void CreateEnemies()
        {
            _ = new BossEnemy(new PointF(0, -100));
            //_ = new EnemySoldier(new PointF(-100, 200));
            _ = new NarcissistEnemy(new PointF(0, 200));
            _ = new NarcissistEnemy(new PointF(200, 200));
        }

        public override void CreateWeapons()
        {
            Weapons.Weapon rapidGun = new Weapons.MissileLauncher(new PointF(0, 200));
            rapidGun.onGround = true;
            MainForm.weaponList.Add(rapidGun);

            rapidGun = new Weapons.RapidGun(new PointF(-600, -600));
            rapidGun.onGround = true;
            MainForm.weaponList.Add(rapidGun);

            rapidGun = new Weapons.RapidGun(new PointF(600, 600));
            rapidGun.onGround = true;
            MainForm.weaponList.Add(rapidGun);

            Grenade g = new Grenade(new PointF(-60, 250));
            g.onGround = true;
            MainForm.grenadeList.Add(g);
            g = new Grenade(new PointF(60, 250));
            g.onGround = true;
            MainForm.grenadeList.Add(g);
        }

        public void CreateTeleporters()
        {
            _ = new Teleporter(new PointF(-700, -700), new PointF(500, -700));
            _ = new Teleporter(new PointF(600, -700), new PointF(-600, -700));

            _ = new Teleporter(new PointF(100, 0), new PointF(-600, -600));
        }

        public void CreatePowerUps()
        {
            _ = new PowerUp(new PointF(-700, 700), PowerUpType.Ammo, 10, false);
            _ = new PowerUp(new PointF(-600, 700), PowerUpType.Health, 50, false);
            
            _ = new PowerUp(new PointF(-30, 250), PowerUpType.Health, 20, true);
            _ = new PowerUp(new PointF(0, 250), PowerUpType.Invincibility, 10, false);
            //_ = new PowerUp(new PointF(30, 250), PowerUpType.Damage, 10);
        }

        public new void CreateLevel()
        {
            base.CreateLevel();
            CreateTeleporters();
            CreatePowerUps();
            MainForm.player1.hp = 150;

            Weapons.Weapon x = new Weapons.MissileLauncher(playerLocation);
            MainForm.player1.weapons.Add(x);
            x = new Weapons.MissileLauncher(playerLocation);
            MainForm.player1.weapons.Add(x);
            x = new Weapons.MissileLauncher(playerLocation);
            MainForm.player1.weapons.Add(x);
        }
    }
}