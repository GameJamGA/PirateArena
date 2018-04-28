using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour {

	public int index = 0; //index of the ship. is used for input controle
    public Rigidbody2D rb;

    private GameManager gm;

    [SerializeField] float Life;
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;

    float horizontalAxis; //is used for rotation

    //initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.Find(StringCollection.GAMEMANAGER).GetComponent<GameManager>();
	}



	void Update () {
		Move(Time.deltaTime);
	}

	void FixedUpdate() {
        InputManager();
    }

    void InputManager() {
        switch (index) { //prosesses input dependent of player index
            case 0:
                horizontalAxis = -Input.GetAxis(StringCollection.Horizontal);
                break;
            case 1:
                horizontalAxis = -Input.GetAxis(StringCollection.HORIZONTAL2);
                break;
            default:
                horizontalAxis = 0; //if player index is not handled coretly
                break;
        }
    }

	void Move(float delta) {
        rb.velocity = this.transform.up * movementSpeed * delta; //changes velosity so you can kolide with islands and ships //TODO: add wind
        
        transform.Rotate(0, 0, horizontalAxis * rotationSpeed * delta); //rotates player dependend of input
    }

    public void OnHit(float damage = 1) { //will decrese the live of the player. it will report its death if it reaches 0 to gamemanager
        Life -= damage;
        if (Life <= 0) {
            gm.SetGameOver();
        } //TODO: else report to UI
    }
}
