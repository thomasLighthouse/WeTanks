using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectMenu
{
    private Object _mainPrefab;
    private GameObject MenuObject;
    // Start is called before the first frame update
    public LevelSelectMenu()
    {
        _mainPrefab = Resources.Load("Menus/LevelSelectMenu");
        MenuObject = (GameObject)GameObject.Instantiate(_mainPrefab, GameObject.Find("Canvas").transform);
        InitializeButtons();
        MenuObject.SetActive(false);
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
        for (int i = 0; i < 5; i++)
        {
            Button b = MenuObject.transform.GetChild(i+2).GetComponent<Button>();
            int temp = i + 1;
            b.onClick.AddListener(() => Game.LoadScene(temp));
        }
        Button quit = MenuObject.transform.GetChild(7).GetComponent<Button>();
        quit.onClick.AddListener(Game.QuitGame);

    }
}
