using UnityEngine;
using System.Collections;

public class Objetivo : MonoBehaviour {

    float DistanciaMax = 6f;
    //Posicion del Objetivo, me refiero a la posicion del objetivo en el mapa(osea, el game object vacio que hay debajo)
    public Transform Pos_Objetivo;
    //Posicion del Pivote del que señala al Objetivo, Me refiero al pivote que existe debajo del personaje encargado de señalar al objetivo
    public Transform Pos_Pivote_objetivo;
    //Posicion maxima, me refiero al hijo del pivote, representa la posicion mas lejana.
    public Transform Pos_Max_Objetivo;
    //Posicion del Jugador en el Mapa
    public Transform Pos_Player_Map;
    // Posicion del marcador
    public Transform Marcador_Objetivo;

    public Transform Pos_segun_objetivomapa;
    public Transform marcador_puerta;

    public GameObject primerObjetivo;
    public GameObject Segundo_oB;
    public bool primerito = false;
  
    public Resume Scripresume;

    // Use this for initialization
    void Start()
    {
        primerObjetivo = GameObject.Find("Objetivo_uno");
        primerObjetivo.SetActive(false);
        Segundo_oB = GameObject.Find("Objetivo_2");
        Segundo_oB.SetActive(false);
        Scripresume = GameObject.Find("Manageguardado").GetComponent<Resume>();

    }

    // Update is called once per frame
    void Update()
    {

        if(primerito&&Scripresume.primerapuerta==false) primer_objetivo();
        if (Scripresume.segundo_objet==true)
        {
            primerObjetivo.SetActive(false);
            Segundo_oB.SetActive(true);
            segundo_objetivo();
        }

    }

public void primer_objetivo()
    {
        primerObjetivo.SetActive(true);

        Pos_Pivote_objetivo.LookAt(new Vector3(Pos_Objetivo.position.x, Pos_Pivote_objetivo.position.y, Pos_Objetivo.position.z));

        Pos_Pivote_objetivo.position = Pos_Player_Map.position;




        float dist = Vector3.Distance(Pos_Pivote_objetivo.position, Pos_Objetivo.transform.position);

        if (dist > DistanciaMax)
        {

            Marcador_Objetivo.position = Pos_Max_Objetivo.position;

        }
        else
        {

            Marcador_Objetivo.position = Pos_Objetivo.position;

        }



    }


   public void segundo_objetivo()
    {

        Pos_Pivote_objetivo.LookAt(new Vector3(Pos_segun_objetivomapa.position.x, Pos_Pivote_objetivo.position.y, Pos_segun_objetivomapa.position.z));

        Pos_Pivote_objetivo.position = Pos_Player_Map.position;




        float dist = Vector3.Distance(Pos_Pivote_objetivo.position, Pos_segun_objetivomapa.transform.position);

        if (dist > DistanciaMax)
        {

            marcador_puerta.position = Pos_Max_Objetivo.position;

        }
        else
        {

            marcador_puerta.position = Pos_segun_objetivomapa.position;

        }

    } 


}


