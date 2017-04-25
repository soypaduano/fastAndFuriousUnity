using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PorroObstaculo : MonoBehaviour {

    public Cronometro cronometroScript;
    public GameObject cronometroGO;

    public GameObject controladorCocheGO;
    public ControladorCoche controladorCocheSCRIPT;


    public AudioFX AudioFX;
    public GameObject AudioGo;

    public GameObject motorDeCarreteraGO;
    public MotorDeCarretera motorDeCarreteraScript;

    public float fumada = 0.0f;
    public bool fumado = false;

    private float timeLeft;

    void Start()
    {
        //Buscamos los componentes
        cronometroGO = FindObjectOfType<Cronometro>().gameObject;
        cronometroScript = cronometroGO.GetComponent<Cronometro>();


        controladorCocheGO = GameObject.Find("ControladorCoche");
        controladorCocheSCRIPT = controladorCocheGO.GetComponent<ControladorCoche>();

        //Lo que hacemos es buscar aquellos objetos que tengan el componente <XX> y lo "casteamos" a tipo GameObject
        AudioGo = FindObjectOfType<AudioFX>().gameObject;
        AudioFX = AudioGo.GetComponent<AudioFX>();

        //Buscamos el motor de carrtera para cambiar la velocidad del juego
        motorDeCarreteraGO = GameObject.Find("MotorDeCarretera");
        motorDeCarreteraScript = motorDeCarreteraGO.GetComponent<MotorDeCarretera>();
    }


    private void Update()
    {
        if (fumado)
        {
            Debug.Log("Entra aqui");
            fumada -= 1 * Time.deltaTime;
            Debug.Log(fumada);
        }
       

    }

    //Cuando choca con el bus
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Comprobamos que el objeto con el que choca tiene el componente Coche. (Que sea distinto de null, es decir, que lo tenga)
        if (collision.GetComponent<Coche>() != null)
        {
            //hacemos una serie de cosas cada vez que chocan.
            AudioFX.reproducirChoque();

            StartCoroutine(MyCoroutine(3.0f));
        }
    }

    IEnumerator MyCoroutine(float duration)
    {

        motorDeCarreteraScript.speed = 6;
        cronometroScript.voyTodoFumado = true;
        controladorCocheSCRIPT.velocidad = 5;
       
       

        yield return new WaitForSeconds(duration);   //Wait

        motorDeCarreteraScript.speed = 12;
        controladorCocheSCRIPT.velocidad = 15;
        cronometroScript.voyTodoFumado = false;
       


    }






}




