using UnityEngine;
using System.Collections;

public class Obstaculo_Destruible : MonoBehaviour {

	private bool colision_arriba = false;
	private bool colision_izquierda = false;
	private GameObject control;
	
	void Start () {
		control = GameObject.Find("control");
	}

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{ 
			if(gameObject.tag == "collider_izq"){
				PlayerPrefs.SetInt("puntaje", control.GetComponent<ControlJuego>().puntaje);
				if(control.GetComponent<ControlJuego>().puntaje > PlayerPrefs.GetInt("mejor_puntaje")){
					PlayerPrefs.SetInt("mejor_puntaje", control.GetComponent<ControlJuego>().puntaje);
				}
				Application.LoadLevel("escena_gameover");
			}
			if(gameObject.tag == "collider_superior"){
				Destroy(transform.parent.gameObject);
				control.GetComponent<ControlJuego>().puntaje += 100;
			}
		}
	}
}
