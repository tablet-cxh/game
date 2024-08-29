using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TimeSystemContoller : MonoBehaviour
{
    // 24分钟为一天
    // 累加时间
    public float totalSeconds = 0;
    // 分钟,初始进游戏为08：00
    public int showMinute = 0;
    // 秒钟
    public int showSeconds = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        // 累加时间到1秒，然后重置秒钟为0（每秒钟执行一次）
        totalSeconds += Time.fixedDeltaTime;
        if (totalSeconds >= 0.98) {
            UpdateTime();
            totalSeconds = 0;
        }
    }

    private void Update()
    {
        
    }

    // 更新时间
    public void UpdateTime() {
        // 判断分钟是否为23
        if (showMinute == 23)
        {
            // 判断秒钟是否为59
            if (showSeconds == 59)
            {
                // 重置分钟和秒钟为0
                showMinute = 0;
                showSeconds = 0;
            }
            else
            {
                // 秒钟累加
                showSeconds += 1;
            }
        }
        else {
            // print("分钟:"+showMinute+",秒钟:"+showSeconds);
            // 当时间不为23分钟时
            //判断秒钟是否为59秒
            if (showSeconds == 59)
            {
                // 重置秒钟为0；
                showSeconds = 0;
                // 分钟+1；
                showMinute += 1;
            }
            else {
                // 当秒钟小于59
                // 秒钟++
                showSeconds += 1;
            }
        }
    }
}
