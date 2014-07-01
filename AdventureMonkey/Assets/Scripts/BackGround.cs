﻿using UnityEngine;
using System.Collections;

// Classe que move uma imagem de fundo como paralax

public class BackGround : MonoBehaviour {

	private Transform tCamera;
	private Vector3 p = Vector3.zero;

	void Start () {
		tCamera = Camera.main.transform;
	}

	void Update () {
		// calculo que move o paxalax em metade do deslocamento da camera.
		// tambem  faz o paralax avançar bruscamente a cada 20 unidades de movimento da camera
		p.Set(tCamera.position.x - (tCamera.position.x*0.5f)%20f + 10f, 0f, 1f);
		transform.position = p;
	}

}
