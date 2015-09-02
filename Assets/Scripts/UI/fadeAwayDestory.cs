using UnityEngine;
using System.Collections;

public class fadeAwayDestory : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        Color temp = new Color(1,1,1,GetComponent<GUITexture>().color.a-Time.deltaTime / 25);
        GetComponent<GUITexture>().color = temp;
        if (GetComponent<GUITexture>().color.a <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
