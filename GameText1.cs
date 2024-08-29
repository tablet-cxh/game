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
    private string[] dialog = { "我：藏族同胞你们好，我和部队走散了，请问他们朝哪里去了？",
                                "藏民：你只要沿着东边那条河一直北上，就能找到大部队了。",
                                "藏民：红军对我们藏民不薄，希望你们早日成功。",
                                "我：多谢你们的帮助，我们一定将红旗插满中华大地！"};
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
