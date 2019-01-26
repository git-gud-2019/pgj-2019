using UnityEngine;
using UnityEngine.UI;

public class WaveMechanism : MonoBehaviour {
    public Text TimerLabel;

    private float Time = 10;

    void Update() {
        Time -= UnityEngine.Time.deltaTime;

        if (Time > 0)
        {
            var minutes = Time / 60; //Divide the guiTime by sixty to get the minutes.
            var seconds = Time % 60;//Use the euclidean division for the seconds.

            //update the label value
            TimerLabel.text = string.Format ("Next wave stars in: {0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            TimerLabel.color = new Color(0, 0, 0, 0);
        }


    }
}
