using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField] float speed;
    [SerializeField] float timeToLive;
    [SerializeField] int damage;

    void Start()
    {
        //destroy the projectile once its time to live runs out
        Destroy(gameObject, timeToLive);
    }

    void Update()
    {
        //recalculate and change the projectile's position on a straight line
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        //check if the collision occured with a turret
        if (other.gameObject.CompareTag("TurretHitbox"))
        {
          other.gameObject.transform.parent.gameObject.GetComponent<HealthSystem>().Damage(damage);
        }
        // or if the collision occured with an enemy
        else if (other.gameObject.CompareTag("Enemies"))
        {
            other.gameObject.transform.GetComponent<HealthSystem>().Damage(damage);
        }
        //the if statement is only necessary because for the turret we actually have to check if the projectile hit the hitbox instead, whilst the there is no hitbox implemented for the characters
        //this means that turrets have an extra layer thus the parent property

        //destroy the projectile after collision
        Destroy(gameObject);
    }
}
