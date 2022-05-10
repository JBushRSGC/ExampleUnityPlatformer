using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    public Text displayText;
    public PlayerMovement playerMovement;

    private void Start()
    {
        displayText = GetComponent<Text>();
    }

    private void Update()
    {
        displayText.text = playerMovement.coins.ToString();
    }
}
