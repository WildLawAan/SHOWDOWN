using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum StageState
{
    STAGE1=0,
    STAGE2,
    STAGE3

}

public class Manager : MonoBehaviour {

    static Manager _instance = null;
    public int lives = 3;
    public int bricks = 20;
    public float resetDelay = 1f;
    public bool Resetnow = true;

    public Text livesText;
    public Text gameOver;
    public Text clear;
    public Text bestScore_text;
    public Text currentScore_text;
    public Text YOU_Win;


    public GameObject bricksPrefab;
    //public GameObject stage2;
    public GameObject player;
    public GameObject deathParticles;
    //private int stage=1;
    //static 으로 일단 해결
    public AudioSource goal;
    public AudioSource gameclear;
    public float resetgame;
    public int level = 3;
    public AudioSource regame;
    public int ballspeed;

    public StageState stage;
    public GameObject brick_stage2;
    int _blockScore = 0;
    int _bestScore = 0;
    public int score = 0;


    public AudioSource Win_sound;
    public AudioSource lose_sound;
    public AudioSource Match_sound;


    GameObject clonePlayer;

    public static Manager Instance()
    {
        return _instance;
    }

	// Use this for initialization
	private void Awake  () {
        if(_instance == null)
        {
            _instance = this;
        }

        else
        {
            Destroy(this.gameObject);
        }

        _bestScore = PlayerPrefs.GetInt("BestScore");
        bestScore_text.text = "Best Score" + _bestScore.ToString();

        DontDestroyOnLoad(this);
    }

    public void SetUp()//맨처음 시작할때 한번 내장함수 아니었던듯
    {
        //이 밑줄 뭔가 자주 쓰이던데..(이걸 여태 안썼다니)

        // clonePlayer = Instantiate(player, new Vector3(1, 0.75f, 0.5f), Quaternion.Euler(new Vector3(90, 0, 0))) as GameObject;//시작할때 작동하도록 
        clonePlayer = Instantiate(player) as GameObject;
        Debug.Log(stage);
        
        switch(stage)
        {
            case StageState.STAGE1:
                //Instantiate(bricksPrefab, new Vector3(1f, 0.75f, 1f), Quaternion.Euler(new Vector3(0, 0, 0)));
                lives = 3;
                bricks = 3;
                if (gameOver.gameObject.activeSelf)
                {
                    gameOver.gameObject.SetActive(false);
                }
                livesText.text = "Lives" + lives;




                break;
            case StageState.STAGE2:
                Instantiate(brick_stage2, new Vector3(0, 0, 0), Quaternion.identity);
                bricks = 9;
                if (clear.gameObject.activeSelf)
                {
                    clear.gameObject.SetActive(false);
                }
                break;

            case StageState.STAGE3:
                break;


        }
       
 
    }

    void CheckGameOver()
    {
        if(bricks < 1)
        {
            clear.gameObject.SetActive(true);
            Time.timeScale = .25f;
            StartCoroutine(ResetGame());
            stage = StageState.STAGE2;
            //Invoke("Reset", resetDelay); //StartCorutine
        }

        if(lives < 1)
        {
            gameOver.gameObject.SetActive(true);
            _blockScore = 0;
            gameclear.Play();


            Time.timeScale = .25f;
            StartCoroutine(ResetGame());
            //Invoke("Reset", resetDelay); 
        }

    }

    IEnumerator ResetGame()
    {

        Destroy(clonePlayer);
        Destroy(GameObject.Find("ball"));



        switch (stage)
        {

            case StageState.STAGE2:
                stage = StageState.STAGE1;
                

                lives = 3;

                break;

        }

        yield return new WaitForSeconds(1.25f);
        Time.timeScale = 1f;
        lives = 3;
        gameOver.gameObject.SetActive(false);
        clear.gameObject.SetActive(false); 
        //SceneManager.LoadScene("Vive_re");

        //yield return new WaitForSeconds(0.5f);
    }

    private void Reset()
    {
        switch(stage)
        {
            case StageState.STAGE1:
                stage = StageState.STAGE2;
                lives = 3;
                bricks = 3;

                break;
            case StageState.STAGE2:
                stage = StageState.STAGE1;
                bricks = 9;

                lives = 3;

                break;
            case StageState.STAGE3:
                break;

        }
        Time.timeScale = 1f;
        //SetUp();
        livesText.text = "Lives" + lives;
        gameOver.gameObject.SetActive(false);

        //SceneManager.LoadScene("Vive_re");
        
    }

    public void LoseLife()
    {
        lose_sound.Play();
        lives--;
        livesText.text = "Lives" + lives;
        level--;
        //Instantiate(deathParticles, clonePlayer.transform.position, Quaternion.identity);
        Resetnow = false;
        Destroy(clonePlayer);
        Invoke("SetupPlayer", resetDelay);
        Resetnow = true;
        CheckGameOver();
    }

    public void Re()
    {
        Destroy(clonePlayer);
        regame.Play();



        Invoke("SetupPlayer", resetDelay);
        print("restrart");
    }

    public void Win()
    {
        Win_sound.Play();
        livesText.text = "Lives" + lives;
        //Instantiate(deathParticles, clonePlayer.transform.position, Quaternion.identity);
        goal.Play();
        level++; // 적의 난이도 상승 
        Resetnow = false;
        Destroy(clonePlayer);
        Invoke("SetupPlayer", resetDelay);
        Resetnow = true;
        CheckGameOver();

        score++;
        if (score > 4)
        {
            Match_sound.Play();
        }
        if (score > 5)
        {
            Debug.Log("Winner!!!!");
            YOU_Win.gameObject.SetActive(true);
        }
    }

    void SetupPlayer()//공이 바닥에 떨어지면 다시 나오게
    {
        clonePlayer = Instantiate(player) as GameObject;
    }

    public void DestroyBricks()
    {
        bricks--;
        print(bricks);
        goal.Play();
        CheckGameOver();

    }

    //정수
    public int blockScore
    {
        get
        {
            return _blockScore;
        }

        set
        {
            _blockScore = value;
            if(_blockScore > _bestScore)
            {
                _bestScore = _blockScore;
                PlayerPrefs.SetInt("BestScore", _bestScore);
                bestScore_text.text = "Best Score" + _bestScore.ToString();


            }

        }
    }

    public int bestScore
    {
        get
        {
            return _bestScore;
        }

    }

}
