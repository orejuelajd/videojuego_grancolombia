using UnityEngine;
using System.Collections;

public class GeneracionObstaculo : MonoBehaviour
{
	public GameObject[] obstaculos;
	public GameObject[] obstaculos_destruibles;
	public float generacionMin = 1f;
	public float generacionMax = 2f;
	private int random_obstaculo = 1;
	private GameObject control;
	private bool primeraVez = true;
	private bool segundaVez = true;
	
	void Start (){
		control = GameObject.Find("control");
		Generar ();
	}
	
	void Generar (){
		if(primeraVez){
			primeraVez = false;
		}else{
			if(segundaVez){
				random_obstaculo = Random.Range (1, 10);
				segundaVez = false;
			}else{
				random_obstaculo = Random.Range (0, 10);
			}
		}
		if(random_obstaculo == 0 && segundaVez == false){
			Instantiate (obstaculos_destruibles [Random.Range(0,obstaculos_destruibles.Length)], new Vector3 (transform.position.x, transform.position.y), Quaternion.identity);
		}
		if(random_obstaculo >= 1 && random_obstaculo <= 10 && segundaVez == false){
			Instantiate (obstaculos [Random.Range(0,obstaculos.Length)], new Vector3 (transform.position.x, transform.position.y), Quaternion.identity);
		}

		Invoke ("Generar", Random.Range (generacionMin, generacionMax));
	}

	void Update(){
		if(generacionMin > 0.7f){
			generacionMin -= control.GetComponent<ControlJuego>().distancia_recorrida;
		}
		if(generacionMax > 0.7f){
			generacionMax -= control.GetComponent<ControlJuego>().distancia_recorrida;
		}
	}
}
