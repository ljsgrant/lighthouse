using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

    public class LevelControl : Interactable

    {
        // name of level to load, defined in Unity editor
        [SerializeField] private string loadLevel;

        // coroutine that changes the level to level defined by loadLevel
        public void ChangeLevel()
        {
            StartCoroutine(LoadYourAsyncScene());
        }

    public override void Interact()
    {
        ChangeLevel();
        Debug.Log("Change level");
    }

    IEnumerator LoadYourAsyncScene()
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadLevel);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }
//}
