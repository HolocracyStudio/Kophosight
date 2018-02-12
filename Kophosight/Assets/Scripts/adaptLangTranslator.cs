using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class adaptLangTranslator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("langage") && PlayerPrefs.GetString("langage") == "Francais")
        {
            GameObject.Find("backButtonText").GetComponent<Text>().text = "Retour au menu";
        }
        else
        {
            GameObject.Find("backButtonText").GetComponent<Text>().text = "Back to menu";
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
