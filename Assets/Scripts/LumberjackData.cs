using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackData : MonoBehaviour
{
    public int forestDepth = 0;
    public float speed = 4;
    public float rotationSpeed = 10;
    public int baseAxeDamage = 1;
    public int panic = 1;
    public int panicLimit = 100;
    public int basePanicRate = 0;
    public bool isRelaxing;
    public int relaxingRate = 4;
    public int wood = 0;
    public int woodRequiredForFire = 10;
    public List<Overcoming> overcomings;
    public List<Quirk> quirks;
    public List<Quirk> activeQuirks;

    public int GetPanicRate() => isRelaxing ? -relaxingRate : basePanicRate + forestDepth;

    public int GetAxeDamage()
    {
        return overcomings.Contains(Overcoming.InstantTreeCutting) ? 9000 : baseAxeDamage;
    }

    public bool IsCarryingTheTree() => GameObject.FindWithTag("The Tree").transform.parent == transform;

    public bool HasEnoughWood() => wood >= woodRequiredForFire;
}