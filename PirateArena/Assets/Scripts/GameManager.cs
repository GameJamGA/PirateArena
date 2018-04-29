﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    /*
     * GAME MANAGER
     * 
     * handles win condition,
     * respawns the player,
     * restarts music
     * 
     * 
     */

    //prefab für die Spieler
    [SerializeField] private GameObject shipPrefab;
    [SerializeField] GameObject myCenter;
    public Vector2 myWind;
    Rigidbody2D myRB;

    private GameObject[] players;
    [SerializeField] private Transform[] spawnPosition;
    [SerializeField] private int maxPlayers;

    bool gameOver;
    

    private void Start()
    {
        GameObject[] temp = new GameObject[maxPlayers];
        temp = GameObject.FindGameObjectsWithTag(StringCollection.SPAWN);

        myRB = transform.GetComponent<Rigidbody2D>();

        players = new GameObject[maxPlayers];

        for (int i = 0; i <= maxPlayers - 1; i++)
        {
            spawnPosition[i] = temp[i].transform;
        }

        StartGame();
        gameOver = false;
    }

    private void Update()
    {
        //draws an random vector to randomize the wind position
        Vector2 randomVec = new Vector2(Random.insideUnitCircle.x, Random.insideUnitCircle.y);


        myWind = (transform.position - myCenter.transform.position);
        //myRB.AddForce(randomVec);
        myRB.velocity = randomVec;
        //add random movement here

        if (gameOver == true)
        {
            AskForRestart();
        }
        //Vector3 movementVector = new Vector3(Vector2.up.x, Vector2.up.y, 0);
        //transform.position += (movementVector * movementspeed);
    }

    private void AskForRestart()
    {

    }

    public void SetGameOver()
    {
        gameOver = true;
    }

    private void StartGame()
    {
        //spawnt schiffe an alle spawns
        
        for(int i = 0; i <= maxPlayers - 1; i++)
        {
            players[i] = Instantiate(shipPrefab, spawnPosition[i].transform.position, spawnPosition[i].transform.rotation);
            players[i].GetComponent<ShipManager>().index = i;
            

        }

       
    }

}
