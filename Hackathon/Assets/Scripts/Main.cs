using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets.Scripts.Extensions;

public class Main : MonoBehaviour {

    public Image imagePanel;
    public GameObject instructionsPanel;
    public Image instruction1Image;
    public Image instruction2Image;
    public Image instruction3Image;
    public Image instruction4Image;
    public GameObject componentPanel;
    public Text orderText;
    public Image loadingPanel;

    private float x;
    private float y;
    private Vector2 resolution;

    private int currentRoundTime = 0;
    private int maxRoundTime = 8;

    void OnGUI()
    {
    }

	// Use this for initialization
	void Start ()
    {
        resolution = new Vector2(Screen.width, Screen.height);
        x = Screen.width / 1080.0f; // 1920 is the x value of the working resolution (as described in the first point)
        y = Screen.height / 1920.0f; // 1042 is the y value of the working resolution (as described in the first point)

        orderText.text = "Change Me";

        InvokeRepeating("OnTickUpdate", 0, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
        if (Screen.width != resolution.x || Screen.height != resolution.y)
        {
            resolution = new Vector2(Screen.width, Screen.height);
            x = resolution.x / 1080.0f;
            y = resolution.y / 1920.0f;
        }
    }

    void OnTickUpdate()
    {
        var currentWidth = 1080.0f * (1.0f / maxRoundTime);
        currentRoundTime++;

        //-1080 -> 1080
        // 0
        loadingPanel.rectTransform.position = new Vector3(currentWidth + loadingPanel.rectTransform.position.x, loadingPanel.transform.position.y);
        Debug.Log(currentWidth);
        //loadingPanel.transform.Translate(new Vector3(currentWidth, loadingPanel.transform.position.y));
        //loadingPanel.rectTransform.SetRightTopPosition(new Vector2(currentWidth, 0));
        if (currentRoundTime == maxRoundTime)
        {
            currentRoundTime = 0;
        }
    }
}
