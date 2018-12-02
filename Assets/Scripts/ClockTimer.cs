using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using TMPro;

public class ClockTimer : MonoBehaviour {

    public float Timer = 30;
    private float curTime;

    public TextMeshProUGUI ClockTimeText;
    public RectTransform ClockHandImage;

    public Coroutine timerCoroutine;

    // Use this for initialization
    void Start () {
       
	}

    public void resetTimer(float Reset = 30)
    {
        curTime = Reset;
        if(timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }
        timerCoroutine = StartCoroutine(Countdown());
    }

    public void stopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }
    }

    IEnumerator Countdown()
    {
        float percent = curTime / Timer;

        while (curTime > -1)
        {
            ClockTimeText.text = (curTime % 60).ToString("00");

            percent = curTime / Timer;


            ClockHandImage.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, 360, percent));
            
            

            yield return new WaitForSeconds(1);

            curTime -= 1;
        }


        FightManager.instance.Answer(-1);

    }


}
