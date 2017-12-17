using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {
    public int player_id = -1;

    public override void OnStartLocalPlayer() {
        GetComponent<Camera>().enabled = true;
        player_id = isServer ? 0 : 1;
        if (player_id == 1) {
            CmdSetID(player_id);
        }
        if (player_id == 0) {
            transform.position = new Vector3(4.5f, 8, -1);
            transform.rotation = Quaternion.Euler(60, 0, 0);
        } else {
            transform.position = new Vector3(4.5f, 8, 10);
            transform.rotation = Quaternion.Euler(60, 180, 0);
        }
    }

    [Command]
    void CmdSetID(int id) {
        player_id = id;
    }
}
