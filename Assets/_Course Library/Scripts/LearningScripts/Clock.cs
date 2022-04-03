using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {

    public GameObject secondHand;
    public GameObject minuteHand;
    public GameObject hourHand;
    string oldSeconds;

    // Update is called once per frame
    void Update() {

        string seconds = System.DateTime.UtcNow.ToString("ss");
        int secondsInt = int.Parse(System.DateTime.UtcNow.ToString("ss"));
        int minutesInt = int.Parse(System.DateTime.UtcNow.ToString("mm"));
        int hoursInt = int.Parse(System.DateTime.UtcNow.ToLocalTime().ToString("hh"));
        print(hoursInt + " : " + minutesInt + " : " + secondsInt);
        iTween.RotateTo(secondHand, iTween.Hash("rotation", new Vector3(secondsInt * 6, 0, 0), "time", 1, "easetype", "easeOutQuint"));

        //       if (seconds != oldSeconds) {
        //           UpdateTimer();
        //       }
        //       oldSeconds = seconds;
    }

       void UpdateTimer() {

           int secondsInt = int.Parse(System.DateTime.UtcNow.ToString("ss"));
           int minutesInt = int.Parse(System.DateTime.UtcNow.ToString("mm"));
           int hoursInt = int.Parse(System.DateTime.UtcNow.ToLocalTime().ToString("hh"));

           print(hoursInt + " : " + minutesInt + " : " + secondsInt);

        //iTween.RotateTo(secondHand, iTween.Hash("x", secondsInt * 6 , "time", 1, "easetype", "easeOutQuint"));
           iTween.RotateTo(secondHand, iTween.Hash("rotation", new Vector3(secondsInt * 6, 0, 0), "time", 1, "easetype", "easeOutQuint"));
           iTween.RotateTo(minuteHand, iTween.Hash("rotation", new Vector3(minutesInt * 6, 0, 0), "time", 1, "easetype", iTween.EaseType.easeOutElastic));
           float hourDistance = (float)(minutesInt) / 60;
           iTween.RotateTo(hourHand, iTween.Hash("x", (hoursInt + hourDistance) * 360 / 12, "time", 1, "easetype", "easeOutElastic"));
       }
}
