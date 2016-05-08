using UnityEngine;
using System.Collections; 
using UnityEngine.UI;

public class Multiplicador : MonoBehaviour {
	
	public Text puntaje;
	private GameObject controlJuego;
	
	void Start () {
		controlJuego = GameObject.Find("control");
	}
	
	void Update () {
		GetComponent<Text>().text = "X" + controlJuego.GetComponent<ControlJuego>().multiplicador;
	}
}