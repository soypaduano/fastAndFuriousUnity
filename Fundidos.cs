using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fundidos : MonoBehaviour {



    public Image fundido;
    //Le vamos a pasar un array de string con escenas
    public string[] escenas;

	
	void Start () {
        //Es una funcion que viene como propiedad en la clase imagen de Unity, nos permite hacer fundido de tipo imagen
        fundido.CrossFadeAlpha(0, 1.5f, false);

	}
	
    //Funcion para cambiar escena

    public void FadeOut(int s)
    {
        fundido.CrossFadeAlpha(1, 0.5f, false);
        StartCoroutine(CambioEscena(escenas[s]));
    }

    IEnumerator CambioEscena(string escena)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(escena);
    }
	

}
