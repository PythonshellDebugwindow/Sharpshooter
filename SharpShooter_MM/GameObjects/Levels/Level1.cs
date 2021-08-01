using System.Drawing;

namespace SharpShooter_MM.GameObjects.Levels
{
    public class Level1 : Level
    {
        public Level1()
        {
            this.playerLocation = new PointF(500, 200);
            borderX = -800;
            borderY = -800;
            borderWidth = 1600;
            borderHeight = 1600;
        }
        
        public override void CreateWalls()
        {
            _ = new Wall(-400, -400, 400, 60, "Orange");
            _ = new Wall(-400, -400, 60, 400, "Orange");
            _ = new Wall(0, -400, 60, 400, "Orange");
            _ = new BreakableWall(-400, 0, 460, 60, "Orange");
            Grenade g = new Grenade(new PointF(-170, 80));
            g.onGround = true;
        }

        public override void CreateEnemies()
        {
            //Pistols
            _ = new EnemySoldier(new PointF(300, 150));
            _ = new EnemySoldier(new PointF(100, 350));
            _ = new EnemySoldier(new PointF(440, 250));
            //SuperBallLaunchers
            EnemySoldier es = new EnemySoldier(new PointF(-300, -300));
            es.currentWeapon = new Weapons.EnemyPistol(es.location);
            es = new EnemySoldier(new PointF(700, 500));
            es.currentWeapon = new Weapons.SuperBallLauncher(es.location);
            //SniperGuns
            es = new EnemySoldier(new PointF(-200, -100));
            es.currentWeapon = new Weapons.EnemyPistol(es.location);
            es = new EnemySoldier(new PointF(-300, -200));
            es.currentWeapon = new Weapons.EnemyPistol(es.location);
            //RapidGuns
            es = new EnemySoldier(new PointF(700, 700));
            es.currentWeapon = new Weapons.SniperGun(es.location);
        }

        public override void CreateWeapons()
        {
            Weapons.SniperGun sniperGun = new Weapons.SniperGun(new PointF(200, 200));
            sniperGun.onGround = true;
            MainForm.weaponList.Add(sniperGun);
            Weapons.RapidGun rapidGun = new Weapons.RapidGun(new PointF(200, 300));
            rapidGun.onGround = true;
            MainForm.weaponList.Add(rapidGun);
        }
    }
}