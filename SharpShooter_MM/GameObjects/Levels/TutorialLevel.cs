using System.Drawing;

namespace SharpShooter_MM.GameObjects.Levels
{
    class TutorialLevel : Level
    {
        public static Wall teleportBarrier;

        public TutorialLevel()
        {
            this.playerLocation = new PointF(0, 0);
            this.playerLocation = new PointF(10111, -583);
            borderX = -1000;
            borderY = -1000;
            borderWidth = 20000;
            borderHeight = 2100;
        }

        public override void CreateWalls()
        {
            _ = new Wall(-180, -180, 2680, 80, "Green"); //1st Ceiling
            _ = new Wall(-180, -100, 80, 280, "Green"); //1st West Wall
            _ = new Wall(-100, 100, 2880, 80, "Green"); //1st Floor

            _ = new Wall(2500, -500, 8500, 80, "Green"); //Ceiling-Bend / 2nd Ceiling
            _ = new Wall(2500, -420, 80, 320, "Green"); //Wall-Bend
            _ = new Wall(2780, -140, 80, 320, "Green"); //Wall-Bend

            _ = new Wall(2780, -220, 8300, 80, "Green"); //2nd Floor

            teleportBarrier = new Wall(10080, -420, 60, 200, "Blue");
            
            _ = new Wall(11000, -500, 80, 280, "Green"); //Last Wall

            //Teleporter walls
            _ = new Wall(0, 400, 630, 80, "Green"); //T
            _ = new Wall(0, 480, 80, 480, "Green"); //L
            _ = new Wall(80, 880, 630, 80, "Green"); //B
            _ = new Wall(630, 400, 80, 480, "Green"); //L

            _ = new BreakableWall(6520, -420, 60, 200, "Blue");
        }

        public override void CreateEnemies()
        {
            EnemySoldier e = new EnemySoldier(new PointF(3880, -320));
            e.currentWeapon.damage = 0;
            e.hp = 3;
            e.moveSpeed = 0;

            e = new NarcissistEnemy(new PointF(9870, -320));
            e.facingAngle = 180;
            e.currentWeapon.fireDelay = 750;
            e.moveSpeed = 0;
            e.timeSinceLastRandomMove = int.MinValue;
            e.randomMoveDelay = int.MaxValue;

            e = new EnemySoldier(new PointF(280, 630));
            e.randomMoveDelay *= 2;
            e.moveSpeed = 3;
            e.currentWeapon.fireDelay = 1200;

            e = new EnemySoldier(new PointF(280, 730));
            e.randomMoveDelay *= 2;
            e.moveSpeed = 3;
            e.currentWeapon.fireDelay = 1200;

            e = new EnemySoldier(new PointF(380, 680));
            e.randomMoveDelay *= 2;
            e.moveSpeed = 3;
            e.currentWeapon.fireDelay = 1200;
        }

        public override void CreateWeapons()
        {
            Weapons.SniperGun sg = new Weapons.SniperGun(new PointF(4720, -320));
            sg.onGround = true;
            sg.damage = 3;
            MainForm.weaponList.Add(sg);
        }

        public void CreateTeleporters()
        {
            //new Teleporter(new PointF(10900, -320), new PointF(500, -500));
            new Teleporter(new PointF(10900, -320), new PointF(180, 680));
        }

        public void CreatePowerUps()
        {
            _ = new PowerUp(new PointF(7280, -320), PowerUpType.Grenades, 5, true);
            _ = new PowerUp(new PointF(7880, -320), PowerUpType.Health, 10, true);
            _ = new PowerUp(new Point(8420, -320), PowerUpType.Ammo, 10, true);
        }

        public new void CreateLevel()
        {
            base.CreateLevel();
            CreateTeleporters();
            CreatePowerUps();
            MainForm.player1.hp = 100;
            MainForm.player1.moveSpeed = 50;
        }
    }
}