using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class CameraChoice: Creature
{


    RaycastHit hitInfo;
    bool result;

    private Creature creature;

    
    private void Update()
    {


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        result = Physics.Raycast(ray, out hitInfo);

       


        if (Input.GetMouseButtonDown(0) && result)
        {
            creature = GameObject.FindGameObjectWithTag("Body").GetComponent<Creature>();

            print(creature.Heroes.Count());

            if (hitInfo.transform?.GetComponent<DestroyerPrefabs>()!=null)
            hitInfo.transform?.GetComponent<DestroyerPrefabs>().CheckCTouch(creature); // удаляем префаб если нажали 2 раза

            Element elem =  creature._elements.First(predicate: (elem) => { return elem.Value.isSelected == true; }).Value;

       
            if(creature.Heroes[0].Skelet.ContainsKey(hitInfo.transform.name))
          creature.Heroes[0].GetArmor(creature.Heroes[0].Skelet[hitInfo.transform.name],SelectedElem:elem,Main:creature);
            
            
          
                
                
             

        
        }

    }
}
