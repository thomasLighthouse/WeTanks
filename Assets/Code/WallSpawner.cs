using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner
{
    private Camera Cam;
    private Vector2 BottomLeft;
    private Vector2 BottomRight;
    private Vector2 TopLeft;
    private Vector2 TopRight;
    // StartGame is called by Game, once the main game is entered
    public void SpawnWalls()
    {
        Cam = Camera.main; 
        BottomLeft = Cam.ViewportToWorldPoint(new Vector2(0, 0));
        BottomRight = Cam.ViewportToWorldPoint(new Vector2(1, 0));
        TopLeft = Cam.ViewportToWorldPoint(new Vector2(0, 1));
        TopRight = Cam.ViewportToWorldPoint(new Vector2(1, 1));
        Debug.Log(TopRight);
        GameObject _wallPrefab = (GameObject)Resources.Load("WoodWall");
        GameObject bottomWall = GameObject.Instantiate(_wallPrefab, (BottomLeft + BottomRight) / 2, new Quaternion());
        bottomWall.transform.localScale = new Vector3(TopRight.x / 2, bottomWall.transform.localScale.y,1);

        GameObject rightWall = GameObject.Instantiate(_wallPrefab,(BottomRight + TopRight) / 2, new Quaternion());
        rightWall.transform.localScale = new Vector3(rightWall.transform.localScale.x, TopRight.y, 1);

        GameObject topWall = GameObject.Instantiate(_wallPrefab, (TopRight + TopLeft) / 2, new Quaternion());
        topWall.transform.localScale = new Vector3(TopRight.x / 2, topWall.transform.localScale.y, 1);

        GameObject leftWall = GameObject.Instantiate(_wallPrefab, (TopLeft + BottomLeft) / 2, new Quaternion());
        leftWall.transform.localScale = new Vector3(leftWall.transform.localScale.x, TopRight.y, 1);
        //Debug.Log(Screen.width);
        //Debug.Log(Screen.height);
    }
}
