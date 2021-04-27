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
        if (overcomings.Contains(Overcoming.InstantTreeCutting))
        {
            return 9000;
        }

        if (activeQuirks.Contains(Quirk.Weak))
        {
            return 0;
        }

        return baseAxeDamage;
    }

    public bool IsCarryingTheTree() => GameObject.FindWithTag("The Tree").transform.parent == transform;

    public bool HasEnoughWood() => wood >= woodRequiredForFire;

    public bool CanUseBonfire() => !activeQuirks.Contains(Quirk.CanNotUseBonfire);

    public float GetSpeed() => overcomings.Contains(Overcoming.DoubleSpeed) ? speed * 2 : speed;
}