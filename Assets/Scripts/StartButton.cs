using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private Animator Transition;

    IEnumerator LoadMenu(int levelIndex)
    {
        Transition.SetTrigger("End");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        Transition.SetTrigger("End");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(levelIndex);
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void LoadNextMenu()
    {
        StartCoroutine(LoadMenu(0));
    }
}
