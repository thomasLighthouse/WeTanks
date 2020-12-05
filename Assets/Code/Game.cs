using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static bool GameActive;
    private static MainMenu TheMainMenu;
    private static PauseMenu ThePauseMenu;
    private static LevelSelectMenu TheLevelSelectMenu;
    private static WallSpawner ws;

    public GameObject LevelWin;
    public GameObject LevelLoss;
    public GameObject GameWin;
    private bool endFlag = false;
    private bool gameLost = false;
    private int curScene;
    // Start is called before the first frame update
    void Start()
    {
        ws = new WallSpawner();
        TheMainMenu = new MainMenu();
        ThePauseMenu = new PauseMenu();
        TheLevelSelectMenu = new LevelSelectMenu();
        Game.GameActive = false;
        curScene = int.Parse(SceneManager.GetActiveScene().name.Remove(0, 5));
    }

    public static void StartGame()
    {
        TheMainMenu.closeMenu();
        ws.SpawnWalls();
        Game.GameActive = true;
    }

    public static void LoadScene(int scene)
    {
        TheLevelSelectMenu.closeMenu();
        SceneManager.LoadScene("Level" + scene);
    }

    public static void LevelSelectMode()
    {
        TheMainMenu.closeMenu();
        TheLevelSelectMenu.openMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameActive)
        {

            if (!endFlag){
                if (GameObject.Find("Player") == null){
                    Instantiate(LevelLoss, new Vector3(0, 0, 0), Quaternion.identity);
                    endFlag = true;
                    gameLost = true;
                }

                if (Object.FindObjectsOfType(typeof(TurretBase)).Length == 0){
                    if (curScene != 5) {
                        Instantiate(LevelWin, new Vector3(0, 0, 0), Quaternion.identity);
                    } else {
                        Instantiate(GameWin, new Vector3(0, 0, 0), Quaternion.identity);
                    }
                    
                    endFlag = true;
                }
            } else {
                if (Input.GetKeyDown("space") && gameLost)
                {
                    LoadScene(curScene);
                } else if (Input.GetKeyDown("space")) {
                    if (curScene != 5) {
                        LoadScene(curScene + 1);
                    } else {
                        LoadScene(curScene);
                    }
                }
            }


            if (Input.GetKey("p"))
            {
                ThePauseMenu.openMenu();
            }


        }
    }
    
    /// <summary>
             /// Quits the game if in editor, otherwise closes the application
             /// Borrowed from Exercise 5, since we're technically allowed to do that
             /// </summary>
    public static void QuitGame()
    {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
