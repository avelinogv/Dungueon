using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class animacion : MonoBehaviour {
    public Animation animo;
    public Dropdown drop;
    public int i;
    // Use this for initialization
    void Start () {

      

	}



    // Update is called once per frame
    void Update () {

       
       
     
        switch (drop.value)
        {
            case 0: animo.Play("stand");
                break;


            case 1:
                animo.Play("idle");
                break;
            case 2:
                animo.Play("ready");
                break;
            case 3:
                animo.Play("walk");
                break;


            case 4:
                animo.Play("run");
                break;



            case 5:
                animo.Play("jump");
                break;
            case 6:
                animo.Play("attack 1");
                break;

            case 7:
                animo.Play("attack 2");
                break;
            case 8:
                animo.Play("attack 3");
                break;
       
            case 9:

                animo.Play("dead");
                break;
            case 10:

                animo.Play("climb");
                break;


            case 11:

                animo.Play("push");
                break;
        }
   
        

    }
}
