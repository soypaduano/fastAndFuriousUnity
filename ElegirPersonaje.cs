using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ElegirPersonaje : MonoBehaviour {

    public Image imagenCambiante;
    public Sprite[] personajeQueCambia;
    public Text textoPersonajes;


    string[] personajes = new string[] { "PIMP FLACO", "KAYDY CAIN", "C TANGANA", "KID KEO", "SEBASTIAN" };


    public int contador;

	// Use this for initialization
	void Start () {

        contador = 0;

        textoPersonajes.text = "Pimp Flaco";
        imagenCambiante.sprite = personajeQueCambia[0];
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}



    public void FadeOut(int s)
    {
        SceneManager.LoadScene("Inicio"); ;
    }

    public void CambiarDerecha(int s)
    {


        if (contador <= 4)
        {

            contador += 1;


            if (contador > 4)
            {
                contador = 4;
            }
            else
            {
                textoPersonajes.text = personajes[contador];
                imagenCambiante.sprite = personajeQueCambia[contador];

            }
        }

        




    }

    public void CambiarIzquierda(int s)
    {
        if (contador >= 0)
        {
            contador -= 1;
            if (contador < 0)
            {
                contador = 0;
            }
            else
            {
                textoPersonajes.text = personajes[contador];
                imagenCambiante.sprite = personajeQueCambia[contador];
            }
        }

    }
}





    



