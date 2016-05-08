using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	private GameObject controlJuego;
	private int puntos = 0;
	private int multiplicador = 1;

	void Start(){
		controlJuego = GameObject.Find("control");
	}

	void Update(){
		multiplicador = controlJuego.GetComponent<ControlJuego>().multiplicador;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			if(tag.Equals("organico")){
				puntos = 10;
			}
			if(tag.Equals("papel")){
				puntos = 20;
			}
			if(tag.Equals("lata")){
				puntos = 50;
			}
			if(tag.Equals("botellaplastica")){
				puntos = 100;
			}
			if(tag.Equals("botellavidrio")){
				puntos = 150;
			}
			if(tag.Equals("bombillo")){
				puntos = 150;
			}
			if(tag.Equals("bateria")){
				puntos = 250;
			}
			if(tag.Equals("celular")){
				puntos = 500;
			}
			if(tag.Equals("gota")){
				controlJuego.GetComponent<ControlJuego>().multiplicador ++;
			}
			controlJuego.GetComponent<ControlJuego>().puntaje += puntos * multiplicador;
			Destroy (this.gameObject);
		}
	}
}
