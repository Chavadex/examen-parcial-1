using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDataSet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private Transform player;
    [SerializeField] private float offsetPosition;

    private void Start()
    {
        string playerNamePref = PlayerPrefs.GetString("UserName", "");

        playerName.text = playerNamePref;
    }

    private void Update()
    {
        playerName.gameObject.transform.position = new Vector3(player.position.x, player.position.y + offsetPosition, player.position.z);
    }
}
