using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour {

    public int Health = 5;
    [HideInInspector]
    public int curHealth;

    public Animator animator;

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

    public void RegainHealth(int regain = 1)
    {
        curHealth += regain;
        curHealth = Mathf.Clamp(curHealth, 0, Health);
    }
}
