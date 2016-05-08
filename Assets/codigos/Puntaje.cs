using UnityEngine;
using System.Collections; 
using UnityEngine.UI;

public class Puntaje : MonoBehaviour {

	public Text puntaje;
	private GameObject controlJuego;

	void Start () {
		controlJuego = GameObject.Find("control");
	}

	void Update () {
		GetComponent<Text>().text = "Puntos: " + controlJuego.GetComponent<ControlJuego>().puntaje;
	}
}
