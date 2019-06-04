using UnityEngine;
using System.Collections;

public class Killfeed : MonoBehaviour {

    [SerializeField]
    GameObject killfeedItemPrefab;

	void Start ()
    {
        GameManager.instance.onPlayerKilledCallback += OnKill;
	}

    public void OnKill(string player, string source)
    {
        //Debug.Log(source + " killed " + player);
        GameObject go = (GameObject)Instantiate(killfeedItemPrefab, this.transform);
        go.GetComponent<KillfeedItem>().Setup(player, source);
        Destroy(go, 3f);
    }
}
