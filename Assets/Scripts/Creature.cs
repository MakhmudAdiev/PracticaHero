using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Creature : MonoBehaviour
{
    public TextAsset JsonHero;
    public TextAsset JsonWeapon;
    public TextAsset JsonAnimal;
    public TextAsset JsonPotion;

    public List<Hero> Heroes;

    public List<Element> _elements = new List <Element>();

    private void Start()
    {
        AddButtonListeners();

        //Heroes = JsonConvert.DeserializeObject<List<Hero>>(JsonHero.text);
        Heroes = JsonConvert.DeserializeObject<List<Hero>>(JsonHero.text);
        List<WeaponI> Weapons = JsonConvert.DeserializeObject<List<WeaponI>>(JsonWeapon.text);
        List<Animal> Animals = JsonConvert.DeserializeObject<List<Animal>>(JsonAnimal.text);
        List<PotionI> Potions = JsonConvert.DeserializeObject<List<PotionI>>(JsonPotion.text);

        int size = 0;
        for (int i = 0; i < Heroes.Count; i++)
        {
            for (int j = 0; j < Weapons.Count; j++)
            {
                if (Weapons[j].id == Heroes[i].weaponId[size])
                {
                    Heroes[i].weapon.Add(Weapons[j]);

                    size++;

                    if (size >= Heroes[i].weaponId.Length)
                        size = 0;
                }
            }
        }

        for (int i = 0; i < Heroes.Count; i++)
        {
            for (int j = 0; j < Animals.Count; j++)
            {
                if (Animals[j].id == Heroes[i].animalId[size])
                {
                    Heroes[i].animal.Add(Animals[j]);

                    size++;

                    if (size >= Heroes[i].animalId.Length)
                        size = 0;
                }
            }
        }

    }


    public void AddButtonListeners()
    {
        foreach (var elem in _elements) //��������  �� ������� ����� ������
        {
            var Button = elem.transform.GetComponent<Button>();

            Button.onClick.AddListener(elem.SelectItem);



        }

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
    [HideInInspector] public int[] weaponId;
    [HideInInspector] public int[] animalId;
    //[HideInInspector] public int[] animald;

    public List<WeaponI> weapon = new List<WeaponI>();
    //public Potion[] potion;
    public List<Animal> animal = new List<Animal>();
}

[Serializable]
public class WeaponI : Ident
{
    public int id { get; set; }

    public string name;
    public int damage;
    public int bodyPart;
}

[Serializable]
public class PotionI : Ident
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


