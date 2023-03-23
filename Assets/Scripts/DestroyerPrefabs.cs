using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DestroyerPrefabs : MonoBehaviour
{
    
    bool isTouched = true;



    public void CheckCTouch(Creature cr)
    {
        print(cr.Heroes[0].CountWearedElem+" ds");

        isTouched = !isTouched;

        if (isTouched)
        {

            Destroy(gameObject);
            cr.Heroes[0].CountWearedElem -= 1;

        }

        else { cr.Heroes[0].CountWearedElem += 1; }

    } 

}
 


