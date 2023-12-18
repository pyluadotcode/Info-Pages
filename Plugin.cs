using BepInEx;
using ComputerPlusPlus;
using GorillaNetworking;
using Photon.Pun;
using System;
using UnityEngine;

[BepInPlugin("com.pyluadotcode.gorillatag.StatusScreen", "StatusScreen", "1.0.0")]
[BepInDependency("com.kylethescientist.gorillatag.computerplusplus")]
public class Plugin : BaseUnityPlugin 
{}

public class Status : IScreen
{
    public string name = "";

    public string Result = "";

    public string Title => "Status";

    public string Description => "This is a simple mod that adds a Status Page. This mod was created by pylua.code";

    //public int Frames;

    public string GetContent()
    {
        
        if (PhotonNetwork.InRoom)
        {
            // Frames = (int)Math.Round(1.0f / Time.unscaledDeltaTime);
            name = "Name: " + GorillaComputer.instance.currentName + "\n";
            string room = "Room: " + PhotonNetwork.CurrentRoom.Name + "\n";
            string roomplay = "Player Count: " + PhotonNetwork.CurrentRoom.PlayerCount + "\n";
            string gmod = "Game Mode: " + GorillaComputer.instance.currentGameMode + "\n";
            string master = "Master Client: " + PhotonNetwork.MasterClient + "\n";
            string color = "Color Code: " + (Color32)GorillaTagger.Instance.offlineVRRig.playerColor + "\n";
            if (gmod == "Game Mode: MODDED_MODDED_CASUALCASUAL\n")
                gmod = "Game Mode: Modded_Casual\n";
            Result = name + room + roomplay + gmod + master + color;
        }
        else
            Result = ("Name: " + GorillaComputer.instance.currentName + "\n" + "Color Code: " + (Color32)GorillaTagger.Instance.offlineVRRig.playerColor + "\n");
        return (Result);
    }

    public void OnKeyPressed(GorillaKeyboardButton button)
    { }



    public void Start() { }
}
