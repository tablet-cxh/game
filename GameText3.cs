using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameText3 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dialogBox;
    public GameObject dialogBoxText;
    private bool isPlayerInSign;
    private Transform DialogControll;
    private string[] dialog = { "战士们嘴唇发紫，脸色苍白，他们都牺牲了！",
                                "是中毒了吗？难道是吃了那些陌生的野菜？",
                                "真是令人悲痛，没想到他们竟然死在了小小的野菜上。",
                                "草原上风险颇多，一刻也不能放松警惕啊。"};
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
            DialogControll.GetComponent<GameText3>().enabled = false;
        }
        else
        {
            dialogBoxText.GetComponent<TMP_Text>().text = dialog[index];
        }
    }
}
