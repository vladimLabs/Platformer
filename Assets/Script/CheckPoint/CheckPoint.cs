using UnityEngine;

public class CheckPoint : MonoBehaviour, IPickable
{
    private int checkPointIndex = 0;
    private CheckpointManager checkpointManager = null;

    public void SetCheckPoint(int index, CheckpointManager manager)
    {
        checkPointIndex = index;
        checkpointManager = manager;
    }

    public void PickUp()
    {
        checkpointManager.SetCurrentCheckPoint(checkPointIndex);
        GameAnalyticsManager.FunnelFinished(checkPointIndex, "checkPoint");
    }
}
