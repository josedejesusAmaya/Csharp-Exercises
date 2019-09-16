using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;

/*
 * No pude hacer que se el archivo se reproduzca al momento de elegir el subItem
 * pero lo hice comparando los nombres (aunque no es la verdadera solución).
 * Tampoco pude hacer que funcionara con archivos .mp3 porque SoundPlayer no los hacepta
 * y para hacerlo tenía que bajar otra librería que ya no entendí bien, así que lo deje
 * con archivos .wav
 */
namespace Explorador
{
    public partial class Form1 : Form
    {
        private SoundPlayer soundPlayer;
        public Form1()
        {
            InitializeComponent();
            treeView();
            this.treeView1.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
        }
        
        private void treeView()
        {
            TreeNode rootNode;
            DirectoryInfo info = new DirectoryInfo(@"C:\Users\Owner\Music\Music");
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                getDirectories(info.GetDirectories(), rootNode);
                treeView1.Nodes.Add(rootNode);
            }
        }

        private void getDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subDirectories;
            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name,0,0);
                aNode.Tag = subDir;
                aNode.ImageKey = "carpeta";
                subDirectories = subDir.GetDirectories();
                if (subDirectories.Length != 0)
                {
                    getDirectories(subDirectories,aNode);
                }
                nodeToAddTo.Nodes.Add(aNode);
            }
        }

        void treeView1_NodeMouseClick(Object sender, TreeNodeMouseClickEventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            TreeNode newSelected = e.Node;
            listView1.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;
            string nameSound = "";
            string files = "ZHU_-_Cold_Blooded_Audio.wav";
            //player.LoadCompleted += new AsyncCompletedEventHandler(player_LoadCompleted);
            //player.SoundLocation = @"C:\";
            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                item = new ListViewItem(file.Name, 1);
                subItems = new ListViewItem.ListViewSubItem[]
                {
                    new ListViewItem.ListViewSubItem(item, "MP3 Format Sound")
                };
                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
                nameSound =  item.SubItems[0].Text;
                //nameSound = item.Text;
                
            }
            if (nameSound != "")
            {
                MessageBox.Show(nameSound);
                //MessageBox.Show(nameSound.Equals(files).ToString());
                if (nameSound.Equals(files))
                {
                    //MessageBox.Show("es el mismo");
                    soundPlayer = new SoundPlayer(nameSound);
                    soundPlayer.Play();
                }
            }


            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            
        }


    }
}
