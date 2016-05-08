using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Control_HUD_GameOver : MonoBehaviour {
	
	private GameObject texto_mejor_puntaje, texto_puntaje;

	void Start () {
		texto_mejor_puntaje = GameObject.Find("mejor_puntaje");
		texto_puntaje = GameObject.Find("puntaje");

		texto_mejor_puntaje.GetComponent<Text>().text = "Mejor Puntaje:" + PlayerPrefs.GetInt("mejor_puntaje"); 
		texto_puntaje.GetComponent<Text>().text = "Puntaje:" + PlayerPrefs.GetInt("puntaje");
	}

	void Update () {
	
	}

	public void reiniciar(){
		Application.LoadLevel("escena_principal");
	}

	public void volverinicio(){
		Application.LoadLevel("escena_inicio");
	}
}
