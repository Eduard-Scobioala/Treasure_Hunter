using System;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManagement : MonoBehaviour
{
    [SerializeField] private Text nrOfCoins;

    public void ChangeNrOfCoins(int _value)
    {
        nrOfCoins.text = (int.Parse(nrOfCoins.text) + _value).ToString();
    }
}
