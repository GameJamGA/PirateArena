using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour {

    [SerializeField] GameObject clouds;
    GameManager myGM;

    [SerializeField] private float movespeed = 2;

    private void Start()
    {
        clouds = transform.gameObject;
        myGM = GameObject.Find(StringCollection.GAMEMANAGER).GetComponent<GameManager>();
    }

    private void FixedUpdate()
    {
        clouds.transform.position += new Vector3(myGM.GetNormalizedWind().x, myGM.GetNormalizedWind().y, 0) * movespeed;
    }

    

}
