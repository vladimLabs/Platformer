using UnityEngine;
using GameAnalyticsSDK;
using System.Collections.Generic;
public class GameAnalyticsManager : MonoBehaviour
    , IGameAnalyticsATTListener


{
    public static GameAnalyticsManager instance;
    private static Dictionary<string, object> parameters;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }
    void Start()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            GameAnalytics.RequestTrackingAuthorization(this);
        }
        else
        {
            GameAnalytics.Initialize();
        }
    }


    public void GameAnalyticsATTListenerNotDetermined()
    {
        GameAnalytics.Initialize();
    }
    public void GameAnalyticsATTListenerRestricted()
    {
        GameAnalytics.Initialize();
    }
    public void GameAnalyticsATTListenerDenied()
    {
        GameAnalytics.Initialize();
    }
    public void GameAnalyticsATTListenerAuthorized()
    {
        GameAnalytics.Initialize();
    }


    public static void FunnelFinished(int stepNumer, string stepName)
    {
        string startStepName = "finishStepNum_" + stepNumer.ToString();
        if (!PlayerPrefs.HasKey(startStepName))
        {
            string missionFinalName = stepNumer.ToString() + " " + stepName;
            LogMissionComplete(missionFinalName);
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, missionFinalName);
            Debug.Log("funnel event: " + missionFinalName);
            PlayerPrefs.SetInt(startStepName, 1);
        }
    }


    private static void LogMissionComplete(string missionName)
    {
        parameters = new Dictionary<string, object>();
        parameters.Add("missionName", missionName);
    }

    public static void Money(int money)
    {
        GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, "coins", money, "picked", "reward");
    }

    public static void Shop()
    {
        GameAnalytics.NewDesignEvent("Shop:opened");
    }

    public static void ErrorEvent()
    {
        GameAnalytics.NewErrorEvent(GAErrorSeverity.Warning,"Error:fall");
    }

}
