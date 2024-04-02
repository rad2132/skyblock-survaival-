using InventorySystem.Events;

namespace InventorySystem
{
    public static class EventAggregator
    {
        public static QuickAccessInventoryPanelRendering QuickAccessInventoryPanelRendering = new();
    }
}