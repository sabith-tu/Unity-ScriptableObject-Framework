using System;

public class TimerUpdate
{
    public Action OnTimerTick;
    public TimerUpdate(float timerLength)
    {
        this.timerLength = timerLength;
        this.timerTimeLeft = timerLength;
    }
    float timerLength;
    float timerTimeLeft;

    public void UpdateTimer(float deltaTime)
    {
        if (timerTimeLeft <= 0)
        {
            OnTimerTick.Invoke();
            timerTimeLeft = timerLength;
        }
        else
        {
            timerTimeLeft -= deltaTime;
        }
    }
}