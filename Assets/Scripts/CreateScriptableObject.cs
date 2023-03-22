using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Creature", menuName = "ScriptableObjects/Creature")]
public class CreateScriptableObject : ScriptableObject
{
    public List<Hero> hero;
}