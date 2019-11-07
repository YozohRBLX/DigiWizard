﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingSpell : MonoBehaviour {
    public MagicSystem magicSystem;
    float timeSinceLastHit;
    public float shootRange;
    private void Update()
    {
        //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitObj;
        magicSystem.RamDepletion(1);
        if (Physics.Raycast(ray, out hitObj, shootRange))
        {
            Vector3 desitnation = transform.position - hitObj.point;
            Quaternion rotationDestination = Quaternion.LookRotation(-desitnation);
            EnemyHealthAndDeathManager enemyHealth = hitObj.collider.GetComponentInParent<EnemyHealthAndDeathManager>(); // getting script from the object hit
            //enemyMonster = hitObj.collider.GetComponent<BaseAI>();

            if (enemyHealth != null) // checking to make sure the hit object is an enemy type with script "EnemyHealthAndDamageManager" attached
            {
                magicSystem.ElementDamageManager("lighting", enemyHealth); // if "EnemyHealthAndDamageManager" exists, then pass in the element
            }
        }
    }
    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.GetComponentInParent<EnemyHealthAndDeathManager>())
    //    {
    //        col.gameObject.GetComponentInParent<EnemyHealthAndDeathManager>().DamageEnemy(3);
    //    }
    //}
}