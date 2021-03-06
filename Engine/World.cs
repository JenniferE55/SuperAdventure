﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class World
    {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();

        public const int ITEM_ID_RUSTY_SWORD = 1;
        public const int ITEM_ID_RAT_TAIL = 2;
        public const int ITEM_ID_PIECE_OF_FUR = 3;
        public const int ITEM_ID_SNAKE_FANG = 4;
        public const int ITEM_ID_SNAKESKIN = 5;
        public const int ITEM_ID_CLUB = 6;
        public const int ITEM_ID_HEALING_POTION = 7;
        public const int ITEM_ID_SPIDER_FANG = 8;
        public const int ITEM_ID_SPIDER_SILK = 9;
        public const int ITEM_ID_ADVENTURER_PASS = 10;
        public const int ITEM_ID_DULL_SWORD = 11;
        public const int ITEM_ID_REGULAR_SWORD = 12;
        public const int ITEM_ID_BALSA_WOOD_SHIELD = 13;
        public const int ITEM_ID_FABRIC_HELMET = 14;
        public const int ITEM_ID_FABRIC_BREASTPLATE = 15;
        public const int ITEM_ID_FABRIC_PANTS = 16;

        public const int MONSTER_ID_RAT = 1;
        public const int MONSTER_ID_SNAKE = 2;
        public const int MONSTER_ID_GIANT_SPIDER = 3;

        public const int QUEST_ID_CLEAR_ALCHEMIST_GARDEN = 1;
        public const int QUEST_ID_CLEAR_FARMERS_FIELD = 2;

        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_TOWN_SQUARE = 2;
        public const int LOCATION_ID_GUARD_POST = 3;
        public const int LOCATION_ID_ALCHEMIST_HUT = 4;
        public const int LOCATION_ID_ALCHEMISTS_GARDEN = 5;
        public const int LOCATION_ID_FARMHOUSE = 6;
        public const int LOCATION_ID_FARM_FIELD = 7;
        public const int LOCATION_ID_BRIDGE = 8;
        public const int LOCATION_ID_SPIDER_FIELD = 9;
        public const int LOCATION_ID_SHOP = 10;

        static World()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopulateLocations();
        }

        private static void PopulateItems()
        {
            Items.Add(new Weapon(ITEM_ID_RUSTY_SWORD, "Rusty sword", "Rusty swords", 10, 0, 5));
            Items.Add(new Item(ITEM_ID_RAT_TAIL, "Rat tail", "Rat tails", 8));
            Items.Add(new Item(ITEM_ID_PIECE_OF_FUR, "Piece of fur", "Pieces of fur", 4));
            Items.Add(new Item(ITEM_ID_SNAKE_FANG, "Snake fang", "Snake fangs", 8));
            Items.Add(new Item(ITEM_ID_SNAKESKIN, "Snakeskin", "Snakeskins", 4));
            Items.Add(new Weapon(ITEM_ID_CLUB, "Club", "Clubs", 50, 2, 7));
            Items.Add(new HealingPotion(ITEM_ID_HEALING_POTION, "Healing potion", "Healing potions", 20, 10));
            Items.Add(new Item(ITEM_ID_SPIDER_FANG, "Spider fang", "Spider fangs", 10));
            Items.Add(new Item(ITEM_ID_SPIDER_SILK, "Spider silk", "Spider silks", 16));
            Items.Add(new Item(ITEM_ID_ADVENTURER_PASS, "Adventurer pass", "Adventurer passes", 0));
            Items.Add(new Weapon(ITEM_ID_DULL_SWORD, "Dull sword", "Dull swords", 100, 3, 8));
            Items.Add(new Weapon(ITEM_ID_REGULAR_SWORD, "Regular sword", "Regular swords", 200, 4, 15));
            Items.Add(new Armor(ITEM_ID_BALSA_WOOD_SHIELD, "Balsa wood shield", "Balsa wood shields", 10, 1, "Shield"));
            Items.Add(new Armor(ITEM_ID_FABRIC_HELMET, "Fabric helmet", "Fabric helmets", 10, 1, "Helmet"));
            Items.Add(new Armor(ITEM_ID_FABRIC_BREASTPLATE, "Fabric breastplate", "Fabric breastplates", 10, 1, "Breastplate"));
            Items.Add(new Armor(ITEM_ID_FABRIC_PANTS, "Pair of fabric pants", "Pairs of fabric pants", 10, 1, "Pants"));
        }

        private static void PopulateMonsters()
        {
            Monster rat = new Monster(MONSTER_ID_RAT, "Rat", 5, 1, 3, 10, 3, 3);
            rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_RAT_TAIL), 75, false));
            rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_PIECE_OF_FUR), 75, true));

            Monster snake = new Monster(MONSTER_ID_SNAKE, "Snake", 5, 2, 3, 10, 3, 3);
            snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKE_FANG), 75, false));
            snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKESKIN), 75, true));

            Monster giantSpider = new Monster(MONSTER_ID_GIANT_SPIDER, "Giant spider", 20, 5, 10, 40, 10, 10);
            giantSpider.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_FANG), 75, true));
            giantSpider.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_SILK), 25, false));

            Monsters.Add(rat);
            Monsters.Add(snake);
            Monsters.Add(giantSpider);
        }

        private static void PopulateQuests()
        {
            List <String>questNotFinishedDialogues = new List<string>();
            questNotFinishedDialogues.Add("Alchemist: Got them rats out yet? Oh, all right.");
            Quest clearAlchemistGarden =
                new Quest(
                    QUEST_ID_CLEAR_ALCHEMIST_GARDEN,
                    "Clear the alchemist's garden",
                    "Kill rats in the alchemist's garden and bring back 3 rat tails. You will receive a healing potion and 10 gold pieces.",
                    20,10,
                    "Alchemist: You there! Get over here! I need your help!" +Environment.NewLine+
                    "Alchemist: I've been having some trouble with some pesky little animals. I can't get into my garden anymore. Help me out?"+Environment.NewLine+
                    "Alchemist: Thanks I really appriciate that. I'll reward you, you won't regret helping me.",
                    questNotFinishedDialogues,
                    "Alchemist: You got me rat tails? To prove to me ya killed 'em? Alright. Thanks.");

            clearAlchemistGarden.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_RAT_TAIL), 3));
            questNotFinishedDialogues.Clear();

            clearAlchemistGarden.RewardItem = ItemByID(ITEM_ID_HEALING_POTION);
            questNotFinishedDialogues.Add("Farmer: Kid! Got me them snake fangs? Ah, I see...");
            questNotFinishedDialogues.Add("Farmer: Ey, snakes gone already?");
            Quest clearFarmersField =
                new Quest(
                    QUEST_ID_CLEAR_FARMERS_FIELD,
                    "Clear the farmer's field",
                    "Kill snakes in the farmer's field and bring back 3 snake fangs. You will receive an adventurer's pass and 20 gold pieces.", 
                    20, 20,
                    "Farmer: Ey! Kid! How 'bout you go out back to the field and do me a lil job, eh?"+Environment.NewLine+
                    "Farmer: Got snakes back there running through my field. Get rid of a few for me, will ya?"+Environment.NewLine+
                    "Farmer: Thanks kid.",
                    questNotFinishedDialogues,
                    "Farmer: Finally did 'em in, did ya? Okay, here's your stuff, as promised."
                    );

            clearFarmersField.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SNAKE_FANG), 3));
            questNotFinishedDialogues.Clear();
            clearFarmersField.RewardItem = ItemByID(ITEM_ID_ADVENTURER_PASS);

            Quests.Add(clearAlchemistGarden);
            Quests.Add(clearFarmersField);
        }

        private static void PopulateLocations()
        {
            // Create each location
            Location home = new Location(LOCATION_ID_HOME, "Home", "Your house. You really need to clean up the place.");

            Location townSquare = new Location(LOCATION_ID_TOWN_SQUARE, "Town square", "You see a fountain.");

            Location alchemistHut = new Location(LOCATION_ID_ALCHEMIST_HUT, "Alchemist's hut", "There are many strange plants on the shelves.");
            alchemistHut.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_ALCHEMIST_GARDEN);

            Location alchemistsGarden = new Location(LOCATION_ID_ALCHEMISTS_GARDEN, "Alchemist's garden", "Many plants are growing here.");
            alchemistsGarden.MonsterLivingHere = MonsterByID(MONSTER_ID_RAT);

            Location farmhouse = new Location(LOCATION_ID_FARMHOUSE, "Farmhouse", "There is a small farmhouse, with a farmer in front.");
            farmhouse.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_FARMERS_FIELD);

            Location farmersField = new Location(LOCATION_ID_FARM_FIELD, "Farmer's field", "You see rows of vegetables growing here.");
            farmersField.MonsterLivingHere = MonsterByID(MONSTER_ID_SNAKE);

            Location guardPost = new Location(LOCATION_ID_GUARD_POST, "Guard post", "There is a large, tough-looking guard here.", ItemByID(ITEM_ID_ADVENTURER_PASS));

            Location bridge = new Location(LOCATION_ID_BRIDGE, "Bridge", "A stone bridge crosses a wide river.");

            Location spiderField = new Location(LOCATION_ID_SPIDER_FIELD, "Forest", "You see spider webs covering covering the trees in this forest.");
            spiderField.MonsterLivingHere = MonsterByID(MONSTER_ID_GIANT_SPIDER);

            List<Item> shop1Items = new List<Item>();
            shop1Items.Add(World.ItemByID(ITEM_ID_HEALING_POTION));
            shop1Items.Add(World.ItemByID(ITEM_ID_RUSTY_SWORD));
            shop1Items.Add(World.ItemByID(ITEM_ID_CLUB));
            shop1Items.Add(World.ItemByID(ITEM_ID_DULL_SWORD));
            shop1Items.Add(World.ItemByID(ITEM_ID_REGULAR_SWORD));
            shop1Items.Add(World.ItemByID(ITEM_ID_BALSA_WOOD_SHIELD));
            shop1Items.Add(World.ItemByID(ITEM_ID_FABRIC_HELMET));
            shop1Items.Add(World.ItemByID(ITEM_ID_FABRIC_BREASTPLATE));
            shop1Items.Add(World.ItemByID(ITEM_ID_FABRIC_PANTS));
            Location shop1 = new Shop(LOCATION_ID_SHOP, "Shop", "You see a man behind a dusty counter, a display set in front of him with prices to each item.", shop1Items);

            // Link the locations together
            home.LocationToNorth = townSquare;

            townSquare.LocationToNorth = alchemistHut;
            townSquare.LocationToSouth = home;
            townSquare.LocationToEast = guardPost;
            townSquare.LocationToWest = farmhouse;

            farmhouse.LocationToEast = townSquare;
            farmhouse.LocationToWest = farmersField;

            farmersField.LocationToEast = farmhouse;

            alchemistHut.LocationToSouth = townSquare;
            alchemistHut.LocationToNorth = alchemistsGarden;

            alchemistsGarden.LocationToSouth = alchemistHut;

            guardPost.LocationToEast = bridge;
            guardPost.LocationToWest = townSquare;

            bridge.LocationToWest = guardPost;
            bridge.LocationToEast = spiderField;
            bridge.LocationToSouth = shop1;

            spiderField.LocationToWest = bridge;

            shop1.LocationToNorth = bridge;

            // Add the locations to the static list
            Locations.Add(home);
            Locations.Add(townSquare);
            Locations.Add(guardPost);
            Locations.Add(alchemistHut);
            Locations.Add(alchemistsGarden);
            Locations.Add(farmhouse);
            Locations.Add(farmersField);
            Locations.Add(bridge);
            Locations.Add(spiderField);
            Locations.Add(shop1);
        }

        public static Item ItemByID(int id)
        {
            foreach (Item item in Items)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }

            return null;
        }

        public static Monster MonsterByID(int id)
        {
            foreach (Monster monster in Monsters)
            {
                if (monster.ID == id)
                {
                    return monster;
                }
            }

            return null;
        }

        public static Quest QuestByID(int id)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.ID == id)
                {
                    return quest;
                }
            }

            return null;
        }

        public static Location LocationByID(int id)
        {
            foreach (Location location in Locations)
            {
                if (location.ID == id)
                {
                    return location;
                }
            }

            return null;
        }
    }
}
