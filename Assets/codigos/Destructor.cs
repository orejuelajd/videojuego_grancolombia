using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

	private GameObject control;

	void Start(){
		control = GameObject.Find("control");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			PlayerPrefs.SetInt("puntaje", control.GetComponent<ControlJuego>().puntaje);
			if(control.GetComponent<ControlJuego>().puntaje > PlayerPrefs.GetInt("mejor_puntaje")){
				PlayerPrefs.SetInt("mejor_puntaje", control.GetComponent<ControlJuego>().puntaje);
			}
			Application.LoadLevel("escena_gameover");
			return;
		}
		if (other.gameObject.transform.parent) 
		{
			Destroy (other.gameObject.transform.parent.gameObject);
		} 
		else 
		{
			Destroy (other.gameObject);
		}
	}

}
