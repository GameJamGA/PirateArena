using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDManager : MonoBehaviour {

    [SerializeField]
    Image RightCD;
    [SerializeField]
    Image LeftCD;

    public void UpdateCD(float procent, bool right){
        if (right)
        {
            RightCD.fillAmount = procent;
        }
        else
        {
            LeftCD.fillAmount = procent;
        }
    }

}
