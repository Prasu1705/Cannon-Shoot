using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float dieTime = 3f;
    public GameObject collisionExplosion;
    public float radius = 5f;
    public float force = 700f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, dieTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            //Gameobject for explosion
            GameObject explosion = (GameObject)Instantiate(collisionExplosion, transform.position, transform.rotation);
            Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider nearbyObject in collidersToDestroy)
            {
                Destructible dest = nearbyObject.GetComponent<Destructible>();
                if(dest != null)
                {
                    dest.Destroy();
                }
            }
            Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider nearbyObject in collidersToMove)
            {
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(force, transform.position, radius);
                }
            }
            Destroy(gameObject);
            Destroy(explosion, 3f);
            return;
        }
    }
}
