using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace SharpShooter_MM.GameObjects
{
    public class Player : Soldier
    {
        public List<Weapons.Weapon> weapons;
        public bool swapped = false;
        public int weaponIndex;
        public static Shield shield;
        public float shieldDistance = 40;
        public int shieldSize;

        public Player(PointF location) : base("Images/Player.png", location)
        {
            Reset();
        }

        public void Reset()
        {
            this.killed = false;
            this.hp = 100;
            this.currentWeapon = new Weapons.EnemyPistol(this.location);
            this.weaponIndex = 0;
            this.weapons = new List<Weapons.Weapon>();
            this.weapons.Add(this.currentWeapon);
            this.grenades = 5;
            this.invincible = false;
            this.damageModifier = 1;
            this.moveSpeed = 20;
            this.shieldSize = this.picture.bitmap.Width / 2;
            shield.Init(0, 0, this.shieldSize, this.shieldSize, this);
        }

        public new void Draw(Graphics g)
        {
            base.Draw(g);
            if(shield.active)
                shield.Draw(g);
        }

        public override void Update(int time)
        {
            base.Update(time);
            if(shield.active)
                shield.Update(time);
        }

        public void KeyDown(Object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
                this.turnDirection = 0.225f;
            if(e.KeyCode == Keys.Right)
                this.turnDirection = -0.225f;

            if(e.KeyCode == Keys.Up)
                this.walkDirection = 1;
            if(e.KeyCode == Keys.Down)
                this.walkDirection = -1;

            if(e.KeyCode == Keys.Space && !shield.active)
                this.isFiring = true;
            
            if(e.KeyCode == Keys.Q && !this.swapped)
            {
                this.swapped = true;
                ++this.weaponIndex;
                if (this.weaponIndex >= this.weapons.Count)
                    this.weaponIndex = 0;
                this.currentWeapon = this.weapons[this.weaponIndex];
            }

            if(e.KeyCode == Keys.W && !shield.active)
            {
                float xComponent = (float)Math.Cos(this.facingAngle / 180f * Math.PI);
                float yComponent = -(float)Math.Sin(this.facingAngle / 180f * Math.PI);
                float shieldLeft = this.location.X + xComponent * this.shieldDistance;
                shield.left = (int)shieldLeft;
                float shieldTop = this.location.Y + yComponent * this.shieldDistance;
                shield.top = (int)shieldTop;
                shield.active = true;
            }

            if(e.KeyCode == Keys.E)
            {
                this.isThrowingGrenade = true;
            }

            if(e.KeyCode == Keys.T)
            {
                if(this.grenades > 0)
                {
                    --this.grenades;
                    Picture p = new Picture("Images/BigExplosion.png", new PointF(), 1, 1);
                    int beSize = p.bitmap.Width;
                    float xComponent = (float)Math.Cos(this.facingAngle / 180f * Math.PI);
                    float yComponent = -(float)Math.Sin(this.facingAngle / 180f * Math.PI);
                    float x = this.location.X + xComponent * (this.grenadeStartDistance + beSize);
                    float y = this.location.Y + yComponent * (this.grenadeStartDistance + beSize);
                    Grenade g = new Grenade(new PointF(x, y));
                    g.velocity = new PointF(0, 0);
                }
            }
        }

        public void KeyUp(Object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
                this.turnDirection = 0;
            if(e.KeyCode == Keys.Right)
                this.turnDirection = 0;

            if(e.KeyCode == Keys.Up)
                this.walkDirection = 0;
            if(e.KeyCode == Keys.Down)
                this.walkDirection = 0;

            if(e.KeyCode == Keys.Space)
                this.isFiring = false;

            if(e.KeyCode == Keys.Q && this.swapped)
                this.swapped = false;

            if(e.KeyCode == Keys.W)
            {
                shield.active = false;
            }
        }
    }
}