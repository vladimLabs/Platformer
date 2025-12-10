using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> heart;
    [SerializeField] private GameObject heartImg;
    [SerializeField] private GameObject heartUI;
    private int heartCount = 0;

    public void ChangeHeartsCount(int heartToChange)
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

    private void Start()
    {
        heartCount = heart.Count;
    }

    public void AddHp()
    {
        heart.Add(Instantiate(heartImg, heartUI.transform));
    }
}
