namespace ParTech.Commands
{
    using System.Linq;
    using Sitecore;
    using Sitecore.Data.Items;
    using Sitecore.Shell.Framework.Commands;

    /// <summary>
    ///     Command that expands all the descendants of the selected item in the Content Editor tree
    /// </summary>
    public class ExpandDescendants : Command
    {
        /// <summary>
        ///     Executes the command in the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Execute(CommandContext context)
        {
            Item parent = context.Items.FirstOrDefault();

            this.RefreshChildren(parent);
        }

        /// <summary>
        ///     Refresh the parent node in the content tree.
        /// </summary>
        /// <param name="parent">The parent.</param>
        private void RefreshChildren(Item parent)
        {
            if (parent != null)
            {
                Context.ClientPage.SendMessage(this, string.Format("item:refreshchildren(id={0})", parent.ID));

                var children = parent.GetChildren();

                foreach (Item child in children)
                {
                    this.RefreshChildren(child);
                }
            }
        }
    }
}