using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhirlManager : MonoBehaviour
{

    [SerializeField]
    float WhirlSpeed;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == StringCollection.PLAYER)
        {
            Vector3 temp = transform.position - collision.transform.position;
            collision.transform.RotateAround(transform.position, new Vector3(0, 0, 1), WhirlSpeed * Time.deltaTime * 2 / temp.magnitude);
        }
    }
}
