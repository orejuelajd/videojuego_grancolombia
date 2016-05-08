using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Control_HUD_Inicio : MonoBehaviour {
	
	private GameObject texto_mejor_puntaje;
	private int mejor_puntaje = 0;
	private GameObject canvas_inicio, canvas_creditos, canvas_ayuda, panel_ayuda_01, panel_ayuda_02;

	void Start () {
		texto_mejor_puntaje = GameObject.Find("mejor_puntaje");
		canvas_inicio = GameObject.Find("canvas_inicio");
		canvas_ayuda = GameObject.Find("canvas_ayuda");
		canvas_creditos = GameObject.Find("canvas_creditos");
		panel_ayuda_01 = GameObject.Find("panel_ayuda_01");
		panel_ayuda_02 = GameObject.Find("panel_ayuda_02");

		try {
			mejor_puntaje = PlayerPrefs.GetInt("mejor_puntaje");
		}
		catch (Exception e) {
			mejor_puntaje = 0;
			PlayerPrefs.SetInt("mejor_puntaje",0);
		}
		
		texto_mejor_puntaje.GetComponent<Text>().text = "Mejor Puntaje: " + mejor_puntaje;
	}

	void Update () {

	}

	public void jugar(){
		Application.LoadLevel("escena_principal");
	}

	public void configuracion(){

	}

	public void ayuda(){
		canvas_inicio.GetComponent<Canvas>().enabled = false;
		canvas_ayuda.GetComponent<Canvas>().enabled = true;
	}

	public void creditos(){
		canvas_inicio.GetComponent<Canvas>().enabled = false;
		canvas_creditos.GetComponent<Canvas>().enabled = true;
	}

	public void volver_creditos(){
		canvas_inicio.GetComponent<Canvas>().enabled = true;
		canvas_creditos.GetComponent<Canvas>().enabled = false;
	}

	public void atras_ayuda(){
		panel_ayuda_01.GetComponent<RawImage>().enabled = true;
		panel_ayuda_02.GetComponent<RawImage>().enabled = false;
	}

	public void adelante_ayuda(){
		panel_ayuda_01.GetComponent<RawImage>().enabled = false;
		panel_ayuda_02.GetComponent<RawImage>().enabled = true;
	}

	public void volver_ayuda(){
		canvas_inicio.GetComponent<Canvas>().enabled = true;
		canvas_ayuda.GetComponent<Canvas>().enabled = false;
	}
}
