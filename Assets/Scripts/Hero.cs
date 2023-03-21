using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Body
{
    head,
    hip,
    leftHand,
    rightHand,
    leftFoot,
    rightFoot
}

public class Hero : Ident 
{
    public int id { get; set; }


    public string name;
    public int   hp;
    public int damage;
    public int armor;

    public readonly Body body;
    public Weapon[] weapon;
    public Potion[] potion;
    public Animal[] animal;
}

[Serializable]
public class Weapon : Ident
{
    public int id { get; set; }

    public string name;
    public int damage;
    public int bodyPart;
}

[Serializable]
public class Potion : Ident
{
    public int id { get; set; }

    public int hpDelta;
}

[Serializable]
public class Animal : Ident
{
    public int id { get; set; }

    public string name;
    public int hp;
    public int damage;
    public int armor;
    public superForce[] force;

    public int level;
}

[Serializable]
public class superForce : Ident
{
    public int id { get; set; }
    public string name;
    public string damage;
}