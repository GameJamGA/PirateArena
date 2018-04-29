using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour {

    public int index = 0; //index of the ship. is used for input controle
    private Rigidbody2D rb;

    private GameManager gm;



    [SerializeField]
    SpriteRenderer RightPreView;
    [SerializeField]
    SpriteRenderer LeftPreView;

    [SerializeField]
    float life;
    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float rotationSpeed;
    [SerializeField]
    float MaxCD;
    [SerializeField]
    float BulletSpeed;
    [SerializeField]
    GameObject Bullet;

    [SerializeField] int MaxPlayer = 2;

    GameObject[] PreViewInstans;

    int right = 0;
    float rightTimer = 0;
    int left = 0;
    float leftTimer = 0;

    float horizontalAxis; //is used for rotation

    //initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.Find(StringCollection.GAMEMANAGER).GetComponent<GameManager>();
        
	}



	void Update () {
		Move(Time.deltaTime);
            leftTimer += Time.deltaTime; //TODO: report to UI
        if (right == 4)
            rightTimer += Time.deltaTime; //TODO: report to UI
        if (left == 4)

        if (rightTimer >= MaxCD) {
            right = 0;
            rightTimer = 0;
        }
        if (leftTimer >= MaxCD) {
            left = 0;
            leftTimer = 0;
        }
        if (right == 1 || left == 1)
            SetReady();
        if (right == 3 || left == 3)
            Fire();
	}

	void FixedUpdate() {
        InputManager();
    }

    void SetReady() {
        if (right == 1) {
            RightPreView.enabled = true;
            right = 2;
        }else if (left == 1) {
            LeftPreView.enabled = true;
            left = 2;
        }
    }

    void Fire(){
        if (right == 3) {
            GameObject temp = Instantiate(Bullet);
            temp.transform.rotation = transform.rotation;
            temp.transform.position = transform.position + this.transform.right / 3;
            temp.GetComponent<Rigidbody2D>().velocity = this.transform.right * BulletSpeed;

            RightPreView.enabled = false;

            right = 4;
        }
        else if (left == 3) {
            GameObject temp = Instantiate(Bullet);
            temp.transform.rotation = transform.rotation;
            temp.transform.position = transform.position - this.transform.right / 3;
            temp.GetComponent<Rigidbody2D>().velocity = -this.transform.right * BulletSpeed;

            LeftPreView.enabled = false;

            left = 4;
        }
        print("Fire!");
    }

    void InputManager() {
        switch (index) { //prosesses input dependent of player index
            case 0:
                horizontalAxis = -Input.GetAxis(StringCollection.Horizontal);

                if (right == 0 && Input.GetAxis(StringCollection.VERTICAL) < 0) {
                    right = 1; //TODO: Srage right side
                    print("Stage right!");
                }else if (left == 0 && Input.GetAxis(StringCollection.VERTICAL) > 0) {
                    left = 1; //TODO: Stage left side
                    print("Stage left!");
                }else if (right == 2 && Input.GetAxis(StringCollection.VERTICAL) >= 0) {
                    right = 3; //TODO: Fire right
                    print("Fire right!");
                }else if (left == 2 && Input.GetAxis(StringCollection.VERTICAL) <= 0) {
                    left = 3; //TODO: Fire left
                    print("Fire left!");
                }

                break;
            case 1:
                horizontalAxis = -Input.GetAxis(StringCollection.HORIZONTAL2);

                if (right == 0 && Input.GetAxis(StringCollection.VERTICAL2) < 0)  {
                    right = 1; //TODO: Srage right side
                }
                else if (left == 0 && Input.GetAxis(StringCollection.VERTICAL2) > 0) {
                    left = 1; //TODO: Stage left side
                }
                else if (right == 1 && Input.GetAxis(StringCollection.VERTICAL2) >= 0) {
                    right = 2; //TODO: Fire right
                }
                else if (left == 1 && Input.GetAxis(StringCollection.VERTICAL2) <= 0) {
                    left = 2; //TODO: Fire left
                }

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
        life -= damage;
        if (life <= 0) {
            gm.SetGameOver();
        } //TODO: else report to UI
    }

    bool SetIndex (int i) {
        if (i < 0)
            return false;
        if (i >= MaxPlayer)
            return false;
        index = i;
        return true;
    }

    private float WindSpeed()
    {
        float mySpeed;
        mySpeed = (Vector2.Dot(gm.GetNormalizedWind(), rb.velocity) + 1) / 2.0f;
        return mySpeed;
    }
}
