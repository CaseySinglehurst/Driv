using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuAIController : MonoBehaviour {

    public TextMeshProUGUI moneyText;

    private void Update()
    {
        moneyText.text = ServerController.instance.coins.ToString();
    }
}
