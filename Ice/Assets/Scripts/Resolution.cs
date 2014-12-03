using UnityEngine;
using System.Collections;

public class Resolution : MonoBehaviour {

    GUITexture image;
    public Vector2 scale;

	void Start () {

        image = GetComponent<GUITexture>();
        //image.pixelInset = new Rect(-140, -100, 280, 200);

        float width = Screen.width * scale.x;
        float height = Screen.height * scale.y;

        //image.pixelInset = new Rect(-width/2, -height/2, width, height);
	}
	
	void Update () {

        float width = Screen.width * scale.x;
        float height = Screen.height * scale.y;
        image.pixelInset = new Rect(-width / 2, -height / 2, width, height);
	}
}
