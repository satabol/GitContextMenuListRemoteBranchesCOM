using LibGit2Sharp;
using SharpShell.Attributes;
using SharpShell.SharpContextMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitContextMenuListRemoteBranchesCOM
{
    //[COMServerAssociation(AssociationType.None)]
    //[COMServerAssociation(AssociationType.Drive)]
    //[COMServerAssociation(AssociationType.FileExtension, "*")]
    //[COMServerAssociation(AssociationType.AllFiles)]
    //[COMServerAssociation(AssociationType.ClassOfExtension, ".txt")]

    [ComVisible(true)]
    [COMServerAssociation(AssociationType.Directory)]
    [COMServerAssociation(AssociationType.Class, @"Directory\Background")]  // Список ключей реестра: http://stackoverflow.com/questions/20449316/how-add-context-menu-item-to-windows-explorer-for-folders
    public class GitRemoteListExtension : SharpContextMenu
    {
        protected override void OnInitialiseMenu(int parentItemIndex)
        {
            base.OnInitialiseMenu(parentItemIndex);
        }
        protected override bool CanShowMenu()
        {
            //throw new NotImplementedException();
            if (itemCountLines != null)
            {
                itemCountLines.DropDownItems.Clear();
                CreateSubMenuRemoteRepoList(itemCountLines);
            }
            return true;
        }

        private ToolStripMenuItem itemCountLines = null;
        protected override System.Windows.Forms.ContextMenuStrip CreateMenu()
        {
            //throw new NotImplementedException();
            //  Create the menu strip.
            var menu = new ContextMenuStrip();

            //  Create a 'count lines' item.
            itemCountLines = new ToolStripMenuItem
            {
                Text = "Git Show Remote Repo"
            };

            CreateSubMenuRemoteRepoList(itemCountLines);

            //  When we click, we'll call the 'CountLines' function.
            //itemCountLines.Click += (sender, args) => ShowRemoteRepoList();
            //itemCountLines.MouseHover += (sender, args) => CreateSubMenuRemoteRepoList(itemCountLines);

            //  Add the item to the context menu.
            menu.Items.Add(itemCountLines);

            //  Return the menu.
            return menu;
        }

        /*
        private void ShowRemoteRepoList()
        {
            StringBuilder sb = new StringBuilder();
            String path = "";
            foreach (var folderPath in SelectedItemPaths)
            {
                path = folderPath;
                break;
            }

            Repository repo = new Repository(path);
            BranchCollection bc = repo.Branches;
            foreach (Remote b in repo.Network.Remotes)
            {
                sb.AppendLine( b.Name + ": " + b.Url );
            }
            MessageBox.Show("Remote repositories:\n" + sb.ToString() );
        }
        */

        private void CreateSubMenuRemoteRepoList(ToolStripMenuItem menu)
        {
            //List<ToolStripMenuItem>
            StringBuilder sb = new StringBuilder();
            String path = null;
            String strError = " error:";
            foreach (var folderPath in SelectedItemPaths)
            {
                path = folderPath;
                break;
            }

            ToolStripMenuItem item = null;
            try
            {
                if (FolderPath == null)
                {
                    //MessageBox.Show("FolderPath: null");
                    strError += " FolderPath=null";
                }
                else
                {
                    //MessageBox.Show("FolderPath: " + FolderPath);
                    if (path == null)
                    {
                        path = FolderPath;
                    }
                }

                if (path != null)
                {
                    Repository repo = new Repository(path);
                    BranchCollection bc = repo.Branches;
                    foreach (Remote b in repo.Network.Remotes)
                    {
                        item = new ToolStripMenuItem();
                        item.Text = b.Name + ": " + b.Url;
                        item.Click += (sender, args) =>
                        {
                            System.Diagnostics.Process.Start(b.Url);
                        };
                        menu.DropDownItems.Add(item);
                        //sb.AppendLine(b.Name + ": " + b.Url);
                    }
                }
            }
            catch (RepositoryNotFoundException e)
            {
                strError += " RepositoryNotFoundException";
                Console.WriteLine("Repository not found in folder "+path+"\n"+e.ToString());
            }
            catch (Exception e)
            {
                strError += " Exception:"+e.Message;
                Console.WriteLine( "Something wrong with path: "+path+"\n"+e.ToString() );
            }

            if (item == null)
            {
                item = new ToolStripMenuItem();
                item.Text = "no remote branches for path " + (path == null ? "null" : path); // +", " + strError;
                menu.DropDownItems.Add(item);
            }
            //menu.ShowDropDown();
            //MessageBox.Show("Remote repositories:\n" + sb.ToString());
        }
    }
}
