using System.Drawing;
using System.Drawing.Drawing2D;

namespace SharpShooter_MM
{
    public class Picture
    {
        public Bitmap bitmap;
        public PointF location;
        public float angle;
        public PointF offset;
        public int frame, frameCount, timePerFrame, animationCounter;
        public string fileName;

        public Picture(string fileName, PointF location, int frames, int flipTime)
        {
            this.fileName = fileName;
            this.bitmap = new Bitmap(fileName);
            this.location = location;
            this.angle = 0;
            this.frame = 0;
            this.frameCount = frames;
            this.timePerFrame = flipTime;
            this.animationCounter = 0;
            this.offset = new PointF(this.bitmap.Width / 2, this.bitmap.Height / frameCount / 2);
        }

        public void Draw(Graphics g)
        {
            Point drawLocation = new Point((int)(this.location.X - this.offset.X),
                                           (int)(this.location.Y - this.offset.Y));
            Matrix m = new Matrix();
            m.RotateAt(-this.angle, this.location);
            g.Transform = m;
            g.DrawImage(this.bitmap, new Rectangle(drawLocation.X, drawLocation.Y, this.bitmap.Width, this.bitmap.Height / frameCount), new Rectangle(0, this.frame * this.bitmap.Height / frameCount, this.bitmap.Width, this.bitmap.Height / frameCount), GraphicsUnit.Pixel);
        }

        public void Update(int time)
        {
            this.animationCounter += time;
            if(this.animationCounter >= this.timePerFrame)
            {
                this.animationCounter = 0;
                ++this.frame;
                if(this.frame >= this.frameCount)
                {
                    this.frame = 0;
                }
            }
        }
    }
}