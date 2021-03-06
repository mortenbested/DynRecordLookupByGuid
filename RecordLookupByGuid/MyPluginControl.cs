using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace RecordLookupByGuid
{
    public partial class MyPluginControl : PluginControlBase
    {
        private List<CrmEntity> entities = new List<CrmEntity>();
        private List<CrmEntity> filteredEntities;
        private Settings settings = new Settings();
        private EntityReference foundRecord = null;

        public MyPluginControl()
        {
            InitializeComponent();
            this.panelMainContainer.Enabled = false;
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            if (!SettingsManager.Instance.TryLoad(GetType(), out settings))
            {
                this.settings = new Settings()
                {
                    IncludeFilter = "*",
                    ExcludeFilter = "msdyn*, msfp*",
                    ExcludeManagedEntities = false,
                    CustomEntitiesOnly = false
                };
            }
            this.textBoxIncludeFilter.Text = this.settings.IncludeFilter;
            this.textBoxExcludeFilter.Text = this.settings.ExcludeFilter;
            this.checkBoxManagedEntities.Checked = this.settings.ExcludeManagedEntities;
            this.checkBoxCustomEntitiesOnly.Checked = this.settings.CustomEntitiesOnly;
        }

        public override void ClosingPlugin(PluginCloseInfo info)
        {
            SettingsManager.Instance.Save(this.GetType(), settings);
        }

        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            this.entities = new List<CrmEntity>();
            this.panelMainContainer.Enabled = false;
            ExecuteMethod(this.LoadEntitiesFromCrm);
        }

        private void ToolStripButtonReloadEntities_Click(object sender, EventArgs e)
        {
            ExecuteMethod(this.LoadEntitiesFromCrm);
        }

        private void LoadEntitiesFromCrm()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Entites",
                Work = (worker, args) =>
                {
                    MetadataLoader metadataLoader = new MetadataLoader(this.Service);
                    args.Result = metadataLoader.LoadEntities();
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    this.panelMainContainer.Enabled = true;
                    this.entities = args.Result as List<CrmEntity>;
                    this.HandleFiltersUpdated();
                }
            });
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            ExecuteMethod(PerformSearchAndOpenRecord);
        }

        private void TextBoxSearchTerm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ExecuteMethod(PerformSearchAndOpenRecord);
            }
        }

        private void PerformSearchAndOpenRecord()
        {
            this.labelNoResults.Visible = false;
            this.linkLabelFoundRecord.Visible = false;

            if (!Guid.TryParse(this.textBoxSearchTerm.Text, out Guid recordGuid))
            {
                MessageBox.Show("Record id not a valid GUID", "Error");
                return;
            }

            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Searching...",
                Work = (worker, args) =>
                {
                    RecordSearcher searcher = new RecordSearcher(this.Service);
                    args.Result = searcher.Search(recordGuid, this.filteredEntities);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (args.Result != null)
                    {
                        EntityReference foundRecord = args.Result as EntityReference;
                        this.foundRecord = foundRecord;
                        this.linkLabelFoundRecord.Text = "Found record: " + foundRecord.Name;
                        this.linkLabelFoundRecord.Visible = true;
                        this.OpenFoundRecord();
                    }
                    else
                    {
                        this.labelNoResults.Visible = true;
                        this.linkLabelFoundRecord.Visible = false;
                    }
                }
            });
        }

        private void OpenFoundRecord()
        {
            Uri baseUrl = new Uri(this.ConnectionDetail.WebApplicationUrl);
            Uri recordUrl = new Uri(baseUrl, $"main.aspx?etn={foundRecord.LogicalName}&id=%7b{foundRecord.Id}%7d&pagetype=entityrecord");
            ProcessStartInfo sInfo = new ProcessStartInfo(recordUrl.ToString());
            Process.Start(sInfo);
        }

        private void TextBoxIncludeFilter_TextChanged(object sender, EventArgs e)
        {
            this.settings.IncludeFilter = this.textBoxIncludeFilter.Text;
            this.HandleFiltersUpdated();
        }

        private void TextBoxExcludeFilter_TextChanged(object sender, EventArgs e)
        {
            this.settings.ExcludeFilter = this.textBoxExcludeFilter.Text;
            this.HandleFiltersUpdated();
        }

        private void HandleFiltersUpdated()
        {
            List<CrmEntity> entitiesFiltered = this.entities;

            if (this.settings.ExcludeManagedEntities)
            {
                entitiesFiltered = entitiesFiltered.Where(entity => !entity.IsManaged).ToList();
            }

            if (this.settings.CustomEntitiesOnly)
            {
                entitiesFiltered = entitiesFiltered.Where(entity => entity.IsCustomEntity).ToList();
            }

            string[] includeFilters = this.SplitFilterString(this.settings.IncludeFilter);
            entitiesFiltered = this.FilterEntities(entitiesFiltered, includeFilters, FilterType.Whitelist);

            string[] excludeFilters = this.SplitFilterString(this.settings.ExcludeFilter);
            entitiesFiltered = this.FilterEntities(entitiesFiltered, excludeFilters, FilterType.Blacklist);

            this.filteredEntities = entitiesFiltered;
            this.buttonSearch.Text = $"Search {this.filteredEntities.Count} Entities";
        }

        private List<CrmEntity> FilterEntities(List<CrmEntity> entities, string[] filters, FilterType filterType)
        {
            string[] filtersAsRegex = filters.Select(filter => "^" + Regex.Escape(filter).Replace("\\*", ".*") + "$").ToArray();

            List<CrmEntity> result = entities.ToList();
            foreach (CrmEntity entity in entities)
            {
                bool matchesFilter = filtersAsRegex.Any(filterPattern => Regex.IsMatch(entity.LogicalName, filterPattern, RegexOptions.IgnoreCase));

                if (filterType == FilterType.Blacklist && matchesFilter)
                {
                    result.Remove(entity);
                }
                else if (filterType == FilterType.Whitelist && !matchesFilter && filters.Length > 0)
                {
                    result.Remove(entity);
                }
            }
            return result;
        }

        private string[] SplitFilterString(string input)
        {
            return input
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(filter => filter.Trim())
                .ToArray();
        }

        private void CheckBoxManagedEntities_CheckedChanged(object sender, EventArgs e)
        {
            this.settings.ExcludeManagedEntities = this.checkBoxManagedEntities.Checked;
            this.HandleFiltersUpdated();
        }

        private void CheckBoxCustomEntitiesOnly_CheckedChanged(object sender, EventArgs e)
        {
            this.settings.CustomEntitiesOnly = this.checkBoxCustomEntitiesOnly.Checked;
            this.HandleFiltersUpdated();
        }

        private void LinkLabelFoundRecord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.OpenFoundRecord();
        }
    }
}