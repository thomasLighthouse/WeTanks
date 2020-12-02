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
    // Start is called before the first frame update
    void Start()
    {
        ws = new WallSpawner();
        TheMainMenu = new MainMenu();
        ThePauseMenu = new PauseMenu();
        TheLevelSelectMenu = new LevelSelectMenu();
        Game.GameActive = false;
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
