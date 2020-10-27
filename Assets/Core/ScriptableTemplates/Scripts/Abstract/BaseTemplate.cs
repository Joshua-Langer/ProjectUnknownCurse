using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LangerNetwork
{
    public abstract partial class BaseTemplate : ScriptableTemplate
    {
        [Header("General")]
        [Tooltip("Used to categorize templates in groups (items, skils, buffs, etc...")]
        public string sortCategory;
        [Tooltip("Used to determine sort order of lists")]
        public int sortOrder;
        [Tooltip("Icon used to visualize the template in game")]
        public Sprite smallIcon;
        [Tooltip("Background of icon to visualize the template in game")]
        public Sprite backgroundIcon;
        //[Tooltip("Rarity of the template")]
        //TODO: NYI - public RarityTemplate rarity;

        [Tooltip("Description of the template used as part of it's tooltip")]
        [TextArea(5, 5)]
        public string description;

        public override void OnValidate()
        {
            base.OnValidate();
        }
    }

}
