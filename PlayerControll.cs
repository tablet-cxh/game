using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    // 获取ui系统预制体
    private GameObject uiSystemPrefab;
    // 控制ui系统界面的显示
    private bool showUiSystem = false;
    // Start is called before the first frame update
    void Start()
    {
        uiSystemPrefab = Resources.Load<GameObject>("UITest");
        GameObject UISystem = GameObject.FindGameObjectWithTag("mainUI").transform.gameObject;
        if (!UISystem)
        {
            Instantiate(uiSystemPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        openAndCloseUIsystem();
    }
    // 系统的打开和关闭
    void openAndCloseUIsystem()
    {
        // 当按下Esc并且存读档界面没有打开
        if (Input.GetKeyDown(KeyCode.B))
        {
            GameObject UISystem = GameObject.FindGameObjectWithTag("mainUI");
            showUiSystem = !showUiSystem;
            // 打开和关闭系统
            UISystem.transform.GetChild(0).gameObject.SetActive(showUiSystem);
        }
    }
}
