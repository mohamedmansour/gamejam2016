using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    public Image imagePanel;
    public GameObject instructionsPanel;
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
