using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Text.RegularExpressions;
using UnityEngine;

public class OpstellingLezen : NetworkBehaviour {
    public Transform tower;

    public const string stower = "1";

    public int player_id;

    // Use this for initialization
    void Start() {
        opstellingLezen(Application.dataPath + "/_Opstellingen/Test_player1.txt", 0);
        opstellingLezen(Application.dataPath + "/_Opstellingen/Test_player2.txt", 1);
    }

    // Update is called once per frame
    void Update() {
        Debug.Log(player_id);
    }

    //Method voor filereading
    string[][] readFile(string file)
    {
        string text = System.IO.File.ReadAllText(file);
        string[] lines = Regex.Split(text, "\r\n");
        int rows = lines.Length;

        string[][] levelBase = new string[rows][];
        for (int i = 0; i < lines.Length; i++)
        {
            string[] stringsOfLine = Regex.Split(lines[i], " ");
            levelBase[i] = stringsOfLine;
            Debug.Log(levelBase[i]);
        }
        return levelBase;
    }

    //Method voor opstelling lezen uit de file
    void opstellingLezen(string pad, int playerID)
    {
        string[][] opstelling = readFile(pad);
        switch (playerID)
        {
            case 0:
                for (int z = 0; z < opstelling.Length; z++)
                {
                    for (int x = 0; x < opstelling[0].Length; x++)
                    {
                        switch (opstelling[z][x])
                        {
                            case stower:
                                Instantiate(tower, new Vector3(x, 0.5f, z), Quaternion.identity);
                                break;
                            default:
                                break;
                        }
                    }
                }
                break;
            case 1:
                for (int z = 0; z < opstelling.Length; z++)
                {
                    for (int x = 0; x < opstelling[0].Length; x++)
                    {
                        switch (opstelling[z][x])
                        {
                            case stower:
                                Instantiate(tower, new Vector3(x , 0.5f, z + 8), Quaternion.identity);
                                break;
                            default:
                                break;
                        }
                    }
                }
                break;
            default:
                break;
        }

    }

    //PlayerID
    public override void OnStartLocalPlayer()
    {
        player_id = isServer ? 0 : 1;
        if (player_id == 1)
        {
            CmdSetID(player_id);
        }
    }

    [Command]
    void CmdSetID(int id)
    {
        player_id = id;
    }
}
