using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TimeSystemContoller : MonoBehaviour
{
    // 24����Ϊһ��
    // �ۼ�ʱ��
    public float totalSeconds = 0;
    // ����,��ʼ����ϷΪ08��00
    public int showMinute = 0;
    // ����
    public int showSeconds = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        // �ۼ�ʱ�䵽1�룬Ȼ����������Ϊ0��ÿ����ִ��һ�Σ�
        totalSeconds += Time.fixedDeltaTime;
        if (totalSeconds >= 0.98) {
            UpdateTime();
            totalSeconds = 0;
        }
    }

    private void Update()
    {
        
    }

    // ����ʱ��
    public void UpdateTime() {
        // �жϷ����Ƿ�Ϊ23
        if (showMinute == 23)
        {
            // �ж������Ƿ�Ϊ59
            if (showSeconds == 59)
            {
                // ���÷��Ӻ�����Ϊ0
                showMinute = 0;
                showSeconds = 0;
            }
            else
            {
                // �����ۼ�
                showSeconds += 1;
            }
        }
        else {
            // print("����:"+showMinute+",����:"+showSeconds);
            // ��ʱ�䲻Ϊ23����ʱ
            //�ж������Ƿ�Ϊ59��
            if (showSeconds == 59)
            {
                // ��������Ϊ0��
                showSeconds = 0;
                // ����+1��
                showMinute += 1;
            }
            else {
                // ������С��59
                // ����++
                showSeconds += 1;
            }
        }
    }
}
