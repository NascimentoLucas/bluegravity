using Bluegravity.Game.Item;
using Bluegravity.Game.Player;
using Bluegravity.Game.Economy;
using Bluegravity.Game.Save;

namespace Bluegravity.Game.Clothes
{
    public class StoreBuyItem : IPurchaseItem
    {
        private PlayerClotheSO _clothe;

        public StoreBuyItem(PlayerClotheSO playerClotheSO)
        {
            _clothe = playerClotheSO;
        }

        public bool IsPurchased()
        {
            return SaveManager.Instance.IsPurchased(_clothe.Id);
        }

        public void OnPressed()
        {
            if (EconomyControll.Instance.SpendMoney(_clothe.GetPrice()))
            {
                SaveManager.Instance.AddItem(_clothe.Id);
                PlayerBehaviour.Instance.WearClothe(_clothe);
            }
        }
    }


    public class StoreSellItem : IPurchaseItem
    {
        private PlayerClotheSO _clothe;

        public StoreSellItem(PlayerClotheSO playerClotheSO)
        {
            _clothe = playerClotheSO;
        }

        public bool IsPurchased()
        {
            return SaveManager.Instance.IsPurchased(_clothe.Id);
        }

        public void OnPressed()
        {
            if (SaveManager.Instance.IsPurchased(_clothe.Id))
            {
                EconomyControll.Instance.AddMoney(_clothe.GetPrice());
                SaveManager.Instance.RemoveItem(_clothe.Id);
            }
        }
    }

}