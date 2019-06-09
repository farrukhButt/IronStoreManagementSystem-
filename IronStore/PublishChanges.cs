using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronStore.ServerEntity;
using IronStore.Entity;
using AutoMapper;

namespace IronStore
{
    public partial class PublishChanges : Form
    {
        public PublishChanges()
        {
            InitializeComponent();
        }

        private void PublishChanges_Load(object sender, EventArgs e)
        {
            try
            {
                AddNewRecordsOnServer();
                GetRecordsFromServer();
                label1.Text = "Successfully completed synchronization";
            }

            catch(Exception ee)
            {
                MessageBox.Show("fail to synchronize records" + System.Environment.NewLine + ee.Message);
            }

        }

        private async void GetRecordsFromServer()
        {
            await Task.Yield();
            ServerSync.DownloadNewData dataDownloader = new ServerSync.DownloadNewData();

            dataDownloader.DownloadNewCustomers();
            dataDownloader.DownloadNewItems();
            dataDownloader.DownloadNewOrders();
            dataDownloader.DownloadNewOrderLines();
            dataDownloader.DownloadNewOrderPayments();
            dataDownloader.DownloadSupplier();
            dataDownloader.DownloadNewSupplierBankDetail();
            dataDownloader.DownloadNewSupplierDuePayments();
            dataDownloader.DownloadNewSupplierPaymentMade();
        }

        private async void AddNewRecordsOnServer()
        {
            await Task.Yield();
            ServerSync.UploadNewData dataUploader = new ServerSync.UploadNewData();

            dataUploader.UploadNewCustomers();
            dataUploader.UploadNewItems();
            dataUploader.UploadNewOrders();
            dataUploader.UploadNewOrderLines();
            dataUploader.UploadNewOrderPayments();
            dataUploader.UploadSuppliers();
            dataUploader.UploadSupplierBankDetail();
            dataUploader.UploadSupplierDuePayment();
            dataUploader.UploadSupplierPaymentMade();
            

        }

        

    }
}
