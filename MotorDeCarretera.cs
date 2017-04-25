using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorDeCarretera : MonoBehaviour
{

    //Objeto que va a guardar las calles que no estemos utilizando
    public GameObject contenedorGO;
    public GameObject mCamGO; //Necesito el game object para acceder al componente camara.
    public Camera mComponenteGO; //Este va ser el componente que vamos a trabajar


    //Array de las calles que vamos a guardar.
    public GameObject[] ContenedorCallesArray;

    //medida pantalla
    public Vector3 medidaLimitePantalla;

    //Variable que va a manejar la velocidad.
    public float speed;


    //Booleanos para controlar las variables de juego.
    public bool juegoTerminado;
    public bool juegoIniciado;
    public bool salioDePantalla;

    int contadorCalles = 0;
    //Este sera mi numro de selector dentro del array de contenedor calle.
    int numeroSelectorCalles = 0;

    //Referencias de la calles
    public GameObject calleAnterior;
    public GameObject calleNueva;


    //Medida de la calle
    float calleSize = 0F;




    //Algunos atributos para el game over 
    public GameObject cocheGO;
    public GameObject audioFXGO;
    public AudioFX audioFXScript;
    public GameObject bgFinalGo;
    public GameObject maxScore;



    //Metodo Start
    void Start()
    {
        //Nos guardamos en el contenedor, el objeto " Contenedor Calles".
        //Buscamos en la escena por String
        contenedorGO = GameObject.Find("ContenedorCalles");     //Este objeto tendrá dentro de el todas las calles.
        inicioJuego();
    }


    //Metodo Update
    void Update()
    {
        if (juegoIniciado == true && juegoTerminado == false)
        {
            //Manejamos todo por segundos. Esto es el movimiento
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            //Queremos comprobar cuando la pantalla sale de la pantalla:
            if (calleAnterior.transform.position.y + calleSize < medidaLimitePantalla.y && salioDePantalla == false)
            {
                //No vuelve a entrar en este condicional
                salioDePantalla = true;
                destruyoCalles();
            }
        }

       
    }

    void destruyoCalles()
    {
        //destruimos la calle que acaba de salir de la pantalla.
        Destroy(calleAnterior);
        calleSize = 0; //La destruimos porque ya no mide nada...
        calleAnterior = null; //Puede que se haya quedado algo, nos aseguramos que se borre todo.
        crearCalles(); //Hacemos que el ciclo se repita una y otra vez.
    }


    void medirPantalla() {
        //queremos saber la medida de pantalla en Y
        //tenemos que acceder a la camara, que es la que nos defina el limite de la pantalla
        //la medida sera el 0 y de Y. 
        medidaLimitePantalla = new Vector3(0, mComponenteGO.ScreenToWorldPoint(new Vector3(0, 0, 0)).y - 0.5f, 0);
    }


    //Metodo que engloba todas las funciones de nuestro inicio de juego.
    void inicioJuego()
    {
        //buscamos el componente camara para mas adelante medir su tamaño
        //primero buscamos el objeto
        mCamGO = GameObject.Find("MainCamera");
        mComponenteGO = mCamGO.GetComponent<Camera>();

        //Cogemos todas las referencias que acabamos de declarar para el Game Over
        cocheGO = GameObject.FindObjectOfType<Coche>().gameObject;
        
        audioFXGO = GameObject.Find("AudioFX");
        audioFXScript = audioFXGO.GetComponent<AudioFX>();

        bgFinalGo = GameObject.Find("Panel");
        bgFinalGo.SetActive(false);

       

        VelocidadMotorCarretera();
        medirPantalla();
        buscoCalles();
       
    }


    //Metodo que indica que el juego ha terminado

     public void JuegoTerminadoEstados()
    {
        //Controlamos todos los estados del juego
        //Apagar musica coche -> Accedemos al Audio Source del componente del coche
        cocheGO.GetComponent<AudioSource>().Stop();
        //Musica de fondo
        audioFXScript.reproducirMusica();
        //activar el panel
        bgFinalGo.SetActive(true);

    }


    //Metodo que inicializa la velocidad de nuestro juego.
    void VelocidadMotorCarretera()
    {
        speed = 12f;
    }

    //Metodo que busca las calles de todo nuestro videojuego.
    void buscoCalles()
    {

        ContenedorCallesArray = GameObject.FindGameObjectsWithTag("Calle");

        //En un bucle FOR, recorremos todos los objetos que hayamos encontrado anteriormente.
        for (int i = 0; i < ContenedorCallesArray.Length; i++)
        {

            //Lo que hacemos aqui es decirle es que ste game object que acaba de encontrar que lo haga hijo de la transform de contenedor calle
            ContenedorCallesArray[i].gameObject.transform.parent = contenedorGO.transform;

            //Los desactivamos
            ContenedorCallesArray[i].gameObject.SetActive(false);

            //Les cambiamos el nombre
            ContenedorCallesArray[i].gameObject.name = "CalleOFF_" + i;
        }

        //Una vez buscamos, creamos la calle.
        crearCalles();

    }

    void crearCalles()
    {
        //Sumamos 1 al contador
        contadorCalles++;

        //Asignamos el numero selector mediante un range del array. Será un numero entre 0 y el tamaño del array. 
        //Lo hacemos así ya que es escalable, nunca sabremos cual será el tamaño del array
        numeroSelectorCalles = Random.Range(0, ContenedorCallesArray.Length);

        //Creamos un objeto Calle
        GameObject Calle = Instantiate(ContenedorCallesArray[numeroSelectorCalles]);
        //Lo ponemos en activo
        Calle.SetActive(true);
        //Le cambiamos el nombre
        Calle.name = "Calle" + contadorCalles;
        //Y la hacemos hija de el motor de la carretera
        Calle.transform.parent = gameObject.transform;

        //Y la posicionamos
        posicionoCalle();
    }



    //Funcion para posicionar la calle
    void posicionoCalle()
    {
        //Para posicionar la calle, primero debemos tener almacenado en algun lugar, la calle anterior y la calle nueva que acabo de crear.

        calleAnterior = GameObject.Find("Calle" + (contadorCalles - 1));

        

        calleNueva = GameObject.Find("Calle" + contadorCalles);

        //Para posicionar, debemos saber cuanto mide la calle anterior. Como lo vamos a saber?
        //Tenemos que recorrer cuantas pieza tiene.Tenemos que saber su tamaño en Y

        //Llamamos al metodo que mide
        MidoCalle();
        //esta es la linea donde vamos a poner 
        //calle nueva, va a tener una posicion de.... 3 vectores, x y z 
        //en x vamos a mantener la medidas
        //pero en y, vamos a hacer 
        print("La posicionamos en... " + calleSize);
        calleNueva.transform.position = new Vector3(calleAnterior.transform.position.x, calleAnterior.transform.position.y + calleSize, 0);
        salioDePantalla = false;

    }


    void MidoCalle()
    {
        for (int i = 0; i < calleAnterior.transform.childCount; i++)
        {
            if (calleAnterior.transform.GetChild(i).gameObject.GetComponent<Pieza>() != null)
            {
                float tamañoPieza = calleAnterior.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
                print("El tamáño de cada pieza es: " + tamañoPieza);
                calleSize = calleSize + tamañoPieza;
                print("El tamaño de la calle es.. " + calleSize);
            }
        }
    }
}








