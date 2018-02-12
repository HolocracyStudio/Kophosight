using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handRotation : MonoBehaviour {
    public Material[] materials;
    Renderer rend;
	// Use this for initialization
	void Start () {
        /*
        rend = GameObject.Find("HoloHands6").GetComponent<Renderer>();
        rend.enabled = true;
        if (PlayerPrefs.HasKey("texture"))
        {
            if(PlayerPrefs.GetString("texture") == "Holographic")
            {
                rend.sharedMaterial = materials[1];
            }
            if (PlayerPrefs.GetString("texture") == "Real")
            {
                rend.sharedMaterial = materials[0];
            }
        }*/
        
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(1, 0, 0);
	}
}
