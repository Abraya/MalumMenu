using UnityEngine;
using Sentry.Internal.Extensions;

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
}
