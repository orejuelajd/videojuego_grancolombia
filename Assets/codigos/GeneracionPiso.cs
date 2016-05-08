using UnityEngine;
using System.Collections;

public class GeneracionPiso : MonoBehaviour
{
	
	public GameObject[] suelo;
	public float generacionMin = 1f;
	public float generacionMax = 2f;
	
	void Start ()
	{
		Generar ();
	}
	
	void Generar ()
	{
		Instantiate (suelo [Random.Range (0, suelo.GetLength (0))], new Vector3 (transform.position.x, transform.position.y , transform.position.z), Quaternion.identity);
		Invoke ("Generar", Random.Range (generacionMin, generacionMax));
	}
}