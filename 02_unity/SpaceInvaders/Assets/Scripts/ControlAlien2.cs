﻿
using UnityEngine;
using System.Collections;

public class ControlAlien2 : MonoBehaviour
{
	public int vida = 2;
	public float velocidad = 0.1f;
	public void pararAlien ()
	{
		velocidad = 0;
	}
	// Conexión al marcador, para poder actualizarlo
	public GameObject marcador;

	// Por defecto, 100 puntos por cada alien
	public int puntos = 200;

	// Use this for initialization
	void Start ()
	{
		// Localizamos el objeto que contiene el marcador
		marcador = GameObject.Find ("Marcador");
	}

	// Update is called once per frame
	void Update ()
	{
		// Calculamos la anchura visible de la cámara en pantalla
		float distanciaHorizontal = Camera.main.orthographicSize * Screen.width / Screen.height;

		// Calculamos el límite izquierdo y el derecho de la pantalla
		float limiteIzq = -1.0f * distanciaHorizontal;
		float limiteDer = 1.0f * distanciaHorizontal;


		// mover aliens
		if (this.transform.position.x >= limiteDer) {
			this.transform.position = new Vector2 (limiteIzq, this.transform.position.y - 1.0f);

		}
		this.transform.position = new Vector2 (this.transform.position.x + velocidad, this.transform.position.y);

	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		
		// Detectar la colisión entre el alien y otros elementos

		// Necesitamos saber contra qué hemos chocado
		if (coll.gameObject.tag == "disparo") {
			// El disparo desaparece (cuidado, si tiene eventos no se ejecutan)
			Destroy (coll.gameObject);
			vida -= 1;
			if (vida == 0) {
				// Sonido de explosión
				GetComponent<AudioSource> ().Play ();

				// Sumar la puntuación al marcador
				marcador.GetComponent<ControlMarcador> ().puntos += puntos;



				// El alien desaparece (hay que añadir un retraso, si no, no se oye la explosión)

				// Lo ocultamos...
				GetComponent<Renderer> ().enabled = false;
				GetComponent<Collider2D> ().enabled = false;

				// ... y lo destruímos al cabo de 5 segundos, para dar tiempo al efecto de sonido
				Destroy (gameObject, 5f);
			}
		

		}
	}
}
