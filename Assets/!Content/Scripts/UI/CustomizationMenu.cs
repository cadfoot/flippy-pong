using System.Collections.Generic;
using FlippyPong.Core;
using FlippyPong.Customization;
using Injection;
using UnityEngine;

namespace FlippyPong.UI
{
    public class CustomizationMenu : InjectableMonoBehaviour<CustomizationMenu>
    {
        [Inject] private IPersistentData _data = default;
        [Inject] private ICustomizationMenuView _view = default;

        [SerializeField] private CustomizationItem _itemPrefab = default;

        private List<ICustomizationItem> _customizationItems = new List<ICustomizationItem>(); 
        
        private void Start()
        {
            foreach (var data in _data.Customization)
            {
                var item = Instantiate(_itemPrefab, _view.ItemsRoot);
                
                item.Apply(data);
                item.OnClick += OnCustomizationItemClicked;
                item.Selected = (ColorCustomization) item.Data == _data.Customization[_data.CustomizationIndex];
                
                _customizationItems.Add(item);
            }
        }

        private void OnCustomizationItemClicked(ICustomizationItem clicked)
        {
            _customizationItems.ForEach(item => item.Selected = clicked.Data == item.Data);

            _data.CustomizationIndex = _customizationItems.IndexOf(clicked);
            _data.Save();
        }
    }
}
