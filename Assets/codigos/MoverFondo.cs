using UnityEngine;
using System.Collections;

public class MoverFondo : MonoBehaviour {

	public float velocidad = 0f;
	private Renderer renderer;

	void Start () {
		renderer =  gameObject.GetComponent<Renderer>();
	}

	void Update () {
		renderer.material.mainTextureOffset = new Vector2(Time.time * velocidad, 0);
	}
}
