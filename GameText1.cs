using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameText1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dialogBox;
    public GameObject dialogBoxText;
    private bool isPlayerInSign;
    private Transform DialogControll;
    private string[] dialog = { "�ң�����ͬ�����Ǻã��ҺͲ�����ɢ�ˣ��������ǳ�����ȥ�ˣ�",
                                "������ֻҪ���Ŷ���������һֱ���ϣ������ҵ��󲿶��ˡ�",
                                "���񣺺�������ǲ��񲻱���ϣ���������ճɹ���",
                                "�ң���л���ǵİ���������һ������������л���أ�"};
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
            if (Input.GetKeyDown(KeyCode.F) && isPlayerInSign)
            {
                ChangeText();
                playerController.enabled = false;
                index++;
            }
        }
        if (index >= dialog.Length)
        {
            playerController.enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isPlayerInSign = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isPlayerInSign = false;
        }
    }

    public void ChangeText()
    {
        if (index == -1)
        {
            dialogBox.SetActive(true);
            dialogBoxText.SetActive(true);
        }
        else if (index == dialog.Length)
        {
            dialogBox.SetActive(false);
            dialogBoxText.SetActive(false);
            DialogControll.GetComponent<GameText1>().enabled = false;
        }
        else
        {
            dialogBoxText.GetComponent<TMP_Text>().text = dialog[index];
        }
    }
}
