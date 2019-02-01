using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crawl.Models;
using Crawl.ViewModels;

namespace Crawl.Services
{
    public sealed class MockDataStore : IDataStore
    {

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static MockDataStore _instance;

        public static MockDataStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MockDataStore();
                }
                return _instance;
            }
        }

        private List<Item> _itemDataset = new List<Item>();
        private List<Character> _characterDataset = new List<Character>();
        private List<Monster> _monsterDataset = new List<Monster>();
        private List<Score> _scoreDataset = new List<Score>();

        private MockDataStore()
        {
            InitilizeSeedData();
        }

        private void InitilizeSeedData()
        {

            // Implement

            // Load Items.
            //_itemDataset.Add(new Item("Gold Sword", "Sword made of Gold, really expensive looking",
            //    "http://www.clker.com/cliparts/e/L/A/m/I/c/sword-md.png", 0, 10, 10, ItemLocationEnum.PrimaryHand, AttributeEnum.Defense));

            //_itemDataset.Add(new Item("Strong Shield", "Enough to hide behind",
            //    "http://www.clipartbest.com/cliparts/4T9/LaR/4T9LaReTE.png", 0, 10, 0, ItemLocationEnum.OffHand, AttributeEnum.Attack));

            //_itemDataset.Add(new Item("Bunny Hat", "Pink hat with fluffy ears",
            //    "http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png", 0, 10, -1, ItemLocationEnum.Head, AttributeEnum.Speed));

            _itemDataset.Add(new Item("Shrink Ray", "Shrinking machine that shrinks user to proportional size",
                "http://www.clipartbest.com/cliparts/9T4/o8X/9T4o8Xybc.png", 0, 10, -1, ItemLocationEnum.LeftFinger, AttributeEnum.Defense));

            _itemDataset.Add(new Item("Noisy Cricket", "Despite its small size, it launches a large orb of energy",
                "https://www.pngrepo.com/download/125228/mechanical-drill-outline.png", 0, 10, 10, ItemLocationEnum.PrimaryHand, AttributeEnum.Attack));

            _itemDataset.Add(new Item("Adorian Crossbow", "Fires shafts of plasma-charged energy up to fifty meters; powerful but with mediocre accuracy",
                "http://www.freepngclipart.com/thumb/light/44954-energy-ball-effects-download-free-image-thumb.png", 3, 10, 10, ItemLocationEnum.OffHand, AttributeEnum.Attack));

            _itemDataset.Add(new Item("Stealth Suit", "Capable of making its wearer invisible, be undetectable by both senses and radar, and emit no signatures",
                "http://www.clipartbest.com/cliparts/9cp/L6e/9cpL6e5Ri.png", 0, 10, -3, ItemLocationEnum.Feet, AttributeEnum.Defense));

            _itemDataset.Add(new Item("Quick Clone", "Used to form a distraction, extra hands, temporary field replacements, or a way to secretly escape",
                "https://b14819fc8561370eb64a-1d1d43ab0f9b35bf2222c6a5c9f3ce1f.ssl.cf1.rackcdn.com/site_data/cbpreferred/editor_assets/businessmen-152572_1280.png", 0, 10, -3, ItemLocationEnum.Head, AttributeEnum.Defense));


            // Load Characters
            _characterDataset.Add(new Character("Zorbet", "A bear like creature from unknown planet", 
                "http://images.clipartpanda.com/monster-clipart-cute-monster-clip-art-1024x1024.png", 28));

            _characterDataset.Add(new Character("Squashee", "A slug like species and are enemies of Zorbets",
                "http://images.clipartpanda.com/orange-monster-clipart-orange-monster-hi.png", 35));

            _characterDataset.Add(new Character("Triclops Family", "Unknown species able to manipulate time",
                "http://images.clipartpanda.com/cute-halloween-monster-clipart-large_cute-monsters.png", 72));

            // Implement Monsters

            // Implement Scores
        }

        private void CreateTables()
        {
            // Do nothing...
        }

        // Delete the Datbase Tables by dropping them
        public void DeleteTables()
        {
            // Implement
        }

        // Tells the View Models to update themselves.
        private void NotifyViewModelsOfDataChange()
        {
            ItemsViewModel.Instance.SetNeedsRefresh(true);
            CharactersViewModel.Instance.SetNeedsRefresh(true);
            
            // Implement Monsters
            
            // Implement Scores
        }

        public void InitializeDatabaseNewTables()
        {
            DeleteTables();

            // make them again
            CreateTables();

            // Populate them
            InitilizeSeedData();

            // Tell View Models they need to refresh
            NotifyViewModelsOfDataChange();
        }

        #region Item
        // Item
        public async Task<bool> InsertUpdateAsync_Item(Item data)
        {

            // Check to see if the item exist
            var oldData = await GetAsync_Item(data.Id);
            if (oldData == null)
            {
                _itemDataset.Add(data);
                return true;
            }

            // Compare it, if different update in the DB
            var UpdateResult = await UpdateAsync_Item(data);
            if (UpdateResult)
            {
                await AddAsync_Item(data);
                return true;
            }

            return false;
        }

        public async Task<bool> AddAsync_Item(Item data)
        {
            _itemDataset.Add(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync_Item(Item data)
        {
            var myData = _itemDataset.FirstOrDefault(arg => arg.Id == data.Id);
            if (myData == null)
            {
                return false;
            }

            myData.Update(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync_Item(Item data)
        {
            var myData = _itemDataset.FirstOrDefault(arg => arg.Id == data.Id);
            _itemDataset.Remove(myData);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetAsync_Item(string id)
        {
            return await Task.FromResult(_itemDataset.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetAllAsync_Item(bool forceRefresh = false)
        {
            return await Task.FromResult(_itemDataset);
        }

        #endregion Item

        #region Character
        // Character
        public async Task<bool> InsertUpdateAsync_Character(Character data)
        {

            // Check to see if the item exist
            var oldData = await GetAsync_Character(data.Id);
            if (oldData == null)
            {
                _characterDataset.Add(data);
                return true;
            }

            // Compare it, if different update in the DB
            var UpdateResult = await UpdateAsync_Character(data);
            if (UpdateResult)
            {
                await AddAsync_Character(data);
                return true;
            }

            return false;
        }
        public async Task<bool> AddAsync_Character(Character data)
        {
            _characterDataset.Add(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync_Character(Character data)
        {
            var myData = _characterDataset.FirstOrDefault(arg => arg.Id == data.Id);
            if (myData == null)
            {
                return false;
            }

            myData.Update(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync_Character(Character data)
        {
            var myData = _characterDataset.FirstOrDefault(arg => arg.Id == data.Id);
            _characterDataset.Remove(myData);

            return await Task.FromResult(true);
        }

        public async Task<Character> GetAsync_Character(string id)
        {
            return await Task.FromResult(_characterDataset.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Character>> GetAllAsync_Character(bool forceRefresh = false)
        {
            return await Task.FromResult(_characterDataset);
        }

        #endregion Character

        #region Monster
        //Monster
        public async Task<bool> AddAsync_Monster(Monster data)
        {
            // Implement
            return false;
        }

        public async Task<bool> UpdateAsync_Monster(Monster data)
        {
            // Implement
            return false;
        }

        public async Task<bool> DeleteAsync_Monster(Monster data)
        {
            // Implement
            return false;
        }

        public async Task<Monster> GetAsync_Monster(string id)
        {
            // Implement
            return null;
        }

        public async Task<IEnumerable<Monster>> GetAllAsync_Monster(bool forceRefresh = false)
        {
            // Implement
            return null;
        }

        #endregion Monster

        #region Score
        // Score
        public async Task<bool> AddAsync_Score(Score data)
        {
            // Implement
            return false;
        }

        public async Task<bool> UpdateAsync_Score(Score data)
        {
            // Implement
            return false;
        }

        public async Task<bool> DeleteAsync_Score(Score data)
        {
            // Implement
            return false;
        }

            public async Task<Score> GetAsync_Score(string id)
        {
            // Implement
            return null;
        }

        public async Task<IEnumerable<Score>> GetAllAsync_Score(bool forceRefresh = false)
        {
            // Implement
            return null;
        }
        #endregion Score
    }
}