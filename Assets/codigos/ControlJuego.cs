using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


public class ControlJuego : MonoBehaviour {

	private float tiempoEspera = 0;
	public string estado = "bosque";
	private float tiempoMaximoEspera = 3;
	private float tiempoMinimoEspera = 5; // en segundos
	private GameObject fondo_bosque, fondo_desierto, canvas_pausa, canvas_alertasalir, canvas_alertareiniciar;
	private GameObject simbolo_musica_desactivada, simbolo_efectos_desactivados;
	private GameObject personaje;
	public int puntaje = 0;
	public float distancia_recorrida = 0;
	public int multiplicador = 1;

	void Start () {
		fondo_bosque = GameObject.Find("fondo_bosque");
		fondo_desierto = GameObject.Find("fondo_desierto");
		canvas_pausa = GameObject.Find("canvas_pausa");
		canvas_alertasalir = GameObject.Find("canvas_alertasalir");
		canvas_alertareiniciar = GameObject.Find("canvas_alertareiniciar");
		simbolo_musica_desactivada = GameObject.Find("simbolo_musica_desactivada");
		simbolo_efectos_desactivados = GameObject.Find("simbolo_efectos_desactivados");
		personaje = GameObject.Find("personaje");
		canvas_pausa.GetComponent<Canvas>().enabled = false;
		canvas_alertasalir.GetComponent<Canvas>().enabled = false;
		canvas_alertareiniciar.GetComponent<Canvas>().enabled = false;
		confSonido();
	}

	void Update () {

		distancia_recorrida += (Time.deltaTime/1000000) * Time.timeScale;
		Debug.Log(distancia_recorrida);

	}

	public void pausar(){
		Time.timeScale = 0;
		gameObject.GetComponent<AudioSource>().enabled = false;
		canvas_pausa.GetComponent<Canvas>().enabled = true;
	}

	public void reanudar(){
		Time.timeScale = 1;
		if(PlayerPrefs.GetInt("musica_activada") == 1){
			gameObject.GetComponent<AudioSource>().enabled = true;
		}
		if(PlayerPrefs.GetInt("efectossonido_activados") == 1){
			personaje.GetComponent<AudioSource>().enabled = true;
		}else{
			personaje.GetComponent<AudioSource>().enabled = false;
		}
		canvas_pausa.GetComponent<Canvas>().enabled = false;
	}

	public void volvermenu(){
		Time.timeScale = 0;
		canvas_pausa.GetComponent<Canvas>().enabled = false;
		canvas_alertasalir.GetComponent<Canvas>().enabled = true;
	}

	public void reiniciar(){
		canvas_pausa.GetComponent<Canvas>().enabled = false;
		canvas_alertareiniciar.GetComponent<Canvas>().enabled = true;
	}

	public void si_reiniciar(){
		Time.timeScale = 1;
		Application.LoadLevel("escena_principal");
	}
	
	public void no_reiniciar(){
		canvas_pausa.GetComponent<Canvas>().enabled = true;
		canvas_alertareiniciar.GetComponent<Canvas>().enabled = false;
	}

	public void si_salir(){
		Time.timeScale = 1;
		Application.LoadLevel("escena_inicio");
	}

	public void no_salir(){
		canvas_pausa.GetComponent<Canvas>().enabled = true;
		canvas_alertasalir.GetComponent<Canvas>().enabled = false;
	}

	public void activacion_musica(){
		if(PlayerPrefs.GetInt("musica_activada") == 1){
			PlayerPrefs.SetInt("musica_activada", 0);
			simbolo_musica_desactivada.GetComponent<RawImage>().enabled = true;
		}else{
			PlayerPrefs.SetInt("musica_activada", 1);
			simbolo_musica_desactivada.GetComponent<RawImage>().enabled = false;
		}
	}

	public void activacion_efectossonido(){
		if(PlayerPrefs.GetInt("efectossonido_activados") == 1){
			PlayerPrefs.SetInt("efectossonido_activados", 0);
			simbolo_efectos_desactivados.GetComponent<RawImage>().enabled = true;
		}else{
			PlayerPrefs.SetInt("efectossonido_activados", 1);
			simbolo_efectos_desactivados.GetComponent<RawImage>().enabled = false;
		}
	}

	void confSonido(){
		try{
			if(PlayerPrefs.GetInt("musica_activada") == 1){
				gameObject.GetComponent<AudioSource>().enabled = true;
				simbolo_musica_desactivada.GetComponent<RawImage>().enabled = false;
			}else{
				gameObject.GetComponent<AudioSource>().enabled = false;
				simbolo_musica_desactivada.GetComponent<RawImage>().enabled = true;
			}
			
			if(PlayerPrefs.GetInt("efectossonido_activados") == 1){
				personaje.GetComponent<AudioSource>().enabled = true;
				simbolo_efectos_desactivados.GetComponent<RawImage>().enabled = false;
			}else{
				personaje.GetComponent<AudioSource>().enabled = false;
				simbolo_efectos_desactivados.GetComponent<RawImage>().enabled = true;
			}
		}catch(Exception e){
			PlayerPrefs.SetInt("musica_activada", 1);
			PlayerPrefs.SetInt("efectossonido_activados", 1);
		}
	}
}