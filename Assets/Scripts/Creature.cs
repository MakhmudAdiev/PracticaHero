using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public TextAsset JsonHero;
    public TextAsset JsonWeapon;
    public  List<Hero> Heroes;

    private void Start()
    {
        Heroes = JsonConvert.DeserializeObject<List<Hero>>(JsonHero.text);
    }
}

public enum Body
{
    head,
    torso,
    leftHand,
    rightHand,
    leftFoot,
    rightFoot
}

[Serializable]
public class Hero : Ident
{
    public int id { get; set; }


    public string name;
    public int hp;
    public int damage;
    public int armor;

    //public Body body;
    public int[] weapon;
    //public Potion[] potion;
    //public Animal[] animal;
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