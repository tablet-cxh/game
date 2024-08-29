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
    private string[] dialog = { "սʿ���촽���ϣ���ɫ�԰ף����Ƕ������ˣ�",
                                "���ж������ѵ��ǳ�����Щİ����Ұ�ˣ�",
                                "�������˱�ʹ��û�뵽���Ǿ�Ȼ������СС��Ұ���ϡ�",
                                "��ԭ�Ϸ����Ķ࣬һ��Ҳ���ܷ��ɾ��谡��"};
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
