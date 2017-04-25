using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour {

    //Necesitamos conectar el cronometro con el motor de carreteras
    private GameObject motorDeCarreterasGO;
    public MotorDeCarretera motorDeCarreteraScript;


    public GameObject controladorCocheGO;



    //Vamos a necesitar una variable de tiempo y una de distancia, traerme los textos donde vamos a poner la distancia.
    public float tiempo;
    public float distancia;
    public Text txtTiempo;
    public Text txtDistancia;
    public Text txtDistanciaFinalRecorrida;
    public Text txtDistanciaMaxScore;

    public bool voyTodoFumado;

    public int maxScore;


    //Cuando vamos a tener que usar algo de UI CANVAS, hay que importar UnityEngine.UI
	// Use this for initialization
	void Start () {
        //Inicializamos las referencias
        motorDeCarreterasGO = GameObject.Find("MotorDeCarretera");
        motorDeCarreteraScript = motorDeCarreterasGO.GetComponent<MotorDeCarretera>();

        controladorCocheGO = GameObject.Find("ControladorCoche");


        //inicializamos valores de tiempo y distancia

        txtTiempo.text = "2:00";
        txtDistancia.text = "0";

        //inicializamos tiempo
        tiempo = 50; //2 minutos

        //Obtenemos la mayor puntuacion:
        maxScore = PlayerPrefs.GetInt("highscore");

        if(maxScore == null)
        {
            PlayerPrefs.SetInt("highscore", 0);
        }

    }
	
	// Update is called once per frame
	void Update () {
        //Empecemos a trabajar los estados del cronometro
        if(motorDeCarreteraScript.juegoIniciado == true && motorDeCarreteraScript.juegoTerminado == false)
        {
            calculoTiempoYDistancia();
        }
        
        //Va a entrar solamente si es menor o igual que 0, y si el juego no ha terminado aun. 
        if(tiempo <= 0 && motorDeCarreteraScript.juegoTerminado == false)
        {


            if (distancia > maxScore)
            {
                maxScore = ((int)distancia);
                PlayerPrefs.SetInt("highscore", maxScore);
            }

            motorDeCarreteraScript.juegoTerminado = true;
            motorDeCarreteraScript.JuegoTerminadoEstados();
            txtDistanciaFinalRecorrida.text = ((int)distancia).ToString() + " MTS" ;
            txtDistanciaMaxScore.text = "Max Score: " +  ((int)maxScore).ToString() + " MTS";
            txtDistancia.text = "0:00";
            txtTiempo.text = "0:00";
            Destroy(controladorCocheGO);
            
            
        }
	}

    //Mecanica que controla todo
    void calculoTiempoYDistancia() {

        //la distancia es lo siguiente

        if (voyTodoFumado)
        {
            distancia += Time.deltaTime * 12;
        } else
        {
            distancia += Time.deltaTime * motorDeCarreteraScript.speed;


        }
        
        //le pasamos este resultado al txt de la distancia
        //Hacemos un cast-> Lo pasamos a INT y luego a String [sobretodo por el time delta time]
        txtDistancia.text = ((int)distancia).ToString();

        tiempo -= Time.deltaTime;
        int minutos = (int)tiempo / 60;
        int segundos = (int)tiempo % 60;

        //Ponemos los minutos, le añadimos los segundos y le ponemos 2 casilleros! (un valor de 2 numeros, y en caso de que
        //no tenga con que rellenar, que lo rellene con 0. 

        txtTiempo.text = minutos.ToString() + ":" + segundos.ToString().PadLeft(2, '0');


        if (distancia > maxScore)
        {
            txtDistancia.color = Color.yellow;
        }


    }
}
