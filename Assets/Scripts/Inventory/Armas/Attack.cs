﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    private Animator anim;
    private int damage;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnimation(AnimationClip clip)
    {
        anim.Play(clip.name);
    }

    public void SetWeapon(int damageValue)
    {
        damage = damageValue;
        Debug.Log(damageValue);
    }

    public int GetDamage()
    {
        return damage;
    }
}
