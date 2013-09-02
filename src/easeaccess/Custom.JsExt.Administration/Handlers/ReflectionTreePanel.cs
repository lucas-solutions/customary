// ReflectionTreePanel.cs
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Html;

namespace Custom.Handlers
{
    using Ext;
    using Ext.data;
    using Ext.tree;

    public class ReflectionTreePanel : Ext.tree.Panel
    {
        public  void ItemClick(NodeInterface record, Element item, Number index, Ext.EventObject e, ReflectionTabsObject tabs)
        {
            //tabs.Items;
            Panel tree = (Panel)this;
            ReflectionNodeObject raw = (ReflectionNodeObject)record.Raw;

            switch (raw.type)
            {
                case "application":
                    tabs.Application.Show();
                    tabs.Application.GetEl().Dom.Style.Display = "";
                    tabs.Area.Show();
                    tabs.Files.Hide();
                    tabs.File.Hide();
                    tabs.Lists.Hide();
                    tabs.List.Hide();
                    tabs.Models.Hide();
                    tabs.Model.Hide();
                    tabs.Notes.Hide();
                    tabs.Note.Hide();
                    tabs.Application.SetActive();
                    break;

                case "area":
                    tabs.Area.Show();
                    tabs.Area.GetEl().Dom.Style.Display = "";
                    tabs.Files.Hide();
                    tabs.File.Hide();
                    tabs.Lists.Hide();
                    tabs.List.Hide();
                    tabs.Models.Hide();
                    tabs.Model.Hide();
                    tabs.Notes.Hide();
                    tabs.Note.Hide();
                    tabs.Area.SetActive();
                    break;

                case "files":
                    tabs.Files.Show();
                    tabs.Files.GetEl().Dom.Style.Display = "";
                    tabs.Files.SetVisible(true);
                    tabs.File.Hide();
                    tabs.Lists.Hide();
                    tabs.List.Hide();
                    tabs.Models.Hide();
                    tabs.Model.Hide();
                    tabs.Notes.Hide();
                    tabs.Note.Hide();
                    tabs.Files.SetActive();
                    break;

                case "file":
                    tabs.File.Show();
                    tabs.File.GetEl().Dom.Style.Display = "";
                    tabs.File.SetVisible(true);
                    tabs.Lists.Hide();
                    tabs.List.Hide();
                    tabs.Models.Hide();
                    tabs.Model.Hide();
                    tabs.Notes.Hide();
                    tabs.Note.Hide();
                    tabs.File.SetActive();
                    break;

                case "lists":
                    tabs.Files.Hide();
                    tabs.File.Hide();
                    tabs.Lists.Show();
                    tabs.Lists.GetEl().Dom.Style.Display = "";
                    tabs.Lists.SetVisible(true);
                    tabs.List.Hide();
                    tabs.Models.Hide();
                    tabs.Model.Hide();
                    tabs.Notes.Hide();
                    tabs.Note.Hide();
                    tabs.Lists.SetActive();
                    break;

                case "list":
                    tabs.Files.Hide();
                    tabs.File.Hide();
                    tabs.List.Show();
                    tabs.List.GetEl().Dom.Style.Display = "";
                    tabs.List.SetVisible(true);
                    tabs.Models.Hide();
                    tabs.Model.Hide();
                    tabs.Notes.Hide();
                    tabs.Note.Hide();
                    tabs.List.SetActive();
                    break;

                case "models":
                    tabs.Files.Hide();
                    tabs.File.Hide();
                    tabs.Lists.Hide();
                    tabs.List.Hide();
                    tabs.Models.Show();
                    tabs.Models.GetEl().Dom.Style.Display = "";
                    tabs.Models.SetVisible(true);
                    tabs.Model.Hide();
                    tabs.Notes.Hide();
                    tabs.Note.Hide();
                    tabs.Models.SetActive();
                    break;

                case "model":
                    tabs.Files.Hide();
                    tabs.File.Hide();
                    tabs.Lists.Hide();
                    tabs.List.Hide();
                    tabs.Model.Show();
                    tabs.Model.GetEl().Dom.Style.Display = "";
                    tabs.Model.SetVisible(true);
                    tabs.Notes.Hide();
                    tabs.Note.Hide();
                    tabs.Model.SetActive();
                    break;

                case "notes":
                    tabs.Files.Hide();
                    tabs.File.Hide();
                    tabs.Lists.Hide();
                    tabs.List.Hide();
                    tabs.Models.Hide();
                    tabs.Model.Hide();
                    tabs.Notes.Show();
                    tabs.Notes.GetEl().Dom.Style.Display = "";
                    tabs.Notes.SetVisible(true);
                    tabs.Notes.GetEl().Show();
                    tabs.Note.Hide();
                    tabs.Notes.SetActive();
                    break;

                case "note":
                    tabs.Files.Hide();
                    tabs.File.Hide();
                    tabs.Lists.Hide();
                    tabs.List.Hide();
                    tabs.Models.Hide();
                    tabs.Model.Hide();
                    tabs.Notes.Hide();
                    tabs.Note.Show();
                    tabs.Note.GetEl().Dom.Style.Display = "block";
                    tabs.Note.SetVisible(true);
                    tabs.Note.GetEl().Show();
                    tabs.Note.SetActive();
                    break;
            }

            tabs.Panel.DoLayout();
        }

        public void ItemDbClick(NodeInterface record, Element item, Number index, Ext.EventObject e, Ext.tab.Panel tabs)
        {
            //tabs.Items;
            Panel tree = (Panel)this;
            ReflectionNodeObject raw = (ReflectionNodeObject)record.Raw;

            Ext.tab.Tab tab = (Ext.tab.Tab)Ext_.Create("Ext.tab.Tab", new Dictionary("id", ReflectionNode.Path(record), "title", raw.type));
           
            tabs.Add(tab);
            

            switch (raw.type)
            {
                case "application":
                    break;

                case "area":
                    break;

                case "files":
                    break;

                case "file":
                    break;

                case "lists":
                    break;

                case "list":
                    break;

                case "models":
                    break;

                case "model":
                    break;

                case "notes":
                    break;

                case "note":
                    break;
            }

            tabs.DoLayout();
            //tab.Show();
            //tab.SetVisible(true);
            //tab.SetActive();
            
        }
    }
}
