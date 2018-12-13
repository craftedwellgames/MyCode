using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass {



    public string theName;

    public float baseHp;
    public float currHp;

    public float BaseMp;
    public float currMp;

    public float baseAtk;
    public float currAtk;

    public float baseDef;
    public float currDef;

    public enum Type
    {
        GRASS,
        FIRE,
        WATER,
        ELECTRIC
    }
    public enum Rarity
    {
        COMMON,
        UNCOMMON,
        RARE,
        SUPERRARE
    }
    public List<BaseAttack> attacks = new List<BaseAttack>();


}
