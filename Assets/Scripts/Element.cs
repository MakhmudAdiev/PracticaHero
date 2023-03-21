using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public  class Element : Creature
{


    protected virtual bool isSelected { get; set; } = false;

    


    public void SelectItem() //выделяем выбранный элемент на доске
    {

       
        if (_elements.Any((elem) => {  return elem.isSelected == true; }) == true) // если  одного выделенного элемента, тогда выделяем тот,который нажат
        {

            foreach (var elem in _elements)
            {
                elem.isSelected = false;
            }


            isSelected = true;

        }
 

      

        Debug.Log("Кнопка была нажата!");
      


    }


}
