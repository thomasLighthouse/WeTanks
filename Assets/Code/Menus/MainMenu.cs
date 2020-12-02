using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu // Note that, as a non-MonoBehaviour, this has no start/update methods
{
    private Object _mainPrefab;
    private GameObject MenuObject;
    // Start is called before the first frame update
    public MainMenu()
    {
        _mainPrefab = Resources.Load("Menus/MainMenu");
        MenuObject = (GameObject)GameObject.Instantiate(_mainPrefab, GameObject.Find("Canvas").transform);
        InitializeButtons();
    }

    public void openMenu()
    {
        MenuObject.SetActive(true);
    }

    public void closeMenu()
    {
        MenuObject.SetActive(false);
    }

    private void InitializeButtons()
    {
        Button start = MenuObject.transform.GetChild(2).GetComponent<Button>();
        start.onClick.AddListener(Game.StartGame);
        Button ls = MenuObject.transform.GetChild(3).GetComponent<Button>();
        ls.onClick.AddListener(Game.LevelSelectMode);
        Button quit = MenuObject.transform.GetChild(4).GetComponent<Button>();
        quit.onClick.AddListener(Game.QuitGame);
    }
}
