using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace SharpShooter_MM
{
    public partial class MainForm : Form
    {
        public Graphics windowsGraphics;
        public static GameObjects.Player player1;

        public static List<GameObjects.Bullet> bulletList;
        public static List<GameObjects.EnemySoldier> enemyList;
        public static List<GameObjects.Wall> wallList;
        public static List<GameObjects.MovingWall> movingWallList;
        public static List<GameObjects.Explosion> explosionList;
        public static List<GameObjects.Weapons.Weapon> weaponList;
        public static List<GameObjects.Teleporter> teleporterList;
        public static List<GameObjects.Grenade> grenadeList;
        public static List<GameObjects.PowerUp> powerUpList;
        public static List<ScheduledAction> scheduledActionList;

        public Graphics onscreenGraphics;
        public Bitmap screen;
        public Picture gameOverScreen;
        public Picture victoryScreen;
        public static Point viewOffset;
        public static float timeElapsed;
        public int currentLevel = 0;//-1;//Test level
        public static int maxLevel = 4;
        public bool isMainMenu = true;
        public Font font;
        public Font tutorialFont;
        public SolidBrush brush;
        public SolidBrush tutorialBrush;
        public StringFormat stringFormat;

        public MainForm()
        {
            InitializeComponent();
            
            this.font = new Font("Arial", 16);
            this.tutorialFont = new Font("Arial", 25);
            this.brush = new SolidBrush(Color.Red);
            this.tutorialBrush = new SolidBrush(Color.White);
            this.stringFormat = new StringFormat();
            this.stringFormat.Alignment = StringAlignment.Center;

            GameObjects.Player.shield = new GameObjects.Shield();
            player1 = new GameObjects.Player(new PointF());
            GameObjects.Player.shield.Init(0, 0, 0, 0, player1);
            
            NextLevelLabel.Hide();
            RestartLabel.Hide();
            QuitLabel.Hide();
            OptionsMenu.Visible = false;
            
            this.windowsGraphics = CreateGraphics();
            this.screen = new Bitmap(this.Width, this.Height);
            this.onscreenGraphics = Graphics.FromImage(screen);
            this.Paint += new PaintEventHandler(DrawGame);
            this.KeyDown += new KeyEventHandler(HandleKeyDown);
        }

        void Init()
        {
            timeElapsed = 0;
            NextLevelLabel.Hide();
            RestartLabel.Hide();
            QuitLabel.Hide();
            GameTimer.Enabled = true;
            
            OptionsMenu.Visible = true;
            ChooseLevelMenu.Visible = false;

            switch(this.currentLevel)
            {
                case 0:
                    new GameObjects.Levels.TutorialLevel().CreateLevel();
                    break;
                case 1:
                    new GameObjects.Levels.Level1().CreateLevel();
                    break;
                case 2:
                    new GameObjects.Levels.Level2().CreateLevel();
                    break;
                case 3:
                    new GameObjects.Levels.Level3().CreateLevel();
                    break;
                case 4:
                    new GameObjects.Levels.Level4().CreateLevel();
                    break;
                case -1:
                    new GameObjects.Levels.TestLevel().CreateLevel();
                    break;
                default:
                    this.currentLevel = 1;
                    new GameObjects.Levels.Level1().CreateLevel();
                    break;
            }

            this.gameOverScreen = new Picture("Images/GameOver.png", new PointF(this.Width / 2, this.Height / 3), 1, 1);
            this.victoryScreen = new Picture("Images/Victory.png", new PointF(this.Width / 2, this.Height / 3), 1, 1);

            this.KeyDown += new KeyEventHandler(player1.KeyDown);
            this.KeyUp += new KeyEventHandler(player1.KeyUp);
        }

        public void DrawGame(Object sender, PaintEventArgs e)
        {
            this.onscreenGraphics.Clear(Color.Black);

            if(isMainMenu || !GameTimer.Enabled)
                return;

            foreach(GameObjects.Teleporter t in teleporterList)
            {
                t.Draw(this.onscreenGraphics);
            }
            foreach(GameObjects.Bullet b in bulletList)
            {
                b.Draw(this.onscreenGraphics);
            }
            foreach(GameObjects.Wall w in wallList)
            {
                w.Draw(this.onscreenGraphics);
            }
            player1.Draw(this.onscreenGraphics);
            foreach (GameObjects.Explosion x in explosionList)
            {
                x.Draw(this.onscreenGraphics);
            }
            foreach(GameObjects.Weapons.Weapon w in weaponList)
            {
                w.Draw(this.onscreenGraphics);
            }
            foreach(GameObjects.Grenade g in grenadeList)
            {
                g.Draw(this.onscreenGraphics);
            }
            foreach(GameObjects.PowerUp p in powerUpList)
            {
                p.Draw(this.onscreenGraphics);
            }
            foreach(GameObjects.EnemySoldier s in enemyList)
            {
                s.Draw(this.onscreenGraphics);
                PointF textLocation = new PointF(s.location.X - viewOffset.X, s.location.Y - s.radius * 1.25f - viewOffset.Y);
                onscreenGraphics.Transform = new Matrix();
                onscreenGraphics.DrawString(s.hp.ToString(), this.font, this.brush, textLocation, this.stringFormat);
            }

            if(this.currentLevel == 0)
            {
                DrawTutorialText();
            }

            if(player1.killed)
            {
                this.gameOverScreen.Draw(this.onscreenGraphics);
                this.windowsGraphics.DrawImage(this.gameOverScreen.bitmap, new PointF());
                LevelEndScreen();
            }
            else if(enemyList.Count == 0)
            {
                this.victoryScreen.Draw(this.onscreenGraphics);
                this.windowsGraphics.DrawImage(this.victoryScreen.bitmap, new PointF());
                LevelEndScreen();
            }

            this.windowsGraphics.DrawImage(this.screen, new Point(0, 0));
        }

        public void LevelEndScreen()
        {
            NextLevelLabel.Show();
            RestartLabel.Show();
            QuitLabel.Show();
            OptionsMenu.Visible = false;
            ChooseLevelMenu.Visible = true;
            GameTimer.Enabled = false;
            if(this.currentLevel >= maxLevel)
            {
                if(!player1.killed)
                    NextLevelLabel.Text = "You Beat The Game";
                else
                    NextLevelLabel.Text = "";
            }
            else
                NextLevelLabel.Text = "Next Level";
        }

        public void DrawTutorialText()
        {
            onscreenGraphics.Transform = new Matrix();
            onscreenGraphics.DrawString("Sharpshooter\r\nPress the Up arrow to move", this.tutorialFont, this.tutorialBrush, new PointF(-32 - viewOffset.X, -32 - viewOffset.Y));
            onscreenGraphics.DrawString("Press the Down arrow to move backwards", this.tutorialFont, this.tutorialBrush, new PointF(750 - viewOffset.X, -16 - viewOffset.Y));
            onscreenGraphics.DrawString("Press the Left and Right arrows to turn", this.tutorialFont, this.tutorialBrush, new PointF(2000 - viewOffset.X, -16 - viewOffset.Y));
            onscreenGraphics.DrawString("Ahead of you is an enemy.\r\nPress space to shoot it.", this.tutorialFont, this.tutorialBrush, new PointF(3180 - viewOffset.X, -356 - viewOffset.Y));
            onscreenGraphics.DrawString("Pick up weapons to add\r\nthem to your inventory", this.tutorialFont, this.tutorialBrush, new PointF(4320 - viewOffset.X, -356 - viewOffset.Y));
            onscreenGraphics.DrawString("Press Q to switch your weapon.", this.tutorialFont, this.tutorialBrush, new PointF(4920 - viewOffset.X, -340 - viewOffset.Y));
            onscreenGraphics.DrawString("Grenades can go farther than bullets.\r\nPress E to throw one, T for short range.\r\nThey can destroy cracked walls.", this.tutorialFont, this.tutorialBrush, new PointF(5920 - viewOffset.X, -371 - viewOffset.Y));
            onscreenGraphics.DrawString("Some powerups give you more grenades.", this.tutorialFont, this.tutorialBrush, new PointF(6620 - viewOffset.X, -340 - viewOffset.Y));
            onscreenGraphics.DrawString("Some give you more health.", this.tutorialFont, this.tutorialBrush, new PointF(7420 - viewOffset.X, -340 - viewOffset.Y));
            onscreenGraphics.DrawString("Others give your current\r\nweapon more ammo.", this.tutorialFont, this.tutorialBrush, new PointF(8020 - viewOffset.X, -356 - viewOffset.Y));
            onscreenGraphics.DrawString("Press W to use your shield.\n\rIt can deflect enemy bullets.", this.tutorialFont, this.tutorialBrush, new PointF(8520 - viewOffset.X, -356 - viewOffset.Y));
            onscreenGraphics.DrawString("Purple enemies like this one can\r\nonly be damaged by their own bullets.", this.tutorialFont, this.tutorialBrush, new PointF(9120 - viewOffset.X, -356 - viewOffset.Y));
            onscreenGraphics.DrawString("Teleporters teleport you to another location.\r\nGet ready to fight!", this.tutorialFont, this.tutorialBrush, new PointF(10180 - viewOffset.X, -356 - viewOffset.Y));
            
            if(this.currentLevel == 0 && GameObjects.Levels.TutorialLevel.teleportBarrier != null)
                onscreenGraphics.DrawString("Kill both enemies to progress.", this.tutorialFont, this.tutorialBrush, new PointF(9900 - viewOffset.X, -480 - viewOffset.Y));
        }
        
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if(isMainMenu)
            {
                this.windowsGraphics.Clear(Color.Black);
                OnPaint(new PaintEventArgs(this.windowsGraphics, new Rectangle(0, 0, this.Width, this.Height)));
                return;
            }

            timeElapsed += 0.1f;

            if(this.currentLevel == 0)
                UpdateTutorial();
            
            if(!player1.killed)
            {
                viewOffset.X = (int)player1.location.X - this.Width / 2;
                viewOffset.Y = (int)player1.location.Y - this.Height / 2;
                player1.Update(GameTimer.Interval);
            }

            HealthLabel.Text = "HP: " + player1.hp;
            TimeLabel.Text = "Time: " + (int)timeElapsed / 60 + "m";
            TimeLabel.Text += " " + (int)timeElapsed % 60 + "s";
            if(player1.currentWeapon is GameObjects.Weapons.EnemyPistol)
                AmmoLabel.Text = "Ammo: ∞";
            else
                AmmoLabel.Text = "Ammo: " + player1.currentWeapon.ammo;
            GrenadesLabel.Text = "Grenades: " + player1.grenades;

            for(int i = 0; i < teleporterList.Count; ++i)
            {
                teleporterList[i].Update(GameTimer.Interval);
            }
            for(int i = 0; i < enemyList.Count; ++i)
            {
                enemyList[i].Update(GameTimer.Interval);
            }
            for(int i = 0; i < wallList.Count; ++i)
            {
                wallList[i].Update(GameTimer.Interval);
            }
            for(int i = 0; i < movingWallList.Count; ++i)
            {
                movingWallList[i].Update(GameTimer.Interval);
            }
            for(int i = 0; i < bulletList.Count; ++i)
            {
                bulletList[i].Update(GameTimer.Interval);
            }
            for(int i = 0; i < explosionList.Count; ++i)
            {
                explosionList[i].Update(GameTimer.Interval);
            }
            for(int i = 0; i < weaponList.Count; ++i)
            {
                weaponList[i].Update(GameTimer.Interval);
            }
            for(int i = 0; i < grenadeList.Count; ++i)
            {
                grenadeList[i].Update(GameTimer.Interval);
            }
            for(int i = 0; i < powerUpList.Count; ++i)
            {
                powerUpList[i].Update(GameTimer.Interval);
            }
            for(int i = 0; i < scheduledActionList.Count; ++i)
            {
                scheduledActionList[i].Update(GameTimer.Interval);
            }
            OnPaint(new PaintEventArgs(this.windowsGraphics, new Rectangle(0, 0, this.Width, this.Height)));
        }

        public void UpdateTutorial()
        {
            if(enemyList.Count <= 3 && GameObjects.Levels.TutorialLevel.teleportBarrier != null)
            {
                wallList.Remove(GameObjects.Levels.TutorialLevel.teleportBarrier);
                GameObjects.Levels.TutorialLevel.teleportBarrier = null;
            }
        }

        public void HandleKeyDown(Object sender, KeyEventArgs e)
        {
            if(this.isMainMenu && e.KeyCode == Keys.Enter)
                PlayLabel_Click(sender, new EventArgs());
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void PlayLabel_Click(object sender, EventArgs e)
        {
            Title.Hide();
            PlayLabel.Hide();

            HealthLabel.Show();
            TimeLabel.Show();
            AmmoLabel.Show();
            GrenadesLabel.Show();
            
            this.isMainMenu = false;
            Init();
        }
        
        private void NextLevelLabel_Click(object sender, EventArgs e)
        {
            if(this.currentLevel < maxLevel)
            {
                ++this.currentLevel;
                Init();
            }
        }
        
        private void playerHealth1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player1.hp = 1;
        }

        private void RestartLabel_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void QuitLabel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void killPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player1.killed = true;
        }

        private void beatLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enemyList.Clear();
        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bulletList.Clear();
            enemyList.Clear();
            wallList.Clear();
            movingWallList.Clear();
            explosionList.Clear();
            weaponList.Clear();
            teleporterList.Clear();
            grenadeList.Clear();
            powerUpList.Clear();
            scheduledActionList.Clear();

            NextLevelLabel.Hide();
            RestartLabel.Hide();
            QuitLabel.Hide();
            
            HealthLabel.Hide();
            TimeLabel.Hide();
            AmmoLabel.Hide();
            GrenadesLabel.Hide();

            PlayLabel.Show();
            Title.Show();

            this.isMainMenu = true;
            Init();
            OptionsMenu.Visible = false;
            ChooseLevelMenu.Visible = true;
            this.windowsGraphics.Clear(Color.Black);
            OnPaint(new PaintEventArgs(this.windowsGraphics, new Rectangle(0, 0, this.Width, this.Height)));
        }

        private void quitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.currentLevel = 0;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.currentLevel = 1;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.currentLevel = 2;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.currentLevel = 3;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            this.currentLevel = 4;
        }

        private void testLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.currentLevel = -1;
        }
    }
}