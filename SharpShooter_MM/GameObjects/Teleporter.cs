using System;
using System.Drawing;

namespace SharpShooter_MM.GameObjects
{
    public class Teleporter
    {
        public PointF location;
        public PointF teleportLocation;
        public Picture picture;
        public int radius;

        public Teleporter(PointF location, PointF teleportLocation)
        {
            this.location = location;
            this.teleportLocation = teleportLocation;
            this.picture = new Picture("Images/Teleporter.png", location, 1, 1);
            this.radius = this.picture.bitmap.Width / 2;
            MainForm.teleporterList.Add(this);
        }

        public void Draw(Graphics g)
        {
            this.picture.location.X = this.location.X - MainForm.viewOffset.X;
            this.picture.location.Y = this.location.Y - MainForm.viewOffset.Y;
            this.picture.Draw(g);
        }

        public void Update(int time)
        {
            if(IsTouching(MainForm.player1))
                MainForm.player1.location = this.teleportLocation;
            foreach(Soldier s in MainForm.enemyList)
                if(IsTouching(s))
                    s.location = this.teleportLocation;
        }

        bool IsTouching(Soldier s)
        {
            double diffX = this.location.X - s.location.X;
            double diffY = this.location.Y - s.location.Y;
            double totalRad = this.radius + s.radius;
            return Math.Sqrt(diffX * diffX + diffY * diffY) < totalRad;
        }
    }
}