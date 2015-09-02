using UnityEngine;
using System.Collections;

public class DebugRot : MonoBehaviour {

    public Transform toTrack;
	void Update () 
    {
        GetComponent<GUIText>().text = ("Rot: " + toTrack.rotation.eulerAngles + "\nPos: " + toTrack.position);
	}
}
