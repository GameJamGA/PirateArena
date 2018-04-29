using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScript : MonoBehaviour {

    [SerializeField]
    GameObject Text;
    [SerializeField]
    float ScroleSpeed;

    float timer = 0;

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        Text.transform.position += transform.up * Time.deltaTime * ScroleSpeed;
        if (timer > 27)
            SceneManager.LoadScene("StartMenu");
    }
}
