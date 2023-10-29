using Bluegravity.Game.Item;
using Bluegravity.Game.Player;
using Bluegravity.Game.Economy;
using Bluegravity.Game.Save;

namespace Bluegravity.Game.Clothes
{
    public class StoreItem : IPurchaseItem
    {
        private PlayerClotheSO _clothe;

        public StoreItem(PlayerClotheSO playerClotheSO)
        {
            _clothe = playerClotheSO;
        }

        public bool IsPurchased()
        {
            return SaveManager.Instance.IsPurchased(_clothe.Id);
        }

        public void OnBuyPressed()
        {
            if (EconomyControll.Instance.SpendMoney(_clothe.GetPrice()))
            {
                SaveManager.Instance.AddItem(_clothe.Id);
                PlayerBehaviour.Instance.WearClothe(_clothe);
            }
        }

        public void OnSellPressed()
        {
            if (IsPurchased())
            {
                SaveManager.Instance.RemoveItem(_clothe.Id);
                EconomyControll.Instance.AddMoney(_clothe.GetPrice());
            }
        }
    }

}