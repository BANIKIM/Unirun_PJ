using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UI 스코어의 값을 변경하기위해선언
using UnityEngine.SceneManagement;//Scene을 


public class GameManager : MonoBehaviour
{
    
    //Unity의 싱글톤 기본 형태
    public static GameManager Instance = null;
    /*    public static GameManager Instance
        {
            get
            {
                if(_instance ==null)
                {
                    _instance = new GameManager();
                }
                return _instance;
            }
        }*/
    private void Awake()
    {
        if(Instance ==null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("이미 이게임에는 게임 매니저가 존재합니다.. 난죽택");
            Destroy(gameObject);
        }
    }

    // GameManager - 어디서든지 접근이 가능해야하고
    // 어떤 오브젝트든 접근하여 사용해야한다.
    // 이유는 Gameover, Socre를 관리 해야 하기 때문에

    public bool isGameover = false;

    public GameObject GameoverUI;
    public Text Score_text;

    public int Score=0;
    //public bool st = false;
    private void Update()
    {
        
        if(isGameover&&Input.GetMouseButtonDown(0))
        {
            //Restart 하기 위해서는 현재 씬을 다시 로드한다.
            SceneManager.LoadScene(0);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
            
        }          
            NextLovel(Score);//스코어 기준으로 다음 스테이지로 간다

    }

    public void AddScore(int score)
    {
        if(!isGameover)
        {
            Score += score;
            Score_text.text = "Score : " + Score;
            
        }


    }
  
    public void NextLovel(int score)
    {
        if(score==3&& SceneManager.GetActiveScene().name=="MainGame")
        {          //SceneManager.GetActiveScene().name=="MainGame" 씬을 비교할 수 있는 메서드  
            SceneManager.LoadScene(1);
           
        }
        
    }

    public void Player_Dead()
    {
        isGameover = true;
        GameoverUI.SetActive(true);
    }

}
