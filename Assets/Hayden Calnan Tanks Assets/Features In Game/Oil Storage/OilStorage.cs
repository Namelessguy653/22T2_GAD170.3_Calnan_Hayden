using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilStorage : MonoBehaviour
{
    public GameObject explosionPrefab; // the explosion we want to spawn in
    public LayerMask tankLayer; // the layer of the game object to effect
    public float maxDamage = 100f; // the maximum amount of damage that my Oil Storage can do.
    public float explosionForce = 1000f; // the amount of force this Oil Storage has
    public float maxOilstorageLifeTime = 2f; // how long should the Oil Storage should live for before it goes boom!
    public float explosionRadius = 5f; // how big is our explosion


    // is called when the trigger hits an object
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == transform)
        {
            // if we some how hit ourselves or another bullet
            // ignore it
            return;
        }
        else
        {
            Boom(); // we hit something go boom
        }
    }

    private void Boom()
    {
        //Used in the ShellExplosion script however it has been modified to explode with a stationary object rather than a projectile
        //Boom is going to be used as the standard explosion method

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, tankLayer); // draw a sphere, if any objects are on the tank layer, grab them and store them in this array

        for (int i = 0; i < colliders.Length; i++) // loop through all the colliders in the explosion
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>(); // grab a reference to the rigidbody
            if (!targetRigidbody)
            {
                Debug.Log("Target Has No Rigidbody Ignoring");
                continue; // if there is no rigidbody continue on to the next element, so skip the rest of this code below.
            }

            targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius); // add a force at the point of impact


            float damage = 10; // calculate the damage based on the distance
            TankGameEvents.OnObjectTakeDamageEvent?.Invoke(targetRigidbody.transform, -damage); // invoke our take damage event
        }

        // spawn in our explosion effect and destroy within the given time
        GameObject clone = Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);
        Destroy(clone, maxOilstorageLifeTime);

    }

}
