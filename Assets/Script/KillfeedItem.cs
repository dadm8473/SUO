using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KillfeedItem : MonoBehaviour {

    [SerializeField]
    Text text;

    public void Setup(string player, string source)
    {
        text.text = "<b>" + source + "</b>" + " killed " + "<color=red>" + "<i>" + player + "</i>" + "</color>";
    }
}
