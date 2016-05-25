using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class opcion_script : MonoBehaviour {
	public Button sonido;
	public bool activado =true;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void quitar_sonido(){
		if (activado == true) {
			AudioListener.pause = true;
			print ("esta en quitar sonido");
			sonido.GetComponentInChildren<Text>().text = "sonido desactivado";
			activado = false;
		} else {
			
			 
			AudioListener.pause = false;
			sonido.GetComponentInChildren<Text>().text = "sonido activado";
			activado = true;
		}
	}
	public void borrar(){
		PlayerPrefs.SetInt ("record", 0);
	}
	public void volver(){
		SceneManager.LoadScene ("inicio");
	}

}
 