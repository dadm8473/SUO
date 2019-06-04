using UnityEngine;
using System.Collections;
using DatabaseControl;
using UnityEngine.SceneManagement;

public class UserAccountManager : MonoBehaviour
{
    public static UserAccountManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);
    }

    public static string LoggedIn_Username { get; protected set; }
    private static string LoggedIn_Password = "";

    public static bool IsLoggedIn { get; protected set; }

    public string loggedInSceneName = "Lobby";
    public string loggedOutSceneName = "LoginMenu";

    public delegate void OnDataReceivedCallback(string data);

    public void LogOut()
    {
        LoggedIn_Username = "";
        LoggedIn_Password = "";

        IsLoggedIn = false;

        Debug.Log("User logged out!");

        SceneManager.LoadScene(loggedOutSceneName);
    }

    public void LogIn(string username, string password)
    {
        LoggedIn_Username = username;
        LoggedIn_Password = password;

        IsLoggedIn = true;

        Debug.Log("Logged in as " + username);

        SceneManager.LoadScene(loggedInSceneName);
    }

    public void SendData(string data)
    {
        if (IsLoggedIn)
        {
            StartCoroutine(sendSendDataRequest(LoggedIn_Username, LoggedIn_Password, data));
        }
    }

    IEnumerator sendSendDataRequest(string username, string password, string data)
    {
        IEnumerator eee = DC.SetUserData(username, password, data);
        while (eee.MoveNext())
        {
            yield return eee.Current;
        }
        WWW returneddd = eee.Current as WWW;
        if (returneddd.text == "ContainsUnsupportedSymbol")
        {
            Debug.Log("Data Upload Error. Could be a server error. To check try again, if problem still occurs, contact us.");
        }
        if (returneddd.text == "Error")
        {
            Debug.Log("Data Upload Error: Contains Unsupported Symbol '-'");
        }
    }

    public void GetData(OnDataReceivedCallback onDataReceived)
    {

        if (IsLoggedIn)
        {
            StartCoroutine(sendGetDataRequest(LoggedIn_Username, LoggedIn_Password, onDataReceived));
        }
    }

    IEnumerator sendGetDataRequest(string username, string password, OnDataReceivedCallback onDataReceived)
    {
        string data = "ERROR";

        IEnumerator eeee = DC.GetUserData(username, password);
        while (eeee.MoveNext())
        {
            yield return eeee.Current;
        }
        WWW returnedddd = eeee.Current as WWW;
        if (returnedddd.text == "Error")
        {
            Debug.Log("Data Upload Error. Could be a server error. To check try again, if problem still occurs, contact us.");
        }
        else
        {
            if (returnedddd.text == "ContainsUnsupportedSymbol")
            {
                Debug.Log("Get Data Error: Contains Unsupported Symbol '-'");
            }
            else
            {
                string DataRecieved = returnedddd.text;
                data = DataRecieved;
            }
        }

        if (onDataReceived != null)
            onDataReceived.Invoke(data);
    }
}