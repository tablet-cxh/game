using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    // ��ȡuiϵͳԤ����
    private GameObject uiSystemPrefab;
    // ����uiϵͳ�������ʾ
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
    // ϵͳ�Ĵ򿪺͹ر�
    void openAndCloseUIsystem()
    {
        // ������Esc���Ҵ��������û�д�
        if (Input.GetKeyDown(KeyCode.B))
        {
            GameObject UISystem = GameObject.FindGameObjectWithTag("mainUI");
            showUiSystem = !showUiSystem;
            // �򿪺͹ر�ϵͳ
            UISystem.transform.GetChild(0).gameObject.SetActive(showUiSystem);
        }
    }
}
