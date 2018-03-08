using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int player;

    public SpriteRenderer rockSprite, paperSprite, scissorsSprite;
    public Image healthBar;

    [HideInInspector]
    public bool rock, paper, scissors;
    [HideInInspector]
    public bool powerAttack, tieBreaker, guard;
    public int rockLV, paperLV, scissorsLV;

    public float hp;
    public float maxHp;
    public int abilityUses;

    public bool ready;
    public bool levelUp;

	// Use this for initialization
	void Start ()
    {
        ResetChoice();
        ResetAttack();

        rockLV = 1;
        paperLV = 1;
        scissorsLV = 1;

        maxHp = 10;
        hp = maxHp;
        abilityUses = 3;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameController.selectPhase && player == 1)
            PlayerOneChoose();
        if (GameController.selectPhase && player == 2)
            PlayerTwoChoose();
        SetHealthBar();

    }

    public void ResetChoice()
    {
        rock = false;
        paper = false;
        scissors = false;
        ready = false;
    }

    public void ResetAttack()
    {
        powerAttack = false;
        tieBreaker = false;
        guard = false;

    }

    public void PlayerOneChoose()
    {
        //Debug.Log("hi");
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (!rock)
            {
                ResetChoice();
                rock = true;
                ready = true;
                Debug.Log("rock" + rock);
            }
            else
                ResetChoice();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (!paper)
            {
                ResetChoice();
                paper = true;
                ready = true;
                Debug.Log("paper" + paper);
            }
            else
                ResetChoice();
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            if (!scissors)
            {
                ResetChoice();
                scissors = true;
                ready = true;
                Debug.Log("scissors" + scissors);
            }
            else
                ResetChoice();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!powerAttack && abilityUses > 0)
            {
                ResetAttack();
                powerAttack = true;
                Debug.Log("power attack" + powerAttack);
            }
            else
                ResetAttack();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!tieBreaker && abilityUses > 0)
            {
                ResetAttack();
                tieBreaker = true;
                Debug.Log("tie breaker" + tieBreaker);
            }
            else
                ResetAttack();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (!guard && abilityUses > 0)
            {
                ResetAttack();
                guard = true;
                Debug.Log("guard" + guard);
            }
            else
                ResetAttack();
        }
    }

    public void PlayerTwoChoose()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (!rock)
            {
                ResetChoice();
                rock = true;
                ready = true;
            }
            else
                ResetChoice();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!paper)
            {
                ResetChoice();
                paper = true;
                ready = true;
            }
            else
                ResetChoice();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (!scissors)
            {
                ResetChoice();
                scissors = true;
                ready = true;
            }
            else
                ResetChoice();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (!powerAttack && abilityUses > 0)
            {
                ResetAttack();
                powerAttack = true;
            }
            else
                ResetAttack();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!tieBreaker && abilityUses > 0)
            {
                ResetAttack();
                tieBreaker = true;
            }
            else
                ResetAttack();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!guard && abilityUses > 0)
            {
                ResetAttack();
                guard = true;
            }
            else
                ResetAttack();
        }
    }

    public void PlayerOneLvUp()
    {
        if (rockLV >= 10 && paperLV >= 10 && scissorsLV >= 10)
            levelUp = false;
        if (levelUp)
        {
            if (Input.GetKeyDown(KeyCode.Alpha4) && rockLV < 10)
            {
                rockLV++;
                levelUp = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha7) && paperLV < 10)
            {
                paperLV++;
                levelUp = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha8) && scissorsLV < 10)
            {
                scissorsLV++;
                levelUp = false;
            }
        }
    }

    public void PlayerTwoLvUp()
    {
        if (rockLV >= 10 && paperLV >= 10 && scissorsLV >= 10)
            levelUp = false;
        if (levelUp)
        {
            if (Input.GetKeyDown(KeyCode.T) && rockLV < 10)
            {
                rockLV++;
                levelUp = false;
            }
            if (Input.GetKeyDown(KeyCode.I) && paperLV < 10)
            {
                paperLV++;
                levelUp = false;
            }
            if (Input.GetKeyDown(KeyCode.K) && scissorsLV < 10)
            {
                scissorsLV++;
                levelUp = false;
            }
        }
    }

    private void SetHealthBar()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, hp/maxHp, 2 * Time.deltaTime);
        //healthBar.fillAmount = hp / maxHp;
    }

}
