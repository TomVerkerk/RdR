using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public Texture[] buttons;
	public Texture background;
	public Vector2 pos;
	public Vector2 size;
	public Vector2 offset;
	public Vector2 offsetLength;
	public bool buttonsVisable;

	// Use this for initialization
	void OnGUI(){
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), background);
		for(int i=0;i<buttons.Length;i++){
			GUI.color = Color.white;
			GUI.DrawTexture (new Rect (Screen.width * (pos.x + (offset.x * (i % offsetLength.x))), Screen.height * (pos.y + (offset.y * Mathf.Floor (i / offsetLength.x))), Screen.width * size.x, Screen.height * size.y), buttons [i]);
			if (!buttonsVisable) {
				GUI.color=Color.clear;
			}
			if(GUI.Button(new Rect(Screen.width*(pos.x+(offset.x*(i%offsetLength.x))),Screen.height*(pos.y+(offset.y*Mathf.Floor(i/offsetLength.x))),Screen.width*size.x,Screen.height*size.y),"")){
				print(i+1);
				openLevel(i);
			}
		}
	}

	void openLevel(int level){
		if (level == 2) {
			Application.Quit ();
		} 
		else {
			Application.LoadLevel (level);
		}
	}
}
