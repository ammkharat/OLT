using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using log4net;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class DocumentLinksControl : UserControl, IDocumentsLinkControl
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(DocumentLinksControl));

        public event Action LinkOpened;
        public event Action LinkAdded;
        
        public DocumentLinksControl()
        {
            Initialize();        

            RegisterPresenterEventHandlers();
        }

        /// <summary>
        /// Register event handlers with presenter
        /// </summary>
        private void RegisterPresenterEventHandlers()
        {            
            AddLinkButton.Click += OnAddLinkClicked;
            RemoveLinkButton.Click += OnRemoveLinkClicked;
            openLinkButton.Click += OnOpenLinkClicked;
            Resize += DocumentsControl_Resize;
        }

        void DocumentsControl_Resize(object sender, EventArgs e)
        {
            documentLinksListBox.Top = 0;
            documentLinksListBox.Left  = 0;
            documentLinksListBox.Height = Height;
        }

        /// <summary>
        /// Form initialization code
        /// </summary>
        private void Initialize()
        {
            InitializeComponent();

            documentLinksListBox.DisplayMember = "TitleWithURL";
        }


        private void OnRemoveLinkClicked(object sender, EventArgs e)
        {
            DocumentLink removedDocumentLink = documentLinksListBox.SelectedItem as DocumentLink;

            List<DocumentLink> documentLinks = documentLinksListBox.DataSource as List<DocumentLink>;
            List<DocumentLink> newDocumentLinks = new List<DocumentLink>();
            //if there is currently a selected link then ask to remove it
            // and remove it.
            if (removedDocumentLink != null && documentLinks != null)
            {
                if (documentLinks.Contains(removedDocumentLink))
                {
                    //rebuild the list if it is not null
                    if (documentLinksListBox.DataSource != null)
                        foreach (DocumentLink documentLink in documentLinks)
                            newDocumentLinks.Add(documentLink);

                    newDocumentLinks.Remove(removedDocumentLink);
                    documentLinksListBox.DataSource = newDocumentLinks;
                }
            }
        }

        private void OnOpenLinkClicked(object sender, EventArgs e)
        {
            DocumentLink toOpenDocumentLink = documentLinksListBox.SelectedItem as DocumentLink; 

            if (toOpenDocumentLink != null && !toOpenDocumentLink.Url.IsNullOrEmptyOrWhitespace())
            {
                if (LinkOpened != null)
                {
                    LinkOpened();
                }

                try
                {
                    Process.Start(toOpenDocumentLink.Url);
                }
                catch (Win32Exception win32Exception)
                {
                    if (NoApplicationIsAssociatedWithLink(win32Exception))
                    {
                        string messageText =
                            string.Format(StringResources.DocumentLinkNoAssociatedApplicationMessageBoxText, toOpenDocumentLink.Url);
                        string caption = StringResources.DocumentLinkNoAssociatedApplicationMessageBoxCaption;

                        logger.Info(messageText);
                        OltMessageBox.Show(Form.ActiveForm, messageText, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string messageText = 
                            string.Format(StringResources.DocumentLinkNotFoundMessageBoxText, toOpenDocumentLink.Url);
                        string caption = StringResources.DocumentLinkNotFoundMessageBoxCaption;

                        logger.Info(messageText);
                        OltMessageBox.Show(Form.ActiveForm, messageText, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                        
                }
                catch (Exception otherException)
                {
                    string messageText =
                        string.Format(StringResources.DocumentLinkOpenErrorMessageText, toOpenDocumentLink.Url);
                    string caption = StringResources.DocumentLinkOpenErrorMessageBoxCaption;

                    logger.Error(messageText + " - " + otherException);
                    OltMessageBox.Show(Form.ActiveForm, messageText, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
        }

        private static bool NoApplicationIsAssociatedWithLink(Win32Exception win32Exception)
        {
            return win32Exception.NativeErrorCode == 1155;
        }

        private void OnAddLinkClicked(object sender, EventArgs e)
        {               
            DocumentLink newDocumentLink = ShowAddDialogAndCreateNewDocumentLink();

            if (newDocumentLink == null) 
            {
                return; 
            }

            List<DocumentLink> documentLinks = GetCopyOfCurrentLinks();
            documentLinks.Add(newDocumentLink);
            documentLinksListBox.DataSource = documentLinks;

            if (LinkAdded != null)
            {
                LinkAdded();
            }
        }

        private List<DocumentLink> GetCopyOfCurrentLinks()
        {
            if (DataSource == null)
            {
                return new List<DocumentLink>();
            }
            return new List<DocumentLink>((List<DocumentLink>)DataSource);
        }

        #region IDocumentsLinkControl Members       
        
        public object DataSource
        {
            get { return documentLinksListBox.DataSource; }
            set { documentLinksListBox.DataSource = value; }
        }

        #endregion

        private DocumentLink ShowAddDialogAndCreateNewDocumentLink()
        {
            AddNewDocumentLinkForm frm = new AddNewDocumentLinkForm
                                                     {StartPosition = FormStartPosition.CenterParent};

            frm.ShowDialog(this);

            return frm.NewDocumentLink;            
        }


        public bool ReadOnlyList
        {
            get
            {
                return AddLinkButton.Enabled ;
            }
            set 
            {
                AddLinkButton.Enabled = value;
                RemoveLinkButton.Enabled = value;
            }
        }


    }
}
