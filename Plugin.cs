using BepInEx;
using ComputerPlusPlus;
using GorillaNetworking;
using Photon.Pun;
using UnityEngine;

[BepInPlugin("com.pyluadotcode.gorillatag.StatusScreen", "StatusScreen", "1.0.0")]
[BepInDependency("com.kylethescientist.gorillatag.computerplusplus")]
public class FrameChecker : BaseUnityPlugin 
{
    private static int FrameRate;
    private static int FPS;
    public static int fps
    {
        get { return FrameRate; }
        set { FrameRate = value; }

    }

    public void Update()
    {
        float current = 0;
        current = Time.frameCount / Time.time;
        
    }
}

public class Status : IScreen
{
    public string name = "";

    public string Result = "";

    public string Title => "Status";

    public string Description => "This is a simple mod that adds a Status Page. This mod was created by pylua.code";


    public string GetContent()
    {
        
        if (PhotonNetwork.InRoom)
        {
            name = "Name: " + GorillaComputer.instance.currentName + "\n";
            string room = "Room: " + PhotonNetwork.CurrentRoom.Name + "\n";
            string roomplay = "Player Count: " + PhotonNetwork.CurrentRoom.PlayerCount + "\n";
            string gmod = "Game Mode: " + GorillaComputer.instance.currentGameMode + "\n";
            string master = "Master Client: " + PhotonNetwork.MasterClient + "\n";
            string color = "Color Code: " + GorillaTagger.Instance.offlineVRRig.playerColor + "\n";
            string fps = "FPS: " + FrameChecker.fps + "\n";
            if (gmod == "Game Mode: MODDED_MODDED_CASUALCASUAL\n")
                gmod = "Game Mode: Modded_Casual\n";
            Result = name + room + roomplay + gmod + master;
        }
        else
            Result = ("Name: " + GorillaComputer.instance.currentName + "\n" + "Color Code: " + GorillaTagger.Instance.offlineVRRig.playerColor + "\n" + "FPS: " + FrameChecker.fps);
        return (Result);
    }

    public void OnKeyPressed(GorillaKeyboardButton button)
    { }



    public void Start() { }
}