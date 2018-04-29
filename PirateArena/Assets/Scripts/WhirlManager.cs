using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhirlManager : MonoBehaviour
{

    [SerializeField]
    float WhirlSpeed;
    [SerializeField]
    SpriteRenderer OuterWhirl;
    [SerializeField]
    SpriteRenderer MiddleWhirl;
    [SerializeField]
    SpriteRenderer InnerWhirl;

    private void Update()
    {
        OuterWhirl.transform.Rotate(0.0f, 0.0f, Time.deltaTime * WhirlSpeed);
        MiddleWhirl.transform.Rotate(0.0f, 0.0f, Time.deltaTime * WhirlSpeed*2);
        InnerWhirl.transform.Rotate(0.0f, 0.0f, Time.deltaTime * WhirlSpeed*4);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == StringCollection.PLAYER)
        {
            Vector3 temp = transform.position - collision.transform.position;
            collision.transform.RotateAround(transform.position, new Vector3(0, 0, 1), WhirlSpeed * Time.deltaTime * 2 / temp.magnitude);
        }
    }
}
