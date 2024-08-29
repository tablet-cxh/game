using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightControll : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject timeSystem;
    public UnityEngine.Rendering.Universal.Light2D Light;
    void Start()
    {
        Light= GameObject.Find("Sun").GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CircadianSystem();
    }

    void CircadianSystem() {
        /**
            20:00-05:00 ����� RGB(10,10,10)
            05:01-7:00 �𽥱��� RGB(10~254,10~254,10~254)
            7:01-18:00 �������� RGB(255,255,255)
            18:01-19:59 �������� RGB(254~10,254~10,254~10)
            05:00-6:59 2Сʱ 120�� 244/120 = 2.04
            18:00-19:59 2Сʱ 120�� 244/120 = 2.04
        **/
        TimeSystemContoller timeSystemContoller = timeSystem.GetComponent<TimeSystemContoller>();
        //
        int minutes = timeSystemContoller.showMinute;
        int seconds = timeSystemContoller.showSeconds;
        // 20:00 - 05:00
        if (minutes >=20 && minutes <=23) {
            Light.color = new Color(10/255f, 10/255f, 10/255f);
        }
        if (minutes>=0 && minutes <=4) {
            Light.color = new Color(10/255f, 10/255f, 10/255f);
        }
        // 05:01-7:00
        if (minutes>=5 && minutes <=6) {
            int totalSeconds = (minutes - 5) * 60 + seconds;
            float groundRGB = totalSeconds * (float)2.04;
            float currentRGB = 10 + groundRGB;
            Light.color = new Color(currentRGB/255f, currentRGB / 255f, currentRGB / 255f);
        }
        // 7:01-18:00
        if (minutes>=7 && minutes <=17) {
            Light.color = new Color(255/255f,255/255f,255/255f);
        }
        // 18:01-19:59
        if (minutes>=18 && minutes<=19) {
            int totalSconds = (minutes - 18) * 60 + seconds;
            float groundRGB = totalSconds * (float)2.04;
            float currentRGB = 254 - groundRGB;
            Light.color = new Color(currentRGB / 255f, currentRGB / 255f, currentRGB / 255f);
        }
    }
}
