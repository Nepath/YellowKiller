using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class QuitGame : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isLocalPlayer)
        {
            if(isServer)
                NetworkManager.singleton.StopHost();
            else
            NetworkManager.singleton.StopClient();
            SceneManager.LoadScene("Menu");
        }
    }
}
