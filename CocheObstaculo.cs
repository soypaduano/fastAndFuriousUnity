using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheObstaculo : MonoBehaviour {

  

    public Cronometro cronometroScript;
    public GameObject cronometroGO;


    public AudioFX AudioFX;
    public GameObject AudioGo;

 


    void Start()
    {
        //Buscamos los componentes
        cronometroGO = FindObjectOfType<Cronometro>().gameObject;
        cronometroScript = cronometroGO.GetComponent<Cronometro>();

        //Lo que hacemos es buscar aquellos objetos que tengan el componente <XX> y lo "casteamos" a tipo GameObject
        AudioGo = FindObjectOfType<AudioFX>().gameObject;
        AudioFX = AudioGo.GetComponent<AudioFX>();
    }

    //Cuando choca con el bus
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Comprobamos que el objeto con el que choca tiene el componente Coche. (Que sea distinto de null, es decir, que lo tenga)
        if (collision.GetComponent<Coche>() != null)
        {
            //hacemos una serie de cosas cada vez que chocan.
            Destroy(this.gameObject);
            AudioFX.reproducirChoque();
            cronometroScript.tiempo = cronometroScript.tiempo - 20;
            Debug.Log("Si sucede brotha");
        }
    }




}
