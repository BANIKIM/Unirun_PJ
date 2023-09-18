using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UI ���ھ��� ���� �����ϱ����ؼ���
using UnityEngine.SceneManagement;//Scene�� 


public class GameManager : MonoBehaviour
{
    
    //Unity�� �̱��� �⺻ ����
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
            Debug.Log("�̹� �̰��ӿ��� ���� �Ŵ����� �����մϴ�.. ������");
            Destroy(gameObject);
        }
    }

    // GameManager - ��𼭵��� ������ �����ؾ��ϰ�
    // � ������Ʈ�� �����Ͽ� ����ؾ��Ѵ�.
    // ������ Gameover, Socre�� ���� �ؾ� �ϱ� ������

    public bool isGameover = false;

    public GameObject GameoverUI;
    public Text Score_text;

    public int Score=0;
    //public bool st = false;
    private void Update()
    {
        
        if(isGameover&&Input.GetMouseButtonDown(0))
        {
            //Restart �ϱ� ���ؼ��� ���� ���� �ٽ� �ε��Ѵ�.
            SceneManager.LoadScene(0);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
            
        }          
            NextLovel(Score);//���ھ� �������� ���� ���������� ����

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
        {          //SceneManager.GetActiveScene().name=="MainGame" ���� ���� �� �ִ� �޼���  
            SceneManager.LoadScene(1);
           
        }
        
    }

    public void Player_Dead()
    {
        isGameover = true;
        GameoverUI.SetActive(true);
    }

}
