using UnityEngine;
using InnerNet;
using System.Linq;
using Il2CppSystem.Collections.Generic;
using System.IO;
using Hazel;
using System.Reflection;
using AmongUs.GameOptions;
using Sentry.Internal.Extensions;
using Il2CppSystem.Net.NetworkInformation;

namespace MalumMenu;
public static class x
{
    public static bool z;
    
    public static void y(HudManager hudManager)
    {
        if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            if (!z)
            {
            Camera.main.gameObject.GetComponent<FollowerCamera>().enabled = false;
            Camera.main.gameObject.GetComponent<FollowerCamera>().Target = null;
            Camera.main.transform.position = new Vector3(20.5f, -13.0f, 0.0f);
            Camera.main.orthographicSize = 13.8f;
            hudManager.UICamera.orthographicSize = 13.8f;
            Utils.adjustResolution();
            z = true;
            }else{
            Camera.main.gameObject.GetComponent<FollowerCamera>().enabled = true;
            Camera.main.gameObject.GetComponent<FollowerCamera>().SetTarget(PlayerControl.LocalPlayer);
            Camera.main.orthographicSize = 3f;
            hudManager.UICamera.orthographicSize = 3f;
            Utils.adjustResolution();
            z = false;
            }
        }
    }
    public static void zz()
    {
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            var HostData = AmongUsClient.Instance.GetHost();
            if (HostData != null && !HostData.Character.Data.Disconnected)
            {
                foreach (PlayerTask task in PlayerControl.LocalPlayer.myTasks)
                {
                    if (!task.IsComplete){
                        foreach (var item in PlayerControl.AllPlayerControls)
                        {
                            MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)RpcCalls.CompleteTask, SendOption.None, AmongUsClient.Instance.GetClientIdFromCharacter(item));
                            messageWriter.WritePacked(task.Id);
                            AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                        }
					    return;
                    }
                }
            }
        }
    }
}
