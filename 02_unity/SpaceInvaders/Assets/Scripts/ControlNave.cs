﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlNave : MonoBehaviour
{
	public GameObject m;

	public Text marcador;
	// Velocidad a la que se desplaza la nave (medido en u/s)
	private float velocidad = 20f;

	// Fuerza de lanzamiento del disparo
	private float fuerza = 0.5f;

	// Acceso al prefab del disparo
	public Rigidbody2D disparo;

	//gameOver

	public GameObject gameOver;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Calculamos la anchura visible de la cámara en pantalla
		float distanciaHorizontal = Camera.main.orthographicSize * Screen.width / Screen.height;

		// Calculamos el límite izquierdo y el derecho de la pantalla
		float limiteIzq = -1.0f * distanciaHorizontal;
		float limiteDer = 1.0f * distanciaHorizontal;

		// Tecla: Izquierda
		if (Input.GetKey (KeyCode.LeftArrow)) {

			// Nos movemos a la izquierda hasta llegar al límite para entrar por el otro lado
			if (transform.position.x > limiteIzq) {
				transform.Translate (Vector2.left * velocidad * Time.deltaTime);
			} else {
				transform.position = new Vector2 (limiteDer, transform.position.y);			
			}
		}

		// Tecla: Derecha
		if (Input.GetKey (KeyCode.RightArrow)) {

			// Nos movemos a la derecha hasta llegar al límite para entrar por el otro lado
			if (transform.position.x < limiteDer) {
				transform.Translate (Vector2.right * velocidad * Time.deltaTime);
			} else {
				transform.position = new Vector2 (limiteIzq, transform.position.y);			
			}
		}

		// Disparo
		if (Input.GetKeyDown (KeyCode.Space)) {
			disparar ();
		}


	}

	void disparar ()
	{
		// Hacemos copias del prefab del disparo y las lanzamos
		Rigidbody2D d = (Rigidbody2D)Instantiate (disparo, transform.position, transform.rotation);

		// Desactivar la gravedad para este objeto, si no, ¡se cae!
		d.gravityScale = 0;

		// Posición de partida, en la punta de la nave
		d.transform.Translate (Vector2.up * 0.7f);

		// Lanzarlo
		d.AddForce (Vector2.up * fuerza, ForceMode2D.Impulse);	
	}

	// jugador pierde
	void OnCollisionEnter2D (Collision2D coll)
	{
        // Detectar la colisión entre la nave y otros elementos

        // Necesitamos saber contra qué hemos chocado
        if (coll.gameObject.tag == "alien") {


            gameOver.SetActive(true);
		
		
		//	gameOver.GetComponentInChildren<Text>().text = marcador.text;
		//	int p =	m.GetComponent<ControlMarcador> ().puntos;
		//	print (p);
			if (PlayerPrefs.GetInt ("record") < m.GetComponent<ControlMarcador> ().puntos) {
	
			PlayerPrefs.SetInt("record",m.GetComponent<ControlMarcador> ().puntos);
		}

  	
			GameObject[] aliens = GameObject.FindGameObjectsWithTag("alien");
                foreach (GameObject a in aliens) { 

				Destroy (a);
     }
            // destruir nave
            Destroy (gameObject);



		}
	}



}
