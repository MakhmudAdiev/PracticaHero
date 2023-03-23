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

    public Dictionary<string,GameObject> _elementsPrefabs;



    private void Start()
    {
        _elements = GameObject.FindObjectsOfType<Element>().ToDictionary(elem => elem.name, value => value);

 

        AddButtonListeners();
      
        Heroes = JsonConvert.DeserializeObject<List<Hero>>(JsonHero.text);
        Weapons = JsonConvert.DeserializeObject<List<WeaponI>>(JsonWeapon.text);
        Animals = JsonConvert.DeserializeObject<List<Animal>>(JsonAnimal.text);
        Potions = JsonConvert.DeserializeObject<List<PotionI>>(JsonPotion.text);
        Forces = JsonConvert.DeserializeObject<List<superForce>>(JsonForce.text);

        AddInfo();
    }

    public void AddButtonListeners()
    {

        foreach (var elem in _elements) //��������  �� ������� ����� ������

        {
            var Button = elem.Value.transform.GetComponent<Button>();

            Button.onClick.AddListener(elem.Value.SelectItem);
        }

    }

    public void CreateThings(GameObject PositionBone,GameObject elemPref)
    {

        Instantiate(elemPref, PositionBone.transform.position + new Vector3(0,0,-1), Quaternion.identity);


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

 

[Serializable]
public class Hero :Ident
{

    public int id { get; set; }
 
    public string name;
    public int hp;
    public int damage;
    public int armor;

    [NonReorderable] public int MaxCountElements = 0;

    [NonSerialized] public short CountWearedElem = 0;

    [HideInInspector] public int[] weaponId;
    [HideInInspector] public int[] animalId;
    [HideInInspector] public int[] potionId;

    public List<WeaponI> weapon = new List<WeaponI>();
    public List<PotionI> potion = new List<PotionI>();
    public List<Animal> animal = new List<Animal>();


    public Dictionary< string,GameObject> Skelet;

    public Hero()
    {

        Skelet = GameObject.FindGameObjectsWithTag("Body").ToDictionary((key) => key.name, (value) => value);

        

    }



    public void GetArmor(GameObject PositionBone, Element SelectedElem = null, Creature Main = null)
    {




 

        var _elementsPrefabs = Resources.LoadAll<GameObject>("Graphics/Elements").ToDictionary(pref => pref.name, value => value);



        if (!((PositionBone.name.StartsWith("Foot")) && ((SelectedElem.name == "Potion")))) // для ног
        {
            Debug.Log("Нельзя на ногу одеть что то кроме зелья!");

        }




        else if(CountWearedElem<MaxCountElements)
        {

            Main.CreateThings(PositionBone, _elementsPrefabs[SelectedElem.name]);
           


        }



        if (PositionBone.name.StartsWith("Head"))
        {
            Debug.Log("На лицо нельзя ничего надевать!");

        }


        else if (PositionBone.name.StartsWith("Arm") && CountWearedElem < MaxCountElements)
        {



            Main.CreateThings(PositionBone, _elementsPrefabs[SelectedElem.name]);
        


        }




    }

    

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


