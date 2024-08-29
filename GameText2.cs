using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameText2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dialogBox;
    public GameObject dialogBoxText;
    public GameObject yu_gou;
    itemController item;
    private PlayerState player;
    private bool isPlayerInSign;
    private bool stage = false;
    private Transform DialogControll;
    private string[] dialog1 = { "�ϰ೤���Һ������ң����˰ɣ��Ҹ������㹳���������ȥ��",
                                "�ϰ೤�������ɣ���ȥ����������Ұ�ˣ��������Ϳ����ˡ�"};
    private string[] dialog2 = { "�ϰ೤������Ұ�˾͹��ˣ�ȥ��Χ���Ұɡ�",
                                "�ϰ೤���������������������ˣ����԰ɡ�",
                                "�ң��ϰ೤���㲻����",
                                "�ϰ೤�����ˣ��ҳԹ��ˡ�",
                                "(���˹��ˡ�������ܿ�������������о����˱�����)",
                                "�ϰ೤�������ˣ������߲���ȥ�ˣ�����㹳���㣬�߳�ȥ�������������Ӵ�����ȥ��"};
    private int index = -1;
    private int index2 = 0;
    private int ye_cai = 0;

    void Start()
    {
        DialogControll = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        if (stage)
        {
            if (index2 <= dialog2.Length)
            {
                if (Input.GetKeyDown(KeyCode.F) && isPlayerInSign)
                {
                    ChangeText2();
                    playerController.enabled = false;
                    index2++;
                }
            }
            if(index2 >= dialog2.Length || ye_cai < 3)
            {
                playerController.enabled = true;
            }
            if (!isPlayerInSign)
            {
                dialogBox.SetActive(false);
                dialogBoxText.SetActive(false);
            }
        }
        else 
        {
            if (index <= dialog1.Length)
            {
                if (Input.GetKeyDown(KeyCode.F) && isPlayerInSign)
                {
                    ChangeText1();
                    playerController.enabled = false;
                    index++;
                }
            }
            if (index > dialog1.Length)
            {
                playerController.enabled = true;
                isPlayerInSign = false;
                stage = true;
            }
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

    public void ChangeText1()
    {
        if (index == -1)
        {
            dialogBox.SetActive(true);
            dialogBoxText.SetActive(true);
        }
        else if (index == dialog1.Length)
        {
            dialogBox.SetActive(false);
            dialogBoxText.SetActive(false);
        }
        else
        {
            dialogBoxText.GetComponent<TMP_Text>().text = dialog1[index];
        }
    }
    public void ChangeText2()
    {
        if (index2 == 0)
        {
            dialogBox.SetActive(true);
            dialogBoxText.SetActive(true);
            if (ye_cai >= 3)
            {
                dialogBoxText.GetComponent<TMP_Text>().text = dialog2[++index2];
            }
            else
            {
                dialogBoxText.GetComponent<TMP_Text>().text = dialog2[0];
                index2--;
            }
        }
        else if (index2 == dialog2.Length)
        {
            item = yu_gou.GetComponent<itemController>();
            if(item != null)
            {
                item.SetObjectActive(true);
                item.SetObjectTrigger(true);
            }
            dialogBox.SetActive(false);
            dialogBoxText.SetActive(false);
            DialogControll.GetComponent<GameText2>().enabled = false;
        }
        else
        {
            if(index2 == dialog2.Length-1)
            {
                if (player != null)
                {
                    player.FeedPlayer(50);
                }
            }
            dialogBoxText.GetComponent<TMP_Text>().text = dialog2[index2];
        }
    }

    public void Add()
    {
        ye_cai++;
    }
}
