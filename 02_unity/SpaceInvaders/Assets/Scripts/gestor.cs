using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class gestor : MonoBehaviour {
	public Text record;
	// Use this for initialization
	void Start () {
		print ("entra");
		if (PlayerPrefs.GetInt ("record") == null)
			PlayerPrefs.SetInt ("record", 0);
			record.text = "record: "+ PlayerPrefs.GetInt("record");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void cerrar(){
		Application.Quit ();
	}
	public void cargar(){
		print ("ha pulsado en reiniciar");
		SceneManager.LoadScene ("Nivel1");
	}
	public void opciones(){

		SceneManager.LoadScene ("opcion");
	}
	public void menu(){
		print ("ha pulsado en el menu");
		SceneManager.LoadScene ("inicio");
	}

}
