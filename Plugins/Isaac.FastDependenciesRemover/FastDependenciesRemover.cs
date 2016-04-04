using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox;
using Isaac.FastDependenciesRemover.Properties;
using Microsoft.Xrm.Sdk;
using MsCrmTools.SolutionComponentsMover.AppCode;
using Microsoft.Crm.Sdk.Messages;
using MsCrmTools.AttributeBulkUpdater.Helpers;
using Microsoft.Xrm.Sdk.Metadata;
using System.Xml;
using Microsoft.Xrm.Sdk.Query;
using System.Xml.Linq;

namespace Isaac.FastDependenciesRemover
{
    public partial class FastDependenciesRemover : PluginBase
    {
        #region Class Members
        Dictionary<string, AttributeMetadata> attributesOriginalState;
        List<Entity> lstDependencies = null;
        #endregion Class Members

        #region UI Methods
        public FastDependenciesRemover()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the logo to display in the tools list
        /// </summary>
        public override Image PluginLogo
        {

            get { return Resources.eladcrm_80x80; }
        }

        private void TsbCloseThisTabClick(object sender, EventArgs e)
        {
            CloseTool();
        }
        #endregion UI Methods

        #region Button Click Methods
        private void TsbLoadEntitiesClick(object sender, EventArgs e)
        {
            ExecuteMethod(LoadEntities);
        }

        private void tsbDependencies_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadDependencies);
        }

        private void TsbDeleteDependenciesClick(object sender, EventArgs e)
        {
            ExecuteMethod(DeleteDependencies);
        }

        private void PublishAll()
        {
            tsbDependencies.Enabled = false;
            tsbEntities.Enabled = false;
            tsbDeleteDependencies.Enabled = false;

            WorkAsync("Publishing all customizations...",
                evt =>
                {
                    var pubRequest = new PublishAllXmlRequest();
                    Service.Execute(pubRequest);
                },
                evt =>
                {
                    if (evt.Error != null)
                    {
                        string errorMessage = CrmExceptionHelper.GetErrorMessage(evt.Error, false);
                        MessageBox.Show(this, errorMessage, "Error", MessageBoxButtons.OK,
                                                          MessageBoxIcon.Error);
                    }

                    tsbDependencies.Enabled = true;
                    tsbEntities.Enabled = true;
                    tsbDeleteDependencies.Enabled = true;
                });
        }
        #endregion Button Click Methods

        #region Binding Methods
        private void LoadEntities()
        {
            lvEntities.Items.Clear();
            lvAttributes.Items.Clear();
            gbEntities.Enabled = false;
            tsbDeleteDependencies.Enabled = false;

            WorkAsync("Loading entities...",
                e =>
                {
                    e.Result = MetadataHelper.RetrieveEntities(Service);
                },
                e =>
                {
                    if (e.Error != null)
                    {
                        string errorMessage = CrmExceptionHelper.GetErrorMessage(e.Error, true);
                        MessageBox.Show(ParentForm, errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var items = new List<ListViewItem>();
                        foreach (EntityMetadata emd in (List<EntityMetadata>)e.Result)
                        {
                            var item = new ListViewItem { Text = emd.DisplayName.UserLocalizedLabel.Label, Tag = emd };
                            item.SubItems.Add(emd.LogicalName);
                            items.Add(item);
                        }
                        lvEntities.Items.AddRange(items.ToArray());

                        gbEntities.Enabled = true;
                    }
                });
        }

        private void LoadDependencies()
        {
            var attid = new Guid(lvAttributes.SelectedItems[0].SubItems[2].Text);
            var attname = lvAttributes.SelectedItems[0].SubItems[0].Text;
            lvItemDependencies.Items.Clear();

            WorkAsync("Loading Attribute Dependencies For Delete ...",
                e =>
                {
                    e.Result = new RetrieveDependenciesForDeleteRequest
                    {
                        ComponentType = (int)componenttype.Attribute,
                        ObjectId = attid
                    };
                },
                e =>
                {
                    if (e.Error != null)
                    {
                        string errorMessage = CrmExceptionHelper.GetErrorMessage(e.Error, false);
                        MessageBox.Show(this, errorMessage, "Error", MessageBoxButtons.OK,
                                                          MessageBoxIcon.Error);
                    }
                    RetrieveDependenciesForDeleteResponse retrieveDependenciesForDeleteResponse =
                     (RetrieveDependenciesForDeleteResponse)Service.Execute((RetrieveDependenciesForDeleteRequest)e.Result);

                    string sComponent = string.Empty;
                    string sName = string.Empty;
                    var items = new List<ListViewItem>();
                    lstDependencies = new List<Entity>();

                    foreach (Entity dep in retrieveDependenciesForDeleteResponse.EntityCollection.Entities)
                    {
                        Dependency strongDep = dep.ToEntity<Dependency>();
                        sComponent = ((componenttype)strongDep.DependentComponentType.Value).ToString();
                        sName = GetDependencyName(strongDep.DependentComponentObjectId.Value, (componenttype)strongDep.DependentComponentType.Value);

                        var item = new ListViewItem(sName);
                        item.SubItems.Add(sComponent);
                        items.Add(item);
                    }
                    lvItemDependencies.Items.AddRange(items.ToArray());

                    tsbDependencies.Enabled = true;
                    tsbEntities.Enabled = true;
                    tsbDeleteDependencies.Enabled = true;
                    lvItemDependencies.Enabled = true;
                }, attid);
        }

        private void DeleteDependencies()
        {
            bool needPublish = false;
            var attname = lvAttributes.SelectedItems[0].SubItems[1].Text;

            WorkAsync("Deleting from Forms and Views ...",
                e =>
                {
                    foreach (Entity dep in lstDependencies)
                    {
                        switch (dep.LogicalName)
                        {
                            case SystemForm.EntityLogicalName:
                                if (!needPublish)
                                    needPublish = needPublish || RemoveFieldFromForm(attname, dep);
                                else
                                    RemoveFieldFromForm(attname, dep);
                                break;

                            case SavedQuery.EntityLogicalName:
                                if (!needPublish)
                                    needPublish = needPublish || RemoveFieldFromView(attname, dep);
                                else
                                    RemoveFieldFromView(attname, dep);
                                break;
                        }
                    }
                },
                e =>
                {
                    if (e.Error != null)
                    {
                        string errorMessage = CrmExceptionHelper.GetErrorMessage(e.Error, false);
                        MessageBox.Show(this, errorMessage, "Error", MessageBoxButtons.OK,
                                                          MessageBoxIcon.Error);
                    }

                    if (needPublish)
                        PublishAll();

                    LoadDependencies();
                });
        }

        private void lvEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvEntities.SelectedItems.Count > 0)
            {
                lvAttributes.Items.Clear();

                var emd = (EntityMetadata)lvEntities.SelectedItems[0].Tag;

                WorkAsync("Loading attributes...",
                    evt =>
                    {
                        attributesOriginalState = new Dictionary<string, AttributeMetadata>();
                        string entityName = evt.Argument.ToString();
                        EntityMetadata metadata = MetadataHelper.RetrieveEntity(entityName, Service);
                        XmlDocument allFormsDoc = MetadataHelper.RetrieveEntityForms(metadata.LogicalName, Service);
                        var items = new List<ListViewItem>();

                        foreach (AttributeMetadata amd in metadata.Attributes)
                        {
                            if (amd.AttributeType.HasValue
                                && amd.AttributeType.Value != AttributeTypeCode.Virtual
                                && string.IsNullOrEmpty(amd.AttributeOf)
                                && !amd.LogicalName.Equals(string.Format("{0}id",entityName)))
                            {
                                string label = amd.DisplayName.UserLocalizedLabel != null ? amd.DisplayName.UserLocalizedLabel.Label : "N/A";

                                var item = new ListViewItem(label);
                                item.SubItems.Add(amd.LogicalName);
                                item.SubItems.Add(amd.MetadataId.Value.ToString());

                                items.Add(item);
                            }
                        }

                        evt.Result = items;
                    },
                    evt =>
                    {
                        if (evt.Error != null)
                        {
                            MessageBox.Show(this, evt.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            lvAttributes.Items.AddRange(((List<ListViewItem>)evt.Result).ToArray());

                            lvAttributes.Enabled = true;
                            tsbDependencies.Enabled = true;
                            gbAttributes.Enabled = true;
                        }

                    },
                    emd.LogicalName);
            }
        }

        #endregion Binding Methods

        public string GetDependencyName(Guid dependencyid, componenttype ctype)
        {
            Entity entity = null; 
            switch(ctype)
            {
                case componenttype.SystemForm:
                    entity = Service.Retrieve(SystemForm.EntityLogicalName, dependencyid, new ColumnSet("formxml", "name"));
                    break;
                case componenttype.SavedQuery:
                    entity = Service.Retrieve(SavedQuery.EntityLogicalName, dependencyid, new ColumnSet("layoutxml", "fetchxml", "name"));
                    break;
                default: return string.Empty;
            }
            
            lstDependencies.Add(entity);

            return entity["name"].ToString();
        }

        public bool RemoveFieldFromForm(string fieldname, Entity eForm)
        {
            SystemForm form = eForm.ToEntity<SystemForm>();
            XDocument formXml = XDocument.Parse(form.FormXml);

            var control = formXml.Descendants("control")
                .Where(x => (x.Attribute("datafieldname") != null && x.Attribute("datafieldname").Value == fieldname) || x.Attribute("id").Value == fieldname);

            if (control != null)
            {
                var cell = control.Select(x => x.Parent);
                var row = cell.Select(x => x.Parent);
                bool isOnlyCellInRow = row.Descendants("cell").Count().Equals(1);

                if (isOnlyCellInRow)
                    row.Remove();
                else
                    cell.Remove();
            }

            Service.Update
            (
                new SystemForm()
                {
                    Id = form.Id,
                    FormXml = formXml.ToString()
                }
            );

            return true;
        }



        public bool RemoveFieldFromView(string fieldname, Entity eView)
        {
            SavedQuery view = eView.ToEntity<SavedQuery>();
            XDocument layoutXml = XDocument.Parse(view.LayoutXml);
            XDocument fetchXml = XDocument.Parse(view.FetchXml);

            var cell = layoutXml.Descendants("cell").Where(x => x.Attribute("name").Value == fieldname);
            var attribute = fetchXml.Descendants("attribute").Where(x => x.Attribute("name").Value == fieldname);
            var orderby = fetchXml.Descendants("order").Where(x => x.Attribute("attribute").Value == fieldname);
            var conditions = fetchXml.Descendants("condition");
            var condition = conditions.Where(x => x.Attribute("attribute").Value == fieldname);
            var filter = conditions.Select(x => x.Parent);

            cell.Remove();
            attribute.Remove();
            orderby.Remove();

            DialogResult dr = MessageBox.Show("Some of the views may contain this attribute on Filter Criteria, do yo want to remove it also from filter?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr.Equals(DialogResult.Yes))
            {
                if (conditions.Count() == 1)
                    filter.Remove();
                else
                    condition.Remove();
            }

            Service.Update
            (
                new SavedQuery()
                {
                    Id = view.Id,
                    LayoutXml = layoutXml.ToString(),
                    FetchXml = fetchXml.ToString()
                }
            );

            return true;
        }
    }
}
