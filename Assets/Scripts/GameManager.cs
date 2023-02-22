using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //Singleton Instance
    public static GameManager insatnce { get; private set; }

    //Singleton declaration
    private void Awake()
    {
        if (insatnce != null && insatnce != this)
        {
            Destroy(this);
        }
        else
        {
            insatnce = this;
        }
    }

    public delegate void GameManagerDelegate();

    public GameManagerDelegate onGameStart;
    public GameManagerDelegate onGameOver;
    public GameManagerDelegate onGameWin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
