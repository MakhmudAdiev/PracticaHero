using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class CameraChoice : Element
{


    RaycastHit hitInfo;
    bool result;

    public Creature hero;

    
    private void Update()
    {


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        result = Physics.Raycast(ray, out hitInfo);
        if (result)
        {

            Debug.Log(hitInfo.transform.name);

        }


        if (Input.GetMouseButtonDown(0) && result)
        {

          Element elem =  hero._elements.First(predicate: (elem) => { return elem.Value.isSelected == true; }).ConvertTo<Element>();

          hero.Heroes[0].GetArmor(hitInfo.transform,SelectedElem:elem);
            
            
          
                
                
             

        
        }

    }
}
