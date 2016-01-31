using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Main : MonoBehaviour {

    public Image imagePanel;
    public GameObject instructionsPanel;
    public Image instruction1Image;
    public Image instruction2Image;
    public Image instruction3Image;
    public Image instruction4Image;
    public GameObject componentPanel;
    public Text orderText;
    

    void OnGUI()
    {
    }

	// Use this for initialization
	void Start ()
    {
        orderText.text = "Change Me";

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
