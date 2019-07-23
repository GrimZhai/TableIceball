using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Score : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    [SyncVar]
    public int scoreH = 0;
    [SyncVar]
    public int scoreC = 0;
    [SyncVar]
    public int game = 0; 

    public void HostWin()
    {
        if (!isServer)
            return;

        scoreH++;
        game = 1;
    }

    public void ClientWin()
    {
        if (!isServer)
            return;

        scoreC++;
        game = 2;
    }

    public int GetHostScore()
    {
        return scoreH;
    }

    public int GetClientScore()
    {
        return scoreC;
    }

    public void SetGameStatus(int status)
    {
        game = status;
    }

    public int GetGameStatus()
    {
        return game;
    }
}
