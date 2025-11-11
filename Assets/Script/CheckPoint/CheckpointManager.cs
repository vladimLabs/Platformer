using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] private CheckPoint[] checkPoints;
    [SerializeField] private GameObject player;
    private int lastCheckPoint;

    private void Start()
    {
        int index = 0;

        foreach (var item in checkPoints)
        {
            item.SetCheckPoint(index, this);
            index++;
        }

        lastCheckPoint = PlayerPrefs.GetInt("CheckPoint");

        player.transform.position = checkPoints[lastCheckPoint].transform.position;
    }

    public void SetCurrentCheckPoint(int index)
    {
        print(index);
        lastCheckPoint = index;
        PlayerPrefs.SetInt("CheckPoint", index);
    }

}
