using System.Collections.Generic;
using FlippyPong.Customization;
using UnityEngine;

namespace FlippyPong
{
    public class PersistentData : IPersistentData
    {
        private const string HISCORE_PREFKEY = "data.hiscore";
        private const string CUSTOM_PREFKEY = "data.custom";

        public PersistentData()
        {
            Load();
        }

        public int HiScore { get; set; }
        public int CustomizationIndex { get; set; }

        public IReadOnlyList<ColorCustomization> Customization { get; private set; }

        public void Load()
        {
            HiScore = PlayerPrefs.GetInt(HISCORE_PREFKEY, 0);
            CustomizationIndex = PlayerPrefs.GetInt(CUSTOM_PREFKEY, 0);

            Customization = new List<ColorCustomization>(Resources.LoadAll<ColorCustomization>("ColorCustomization"));
        }

        public void Save()
        {
            PlayerPrefs.SetInt(CUSTOM_PREFKEY, CustomizationIndex);
            PlayerPrefs.SetInt(HISCORE_PREFKEY, HiScore);
            PlayerPrefs.Save();
        }
    }
}
