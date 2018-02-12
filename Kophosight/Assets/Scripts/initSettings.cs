using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class initSettings : MonoBehaviour {    
    string[] langPoss = new string[2];
    GameObject frFlag;
    GameObject enFlag;
    // Use this for initialization
    void Start () {       
        enFlag = GameObject.Find("flagEN");
        frFlag = GameObject.Find("flagFR");
        frFlag.SetActive(false);
        enFlag.SetActive(false);
        langPoss[0] = "English";
        langPoss[1] = "Francais";
        if (!PlayerPrefs.HasKey("langage") || PlayerPrefs.GetString("langage") == "<select>")
        {
            PlayerPrefs.SetString("langage", "English");
        }
        if (PlayerPrefs.HasKey("langage"))
        {
            
            GameObject.Find("langageText").GetComponent<Text>().text = PlayerPrefs.GetString("langage");
            Debug.Log("Saved langage found :" + PlayerPrefs.GetString("langage"));
            if (GameObject.Find("langageText").GetComponent<Text>().text == "English")
            {
                enFlag.SetActive(true);
            }
            else if (GameObject.Find("langageText").GetComponent<Text>().text == "Francais")
            {
                frFlag.SetActive(true);
            }
            
        }
        if (!PlayerPrefs.HasKey("texture") || PlayerPrefs.GetString("texture") == "<select>")
        {
            PlayerPrefs.SetString("texture", "Real");
        }
        if (PlayerPrefs.HasKey("texture"))
        {
            Text textview = GameObject.Find("textureText").GetComponent<Text>();
            if (PlayerPrefs.GetString("texture") == "Holographic" && PlayerPrefs.HasKey("langage") && PlayerPrefs.GetString("langage") == "Francais")
            {
                textview.text = "Holographique";
            }
            else if (PlayerPrefs.GetString("texture") == "Holographic" && PlayerPrefs.HasKey("langage") && PlayerPrefs.GetString("langage") == "English")
            {
                textview.text = "Holographic";
            }
            else if (PlayerPrefs.GetString("texture") == "Real" && PlayerPrefs.HasKey("langage") && PlayerPrefs.GetString("langage") == "Francais")
            {
                textview.text = "Réaliste";
            }
            else if (PlayerPrefs.GetString("texture") == "Real" && PlayerPrefs.HasKey("langage") && PlayerPrefs.GetString("langage") == "English")
            {
                textview.text = "Real";
            }
            else if (PlayerPrefs.GetString("texture") == "Real" && !PlayerPrefs.HasKey("langage"))
            {
                textview.text = "Real";
            }
            else if (PlayerPrefs.GetString("texture") == "Holographic" && !PlayerPrefs.HasKey("langage"))
            {
                textview.text = "Holographic";
            }
        }
        //version francaise des paramètres
        if (PlayerPrefs.HasKey("langage") && PlayerPrefs.GetString("langage") == "Francais")
        {                   
            GameObject.Find("langageLabel").GetComponent<Text>().text = "Langue";            
            GameObject.Find("textureLabel").GetComponent<Text>().text = "Texture";            
            GameObject.Find("handLabel").GetComponent<Text>().text = "Main codeuse";            
            GameObject.Find("leftLabel").GetComponent<Text>().text = "Gauche";
            GameObject.Find("rightLabel").GetComponent<Text>().text = "Droite";
            GameObject.Find("applyText").GetComponent<Text>().text = "Appliquer";            
        }
        else
        {            
            GameObject.Find("langageLabel").GetComponent<Text>().text = "Langage";
            GameObject.Find("textureLabel").GetComponent<Text>().text = "Texture";
            GameObject.Find("handLabel").GetComponent<Text>().text = "Coding Hand";
            GameObject.Find("leftLabel").GetComponent<Text>().text = "Left";
            GameObject.Find("rightLabel").GetComponent<Text>().text = "Right";
            GameObject.Find("applyText").GetComponent<Text>().text = "Apply";                        
        }
    }

    // Update is called once per frame
    void Update () {
        
    }
    public void switchLang()
    {
       
        if (GameObject.Find("langageText").GetComponent<Text>().text == langPoss[0])
        {
            enFlag.SetActive(false);
            frFlag.SetActive(true);
            GameObject.Find("langageText").GetComponent<Text>().text = langPoss[1];
        }
        else if (GameObject.Find("langageText").GetComponent<Text>().text == langPoss[1])
        {
            frFlag.SetActive(false);
            enFlag.SetActive(true);            
            GameObject.Find("langageText").GetComponent<Text>().text = langPoss[0];
        }
        PlayerPrefs.SetString("langage", GameObject.Find("langageText").GetComponent<Text>().text);
    }

}
