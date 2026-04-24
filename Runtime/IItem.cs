using UnityEngine;

namespace Fsi.Inventory
{
    public interface IItem
    {
        public string Name { get; }
        public string Desc { get; }
        public Sprite Sprite { get; }
    }
}