using Bluegravity.Game.Economy;
using Bluegravity.Game.Inventory;
using Bluegravity.Game.Save;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DevBuildTools : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField]
    [Scene]
    private string _menuScene;


    #region UI Methods

    public void SetMoney(TMP_InputField _amount)
    {
        float value;
        try
        {
            value = float.Parse(_amount.text);
        }
        catch
        {
            value = 0;
        }


        if (EconomyControll.Instance == null)
        {
            InventoryData _data = InventoryData.LoadJson();
            _data.SetGold(value);
            InventoryData.SaveToJson(_data);
        }
        else
        {
            EconomyControll.Instance.SetMoney(value);
        }
    }


    public void GoToMenu()
    {
        SceneManager.LoadSceneAsync(_menuScene, LoadSceneMode.Single);
    }
    #endregion
}
