using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Attach to Main Camera
/// </summary>
public class Menu : MonoBehaviour {
    public Texture backgroundTexture;

    void OnGUI()
    {
        // Display our background texture.
        //GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        // Display buttons
        //GUI.Button(new Rect(Screen.width * .5f, Screen.height * 0.5f, Screen.width * .5f, Screen.height * .1f), "Plays");
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Profile");
    }

}
