using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodShop : MonoBehaviour
{
    public static FoodShop FoodShops;

    public List<Food> foodlist = new List<Food>();

    private List<GameObject> buyButtonList = new List<GameObject>();

    private bool warningActive = false;
    public GameObject WarningImage;
    public GameObject prefab;
    public Transform grid;
    public GameObject player;
    public GameObject Marker;
  
    // Use this for initialization
    void Start()
    {
        FoodShops = this;
        FillList();
        WarningImage.SetActive(false);
    }

    // Update is called once per frae
    void Update()
    {

    }
    void FillList()
    {
        for (int i = 0; i < foodlist.Count; i++)
        {
            GameObject holder = Instantiate(prefab,grid, false);
            ItemHolder holderScript = holder.GetComponent<ItemHolder>();
            vAddItemByID addItem = holder.GetComponent<vAddItemByID>();
            BuyCar CarBuy = holder.GetComponent<BuyCar>();

            
            holderScript.ItemName.text = foodlist[i].FoodName;
            holderScript.ItemPrice.text = "$ " + foodlist[i].FoodPrice.ToString("N2");
            holderScript.ItemID = foodlist[i].FoodID;
            holderScript.ItemImage.sprite = foodlist[i].SpriteImage;

            
            

            holderScript.buyButton.GetComponent<BuyFood>().FoodID = foodlist[i].FoodID;

            addItem.id = foodlist[i].FoodID;
            addItem.GameObj = player;
        }
    }

    public IEnumerator showWarning()
    {
        if(warningActive)
        {
            yield break;

        }
        warningActive = true;


        WarningImage.SetActive(true);
        yield return new WaitForSeconds(2f);


        WarningImage.SetActive(false);
        warningActive = false;
    }
}
 
