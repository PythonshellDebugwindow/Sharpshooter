using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SharpShooter_MM.GameObjects
{
    public class Wall
    {
        public int left, top, width, height;
        public Bitmap image;

        public Wall(int left, int top, int width, int height, string colour)
        {
            this.left = left;
            this.top = top;
            this.width = width;
            this.height = height;
            this.image = new Bitmap("Images/" + colour + "Box.png");
            if(!(this is Shield))
                MainForm.wallList.Add(this);
        }

        public virtual void Draw(Graphics g)
        {
            g.Transform = new Matrix();
            g.DrawImage(this.image, new RectangleF(left - MainForm.viewOffset.X, top - MainForm.viewOffset.Y, width, height));
        }

        public virtual void Update(int time)
        {}

        public PointF PointNearestTo(PointF p)
        {
            PointF nearestPoint = new PointF();

            if(this.left > p.X)
            {
                nearestPoint.X = this.left;
            }
            else if(this.left + this.width < p.X)
            {
                nearestPoint.X = this.left + this.width;
            }
            else
            {
                nearestPoint.X = p.X;
            }
            
            if(this.top > p.Y)
            {
                nearestPoint.Y = this.top;
            }
            else if(this.top + this.height < p.Y)
            {
                nearestPoint.Y = this.top + this.height;
            }
            else
            {
                nearestPoint.Y = p.Y;
            }

            return nearestPoint;
        }

        public PointF NormalAtNearestPoint(PointF p)
        {
            PointF nearestPoint = PointNearestTo(p);
            PointF normal = new PointF(nearestPoint.X - p.X, nearestPoint.Y - p.Y);
            if(normal.X == 0 && normal.Y == 0)
            {
                return normal;
            }
            float factor = (float)(1 / Math.Sqrt(normal.X * normal.X + normal.Y * normal.Y));
            normal.X *= factor;
            normal.Y *= factor;
            return normal;
        }
    }
}