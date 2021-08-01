using System.Collections.Generic;
using System.Drawing;

namespace SharpShooter_MM.GameObjects.Levels
{
    public abstract class Level
    {
        public PointF playerLocation;
        public static int borderX, borderY, borderWidth, borderHeight;
        
        public static void InitializeLists()
        {
            MainForm.bulletList = new List<Bullet>();
            MainForm.enemyList = new List<EnemySoldier>();
            MainForm.wallList = new List<Wall>();
            MainForm.movingWallList = new List<MovingWall>();
            MainForm.explosionList = new List<Explosion>();
            MainForm.weaponList = new List<Weapons.Weapon>();
            MainForm.teleporterList = new List<Teleporter>();
            MainForm.grenadeList = new List<Grenade>();
            MainForm.powerUpList = new List<PowerUp>();
            MainForm.scheduledActionList = new List<ScheduledAction>();
        }

        public static void CreateBorders(int topX, int topY, int width, int height)
        {
            _ = new Wall(topX - 80, topY - 80, width + 80, 80, "Green");
            _ = new Wall(topX - 80, topY, 80, height + 80, "Green");
            _ = new Wall(topX, topY + height, width + 80, 80, "Green");
            _ = new Wall(topX + width, topY - 80, 80, height + 80, "Green");
        }

        public abstract void CreateWalls();

        public abstract void CreateEnemies();

        public abstract void CreateWeapons();

        public void CreateLevel()
        {
            MainForm.player1.Reset();
            MainForm.player1.location = playerLocation;
            InitializeLists();
            CreateBorders(borderX, borderY, borderWidth, borderHeight);
            CreateWalls();
            CreateEnemies();
            CreateWeapons();
        }
    }
}