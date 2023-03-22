using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public TextAsset JsonForce;

    public List<Hero> Heroes;
    private List<WeaponI> Weapons;
    private List<Animal> Animals;
    private List<PotionI> Potions;
    private List<superForce> Forces;

    public Dictionary<string, Element> _elements;

    public CreateScriptableObject scrObj;

    private void Start()
    {
        scrObj = FindObjectOfType<CreateScriptableObject>();


        _elements = GameObject.FindObjectsOfType<Element>().ToDictionary(elem => elem.name, value => value); 

        AddButtonListeners();

        Heroes = JsonConvert.DeserializeObject<List<Hero>>(JsonHero.text);
        Weapons = JsonConvert.DeserializeObject<List<WeaponI>>(JsonWeapon.text);
        Animals = JsonConvert.DeserializeObject<List<Animal>>(JsonAnimal.text);
        Potions = JsonConvert.DeserializeObject<List<PotionI>>(JsonPotion.text);
        Forces = JsonConvert.DeserializeObject<List<superForce>>(JsonForce.text);

        AddInfo();
        scrObj.hero = Heroes;

    }

    public void AddButtonListeners()
    {
 
        foreach (var elem in _elements) //��������  �� ������� ����� ������
 
        {
            var Button = elem.Value.transform.GetComponent<Button>();

            Button.onClick.AddListener(elem.Value.SelectItem);
        }

    }

    public void AddInfo() 
    {
        //добавление информации о оружии
        int sizeWeapon = 0;
        for (int i = 0; i < Heroes.Count; i++)
        {
            for (int j = 0; j < Weapons.Count; j++)
            {
                if (Weapons[j].id == Heroes[i].weaponId[sizeWeapon])
                {
                    Heroes[i].weapon.Add(Weapons[j]);

                    sizeWeapon++;

                    if (sizeWeapon >= Heroes[i].weaponId.Length)
                        sizeWeapon = 0;
                }
            }
        }

        //добавление информации о животных
        int sizeAnimal = 0;
        for (int i = 0; i < Heroes.Count; i++)
        {
            for (int j = 0; j < Animals.Count; j++)
            {
                if (Animals[j].id == Heroes[i].animalId[sizeAnimal])
                {
                    Heroes[i].animal.Add(Animals[j]);

                    sizeAnimal++;

                    if (sizeAnimal >= Heroes[i].animalId.Length)
                        sizeAnimal = 0;
                }
            }
        }

        //добавление информации о зельях
        int sizePotion = 0;
        for (int i = 0; i < Heroes.Count; i++)
        {
            for (int j = 0; j < Potions.Count; j++)
            {
                if (Potions[j].id == Heroes[i].potionId[sizePotion])
                {
                    Heroes[i].potion.Add(Potions[j]);

                    sizePotion++;

                    if (sizePotion >= Heroes[i].potionId.Length)
                        sizePotion = 0;
                }
            }
        }

        //добавление информации о способностях
        int sizeForce = 0;
        for (int i = 0; i < Animals.Count; i++)
        {
            for (int j = 0; j < Forces.Count; j++)
            {
                if (Forces[j].id == Animals[i].forceId[sizeForce])
                {
                    Animals[i].force.Add(Forces[j]);

                    sizeForce++;

                    if (sizeForce >= Animals[i].forceId.Length)
                        sizeForce = 0;
                }
            }
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
    [HideInInspector] public int[] potionId;

    public List<WeaponI> weapon = new List<WeaponI>();
    public List<PotionI> potion = new List<PotionI>();
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

    public string name;
    public string performanceIncrease; 
    public int value;
}

[Serializable]
public class Animal : Ident
{
    public int id { get; set; }

    public string name;
    public int hp;
    public int damage;
    public int armor;
    public int level;

    [HideInInspector] public int[] forceId;
    public List<superForce> force = new List<superForce>();

}

[Serializable]
public class superForce : Ident
{
    public int id { get; set; }

    public string name;
    public int damage;
}


