using UnityEngine;
using System.Collections;

/// <summary>
/// Attach to Main Camera
/// </summary>
public class Menu : MonoBehaviour {
    public Texture backgroundTexture;

    void OnGUI()
    {
        // Display our background texture.
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);


    }


}
