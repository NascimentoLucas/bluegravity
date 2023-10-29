using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bluegravity.Game.Item
{
    public interface IViewItem
    {
        float GetPrice();
        string GetName();
        Sprite GetIcon();
    }

    public interface IPurchaseItem
    {
        void OnBuyPressed();
        void OnSellPressed();
        bool IsPurchased();

    }
}