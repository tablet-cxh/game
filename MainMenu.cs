using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject loadingScreen;
    public Slider slider;
    public TMP_Text ProgressText;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(AsyncLoadLevel(sceneIndex));
    }

    IEnumerator AsyncLoadLevel(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while(!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            slider.value = progress;
            ProgressText.text = Mathf.FloorToInt(progress * 100f).ToString() + "%";
            yield return null;
        }
    }

    public void OpenGameSettingUI()
    {
        GameObject gameSettingUI = GameObject.FindGameObjectWithTag("Setting").gameObject;
        GameObject mainMenu = GameObject.FindGameObjectWithTag("mainMenu").gameObject;
        gameSettingUI.transform.GetChild(0).gameObject.SetActive(true);
        mainMenu.transform.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
