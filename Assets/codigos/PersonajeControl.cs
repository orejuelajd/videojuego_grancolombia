using UnityEngine;

[RequireComponent(typeof(Personaje))]
public class PersonajeControl : MonoBehaviour 
{
	private Personaje personaje;
    private bool salto;
	AudioSource as_personaje;
	public AudioClip ac_jump;
	private bool crouch;
	
	void Awake()
	{
		personaje = GetComponent<Personaje>();
		as_personaje = gameObject.GetComponent<AudioSource>();
	}

    void Update (){
    }

	void FixedUpdate()
	{
	    float h = Input.GetAxis("Horizontal");
		personaje.Move( 1, false , salto );
		personaje.Move (1, crouch, false);
		salto = false;
	}

	public void Saltar(){
		salto = true;
		as_personaje.PlayOneShot(ac_jump);
	}

	public void Agachar(){
		crouch = true;
		Invoke("Levantar", 0.5f);
	}

	public void Levantar(){
		crouch = false;
	}
}
