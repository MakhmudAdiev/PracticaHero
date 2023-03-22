using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public  class Element : Creature
{



    private bool _isSelected = false;

    public bool isSelected { 
        
        
        get { return _isSelected; }
        
        
        set {


            if (value == true)
            {


                _isSelected = true;
                transform.localPosition = Vector3.one * 2;


            }


            else
            {

                _isSelected = false;
                transform.localPosition = Vector3.one;
            
            
            
            
            
            }
        
        }
    
    
    
    }






    


    public void SelectItem() //выделяем выбранный элемент на доске
    {
 

      
            foreach (var elem in _elements)
            {
                elem.Value.isSelected = false;
         
            }


            isSelected = true;

  



 
      


    }


}
