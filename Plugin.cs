using BepInEx;
using ComputerPlusPlus;
using GorillaNetworking;
using Photon.Pun;
using Photon;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.Rendering;
using Utilla;

namespace InfoPages 
{
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin("io.github.pylua-dot-code.GorillaTag.InfoPages", "Info Pages", "2.0.0")]
    public class Plugin : BaseUnityPlugin
    {
    
    }

    internal class Screen : IScreen
    {
        public string name = "Info";

        public string Title => "Info Pages:";

        public string Description => ""; // Disables Header

        public int Page = 0; // Pages go 0-2

        public string CustomHeader = "ERROR:";

        public string Content = "This mod broke, please contact @static_code";

        public bool agree = false;

        public string GetContent()
        {
            // Custom Header Manager
            if (Page == 0)
            {
                CustomHeader = "<color=blue> Player Info:</color> \n";
            }
            if (Page == 1) 
            {
                CustomHeader = "<color=blue> Game Info:</color> \n";
            }
            if (Page == 2)
            {
                CustomHeader = "<color=blue> Support Page:</color> \n";
            }
            // Content Manager
            if (Page == 0)
            {
                string Name = "Name: " + GorillaComputer.instance.currentName + "\n";
                string Color = "Color Code: " + (Color32)GorillaTagger.Instance.offlineVRRig.playerColor + "\n";
                Content = Name + Color;
            }
            if (Page == 1)
            {
                if(!PhotonNetwork.InRoom)
                {
                    Content = "You are not in a room";
                }
                else
                {
                    string rname = "Room Code: " + PhotonNetwork.CurrentRoom.Name + "\n";
                    string proom = "Player Count: " + PhotonNetwork.CurrentRoom.PlayerCount + "\n";
                    string master = "Master Client: " + PhotonNetwork.MasterClient + "\n";
                    string gamemode = "Game Mode: " + GorillaComputer.instance.currentGameMode + "\n";
                    if (gamemode == "Game Mode: MODDED_MODDED_CASUALCASUAL\n")
                        gamemode = "Game Mode: Modded_Casual\n";
                    Content = rname + proom + master + gamemode;
                }
            }
            if (Page == 2)
            {
                if(agree)
                {
                    Content = "Player ID: " + PhotonNetwork.LocalPlayer.UserId;
                }
                else
                {
                    Content = "Press option 1 to display user id. DO NOT SHARE THIS WITH ANYONE";
                }
            }
            // Display
            return (CustomHeader + Content);
        }

        public void OnKeyPressed(GorillaKeyboardButton button)
        {
            if(button.characterString == "D") 
            {
                Page += 1;
                agree = false;
            }
            if(button.characterString == "A")
            {
                Page -= 1;
                agree = false;
            }
            if(Page < 0) 
            {
                Page = 2;
            }
            if (Page > 2)
            {
                Page = 0;
            }
            if(button.characterString == "option1")
            {
                agree = true;
            }

        }
        public void Start() { }
    }
}