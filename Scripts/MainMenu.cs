using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator animator;

    public void PlayGame()
    {
        StartCoroutine(LoadLevel("MainFrame"));
    }

    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator LoadLevel(string levelName)
    {
        // play animation
        animator.SetTrigger("Start");

        // wait
        yield return new WaitForSeconds(1);

        // load scnene
        SceneManager.LoadScene(levelName);
    }
}
