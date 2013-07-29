using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using Sitecore.Globalization;

namespace ParTech.Commands
{
    /// <summary>
    /// Command that expands all the descendants of the selected item in the Content Editor tree
    /// </summary>
    public class ExpandDescendants : Command
    {
        public override void Execute(CommandContext context)
        {
            Item parent = context.Items.FirstOrDefault();

            RefreshChildren(parent);
        }

        private void RefreshChildren(Item parent)
        {
            if (parent != null)
            {
                Sitecore.Context.ClientPage.SendMessage(this, string.Format("item:refreshchildren(id={0})", parent.ID));

                var children = parent.GetChildren();

                foreach (Item child in children)
                {
                    RefreshChildren(child);
                }
            }
        }
    }
}