using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCoche : MonoBehaviour {

    //Referenciar este mismo coche
    public GameObject cocheGO;

    public GameObject motorDeCarreteraGO;
    public MotorDeCarretera motorDeCarreteraScript;

    //Variables que vamos a utilizar para el comportamiento del coche
    public float anguloGiro;
    public float velocidad;

	// Use this for initialization
	void Start () {

        //Buscamos objetos de tipo coche. Al final de la llamada .gameObject, lo devolvemos como un gam eobject y no como un componente.
        cocheGO = GameObject.FindObjectOfType<Coche>().gameObject;

        motorDeCarreteraGO = GameObject.Find("MotorDeCarretera");
        motorDeCarreteraScript = motorDeCarreteraGO.GetComponent<MotorDeCarretera>();


		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float giroenZ;
        giroenZ = (-anguloGiro);
/*
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            Touch touch = Input.GetTouch(0);

            float middle = Screen.width / 2;

            //Check if it is left or right?
            if (touch.position.x < middle)
            {
                cocheGO.transform.Translate(Vector2.left * velocidad * Time.deltaTime);
                cocheGO.transform.rotation = Quaternion.Euler(new Vector3(0, 0, giroenZ));

            }
            else if (touch.position.y > middle)
            {
                cocheGO.transform.Translate(-Vector2.right * velocidad * Time.deltaTime);
                cocheGO.transform.rotation = Quaternion.Euler(new Vector3(0, 0, giroenZ));
            }

        }

        */


        if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                float middle = Screen.width / 2;


                if (touch.position.x < middle && touch.phase == TouchPhase.Stationary)
                {
                    transform.Translate(Vector2.left * velocidad * Time.deltaTime);
                }
                else if (touch.position.x > middle && touch.phase == TouchPhase.Stationary)
                {
                    transform.Translate(Vector2.right * velocidad * Time.deltaTime);
                }
            }

        







        //tenemos que definir como vamos a mover el coche
        //empezaremos a trabajar con la clase Input (tactiles, teclados, etc..)
        //Solo le movemos en X,Y -> Axis sirven para configurar todas las entradas de botones.




        //el giro lo vamos a trabajr con el coche
        //antes que nada vamos a declarar float GiroEnZ. Siempre vamos a estar girando el coche en el eje z.
        //Esto nos va a devolver un valor en decimales, pero esto hay que convertirlo en un valor de angulos

        //A la transform rotation le mandamos un quaternion eurler con el giro en Z.


    }
}
