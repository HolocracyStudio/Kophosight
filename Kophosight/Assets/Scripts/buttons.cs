using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttons : MonoBehaviour {

    public void LoadTranslatorScene()
    {
        SceneManager.LoadScene("translator");
    }

    public void LoadLearnScene()
    {
        SceneManager.LoadScene("learn");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("menuV2");
    }
    public void LoadSettingsScene()
    {
        SceneManager.LoadScene("settingsv2");
    }
    public void applySettings()
    {              
        PlayerPrefs.Save();
        SceneManager.LoadScene("menuV2");
    }
}
