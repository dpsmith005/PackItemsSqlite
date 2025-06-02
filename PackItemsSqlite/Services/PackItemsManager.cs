using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackItemsSqlite
{
    internal class PackItemsManager
    {
        private List<PackItem> _packitems;
        private List<PackItemDGV> _packitemsDGV;
        private string _kind;
        private string _selValue;
        private List<GroupItem> _groupitems;
        private List<TagItem> _tagitems;
        private readonly IPackItemsRepository _packItemsRepository;

        public PackItemsManager(IPackItemsRepository packItemsRepository)
        {
            _packItemsRepository = packItemsRepository;
        }
        public List<PackItemDGV> ItemsDGV
        {
            get
            {
                //if (_packitemsDGV == null) {
                _packitemsDGV = _packItemsRepository.GetGridItems(_kind, _selValue).ToList();
                //}
                return _packitemsDGV;
            }
        }
        public List<PackItem> Items
        {
            get
            {
                //if (_packitems == null) {
                _packitems = _packItemsRepository.GetAllPackItems().ToList();
                //}
                return _packitems;
            }
        }
        public List<GroupItem> Groups
        {
            get
            {
                //if (_groupitems == null) {
                _groupitems = _packItemsRepository.GetAllGroups().ToList();
                //}
                return _groupitems;
            }
        }
        public List<TagItem> Tags
        {
            get
            {
                //if (_tagitems == null) {
                _tagitems = _packItemsRepository.GetAllTags().ToList();
                //}
                return _tagitems;
            }

        }
        public List<PackItemDGV> GetItemsFilter(string kind, string selValue)
        {
            _kind = kind;
            _selValue = selValue;

            _packitemsDGV = _packItemsRepository.GetGridItems(kind, selValue).ToList();
            return _packitemsDGV;
        }
        public List<PackItem> GetSingleItem(string value)
        {
            return _packItemsRepository.GetSinglePackItem(value).ToList();
        }
        public void ItemDelete(string item)
        {
            _packItemsRepository.PackItemDelete(item);
        }
        public void ItemInsert(PackItem packItem)
        {
            _packItemsRepository.PackItemInsert(packItem);
        }
        public void ItemUpdate(PackItem packItem)
        {
            _packItemsRepository.PackItemUpdate(packItem);
        }
        public void GroupItemUpdate(string groupName, int listOrder)
        {
            _packItemsRepository.GroupItemUpdate(groupName, listOrder);
        }
    }
}
