using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> heart;
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private Transform heartParent;
    private float heartCount = 0;

    public void ChangeHeartsCount(float heartToChange)
    {
        heartCount += heartToChange;
        for (int i = 0; i < heart.Count ; i++)
        {
            if (i <= heartCount - 1)
            {
                heart[i].SetActive(true);
            }
            else
            {
                heart[i].SetActive(false);
            }
        }
    }

    public void AddHeart()
    {
       heart.Add(Instantiate(heartPrefab, heartParent));
       ChangeHeartsCount(1);
       PlayerPrefs.SetInt("HP", heart.Count);
    }
    private void Start()
    {
        if (PlayerPrefs.GetInt("HP") == 0)
        {
            PlayerPrefs.SetInt("HP", heart.Count);
            heartCount = heart.Count;
        }
        else
        {
            int count = PlayerPrefs.GetInt("HP");
            print(count);
            for (int i = 0; i < count; i++)
            {
                if (i >= heart.Count)
                {
                    heart.Add(Instantiate(heartPrefab, heartParent));
                    heartCount = heart.Count;
                    ChangeHeartsCount(1);
                }
            }
        }
    }
}
