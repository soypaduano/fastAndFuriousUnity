using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaAtras : MonoBehaviour {

    //variables que necesito para la cuenta atras
    public GameObject motorDeCarreterasGO;
    public MotorDeCarretera motorDeCarreteraScript;


    //array de sprites
    public Sprite[] numeros;


    //necesito acceder al componente sprite renderer
    public GameObject contadorNumerosGO; // Game Object
    public SpriteRenderer contadorNumerosComp; //Componente

    //Elementos del coche.
    public GameObject cocheGO;
    public GameObject controladorCoche;


	// Use this for initialization
	void Start () {
        InicioComponentes();
		
	}





    void InicioComponentes()
    {
        motorDeCarreterasGO = GameObject.Find("MotorDeCarretera");
        motorDeCarreteraScript = motorDeCarreterasGO.GetComponent<MotorDeCarretera>();

        contadorNumerosGO = GameObject.Find("ContadorNumeros");
        contadorNumerosComp = contadorNumerosGO.GetComponent<SpriteRenderer>();

        cocheGO = GameObject.Find("Coche");
        controladorCoche = GameObject.Find("ControladorCoche");

        InicioCuentaAtras();
    }


    void InicioCuentaAtras()
    {
        //La cuenta atras se realiza con una con una corutina.
        StartCoroutine(Contando());

    }

    IEnumerator Contando()
    {
        //Primero que nada ejecutamos el sonido:
        controladorCoche.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        //Espera 2 segundos........

        contadorNumerosComp.sprite = numeros[1]; //Se pone la imagen 3
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1); // esperamos un segundo

        contadorNumerosComp.sprite = numeros[2]; //Se pone la imagen 3
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1); // esperamos un segundo

        contadorNumerosComp.sprite = numeros[3]; //Se pone la imagen 3
        motorDeCarreteraScript.juegoIniciado = true; //Iniciamos el juego
        contadorNumerosGO.GetComponent<AudioSource>().Play(); //sonamos el sonido
        cocheGO.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);



        contadorNumerosGO.SetActive(false);
  
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
