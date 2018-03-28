using System.Collections.Generic;
using System.Linq;
using DevExtreme.NETCore.Demos.Models.Demos;
using Microsoft.AspNetCore.Mvc;

namespace DevExtreme.NETCore.Demos.Models.Menu {
    public static class Menu {
        static List<MenuPlainData> Items = new List<MenuPlainData>();
        public static void Initialize(List<MvcDemoGroup> categories) {
            InitializeGroups(categories);
        }

        public static List<MenuPlainData> Get(string demoController, string demoAction, IUrlHelper urlHelper) {
            foreach(var node in Items) {
                if(string.IsNullOrEmpty(node.Url)) {
                    node.Url = urlHelper.Content(string.Format("~/{0}/{1}/", node.Controller, node.Action));
                }
                node.Active = node.Action == demoAction && node.Controller == demoController;
            }

            foreach(var node in Items.Where(i => i.Active)) {
                SetActiveParrent(node);
            }

            return Items;
        }

        static void SetActiveParrent(MenuPlainData node) {
            if(!string.IsNullOrEmpty(node.ParrentId)) {
                int index = Items.FindIndex(x => x.Id == node.ParrentId);
                var parrent = Items[index];
                parrent.Active = true;
                SetActiveParrent(parrent);
            }
        }

        static void InitializeGroups(List<MvcDemoGroup> groups, MenuPlainData parrent = null) {
            var demosItems = new List<MenuPlainData>();
            foreach(var group in groups) {
                var menuItem = new MenuPlainData(group, parrent);
                var demos = group.Demos == null ? null : group.Demos.Where(demo => !demo.Hidden).ToList();
                if(group.Groups != null || (demos != null && demos.Count > 0)) {
                    demosItems.Add(menuItem);
                    if (demos != null && demos.Count > 0) {
                        if (demos.Count > 1) {
                            foreach (var groupDemo in demos) {
                                Items.Add(new MenuPlainData(groupDemo, menuItem));
                            }
                        }
                        var firstdemo = demos[0];
                        menuItem.Action = firstdemo.Name;
                        menuItem.Controller = firstdemo.Widget;
                    }
                    if (group.Groups != null) {
                        InitializeGroups(group.Groups, menuItem);
                    }
                }
            }
            if(demosItems.Count > 0) {
                if(parrent != null) {
                    var firstItem = demosItems[0];
                    parrent.Action = firstItem.Action;
                    parrent.Controller = firstItem.Controller;
                }
                Items.AddRange(demosItems);
            }
        }

    }
}