using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Potion : Element, Ident
{
    public int id { get; set; }

   

    public int hpDelta;
}