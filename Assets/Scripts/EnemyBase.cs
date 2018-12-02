using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Attacks
{
    public string name;
    public int Damage;
}

public class EnemyBase : MonoBehaviour {

    public int Health = 5;
    [HideInInspector]
    public int curHealth;

    public Animator animator;

    public List<Attacks> attacks = new List<Attacks>(2);

    private void Reset()
    {
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
        curHealth = Health;
	}

    public void SetMaxHealth(int NewMax)
    {
        Health = NewMax;
    }

    public void SetCurHealth(int newHealth)
    {
        curHealth = newHealth;
    }

    public Attacks GetAttacks()
    {
        return attacks[Random.Range(0, attacks.Count)];
    }
}
