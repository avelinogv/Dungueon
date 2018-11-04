using UnityEngine;
using System.Collections;

public class scripi : MonoBehaviour {

    float DistanciaMax = 9f;
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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
}
