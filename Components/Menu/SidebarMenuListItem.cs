using System.Collections.Generic;

namespace Components.Menu
{
    public class SidebarMenuItem
    {
        public string Name { get; set; }
        public string LogoName { get; set; }
        public string HrefLink { get; set; }
        public string ModuleColor { get; set; }
        public IList<SidebarMenuListItem> NavItems { get; set; } = new List<SidebarMenuListItem>();
    }

    public class SidebarMenuListItem
    {
        public string DisplayList { get; set; }
        public string ArrowName { get; set; }
        public string ParentHref { get; set; }
        public string ListName { get; set; }

        public string Name { get; set; } = "Placeholder";
        public string ModuleColor { get; set; } = "#217AA2";
        public string LogoName { get; set; } = "error";
        public bool IsLocked { get; set; } = false;
        public string HrefLink { get; set; }
    }
}
