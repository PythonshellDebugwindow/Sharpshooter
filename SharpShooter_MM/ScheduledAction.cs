using System;

namespace SharpShooter_MM
{
    public class ScheduledAction
    {
        Action action;
        float end;

        public ScheduledAction(Action action, float delayMS)
        {
            this.action = action;
            this.end = MainForm.timeElapsed + delayMS;
        }

        public void Update(int time)
        {
            if(MainForm.timeElapsed >= this.end)
            {
                this.action.Invoke();
                MainForm.scheduledActionList.Remove(this);
            }
        }
    }
}