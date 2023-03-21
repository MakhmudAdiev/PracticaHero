using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public  class Element : Creature
{



    public bool isSelected = false;

    


    public void SelectItem() //выделяем выбранный элемент на доске
    {
 

      
            foreach (var elem in _elements)
            {
                elem.Value.isSelected = false;

                elem.Value.transform.localScale = Vector3.one;

                Debug.Log("Уменьшение");
            }


            isSelected = true;

            transform.localScale = Vector3.one * 2;




        Debug.Log("Кнопка была нажата!  Статус :"+isSelected+" "+_elements.Count());
      


    }


}
