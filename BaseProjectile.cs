using UnityEngine;
using System.Collections;

public abstract class BaseProjectile : MonoBehaviour
{
    public float projectileSpeed = 1000.0f;

    public abstract void FireProjectile(GameObject spawnPoint, GameObject target, int damage, float attackSpeed, float speed);
}
