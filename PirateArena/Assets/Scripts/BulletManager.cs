using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

    float currentLifeTime = 0;

    [SerializeField] GameObject explosion;
    [SerializeField] float maxLifeTime;
    [SerializeField] float damage = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentLifeTime += Time.deltaTime;

        if (currentLifeTime >= maxLifeTime)
        {
            Destroy(transform.gameObject);
        }
        
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == StringCollection.PLAYER)
        {
            Debug.Log("Hit!");
            collision.transform.gameObject.GetComponent<ShipManager>().OnHit(damage);
            GameObject explosionObj = Instantiate(explosion, collision.transform.position, collision.transform.rotation, collision.transform);
            explosionObj.GetComponent<ParticleSystem>().Play();

            Destroy(transform.gameObject);
        }
    }

}
