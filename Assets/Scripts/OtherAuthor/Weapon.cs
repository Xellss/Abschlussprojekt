using UnityEngine;
using System.Collections;

public enum Weapontypes
{
    None,
    Melee,
    Ranged
}

public class Weapon : MonoBehaviour
{
    [SerializeField]
    public Weapontypes Weapontype = Weapontypes.None;

    public int DamagePoints;
    public int Range;
    public float AttackSpeed;
}
