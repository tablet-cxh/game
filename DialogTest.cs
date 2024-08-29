using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogTest : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform DialogControll;
    private string[] dialog = { "这是1935年的某一天，红四方面军进入草地。作为新兵的你脚力不足，已经脱离了大部队。",
                                "前方沼泽密布，路途凶险，饥饿、寒冷都能夺去你的性命。请努力活下去，走出草地。",
                                "前面那个木牌是其他人留下的吗？过去看看。"};
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
