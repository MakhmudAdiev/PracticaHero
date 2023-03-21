using System;
using UnityEngine;

[Serializable]
public class Weapon : Element, Ident
{
    public int id { get; set; }

  

    public string name;
    public int damage;
    public int bodyPart;

}