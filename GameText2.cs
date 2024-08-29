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
    private string[] dialog1 = { "老班长：幸好遇到我，饿了吧，我刚做了鱼钩，给你钓鱼去。",
                                "老班长：这样吧，你去帮我找三个野菜，回来差不多就可以了。"};
    private string[] dialog2 = { "老班长：三个野菜就够了，去周围找找吧。",
                                "老班长：不错，这样鱼汤就做好了，来吃吧。",
                                "我：老班长，你不吃吗？",
                                "老班长：不了，我吃过了。",
                                "(咕咚咕咚。。。你很快喝完了鱼汤，感觉到了饱腹感)",
                                "老班长：年轻人，我是走不出去了，这个鱼钩给你，走出去，将革命的种子传播出去！"};
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
