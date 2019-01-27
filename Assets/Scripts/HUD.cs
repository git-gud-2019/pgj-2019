using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour, ClicableMapObject.ClicableMapObjectListener
{
    private const int TRAP_PRICE = 3;
    private const int TOWER_PRICE = 5;

    public enum State
    {
        PREPARING,
        UNDER_ATTACK,
        GAME_OVER
    }


    public State CurrentState = State.PREPARING;
    public int Coins = 10;
    public int Health = 100;

    public GameObject TrapPositionsParent;
    public GameObject TowerPositionsParent;

    public GameObject TrapPrefab;
    public GameObject TurretPrefab;

    public EnemyWaves enemyWaves;

    public GameObject BuildingsPanel;
    public GameObject BuildingsButton;
    public Text TimerText;
    public Text CoinsText;
    public Text HealthText;



    private const string TOWER_POSITION_TAG = "TowerPos";
    private const string TRAP_POSITION_TAG = "TrapPos";

    private int waveNumber = 0;
    private float timeToNextWave = 20;

    void Start()
    {
        //Coins = PlayerPrefs.GetInt("Coins", Coins);
        //Health = PlayerPrefs.GetInt("Health", Health);

        // Update Coins and Lives
        CoinsText.text = Coins.ToString();
        HealthText.text = Health.ToString();

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
        if (CurrentState == State.GAME_OVER)
        {
            return;
        }
        CurrentState = state;
        switch (state)
        {
            case State.PREPARING:
                BuildingsButton.SetActive(true);
                waveNumber += 1;
                timeToNextWave = 20;

                break;
            case State.UNDER_ATTACK:
                enemyWaves.StartWave(1 + waveNumber, 3, 5);
                TowerPositionsParent.SetActive(false);
                TrapPositionsParent.SetActive(false);
                BuildingsButton.SetActive(false);


                TimerText.text = string.Format("Wave: {0}", waveNumber);
                BuildingsPanel.gameObject.SetActive(false);

                break;
            case State.GAME_OVER:
                TimerText.text = string.Format("Game Over");
                //TODO: show game over image
                break;
        }

    }

    void LateUpdate()
    {
        if (CurrentState == State.GAME_OVER)
        {
            return;
        }

        if (CurrentState == State.PREPARING)
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
                if (Coins < TRAP_PRICE)
                {
                    break;
                }
                ShowHideBuildings();
                TrapPositionsParent.SetActive(true);
                break;
            case 1:
                if (Coins < TOWER_PRICE)
                {
                    break;
                }
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

    public void UpdateHealth()
    {
        HealthText.text = Health.ToString();
    }

    public void BuildOnPosition(ClicableMapObject obj)
    {
        TowerPositionsParent.SetActive(false);
        TrapPositionsParent.SetActive(false);

        if (CurrentState == State.PREPARING)
        {
            switch (obj.tag)
            {
                case TRAP_POSITION_TAG:
                    ChangeCoins(-TRAP_PRICE);

                    Instantiate(
                        TrapPrefab,
                        new Vector3(obj.transform.position.x, obj.transform.position.y, 0f),
                        Quaternion.identity
                    );

                    break;
                case TOWER_POSITION_TAG:
                    ChangeCoins(-TOWER_PRICE);
                    Instantiate(
                        TurretPrefab,
                        new Vector3(obj.transform.position.x, obj.transform.position.y, 0f),
                        TurretPrefab.transform.rotation
                    );
                    break;
            }

        }
    }
}
