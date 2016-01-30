using UnityEngine;
using System.Collections;

public class DialComponent : MonoBehaviour {
    private GameObject pointer;
    
    // Use this for initialization
    void Start () {
        pointer = GameObject.Find("DialPointer");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        //pointer.transform.localRotation = Quaternion.AngleAxis(20f, Vector3.forward);
        pointer.transform.RotateAround(transform.position, Vector3.forward  , 20f);
        //pointer.transform.Rotate(0, 0, 90f);
    }

    void OnMouseDrag()
    {
        //Debug.Log(Input.mousePosition);
        /*
        var v3 = Input.mousePosition - v3Pos;
        v3.Normalize();
        var f = Vector3.Dot(v3, Vector3.up);
        if (Vector3.Distance(v3Pos, Input.mousePosition) < threshold)
        {
            Debug.Log("No movement");
            return;
        }

        if (f >= 0.5)
        {
            Debug.Log("Up");
        }
        else if (f <= -0.5)
        {
            Debug.Log("Down");
        }
        else {
            f = Vector3.Dot(v3, Vector3.right);
            if (f >= 0.5)
            {
                Debug.Log("Right");
            }
            else {
                Debug.Log("Left");
            }
        }
        v3Pos = Input.mousePosition;
        */
    }

}
