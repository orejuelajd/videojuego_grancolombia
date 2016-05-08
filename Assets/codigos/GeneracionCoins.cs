using UnityEngine;
using System.Collections;

public class GeneracionCoins : MonoBehaviour {
	
	public GameObject[] obj;
	public float generacionMin = 1f;
	public float generacionMax = 2f;
	private string estado = "";
	private int numeroRandom = 0;
	private int powerupSeleccionado = 0;
	private int random_altura = 0;

	void Start () {
		Generar();
	}
	
	void Generar()
	{
		numeroRandom = Random.Range(0,110);
		if(numeroRandom > 0 && numeroRandom < 20){
			powerupSeleccionado = 0;
		}
		if(numeroRandom > 20 && numeroRandom < 40){
			powerupSeleccionado = 1;
		}
		if(numeroRandom > 40 && numeroRandom < 55){
			powerupSeleccionado = 2;
		}
		if(numeroRandom > 55 && numeroRandom < 70){
			powerupSeleccionado = 3;
		}
		if(numeroRandom > 70 && numeroRandom < 85){
			powerupSeleccionado = 4;
		}
		if(numeroRandom >= 85 && numeroRandom < 95){
			powerupSeleccionado = 5;
		}
		if(numeroRandom > 95 && numeroRandom < 100){
			powerupSeleccionado = 6;
		}
		if(numeroRandom > 100 && numeroRandom < 105){
			powerupSeleccionado = 7;
		}
		if(numeroRandom > 105 && numeroRandom < 110){
			powerupSeleccionado = 8;
		}
		Instantiate(obj[powerupSeleccionado], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
		//Invoke ("Generar", Random.Range (generacionMin, generacionMax));
	}
}