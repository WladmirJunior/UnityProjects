using UnityEngine;
using System.Collections;

// Classe que move uma imagem de fundo como paralax

public class BackGround : MonoBehaviour {

	private Transform tCamera;
	private Vector3 p = Vector3.zero;

    public float motion = 0.5F;

	void Start () {
		tCamera = Camera.main.transform;
	}

	void Update () {
		// calculo que move o paxalax em metade do deslocamento da camera.
		p.Set(tCamera.position.x - (tCamera.position.x*motion) + 10f, 0f, 1f);
		transform.position = p;
	}

}
