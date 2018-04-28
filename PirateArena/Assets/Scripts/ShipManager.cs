using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour {

	public int index = 0;
    public Rigidbody2D rb;

    [SerializeField] int maxLife;
    int currentLife;
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;

    float horizontalAxis;

    // Use this for initialization
    void Start () {
        currentLife = maxLife;
        rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		Move(Time.deltaTime);
	}

	void FixedUpdate() {
        //ka fieleicht input oder sowas
    }

	void Move(float delta){
        //transform.position += this.transform.up * movementSpeed;
        rb.velocity = this.transform.up * movementSpeed * delta;

        switch (index)
        {
            case 0:
                horizontalAxis = -Input.GetAxis(StringCollection.Horizontal);
                break;
            case 1:
                horizontalAxis = -Input.GetAxis(StringCollection.HORIZONTAL2);
                break;
            default:
                break;
        }
        /*Quaternion temp = Quaternion.Euler(0, 0, horizontalAxis * rotationSpeed);
        transform.rotation = temp;*/
        transform.Rotate(0, 0, horizontalAxis * rotationSpeed * delta);
    }
}
