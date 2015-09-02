using UnityEngine;
using System.Collections;

public class WallCollider : MonoBehaviour
{

    public float fadeSpeed;
    public SelectObject selectedObject;
    private bool fading = false;
    private Color customColor;
    private Color emptyColor;

    void Start()
    {
        customColor.r = 1;
        customColor.g = 2;
        customColor.b = 4;
        customColor.a = 0.1f;
        emptyColor.a = 0;
    }

    void Update()
    {
        if (fading == true)
        {
            Hit();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == TagConst.MOVEABLE)
        {
            selectedObject.arrived = true;
            col.transform.position -= selectedObject.target * 0.01f;
            GetComponent<Renderer>().material.SetColor("_Color", customColor);
            fading = true;
        }
    }

    void Hit()
    {
        GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, emptyColor, fadeSpeed * Time.deltaTime);
        if (GetComponent<Renderer>().material.color.a < 0.01f)
        {
            GetComponent<Renderer>().material.color = emptyColor;
            fading = false;
        }
    }
}
