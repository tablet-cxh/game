using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetting : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource menuAudio;
    private Slider audioSlider;

    void Start()
    {
        menuAudio = GameObject.FindGameObjectWithTag("MainCamera").transform.GetComponent<AudioSource>();
        audioSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        VolumeControll();
    }

    public void VolumeControll()
    {
        menuAudio.volume = audioSlider.value;
    }

    public void CloseGameSettingUI()
    {
        GameObject gameSettingUI = GameObject.FindGameObjectWithTag("Setting").gameObject;
        GameObject mainMenu = GameObject.FindGameObjectWithTag("Menu").gameObject;
        gameSettingUI.transform.GetChild(0).gameObject.SetActive(false);
        mainMenu.transform.GetChild(0).gameObject.SetActive(true);
    }
}
