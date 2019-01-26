using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour, ClicableMapObject.ClicableMapObjectListener
{
    private const int TRAP_PRICE = 5;
    private const int TOWER_PRICE = 3;

    public enum State
    {
        PREPARING,
        BUILD_TRAP,
        BUILD_TOWER,
        UNDER_ATTACK
    }

    public State CurrentState = State.PREPARING;
    public int Coins = 10;
    public int Health = 5;

    public int HamburgersCount = 5;

    public GameObject TrapPositionsParent;
    public GameObject TowerPositionsParent;

    public EnemyWaves enemyWaves;

    public GameObject BuildingsPanel;
    public GameObject BuildingsButton;
    public Text TimerText;
    public Text CoinsText;



    private static string TOWER_POSITION_TAG = "TowerPos";
    private static string TRAP_POSITION_TAG = "TrapPos";

    private int waveNumber = 0;
    private float timeToNextWave = 10;

    void Start()
    {
        Coins = PlayerPrefs.GetInt("Coins", Coins);
        Health = PlayerPrefs.GetInt("Health", Health);

        // Update Coins and Lives
        CoinsText.text = Coins.ToString();
        GetComponent<LiveCounter>().Refresh();

        foreach (var child in TrapPositionsParent.GetComponentsInChildren<ClicableMapObject>())
        {
            child.tag = TRAP_POSITION_TAG;
            child.SetListener(this);
        }
        foreach (var child in TowerPositionsParent.GetComponentsInChildren<ClicableMapObject>())
        {
            child.tag = TOWER_POSITION_TAG;
            child.SetListener(this);
        }



        ChangeState(State.PREPARING);

    }

    public void ChangeState(State state)
    {
        CurrentState = state;
        switch (state)
        {
            case State.PREPARING:
                BuildingsButton.SetActive(true);
                waveNumber += 1;
                timeToNextWave = 10;

                break;

            case State.BUILD_TOWER:
                TowerPositionsParent.SetActive(true);
                break;

            case State.BUILD_TRAP:

                TrapPositionsParent.SetActive(true);
                break;
            case State.UNDER_ATTACK:
                enemyWaves.StartWave(1 + waveNumber, 3, 5);
                TowerPositionsParent.SetActive(false);
                TrapPositionsParent.SetActive(false);
                BuildingsButton.SetActive(false);


                TimerText.text = string.Format("Wave: {0}", waveNumber);
                //ChangeCoins(3);
                //ChangeState(State.PREPARING);
                BuildingsPanel.gameObject.SetActive(false);

                break;
        }

    }

    void LateUpdate()
    {
        if (CurrentState != State.UNDER_ATTACK)
        {
            var minutes = timeToNextWave / 60; //Divide the guiTime by sixty to get the minutes.
            var seconds = timeToNextWave % 60; //Use the euclidean division for the seconds.

            //update the label value
            TimerText.text = string.Format("Wave {2} stars in: {0:00}:{1:00}", minutes, seconds, waveNumber);

            timeToNextWave -= Time.deltaTime;

            if (timeToNextWave < 0)
            {
                ChangeState(State.UNDER_ATTACK);
            }
        }
    }

    public void Build(int buildingId)
    {
        TowerPositionsParent.SetActive(false);
        TrapPositionsParent.SetActive(false);

        switch (buildingId)
        {
            case 0:
                if (Coins >= TRAP_PRICE)
                    ChangeState(State.BUILD_TRAP);
                ShowHideBuildings();
                TrapPositionsParent.SetActive(true);
                break;
            case 1:
                if (Coins >= TOWER_PRICE)
                    ChangeState(State.BUILD_TOWER);
                ShowHideBuildings();
                TowerPositionsParent.SetActive(true);
                break;
        }
    }

    public void ShowHideBuildings()
    {
        BuildingsPanel.gameObject.SetActive(!BuildingsPanel.gameObject.activeSelf);
    }

    public void ChangeCoins(int value)
    {
        Coins += value;
        CoinsText.text = Coins.ToString();
    }

    public void BuildOnPosition(ClicableMapObject obj)
    {
        TowerPositionsParent.SetActive(false);
        TrapPositionsParent.SetActive(false);

        if (CurrentState == State.BUILD_TRAP && obj.tag == TRAP_POSITION_TAG)
        {
            ChangeCoins(-TRAP_PRICE);

            //build prap on position
        }
        else if (CurrentState == State.BUILD_TOWER && obj.tag == TOWER_POSITION_TAG)
        {
            ChangeCoins(-TOWER_PRICE);
        }
    }
}
