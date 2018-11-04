using UnityEngine;
using System.Collections;

public class posicion_nor : MonoBehaviour {

    public Transform Piv_Norte;
    public Transform Marca_Player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Piv_Norte.position = Marca_Player.position;

    }
}
