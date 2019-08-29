using UnityEngine;
using System.Collections;

public class TrackingSystem : MonoBehaviour
{
    public float speed = 3.0f;

    public GameObject target;
    Vector3 previousPosition = Vector3.zero;
    Quaternion rotation;

    // Update is called once per frame
    void Update()
    {
        //if there is a target locked
        if (target)
        {
            //then check if the previous position of the target matches the new position of the target
            if (previousPosition != target.transform.position)
            {
                //if positions differ, update the previous position to the new one and calculate the rotation quaternion between the previous position of the target and the current position of the target
                previousPosition = target.transform.position;
                rotation = Quaternion.LookRotation(previousPosition - transform.position);
            }

            //if the current rotation of the turret is not the same as the rotation calculated
            if (transform.rotation != rotation)
            {
                //calculate the rotation in the y-axis i.e. sideways that the turret needs to do
                rotation.eulerAngles = new Vector3(0, rotation.eulerAngles.y, 0);
                //rotate the turret towards the calculated quaternion rotation gradually at a specific rate
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, speed * Time.deltaTime);
            }
        }
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
}
