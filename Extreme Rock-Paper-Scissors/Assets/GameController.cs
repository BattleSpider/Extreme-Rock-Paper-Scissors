using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Player playerOne, playerTwo;

    private bool playerOneWins, playerTwoWins;

    public static bool selectPhase, battlePhase, lvUpPhase;

	// Use this for initialization
	void Start ()
    {
        SetPhase(1);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(selectPhase && playerOne.ready && playerTwo.ready && Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetPhase(2);
            StartCoroutine(Battle());
        }
	}

    IEnumerator Battle()
    {
        yield return null;
    }

    public void SetPhase(int phase)
    {
        selectPhase = false;
        battlePhase = false;
        lvUpPhase = false;
        if (phase == 1)
            selectPhase = true;
        if (phase == 2)
            battlePhase = true;
        if (phase == 3)
            lvUpPhase = true;
    }

    public void DetermineWinner()
    {
        playerOneWins = false;
        playerTwoWins = false;

        if (playerOne.rock && playerTwo.rock)
        {
            if (playerOne.tieBreaker)
                DamagePlayer(2, playerOne.rockLV);
            if (playerTwo.tieBreaker)
                DamagePlayer(1, playerTwo.rockLV);
        }
        if(playerOne.rock && playerTwo.paper)
        {
            DamagePlayer(1, playerTwo.paperLV);
        }
        if (playerOne.rock && playerTwo.scissors)
        {
            DamagePlayer(2, playerOne.rockLV);
        }
        if (playerOne.paper && playerTwo.paper)
        {
            if (playerOne.tieBreaker)
                DamagePlayer(2, playerOne.paperLV);
            if (playerTwo.tieBreaker)
                DamagePlayer(1, playerTwo.paperLV);
        }
        if (playerOne.paper && playerTwo.rock)
        {
            DamagePlayer(2, playerOne.paperLV);
        }
        if (playerOne.paper && playerTwo.scissors)
        {
            DamagePlayer(1, playerTwo.scissorsLV);
        }
        if (playerOne.scissors && playerTwo.scissors)
        {
            if (playerOne.tieBreaker)
                DamagePlayer(2, playerOne.scissorsLV);
            if (playerTwo.tieBreaker)
                DamagePlayer(1, playerTwo.scissorsLV);
        }
        if (playerOne.scissors && playerTwo.rock)
        {
            DamagePlayer(1, playerTwo.rockLV);
        }
        if (playerOne.scissors && playerTwo.paper)
        {
            DamagePlayer(2, playerOne.scissorsLV);
        }
    }

    public void DamagePlayer(int player, int damage)
    {
        if (player == 1)
        {
            if (playerTwo.powerAttack && !playerOne.guard)
                damage = damage * 2;
            if (playerOne.guard && !playerTwo.powerAttack)
                damage = 0;
            playerOne.hp -= damage;
            if (damage != 0)
                playerTwoWins = true;
        }
        if (player == 2)
        {
            if (playerOne.powerAttack && !playerTwo.guard)
                damage = damage * 2;
            if (playerTwo.guard && !playerOne.powerAttack)
                damage = 0;
            playerTwo.hp -= damage;
            if (damage != 0)
                playerOneWins = true;
        }
    }
}
