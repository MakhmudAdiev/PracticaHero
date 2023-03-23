using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

[CreateAssetMenu(fileName = "Animal", menuName = "ScriptableObjects/Creature")]
public class CreateScriptableObject : ScriptableObject
{
    public TextAsset JsonAnimal;
    public List<Animal> weapon;

    [ContextMenu("UpdateInfo")]
    public void UpdateInfo()
    {
        weapon = JsonConvert.DeserializeObject<List<Animal>>(JsonAnimal.text);
    }
}