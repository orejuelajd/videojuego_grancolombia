using UnityEngine;
using System.Collections;
using System.Threading;

public class DeteccionSwipes : MonoBehaviour {
	
	private Vector2 firstPressPos;
	private Vector2 secondPressPos;
	private Vector2 currentSwipe;
	private float valor_intervalo = 0.5f;
	private GameObject canvas_pausa;
	
	void Start () {
		canvas_pausa = GameObject.Find("canvas_pausa");
	}

	void Update () {
		if(canvas_pausa.GetComponent<Canvas>().enabled == false){
			Swipe();
		}
	}

	public void Swipe(){
		if(Input.touches.Length > 0)
		{
			Touch t = Input.GetTouch(0);
			if(t.phase == TouchPhase.Began)
			{
				//save began touch 2d point
				firstPressPos = new Vector2(t.position.x,t.position.y);
			}
			if(t.phase == TouchPhase.Ended)
			{
				//save ended touch 2d point
				secondPressPos = new Vector2(t.position.x,t.position.y);
				
				//create vector from the two points
				currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
				
				//normalize the 2d vector
				currentSwipe.Normalize();
				
				//swipe upwards
				if(currentSwipe.y > 0  && currentSwipe.x > -valor_intervalo  && currentSwipe.x < valor_intervalo)
				{ 
					//Debug.Log("up swipe");
					gameObject.GetComponent<PersonajeControl>().Saltar();
				}
				//swipe down
				if(currentSwipe.y < 0  && currentSwipe.x > -valor_intervalo  && currentSwipe.x < valor_intervalo)
				{
					//Debug.Log("down swipe");
					gameObject.GetComponent<PersonajeControl>().Agachar();
				}
				//swipe left
				if(currentSwipe.x < 0  && currentSwipe.y > -valor_intervalo  && currentSwipe.y < valor_intervalo)
				{
					//Debug.Log("left swipe");
				}
				//swipe right
				if(currentSwipe.x > 0  && currentSwipe.y > -valor_intervalo  && currentSwipe.y < valor_intervalo)
				{
					//Debug.Log("right swipe");
				}
			}
		}
	}
}
