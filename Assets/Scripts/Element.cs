using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public  class Element : Creature
{


    protected virtual bool isSelected { get; set; } = false;

    


    public void SelectItem() //выдел€ем выбранный элемент на доске
    {

        isSelected = true;

        Debug.Log(" нопка была нажата!");


    }


}
