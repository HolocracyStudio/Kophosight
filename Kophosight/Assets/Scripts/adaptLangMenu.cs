using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class adaptLangMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //version francaise, si précisée :
        if (PlayerPrefs.HasKey("langage") && PlayerPrefs.GetString("langage") == "Francais")
        {
            GameObject.Find("startText").GetComponent<Text>().text = "Démarrer";            
            GameObject.Find("learnText").GetComponent<Text>().text = "Apprendre";            
            GameObject.Find("settingsText").GetComponent<Text>().text = "Paramètres";            
        }
        //version anglaise par défaut :
        else
        {
            GameObject.Find("startText").GetComponent<Text>().text = "Start";            
            GameObject.Find("learnText").GetComponent<Text>().text = "Learn";            
            GameObject.Find("settingsText").GetComponent<Text>().text = "Settings";            
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
