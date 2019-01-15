using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static GameOver ins;

    [SerializeField] private GameObject GameOverMenu;
    public static int PlayerScore;

    void Awake()
    {
        ins = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Restart()
    {
        SceneManager.LoadScene("MapGeneratorScene");
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
}
