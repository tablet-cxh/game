using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogTest : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform DialogControll;
    private string[] dialog = { "����1935���ĳһ�죬���ķ��������ݵء���Ϊ�±�����������㣬�Ѿ������˴󲿶ӡ�",
                                "ǰ�������ܲ���·;���գ����������䶼�ܶ�ȥ�����������Ŭ������ȥ���߳��ݵء�",
                                "ǰ���Ǹ�ľ�������������µ��𣿹�ȥ������"};
    private int index = -1;
    void Start()
    {
        DialogControll = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        if (index <= dialog.Length)
        {
            playerController.enabled = false;
            ChangeText();
            if(Input.GetKeyDown(KeyCode.F))
            {
                index++;
            }
        }
        if (index >= dialog.Length)
        {
            playerController.enabled = true;
        }
    }

    public void ChangeText()
    {
        if (index == -1)
        {
            DialogControll.GetChild(0).gameObject.SetActive(true);
            DialogControll.GetChild(0).GetChild(0).gameObject.SetActive(true);
        }
        else if(index == dialog.Length)
        {
            DialogControll.GetChild(0).gameObject.SetActive(false);
            DialogControll.GetChild(0).GetChild(0).gameObject.SetActive(false);
            DialogControll.GetComponent<DialogTest>().enabled = false;
        }
        else
        {
            DialogControll.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = dialog[index];
        }
    }
}
