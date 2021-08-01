namespace SharpShooter_MM.GameObjects
{
    public class MovingWall : Wall
    {
        public int leftMin, topMin, leftMax, topMax, xSpeed, ySpeed;
        
        public MovingWall(int left, int top, int leftMax, int topMax, int width, int height, string colour, int xSpeed, int ySpeed) : base(left, top, width, height, colour)
        {
            MainForm.movingWallList.Add(this);
            this.leftMin = left;
            this.topMin = top;
            this.leftMax = leftMax;
            this.topMax = topMax;
            this.xSpeed = xSpeed;
            this.ySpeed = ySpeed;
        }

        public MovingWall(int left, int top, int leftMin, int topMin, int leftMax, int topMax, int width, int height, string colour, int xSpeed, int ySpeed) : this(leftMin, topMin, leftMax, topMax, width, height, colour, xSpeed, ySpeed)
        {
            this.left = left;
            this.top = top;
        }

        public override void Update(int time)
        {
            this.left += this.xSpeed;
            this.top += this.ySpeed;
            if(this.left <= this.leftMin || this.left >= this.leftMax)
            {
                this.xSpeed *= -1;
            }
            if(this.top <= this.topMin || this.top >= this.topMax)
            {
                this.ySpeed *= -1;
            }
        }
    }
}