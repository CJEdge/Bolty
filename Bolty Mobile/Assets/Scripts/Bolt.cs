using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    public GameObject spawner;
    public float speed;
    public float damage = 10;
    public GameObject hitFX;
    Quaternion myRot;
    
    void Start()
    {
        spawner = GameObject.Find("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        myRot = transform.rotation;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        BoltyMovement bolty = collider.gameObject.GetComponent<BoltyMovement>();
        Health health = collider.gameObject.GetComponent<Health>();
        Shield shield = collider.gameObject.GetComponent<Shield>();
        if (bolty && health)
        {
            Instantiate(hitFX, transform.position, myRot);
            health.DealDamage(damage);
            Destroy(gameObject);
        }
        else if (shield)
        {
            Instantiate(hitFX, transform.position, myRot);
            Destroy(gameObject);
        }

    }
}
