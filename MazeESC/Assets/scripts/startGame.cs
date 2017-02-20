using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class startGame : MonoBehaviour {

  public int sceneToLoad;

  void OnGUI()
  {
    GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height - 80, 100,30), "*MazeESC* ");
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height - 50, 100, 40), "START GAME " + (sceneToLoad + 1)))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
  }
}
