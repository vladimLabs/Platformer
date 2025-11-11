using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject[] heart;
    private int heartCount = 0;

    public void ChangeHeartsCount(int heartToChange)
    {
        heartCount += heartToChange;
        for (int i = 0; i < heart.Length ; i++)
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
        heartCount = heart.Length;
    }
}
