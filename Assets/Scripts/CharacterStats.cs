using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterStats
{
    public int healthPoints = 100; //health value at the beginning of the battle
    public int strength = 10; //how much damage physical attacks do
    public int magic = 10; //how much damage magic attacks do
    public int dexterity = 10; //how likely your attack is to hit 
    public int agility = 10; //how likely an enemy attack is to miss
    public int luck = 10; //how likely an attack is to critical hit
}
