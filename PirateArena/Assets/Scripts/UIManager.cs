using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    private GameManager myGM;

    [SerializeField] GameObject player1Parent;
    [SerializeField] GameObject player2Parent;

    [SerializeField] GameObject player1CD;
    [SerializeField] GameObject player2CD;

    GameObject[] player1UI = new GameObject[3];
    GameObject[] player2UI = new GameObject[3];

    private void Start()
    {
        myGM = GameObject.Find(StringCollection.GAMEMANAGER).GetComponent<GameManager>();

        ResetLifeUI();

    }

    public void LoseLifeUI(int index)
    {
        if(index == 0)
        {
            if (player1UI[2].activeSelf )
            {
                player1UI[2].SetActive(false);
            }
            else if(player1UI[1].activeSelf && !player1UI[2].activeSelf)
            {
                player1UI[1].SetActive(false);
            }else if(player1UI[0].activeSelf && !player1UI[1].activeSelf && !player1UI[2].activeSelf)
            {
                player1UI[0].SetActive(false);
            }
            else
            {
                myGM.SetGameOver();
            }
        }
        else if(index == 1)
        {
            if (player2UI[2].activeSelf)
            {
                player2UI[2].SetActive(false);
            }
            else if (player2UI[1].activeSelf && !player2UI[2].activeSelf)
            {
                player2UI[1].SetActive(false);
            }
            else if (player2UI[0].activeSelf && !player2UI[1].activeSelf && !player2UI[2].activeSelf)
            {
                player2UI[0].SetActive(false);
            }
            else
            {
                myGM.SetGameOver();
            }
        }
    }

    public void ResetLifeUI()
    {
        int iA = 11;
        int jA = 21;

        for (int i = 0; i <= player1UI.Length - 1; i++)
        {
            player1UI[i] = GameObject.Find(iA.ToString());
            player1UI[i].SetActive(true);
            iA++;
        }
        for (int j = 0; j <= player1UI.Length - 1; j++)
        {
            player2UI[j] = GameObject.Find(jA.ToString());
            player1UI[j].SetActive(true);
            jA++;
        }
    }
    public void UpdateCD(int index, float procent, bool right)
    {
        if (index == 0)
        {
            player1CD.GetComponent<CDManager>().UpdateCD(procent, right);
        }else if (index == 1)
        {
            player2CD.GetComponent<CDManager>().UpdateCD(procent, right);
        }
    }

}
