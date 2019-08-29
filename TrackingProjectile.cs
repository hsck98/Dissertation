using UnityEngine;
using System.Collections;
using UnityEditor;

public class TrackingProjectile : BaseProjectile
{
    GameObject target;
    GameObject launcher;
    [SerializeField] float speed;
    [SerializeField] int damage;

    Vector3 previousPosition;

    // Update is called once per frame
    void Update()
    {
        //if there is a target 
        if (target)
        {
            //update the previous position of the target to the new position of the target
            previousPosition = target.transform.position;
        }
        //if there is no target
        else
        {
            //check if the position of the projectile is the same as the previous position of the target in which case it should be destroyed as it has reached its destination
            if (transform.position == previousPosition)
            {
                Destroy(gameObject);
            }
        }

        //continuously change the position of the tracking projectile to move towards the target's position at a constant speed
        transform.position = Vector3.MoveTowards(transform.position, previousPosition, speed * Time.deltaTime);
    }

    public override void FireProjectile(GameObject launcher, GameObject target, int damage, float attackSpeed, float speed)
    {
        if (target)
        {
            this.target = target;
            previousPosition = target.transform.position;
            this.launcher = launcher;
            this.damage = damage;
            this.speed = speed;
        }
    }

    //check if the projectile collides with any other objects
    void OnCollisionEnter(Collision other)
    {
        //only destroy the projectile if the collision occurs with the target, and also lower the target's health
        if (other.gameObject == target)
        {
            other.gameObject.transform.GetComponent<HealthSystem>().Damage(damage);
            Destroy(gameObject);
        }
    }
}