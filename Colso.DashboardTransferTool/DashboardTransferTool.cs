using Colso.DashboardTransferTool.AppCode;
using Colso.DashboardTransferTool.Forms;
using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;
using System.Xml;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;

namespace Colso.DashboardTransferTool
{
    public partial class DashboardTransferTool : UserControl, IXrmToolBoxPluginControl, IGitHubPlugin, IHelpPlugin, IStatusBarMessenger
    {
        #region Variables

        /// <summary>
        /// Information panel
        /// </summary>
        private Panel informationPanel;

        /// <summary>
        /// Dynamics CRM 2011 organization service
        /// </summary>
        private IOrganizationService service;

        /// <summary>
        /// Dynamics CRM 2011 target organization service
        /// </summary>
        private IOrganizationService targetService;

        private bool workingstate = false;
        private Dictionary<string, int> lvSortcolumns = new Dictionary<string, int>();

        #endregion Variables

        public DashboardTransferTool()
        {
            InitializeComponent();
        }

        #region XrmToolbox

        public event EventHandler OnCloseTool;
        public event EventHandler OnRequestConnection;
        public event EventHandler<StatusBarMessageEventArgs> SendMessageToStatusBar;

        public Image PluginLogo
        {
            get { return null; }
        }

        public IOrganizationService Service
        {
            get { throw new NotImplementedException(); }
        }

        public string HelpUrl
        {
            get
            {
                return "https://github.com/MscrmTools/Colso.Xrm.DashboardTransferTool/wiki";
            }
        }

        public string RepositoryName
        {
            get
            {
                return "Colso.Xrm.DashboardTransferTool";
            }
        }

        public string UserName
        {
            get
            {
                return "MscrmTools";
            }
        }

        public void ClosingPlugin(PluginCloseInfo info)
        {
            if (info.FormReason != CloseReason.None ||
                info.ToolBoxReason == ToolBoxCloseReason.CloseAll ||
                info.ToolBoxReason == ToolBoxCloseReason.CloseAllExceptActive)
            {
                return;
            }

            info.Cancel = MessageBox.Show(@"Are you sure you want to close this tab?", @"Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes;
        }

        public void UpdateConnection(IOrganizationService newService, ConnectionDetail connectionDetail, string actionName = "", object parameter = null)
        {
            if (actionName == "TargetOrganization")
            {
                targetService = newService;
                SetConnectionLabel(connectionDetail, "Target");
            }
            else
            {
                service = newService;
                SetConnectionLabel(connectionDetail, "Source");
            }
        }

        public string GetCompany()
        {
            return GetType().GetCompany();
        }

        public string GetMyType()
        {
            return GetType().FullName;
        }

        public string GetVersion()
        {
            return GetType().Assembly.GetName().Version.ToString();
        }

        #endregion XrmToolbox

        #region Form events

        private void btnSelectTarget_Click(object sender, EventArgs e)
        {
            if (OnRequestConnection != null)
            {
                var args = new RequestConnectionEventArgs { ActionName = "TargetOrganization", Control = this };
                OnRequestConnection(this, args);
            }
        }

        private void tsbCloseThisTab_Click(object sender, EventArgs e)
        {
            if (OnCloseTool != null)
                OnCloseTool(this, null);
        }

        private void tsbLoadDashboards_Click(object sender, EventArgs e)
        {
            if (service == null)
            {
                if (OnRequestConnection != null)
                {
                    var args = new RequestConnectionEventArgs
                    {
                        ActionName = "Load",
                        Control = this
                    };
                    OnRequestConnection(this, args);
                }
            }
            else
            {
                PopulateSource();
            }
        }
        
        private void tsbTransferDashboards_Click(object sender, EventArgs e)
        {
            Transfer();
        }

        private void lvSourceDashboards_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SetListViewSorting(lvSourceDashboards, e.Column);
        }

        private void tsbDonate_Click(object sender, EventArgs e)
        {

        }

        #endregion Form events

        #region Methods

        private void SetConnectionLabel(ConnectionDetail detail, string serviceType)
        {
            switch (serviceType)
            {
                case "Source":
                    lbSourceValue.Text = detail.ConnectionName;
                    lbSourceValue.ForeColor = Color.Green;
                    break;

                case "Target":
                    lbTargetValue.Text = detail.ConnectionName;
                    lbTargetValue.ForeColor = Color.Green;
                    break;
            }
        }

        private void ManageWorkingState(bool working)
        {
            workingstate = working;
            gbSourceDashboards.Enabled = !working;
            Cursor = working ? Cursors.WaitCursor : Cursors.Default;
        }
      
        private void PopulateSource()
        {
            if (!workingstate)
            {
                // Reinit other controls
                lvSourceDashboards.Items.Clear();
                ManageWorkingState(true);

                // Launch treatment
                var bwFill = new BackgroundWorker();
                bwFill.DoWork += (sender, e) => {
                    // Retrieve 
                    List<Entity> dashboardsList = DashboardHelper.RetrieveDashboards(service);
                    dashboardsList.AddRange(DashboardHelper.RetrieveUserDashboards(service));

                    // Prepare list of items
                    var sourceDashboardsList = new List<ListViewItem>();

                    foreach (Entity view in dashboardsList)
                    {
                        var item = new ListViewItem(view["name"].ToString());
                        item.Tag = view;
                        SetDashboardImageAndType(item);

                        if (view.Contains("iscustomizable") &&
                           ((BooleanManagedProperty)view["iscustomizable"]).Value == false)
                        {
                            item.ForeColor = Color.Gray;
                            item.ToolTipText = "This dashboard has not been defined as customizable";
                        }

                        sourceDashboardsList.Add(item);
                    }

                    e.Result = sourceDashboardsList;
                };
                bwFill.RunWorkerCompleted += (sender, e) => {
                    if (e.Error != null)
                    {
                        MessageBox.Show(this, "An error occured: " + e.Error.Message, "Error", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    else
                    {
                        var items = (List<ListViewItem>)e.Result;
                        if (items.Count == 0)
                        {
                            MessageBox.Show(this, "The system does not contain any dashboards", "Warning", MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                        }
                        else
                        {
                            lvSourceDashboards.Items.AddRange(items.ToArray());
                        }
                    }

                    ManageWorkingState(false);
                };
                bwFill.RunWorkerAsync();
            }
        }
     
        private void Transfer()
        {
            if (service == null || targetService == null)
            {
                MessageBox.Show("You must select both a source and a target organization", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lvSourceDashboards.SelectedItems.Count == 0)
            {
                MessageBox.Show("You must select at least one dashboard to be transfered", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ManageWorkingState(true);

            informationPanel = InformationPanel.GetInformationPanel(this, "Transfering dashboards...", 340, 150);
            SendMessageToStatusBar(this, new StatusBarMessageEventArgs("Transfering dashboards..."));

            var bwTransferDashboards = new BackgroundWorker { WorkerReportsProgress = true };
            bwTransferDashboards.DoWork += (sender, e) =>
            {
                var dashboards = (List<Entity>)e.Argument;
                var errors = new List<Tuple<string, string>>();

                foreach (var dbEntity in dashboards)
                {
                    var name = dbEntity.GetAttributeValue<string>("name");
                    var worker = (BackgroundWorker)sender;
                    worker.ReportProgress(0, "Transfering dashboard '" + name + "'...");

                    try
                    {
                        var dashboard = new AppCode.Dashboard(dbEntity, service, targetService);
                        dashboard.Transfer();
                    }
                    catch (FaultException<OrganizationServiceFault> error)
                    {
                        if(error.HResult == -2146233087)
                        {
                            errors.Add(new Tuple<string, string>(name, "The dashboard you tried to transfer already exists but you don't have read access to it. Get access to this dashboard on the target organization to update it"));
                        }
                        else
                        {
                            errors.Add(new Tuple<string, string>(name, error.Message));
                        }
                    }
                }

                e.Result = errors;
            };
            bwTransferDashboards.RunWorkerCompleted += (sender, e) => {
                Controls.Remove(informationPanel);
                informationPanel.Dispose();
                SendMessageToStatusBar(this, new StatusBarMessageEventArgs(""));
                ManageWorkingState(false);

                var errors = (List<Tuple<string, string>>)e.Result;

                if (errors.Count > 0)
                {
                    var errorDialog = new ErrorList((List<Tuple<string, string>>)e.Result);
                    errorDialog.ShowDialog(ParentForm);
                }
            };
            bwTransferDashboards.ProgressChanged += (sender, e) => {
                InformationPanel.ChangeInformationPanelMessage(informationPanel, e.UserState.ToString());
                SendMessageToStatusBar(this, new StatusBarMessageEventArgs(e.UserState.ToString()));
            };
            bwTransferDashboards.RunWorkerAsync(lvSourceDashboards.SelectedItems.Cast<ListViewItem>().Select(v=>(Entity)v.Tag).ToList());
        }
     
        private void SetDashboardImageAndType(ListViewItem item)
        {
            var view = (Entity)item.Tag;

            if (view.LogicalName == "systemform")
            {
                item.SubItems.Add("System dashboard");
                item.ImageIndex = 0;
            }
            else
            {
                item.SubItems.Add("User dashboard");
                item.ImageIndex = 1;
            }
        }

        private void SetListViewSorting(ListView listview, int column)
        {
            int currentSortcolumn = -1;
            if (lvSortcolumns.ContainsKey(listview.Name))
                currentSortcolumn = lvSortcolumns[listview.Name];
            else
                lvSortcolumns.Add(listview.Name, currentSortcolumn);

            if (currentSortcolumn != column)
            {
                lvSortcolumns[listview.Name] = column;
                listview.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (listview.Sorting == SortOrder.Ascending)
                    listview.Sorting = SortOrder.Descending;
                else
                    listview.Sorting = SortOrder.Ascending;
            }

            listview.ListViewItemSorter = new ListViewItemComparer(column, listview.Sorting);
        }

        #endregion Methods

    }
}