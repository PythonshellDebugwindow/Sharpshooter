using System.Drawing;

namespace SharpShooter_MM.GameObjects
{
    public class Explosion
    {
        public PointF location;
        public Picture picture;
        public float lifetime = 300f;
        public int radius;
        public static Sound explosionSound = new Sound("Sounds/Explosion1.wav");

        public Explosion(PointF location)
        {
            this.location = location;
            this.picture = new Picture("Images/Explode.png", location, 6, 40);
            this.radius = this.picture.bitmap.Width / 2;
            MainForm.explosionList.Add(this);
            explosionSound.Play();
        }

        public void Draw(Graphics g)
        {
            this.picture.location.X = this.location.X - MainForm.viewOffset.X;
            this.picture.location.Y = this.location.Y - MainForm.viewOffset.Y;
            this.picture.Draw(g);
        }

        public void Update(int time)
        {
            this.picture.Update(time);
            this.lifetime -= time;
            if(this.lifetime <= 0)
            {
                MainForm.explosionList.Remove(this);
            }
        }
    }
}
