using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textureMenu : MonoBehaviour {    
    string[] textPossFR = new string[2];
    string[] textPossEN = new string[2];
    // Use this for initialization
    void Start () {       
        textPossFR[0] = "Holographique";
        textPossFR[1] = "Réaliste";
        textPossEN[0] = "Holographic";
        textPossEN[1] = "Real";
    }
	
	// Update is called once per frame
	void Update () {		
	}

    public void switchText()
    {
        Debug.Log("SwitchText called");     
        if(GameObject.Find("textureText").GetComponent<Text>().text == textPossFR[0])
        {            
            GameObject.Find("textureText").GetComponent<Text>().text = textPossFR[1];
        }
        else if (GameObject.Find("textureText").GetComponent<Text>().text == textPossEN[0])
        {            
            GameObject.Find("textureText").GetComponent<Text>().text = textPossEN[1];            
        }
        else if (GameObject.Find("textureText").GetComponent<Text>().text == textPossFR[1])
        {
            GameObject.Find("textureText").GetComponent<Text>().text = textPossFR[0];
        }
        else if (GameObject.Find("textureText").GetComponent<Text>().text == textPossEN[1])
        {
            GameObject.Find("textureText").GetComponent<Text>().text = textPossEN[0];
        }

        if(GameObject.Find("textureText").GetComponent<Text>().text == textPossEN[0] || GameObject.Find("textureText").GetComponent<Text>().text == textPossFR[0])
        {
            PlayerPrefs.SetString("texture", "Holographic");
        }
        else if (GameObject.Find("textureText").GetComponent<Text>().text == textPossEN[1] || GameObject.Find("textureText").GetComponent<Text>().text == textPossFR[1])
        {
            PlayerPrefs.SetString("texture", "Real");
        }
    }
    public void changeTextChoice(string texture)
    {
        if (texture == "Holographic")
        {
            PlayerPrefs.SetString("texture", texture);
            if (PlayerPrefs.HasKey("langage") && PlayerPrefs.GetString("langage") == "Francais")
            {

                GameObject.Find("textureText").GetComponent<Text>().text = "Holographique";
            }
            else
            {
                GameObject.Find("textureText").GetComponent<Text>().text = "Holographic";
            }
        }
        else if (texture == "Real")
        {
            PlayerPrefs.SetString("texture", texture);
            if (PlayerPrefs.HasKey("langage") && PlayerPrefs.GetString("langage") == "Francais")
            {

                GameObject.Find("textureText").GetComponent<Text>().text = "Réaliste";
            }
            else
            {
                GameObject.Find("textureText").GetComponent<Text>().text = "Real";
            }
        }             
    }
}
