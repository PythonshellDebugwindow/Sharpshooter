using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SharpShooter_MM.GameObjects
{
    public class Shield : Wall
    {
        public float angle = 0;
        public Player owner;
        public PointF offset;
        public int plId;
        public bool active = false;

        public Shield() : base(0, 0, 0, 0, "Blue")
        {}

        public void SetOwner(Player owner)
        {
            this.owner = owner;
        }

        public void Init(int left, int top, int width, int height, Player owner)
        {
            this.left = left;
            this.top = top;
            this.width = width;
            this.height = height;
            this.owner = owner;
            this.offset = new PointF(this.owner.shieldSize / 2, this.owner.shieldSize / 2);
        }

        public override void Draw(Graphics g)
        {
            g.Transform = new Matrix();
            g.Transform.RotateAt(this.angle, this.owner.location);
            g.DrawImage(this.image, new RectangleF(left - MainForm.viewOffset.X, top - MainForm.viewOffset.Y, width, height));
        }

        public override void Update(int time)
        {
            float xComponent = (float)Math.Cos(this.owner.facingAngle / 180f * Math.PI);
            float yComponent = -(float)Math.Sin(this.owner.facingAngle / 180f * Math.PI);
            float shieldLeft = this.owner.location.X - this.offset.X + xComponent * this.owner.shieldDistance;
            this.left = (int)shieldLeft;
            float shieldTop = this.owner.location.Y - this.offset.Y + yComponent * this.owner.shieldDistance;
            this.top = (int)shieldTop;
            this.angle = this.owner.facingAngle;
        }
    }
}