using System;
using UnityEngine;

[Serializable]
public class Weapon : Element, Ident
{
    public int id { get; set; }

    protected override bool isSelected { get; set; } = false;

    public string name;
    public int damage;
    public int bodyPart;

}