
namespace SharpShooter_MM
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.ChooseLevelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.testLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beatLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerHealth1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Title = new System.Windows.Forms.PictureBox();
            this.PlayLabel = new System.Windows.Forms.Label();
            this.RestartLabel = new System.Windows.Forms.Label();
            this.HealthLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.QuitLabel = new System.Windows.Forms.Label();
            this.AmmoLabel = new System.Windows.Forms.Label();
            this.NextLevelLabel = new System.Windows.Forms.Label();
            this.GrenadesLabel = new System.Windows.Forms.Label();
            this.tutorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Title)).BeginInit();
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChooseLevelMenu,
            this.OptionsMenu});
            resources.ApplyResources(this.MainMenu, "MainMenu");
            this.MainMenu.Name = "MainMenu";
            // 
            // ChooseLevelMenu
            // 
            this.ChooseLevelMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tutorialToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.testLevelToolStripMenuItem});
            this.ChooseLevelMenu.Name = "ChooseLevelMenu";
            resources.ApplyResources(this.ChooseLevelMenu, "ChooseLevelMenu");
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // testLevelToolStripMenuItem
            // 
            this.testLevelToolStripMenuItem.Name = "testLevelToolStripMenuItem";
            resources.ApplyResources(this.testLevelToolStripMenuItem, "testLevelToolStripMenuItem");
            this.testLevelToolStripMenuItem.Click += new System.EventHandler(this.testLevelToolStripMenuItem_Click);
            // 
            // OptionsMenu
            // 
            this.OptionsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem,
            this.killPlayerToolStripMenuItem,
            this.beatLevelToolStripMenuItem,
            this.playerHealth1ToolStripMenuItem,
            this.mainMenuToolStripMenuItem,
            this.quitGameToolStripMenuItem});
            this.OptionsMenu.Name = "OptionsMenu";
            resources.ApplyResources(this.OptionsMenu, "OptionsMenu");
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resources.ApplyResources(this.resetToolStripMenuItem, "resetToolStripMenuItem");
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // killPlayerToolStripMenuItem
            // 
            this.killPlayerToolStripMenuItem.Name = "killPlayerToolStripMenuItem";
            resources.ApplyResources(this.killPlayerToolStripMenuItem, "killPlayerToolStripMenuItem");
            this.killPlayerToolStripMenuItem.Click += new System.EventHandler(this.killPlayerToolStripMenuItem_Click);
            // 
            // beatLevelToolStripMenuItem
            // 
            this.beatLevelToolStripMenuItem.Name = "beatLevelToolStripMenuItem";
            resources.ApplyResources(this.beatLevelToolStripMenuItem, "beatLevelToolStripMenuItem");
            this.beatLevelToolStripMenuItem.Click += new System.EventHandler(this.beatLevelToolStripMenuItem_Click);
            // 
            // playerHealth1ToolStripMenuItem
            // 
            this.playerHealth1ToolStripMenuItem.Name = "playerHealth1ToolStripMenuItem";
            resources.ApplyResources(this.playerHealth1ToolStripMenuItem, "playerHealth1ToolStripMenuItem");
            this.playerHealth1ToolStripMenuItem.Click += new System.EventHandler(this.playerHealth1ToolStripMenuItem_Click);
            // 
            // mainMenuToolStripMenuItem
            // 
            this.mainMenuToolStripMenuItem.Name = "mainMenuToolStripMenuItem";
            resources.ApplyResources(this.mainMenuToolStripMenuItem, "mainMenuToolStripMenuItem");
            this.mainMenuToolStripMenuItem.Click += new System.EventHandler(this.mainMenuToolStripMenuItem_Click);
            // 
            // quitGameToolStripMenuItem
            // 
            this.quitGameToolStripMenuItem.Name = "quitGameToolStripMenuItem";
            resources.ApplyResources(this.quitGameToolStripMenuItem, "quitGameToolStripMenuItem");
            this.quitGameToolStripMenuItem.Click += new System.EventHandler(this.quitGameToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // Title
            // 
            resources.ApplyResources(this.Title, "Title");
            this.Title.Name = "Title";
            this.Title.TabStop = false;
            // 
            // PlayLabel
            // 
            resources.ApplyResources(this.PlayLabel, "PlayLabel");
            this.PlayLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PlayLabel.Name = "PlayLabel";
            this.PlayLabel.Click += new System.EventHandler(this.PlayLabel_Click);
            // 
            // RestartLabel
            // 
            resources.ApplyResources(this.RestartLabel, "RestartLabel");
            this.RestartLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.RestartLabel.Name = "RestartLabel";
            this.RestartLabel.Click += new System.EventHandler(this.RestartLabel_Click);
            // 
            // HealthLabel
            // 
            resources.ApplyResources(this.HealthLabel, "HealthLabel");
            this.HealthLabel.ForeColor = System.Drawing.Color.Red;
            this.HealthLabel.Name = "HealthLabel";
            // 
            // TimeLabel
            // 
            resources.ApplyResources(this.TimeLabel, "TimeLabel");
            this.TimeLabel.ForeColor = System.Drawing.Color.Red;
            this.TimeLabel.Name = "TimeLabel";
            // 
            // QuitLabel
            // 
            resources.ApplyResources(this.QuitLabel, "QuitLabel");
            this.QuitLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.QuitLabel.Name = "QuitLabel";
            this.QuitLabel.Click += new System.EventHandler(this.QuitLabel_Click);
            // 
            // AmmoLabel
            // 
            resources.ApplyResources(this.AmmoLabel, "AmmoLabel");
            this.AmmoLabel.ForeColor = System.Drawing.Color.Red;
            this.AmmoLabel.Name = "AmmoLabel";
            // 
            // NextLevelLabel
            // 
            resources.ApplyResources(this.NextLevelLabel, "NextLevelLabel");
            this.NextLevelLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.NextLevelLabel.Name = "NextLevelLabel";
            this.NextLevelLabel.Click += new System.EventHandler(this.NextLevelLabel_Click);
            // 
            // GrenadesLabel
            // 
            resources.ApplyResources(this.GrenadesLabel, "GrenadesLabel");
            this.GrenadesLabel.ForeColor = System.Drawing.Color.Red;
            this.GrenadesLabel.Name = "GrenadesLabel";
            // 
            // tutorialToolStripMenuItem
            // 
            this.tutorialToolStripMenuItem.Name = "tutorialToolStripMenuItem";
            resources.ApplyResources(this.tutorialToolStripMenuItem, "tutorialToolStripMenuItem");
            this.tutorialToolStripMenuItem.Click += new System.EventHandler(this.tutorialToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.Controls.Add(this.GrenadesLabel);
            this.Controls.Add(this.NextLevelLabel);
            this.Controls.Add(this.AmmoLabel);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.HealthLabel);
            this.Controls.Add(this.QuitLabel);
            this.Controls.Add(this.RestartLabel);
            this.Controls.Add(this.PlayLabel);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Title)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem OptionsMenu;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.PictureBox Title;
        private System.Windows.Forms.Label PlayLabel;
        private System.Windows.Forms.Label RestartLabel;
        private System.Windows.Forms.ToolStripMenuItem killPlayerToolStripMenuItem;
        private System.Windows.Forms.Label HealthLabel;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label QuitLabel;
        private System.Windows.Forms.ToolStripMenuItem quitGameToolStripMenuItem;
        private System.Windows.Forms.Label AmmoLabel;
        private System.Windows.Forms.ToolStripMenuItem ChooseLevelMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.Label NextLevelLabel;
        private System.Windows.Forms.ToolStripMenuItem beatLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerHealth1ToolStripMenuItem;
        private System.Windows.Forms.Label GrenadesLabel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem tutorialToolStripMenuItem;
    }
}

