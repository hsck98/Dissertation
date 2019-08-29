using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootingSystem : MonoBehaviour
{
    public int damage;
    public float range;
    public float speed;
    public float fireRate;
    private float fireTimer = 0.0f;
    public GameObject projectile;
    public GameObject projectileSpawnPoint;
    public GameObject target;

    //this list will keep track of the projectiles that are being directed towards one specific player, everytime a new player is targeted, the list is emptied out
    List<GameObject> previousProjectiles = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        //if there is no target, then do nothing
        if (!target)
        {
            return;
        }

        //if there is a target, start the timer for the fire rate because we are going to start shooting
        fireTimer += Time.deltaTime;

        //if the timer is greater than the fireRate (aka the fire rate is just a time value for the next time the turret can fire
        if (fireTimer >= fireRate)
        {
            //calculate the distance between the target and this turret
            float distance = Vector3.Distance(target.transform.position, transform.position);

            //if the distance is greater than the range of the turret, then do nothing, otherwise spawn projectiles and restart the fire timer
            if (distance < range)
            {
                SpawnProjectiles();

                fireTimer = 0.0f;
            }
        }
    }

    //this function spawns projectiles
    void SpawnProjectiles()
    {
        //is a projectile out there targeting a player? if there is already then do nothing
        if (!projectile)
        {
            return;
        }

        //else clear the list of previous projectiles
        previousProjectiles.Clear();

        //and instantiate a tracking projectile at the turret's projectile spawn point
        GameObject proj = Instantiate(projectile, projectileSpawnPoint.transform.position, Quaternion.Euler(projectileSpawnPoint.transform.forward)) as GameObject;
        proj.GetComponent<BaseProjectile>().FireProjectile(projectileSpawnPoint, target, damage, fireRate, speed);

        //now add the projectile to the list
        previousProjectiles.Add(proj);
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    //this function removes previous projectiles, note that this function is not called in anywhere in our scripts but has been implemented considering possible future utilities.
    void RemovePreviousProjectiles()
    {
        //whilst there are still previous projectiles following a target, keep removing them 1 by 1.
        while (previousProjectiles.Count > 0)
        {
            Destroy(previousProjectiles[0]);
            previousProjectiles.RemoveAt(0);
        }
    }
}
