using System;
using System.Collections.Generic;

namespace p01_lambda
{
    enum ItemType
    {
        Weapon,
        Armor,
        Amulet,
        Ring
    }

    enum Rarity
    {
        Normal,
        Uncommon,
        Rare
    }

    class Item
    {
        public ItemType ItemType;
        public Rarity Rarity;
    }

    class Program
    {
        static List<Item> _items = new List<Item>();
        delegate bool ItemSelector(Item item);

        static bool IsWeapon(Item item)
        {
            return item.ItemType == ItemType.Weapon;
        }

        /*static Item FindItem(ItemSelector selector)
        {
            foreach(Item item in _items)
            {
                if(selector(item))
                    return item;
            }
            return null;
        }*/

        delegate Return MyFunc<T, Return>(T item);

        static Item FindItem(MyFunc<Item, bool> selector)
        {
            foreach (Item item in _items)
            {
                if (selector(item))
                    return item;
            }
            return null;
        }

        static Item FindWeapon()
        {
            foreach (Item item in _items)
            {
                if (item.ItemType == ItemType.Weapon)
                    return item;
            }
            return null;
        }

        static Item FindRareItem()
        {
            foreach (Item item in _items)
            {
                if (item.Rarity == Rarity.Rare)
                    return item;
            }
            return null;
        }



        static void Main(string[] args)
        {

            _items.Add(new Item() { ItemType = ItemType.Weapon, Rarity = Rarity.Normal });
            _items.Add(new Item() { ItemType = ItemType.Armor, Rarity = Rarity.Uncommon });
            _items.Add(new Item() { ItemType = ItemType.Ring, Rarity = Rarity.Rare });

            //ItemSelector selector = new ItemSelector((Item item) => { return item.ItemType == ItemType.Weapon; });
            //Item item = FindItem(selector);

            //Lambda : 일회용 함수를 만드는데 사용하는 문법이다.
            //Item item = FindItem(IsWeapon);
            //아래 코드로 가능 (Anonymous Function : 무명 함수 / 익명 함수)
            //Item item = FindItem(delegate (Item item) {
            //    return item.ItemType == ItemType.Weapon;
            //});
            //람다식
            Item item = FindItem((Item item) => { return item.ItemType == ItemType.Weapon; });

            //MyFunc<Item, bool> selector = new MyFunc<Item, bool>((Item item) => { return item.ItemType == ItemType.Weapon; });
            //MyFunc<Item, bool> selector = (Item item) => { return item.ItemType == ItemType.Weapon; };

            Func<Item, bool> selector = (Item item) => { return item.ItemType == ItemType.Weapon; };

            /**
             * delegate를 직접 선언하지 않아도, 이미 만들어진 애들이 존재한다.
             * -> 반환 타입이 있을 경우 Func
             * -> 반환 타입이 없을 경우 Action
             */

        }
    }
}
