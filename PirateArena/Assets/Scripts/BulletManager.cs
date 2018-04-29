using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

    float currentLifeTime = 0;

    [SerializeField]
    float maxLifeTime;

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
            collision.transform.gameObject.GetComponent<ShipManager>().OnHit();
            Destroy(transform.gameObject);
        }
    }

}
