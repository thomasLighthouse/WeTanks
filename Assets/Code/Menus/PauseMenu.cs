using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu
{
    private Object _mainPrefab;
    private GameObject MenuObject;
    // Start is called before the first frame update
    public PauseMenu()
    {
        _mainPrefab = Resources.Load("Menus/PauseMenu");
        MenuObject = (GameObject)GameObject.Instantiate(_mainPrefab, GameObject.Find("Canvas").transform);
        InitializeButtons();
        MenuObject.SetActive(false); // When it's created, it starts out unpaused
    }

    public void openMenu()
    {
        MenuObject.SetActive(true);
        Game.GameActive = false;
        Time.timeScale = 0f;
    }

    public void closeMenu()
    {
        MenuObject.SetActive(false);
        Game.GameActive = true;
        Time.timeScale = 1f;
    }

    private void InitializeButtons()
    {
        Button start = MenuObject.transform.GetChild(1).GetComponent<Button>();
        start.onClick.AddListener(closeMenu);
        Button quit = MenuObject.transform.GetChild(3).GetComponent<Button>();
        quit.onClick.AddListener(Game.QuitGame);
    }
}
