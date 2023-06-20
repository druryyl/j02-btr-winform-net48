namespace btr.winform48.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.PurchasingTab = new System.Windows.Forms.RibbonTab();
            this.PurchaseOrderPanel = new System.Windows.Forms.RibbonPanel();
            this.PoButton = new System.Windows.Forms.RibbonButton();
            this.ReportPoButton = new System.Windows.Forms.RibbonButton();
            this.InvoicePanel = new System.Windows.Forms.RibbonPanel();
            this.InvoiceButton = new System.Windows.Forms.RibbonButton();
            this.ClaimButton = new System.Windows.Forms.RibbonButton();
            this.InvoiceReportButton = new System.Windows.Forms.RibbonButton();
            this.MasterPurchasingPanel = new System.Windows.Forms.RibbonPanel();
            this.Principal = new System.Windows.Forms.RibbonButton();
            this.SalesTab = new System.Windows.Forms.RibbonTab();
            this.FakturPanel = new System.Windows.Forms.RibbonPanel();
            this.FakturButton = new System.Windows.Forms.RibbonButton();
            this.FakturReportButton = new System.Windows.Forms.RibbonButton();
            this.MasterSalePanel = new System.Windows.Forms.RibbonPanel();
            this.OutletButton = new System.Windows.Forms.RibbonButton();
            this.SalesPersonButton = new System.Windows.Forms.RibbonButton();
            this.InventoryTab = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton4 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton5 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton6 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton7 = new System.Windows.Forms.RibbonButton();
            this.MasterInventoryPanel = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton8 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton9 = new System.Windows.Forms.RibbonButton();
            this.FinanceTab = new System.Windows.Forms.RibbonTab();
            this.SettingTab = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.CaptionBarVisible = false;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 72);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon1.Size = new System.Drawing.Size(846, 138);
            this.ribbon1.TabIndex = 1;
            this.ribbon1.Tabs.Add(this.PurchasingTab);
            this.ribbon1.Tabs.Add(this.SalesTab);
            this.ribbon1.Tabs.Add(this.InventoryTab);
            this.ribbon1.Tabs.Add(this.FinanceTab);
            this.ribbon1.Tabs.Add(this.SettingTab);
            this.ribbon1.Text = "ribbon1";
            // 
            // PurchasingTab
            // 
            this.PurchasingTab.Name = "PurchasingTab";
            this.PurchasingTab.Panels.Add(this.PurchaseOrderPanel);
            this.PurchasingTab.Panels.Add(this.InvoicePanel);
            this.PurchasingTab.Panels.Add(this.MasterPurchasingPanel);
            this.PurchasingTab.Text = "Purchasing";
            // 
            // PurchaseOrderPanel
            // 
            this.PurchaseOrderPanel.Items.Add(this.PoButton);
            this.PurchaseOrderPanel.Items.Add(this.ReportPoButton);
            this.PurchaseOrderPanel.Name = "PurchaseOrderPanel";
            this.PurchaseOrderPanel.Text = "Purchase Order";
            // 
            // PoButton
            // 
            this.PoButton.Image = global::btr.winform48.Properties.Resources.purchase_order_48px;
            this.PoButton.LargeImage = global::btr.winform48.Properties.Resources.purchase_order_48px;
            this.PoButton.Name = "PoButton";
            this.PoButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("PoButton.SmallImage")));
            this.PoButton.Text = "PO";
            // 
            // ReportPoButton
            // 
            this.ReportPoButton.Image = global::btr.winform48.Properties.Resources.documents_48px;
            this.ReportPoButton.LargeImage = global::btr.winform48.Properties.Resources.documents_48px;
            this.ReportPoButton.Name = "ReportPoButton";
            this.ReportPoButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("ReportPoButton.SmallImage")));
            this.ReportPoButton.Text = "PO Report";
            // 
            // InvoicePanel
            // 
            this.InvoicePanel.Items.Add(this.InvoiceButton);
            this.InvoicePanel.Items.Add(this.ClaimButton);
            this.InvoicePanel.Items.Add(this.InvoiceReportButton);
            this.InvoicePanel.Name = "InvoicePanel";
            this.InvoicePanel.Text = "Invoice";
            // 
            // InvoiceButton
            // 
            this.InvoiceButton.Image = global::btr.winform48.Properties.Resources.invoice_48px;
            this.InvoiceButton.LargeImage = global::btr.winform48.Properties.Resources.invoice_48px;
            this.InvoiceButton.Name = "InvoiceButton";
            this.InvoiceButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("InvoiceButton.SmallImage")));
            this.InvoiceButton.Text = "Invoice";
            // 
            // ClaimButton
            // 
            this.ClaimButton.Image = global::btr.winform48.Properties.Resources.report_card_48px;
            this.ClaimButton.LargeImage = global::btr.winform48.Properties.Resources.report_card_48px;
            this.ClaimButton.Name = "ClaimButton";
            this.ClaimButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("ClaimButton.SmallImage")));
            this.ClaimButton.Text = "Claim";
            // 
            // InvoiceReportButton
            // 
            this.InvoiceReportButton.Image = global::btr.winform48.Properties.Resources.documents_48px;
            this.InvoiceReportButton.LargeImage = global::btr.winform48.Properties.Resources.documents_48px;
            this.InvoiceReportButton.Name = "InvoiceReportButton";
            this.InvoiceReportButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("InvoiceReportButton.SmallImage")));
            this.InvoiceReportButton.Text = "Invoice Report";
            // 
            // MasterPurchasingPanel
            // 
            this.MasterPurchasingPanel.Items.Add(this.Principal);
            this.MasterPurchasingPanel.Name = "MasterPurchasingPanel";
            this.MasterPurchasingPanel.Text = "Master Data";
            // 
            // Principal
            // 
            this.Principal.Image = global::btr.winform48.Properties.Resources.factory_48px;
            this.Principal.LargeImage = global::btr.winform48.Properties.Resources.factory_48px;
            this.Principal.Name = "Principal";
            this.Principal.SmallImage = ((System.Drawing.Image)(resources.GetObject("Principal.SmallImage")));
            this.Principal.Text = "Principal";
            // 
            // SalesTab
            // 
            this.SalesTab.Name = "SalesTab";
            this.SalesTab.Panels.Add(this.FakturPanel);
            this.SalesTab.Panels.Add(this.MasterSalePanel);
            this.SalesTab.Text = "Sales";
            // 
            // FakturPanel
            // 
            this.FakturPanel.Items.Add(this.FakturButton);
            this.FakturPanel.Items.Add(this.FakturReportButton);
            this.FakturPanel.Name = "FakturPanel";
            this.FakturPanel.Text = "Faktur";
            // 
            // FakturButton
            // 
            this.FakturButton.Image = global::btr.winform48.Properties.Resources.day_view_48px;
            this.FakturButton.LargeImage = global::btr.winform48.Properties.Resources.day_view_48px;
            this.FakturButton.Name = "FakturButton";
            this.FakturButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("FakturButton.SmallImage")));
            this.FakturButton.Text = "Faktur";
            // 
            // FakturReportButton
            // 
            this.FakturReportButton.Image = global::btr.winform48.Properties.Resources.documents_48px;
            this.FakturReportButton.LargeImage = global::btr.winform48.Properties.Resources.documents_48px;
            this.FakturReportButton.Name = "FakturReportButton";
            this.FakturReportButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("FakturReportButton.SmallImage")));
            this.FakturReportButton.Text = "Faktur Report";
            // 
            // MasterSalePanel
            // 
            this.MasterSalePanel.Items.Add(this.OutletButton);
            this.MasterSalePanel.Items.Add(this.SalesPersonButton);
            this.MasterSalePanel.Name = "MasterSalePanel";
            this.MasterSalePanel.Text = "Master Data";
            // 
            // OutletButton
            // 
            this.OutletButton.Image = global::btr.winform48.Properties.Resources._3d_farm_48px;
            this.OutletButton.LargeImage = global::btr.winform48.Properties.Resources._3d_farm_48px;
            this.OutletButton.Name = "OutletButton";
            this.OutletButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("OutletButton.SmallImage")));
            this.OutletButton.Text = "Outlet";
            // 
            // SalesPersonButton
            // 
            this.SalesPersonButton.Image = global::btr.winform48.Properties.Resources.caretaker_48px;
            this.SalesPersonButton.LargeImage = global::btr.winform48.Properties.Resources.caretaker_48px;
            this.SalesPersonButton.Name = "SalesPersonButton";
            this.SalesPersonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("SalesPersonButton.SmallImage")));
            this.SalesPersonButton.Text = "Sales Person";
            // 
            // InventoryTab
            // 
            this.InventoryTab.Name = "InventoryTab";
            this.InventoryTab.Panels.Add(this.ribbonPanel1);
            this.InventoryTab.Panels.Add(this.ribbonPanel2);
            this.InventoryTab.Panels.Add(this.ribbonPanel3);
            this.InventoryTab.Panels.Add(this.MasterInventoryPanel);
            this.InventoryTab.Text = "Inventory";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.ribbonButton1);
            this.ribbonPanel1.Items.Add(this.ribbonButton4);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "Receiving";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = global::btr.winform48.Properties.Resources.delivered_48px;
            this.ribbonButton1.LargeImage = global::btr.winform48.Properties.Resources.delivered_48px;
            this.ribbonButton1.Name = "ribbonButton1";
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "Goods Receipt";
            // 
            // ribbonButton4
            // 
            this.ribbonButton4.Image = global::btr.winform48.Properties.Resources.documents_48px;
            this.ribbonButton4.LargeImage = global::btr.winform48.Properties.Resources.documents_48px;
            this.ribbonButton4.Name = "ribbonButton4";
            this.ribbonButton4.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.SmallImage")));
            this.ribbonButton4.Text = "Receipt Report";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.ribbonButton2);
            this.ribbonPanel2.Items.Add(this.ribbonButton5);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Text = "Delivery";
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = global::btr.winform48.Properties.Resources.truck_48px;
            this.ribbonButton2.LargeImage = global::btr.winform48.Properties.Resources.truck_48px;
            this.ribbonButton2.Name = "ribbonButton2";
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "Delivery";
            // 
            // ribbonButton5
            // 
            this.ribbonButton5.Image = global::btr.winform48.Properties.Resources.documents_48px;
            this.ribbonButton5.LargeImage = global::btr.winform48.Properties.Resources.documents_48px;
            this.ribbonButton5.Name = "ribbonButton5";
            this.ribbonButton5.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.SmallImage")));
            this.ribbonButton5.Text = "Delivery Report";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Items.Add(this.ribbonButton3);
            this.ribbonPanel3.Items.Add(this.ribbonButton6);
            this.ribbonPanel3.Items.Add(this.ribbonButton7);
            this.ribbonPanel3.Name = "ribbonPanel3";
            this.ribbonPanel3.Text = "Stock Control";
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.Image = global::btr.winform48.Properties.Resources.trolley_48px1;
            this.ribbonButton3.LargeImage = global::btr.winform48.Properties.Resources.trolley_48px1;
            this.ribbonButton3.Name = "ribbonButton3";
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            this.ribbonButton3.Text = "Mutasi";
            // 
            // ribbonButton6
            // 
            this.ribbonButton6.Image = global::btr.winform48.Properties.Resources.to_do_48px;
            this.ribbonButton6.LargeImage = global::btr.winform48.Properties.Resources.to_do_48px;
            this.ribbonButton6.Name = "ribbonButton6";
            this.ribbonButton6.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.SmallImage")));
            this.ribbonButton6.Text = "Adjustment";
            // 
            // ribbonButton7
            // 
            this.ribbonButton7.Image = global::btr.winform48.Properties.Resources.transaction_list_48px;
            this.ribbonButton7.LargeImage = global::btr.winform48.Properties.Resources.transaction_list_48px;
            this.ribbonButton7.Name = "ribbonButton7";
            this.ribbonButton7.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton7.SmallImage")));
            this.ribbonButton7.Text = "Buku Stok";
            // 
            // MasterInventoryPanel
            // 
            this.MasterInventoryPanel.Items.Add(this.ribbonButton8);
            this.MasterInventoryPanel.Items.Add(this.ribbonButton9);
            this.MasterInventoryPanel.Name = "MasterInventoryPanel";
            this.MasterInventoryPanel.Text = "Data Master";
            // 
            // ribbonButton8
            // 
            this.ribbonButton8.Image = global::btr.winform48.Properties.Resources.ingredients_48px;
            this.ribbonButton8.LargeImage = global::btr.winform48.Properties.Resources.ingredients_48px;
            this.ribbonButton8.Name = "ribbonButton8";
            this.ribbonButton8.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton8.SmallImage")));
            this.ribbonButton8.Text = "Product";
            // 
            // ribbonButton9
            // 
            this.ribbonButton9.Image = global::btr.winform48.Properties.Resources.warehouse_48px;
            this.ribbonButton9.LargeImage = global::btr.winform48.Properties.Resources.warehouse_48px;
            this.ribbonButton9.Name = "ribbonButton9";
            this.ribbonButton9.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton9.SmallImage")));
            this.ribbonButton9.Text = "Warehouse";
            // 
            // FinanceTab
            // 
            this.FinanceTab.Name = "FinanceTab";
            this.FinanceTab.Panels.Add(this.ribbonPanel4);
            this.FinanceTab.Panels.Add(this.ribbonPanel5);
            this.FinanceTab.Panels.Add(this.ribbonPanel6);
            this.FinanceTab.Text = "Finance";
            // 
            // SettingTab
            // 
            this.SettingTab.Name = "SettingTab";
            this.SettingTab.Text = "Setting";
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.Name = "ribbonPanel4";
            this.ribbonPanel4.Text = "Hutang";
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.Name = "ribbonPanel5";
            this.ribbonPanel5.Text = "PIutang";
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.Name = "ribbonPanel6";
            this.ribbonPanel6.Text = "Tax";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(846, 495);
            this.Controls.Add(this.ribbon1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Bintang Timur Rahayu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab PurchasingTab;
        private System.Windows.Forms.RibbonPanel PurchaseOrderPanel;
        private System.Windows.Forms.RibbonTab SalesTab;
        private System.Windows.Forms.RibbonPanel FakturPanel;
        private System.Windows.Forms.RibbonTab InventoryTab;
        private System.Windows.Forms.RibbonTab FinanceTab;
        private System.Windows.Forms.RibbonPanel InvoicePanel;
        private System.Windows.Forms.RibbonTab SettingTab;
        private System.Windows.Forms.RibbonButton PoButton;
        private System.Windows.Forms.RibbonPanel MasterPurchasingPanel;
        private System.Windows.Forms.RibbonButton ReportPoButton;
        private System.Windows.Forms.RibbonButton InvoiceButton;
        private System.Windows.Forms.RibbonButton InvoiceReportButton;
        private System.Windows.Forms.RibbonButton ClaimButton;
        private System.Windows.Forms.RibbonButton Principal;
        private System.Windows.Forms.RibbonButton FakturButton;
        private System.Windows.Forms.RibbonButton FakturReportButton;
        private System.Windows.Forms.RibbonPanel MasterSalePanel;
        private System.Windows.Forms.RibbonButton OutletButton;
        private System.Windows.Forms.RibbonButton SalesPersonButton;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonPanel MasterInventoryPanel;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.RibbonButton ribbonButton3;
        private System.Windows.Forms.RibbonButton ribbonButton4;
        private System.Windows.Forms.RibbonButton ribbonButton5;
        private System.Windows.Forms.RibbonButton ribbonButton6;
        private System.Windows.Forms.RibbonButton ribbonButton7;
        private System.Windows.Forms.RibbonButton ribbonButton8;
        private System.Windows.Forms.RibbonButton ribbonButton9;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonPanel ribbonPanel6;
    }
}