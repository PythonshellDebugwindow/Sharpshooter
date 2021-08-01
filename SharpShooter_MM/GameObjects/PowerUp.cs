using System;
using System.Drawing;

namespace SharpShooter_MM.GameObjects
{
    public enum PowerUpType
    {
        Health,
        Ammo,
        Grenades,
        Speed,
        Invincibility,
        Damage
    }

    public class PowerUp
    {
        public PointF location;
        public Picture picture;
        public PowerUpType type;
        public int strength;
        public int radius;
        public bool enemiesCanUse = false;

        public PowerUp(PointF location, PowerUpType type, int strength, bool enemiesCanUse)
        {
            string fileName = "Images/PowerUp";
            fileName += Enum.GetName(typeof(PowerUpType), type) + ".png";
            this.picture = new Picture(fileName, location, 1, 1);
            this.radius = this.picture.bitmap.Width / 2;
            this.location = location;
            this.type = type;
            this.strength = strength;
            this.enemiesCanUse = enemiesCanUse;
            MainForm.powerUpList.Add(this);
        }

        public void Draw(Graphics g)
        {
            this.picture.location.X = this.location.X - MainForm.viewOffset.X;
            this.picture.location.Y = this.location.Y - MainForm.viewOffset.Y;
            this.picture.Draw(g);
        }
        
        public void Update(int time)
        {
            Soldier s = null;

            if(this.enemiesCanUse)
            {
                foreach(EnemySoldier e in MainForm.enemyList)
                {
                    if(IsTouching(e))
                        s = e;
                }
            }

            if(IsTouching(MainForm.player1))
                s = MainForm.player1;

            if(s != null)
            {
                switch(this.type)
                {
                    case PowerUpType.Health:
                        s.hp += this.strength;
                        break;
                    case PowerUpType.Ammo:
                        if(s.currentWeapon is Weapons.MissileLauncher)
                            return;
                        s.currentWeapon.ammo += this.strength;
                        break;
                    case PowerUpType.Grenades:
                        s.grenades += this.strength;
                        break;
                    case PowerUpType.Speed:
                        s.moveSpeed *= 1.3f;
                        MainForm.scheduledActionList.Add(new ScheduledAction(Slow(s), strength));
                        break;
                    case PowerUpType.Invincibility:
                        s.invincible = true;
                        MainForm.scheduledActionList.Add(new ScheduledAction(Mortalize(s), strength));
                        break;
                    case PowerUpType.Damage:
                        s.damageModifier *= 2;
                        MainForm.scheduledActionList.Add(new ScheduledAction(Weaken(s), strength));
                        break;
                }
                MainForm.powerUpList.Remove(this);
            }
        }

        public bool IsTouching(Soldier s)
        {
            double diffX = this.location.X - s.location.X;
            double diffY = this.location.Y - s.location.Y;
            double totalRad = this.radius + s.radius;
            return Math.Sqrt(diffX * diffX + diffY * diffY) < totalRad;
        }

        public static Action Slow(Soldier s)
        {
            return () => s.moveSpeed /= 1.3f;
        }

        public static Action Mortalize(Soldier s)
        {
            return () => s.invincible = false;
        }

        public static Action Weaken(Soldier s)
        {
            return () => s.damageModifier /= 2;
        }
    }
}