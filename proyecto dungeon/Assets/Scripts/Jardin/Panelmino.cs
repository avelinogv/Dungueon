using UnityEngine;
using System.Collections;

public class Panelmino : MonoBehaviour
{
    public scripcontrojardin per;
    // Use this for initialization
    void Start()
    {
        per = GameObject.Find("controladorpergaminojar").GetComponent<scripcontrojardin>();
    }

    public void OnTriggerEnter()
    {
        per.activo();
        per.texto.text = "El minotauro fue encontrado arrasando ciudades enteras, el pueblo en su desesperación fue a buscar a los guerreros más valientes para poder capturarlo y atraparlo. Ahora pasa sus días encerrado en esta jaula ";


    }

    public void OnTriggerExit()
    {
        per.desactivo();
        //DestroyObject(gameObject);


    }
}