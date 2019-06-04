using UnityEngine;
using UnityEngine.Networking;

public class HostGame : MonoBehaviour {

    [SerializeField]
    private uint roomSize = 6;

    private string roomName;

    private NetworkManager networkManager;

    void Start()
    {
        networkManager = NetworkManager.singleton;
        if(networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void SetRoomName(string _name)
    {
        roomName = _name;
    }

    public void CreatRoom()
    {
        if(roomName != "" && roomName != null)
        {
            Debug.Log("생성된 방 : " + roomName + "입장가능한 플레이어 수 : " + roomSize + " 명");
            networkManager.matchMaker.CreateMatch(roomName, roomSize, true, "", "", "", 0 , 0, networkManager.OnMatchCreate);
        }
    }
}
