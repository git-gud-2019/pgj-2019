using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //to use this add first a slider to your canvas in the editor.
    public float Time;
    public float Maxtime; //insert your maxium time
    public Image TimerBar;
    public Image TimerBg;


    void Start()
    {
    }

    void Update()
    {
        if (Time < Maxtime)
        {
            Time += UnityEngine.Time.deltaTime;
            TimerBar.fillAmount = Time / Maxtime;
        }
        else
        {
            Destroy(TimerBar);
            Destroy(TimerBg);
            //time is over, add here what you want to happen next
        }
    }
}
