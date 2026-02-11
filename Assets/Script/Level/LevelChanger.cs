using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(false);
        }
    }

    public void ChangeLevel(int Index)
    {
        StartCoroutine(Delay(Index));
    }

    IEnumerator Delay(int Index)
    {
        PlayerPrefs.SetInt("Level", Index);
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene(Index);
    }
}
