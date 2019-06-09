using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IronStore
{
    public partial class Invoice : Form
    {

        List<InvoiceOrderList> _orderList;
        string _total;
        string _bill;
        string _paymentMade;
        string _oldpayments;
        string _customer;
        string _adress;
        string _invoiceId;
        string _detail;
        string _deliveryDate;
        string _orderDate;
        public Invoice(List<InvoiceOrderList> list,string total, string bill, string paymentMade, string oldpayments, string customer, string adress, string invoiceID, string detail, string deliveryDate, string orderDate)
        {
            _orderList = list;
            _adress = adress;
            _customer = customer;
            _detail = detail;
            _orderDate = orderDate;
            _deliveryDate = deliveryDate;
            _total = total;
            _bill = bill;
            _paymentMade = paymentMade;
            _invoiceId = invoiceID;
            _oldpayments = oldpayments;
            InitializeComponent();
        }

        private void Invoice_Load(object sender, EventArgs e)
        {
            if (_adress.Count() <= 0 || _adress == null)
            {
                _adress = " ";
            }
            if (_detail.Count() <= 0 || _detail == null)
            {
                //_detail = " ";
            }
            
            InvoiceOrderListBindingSource.DataSource = _orderList;
            Microsoft.Reporting.WinForms.ReportParameter[] rParameters = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("InvoiceID",_invoiceId.ToString()),
                 new Microsoft.Reporting.WinForms.ReportParameter("Bill",_bill.ToString()),
                  new Microsoft.Reporting.WinForms.ReportParameter("Total",_total.ToString()),
                   new Microsoft.Reporting.WinForms.ReportParameter("PaymentMade",_paymentMade.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("OrderDate",_orderDate.ToString()),
                     new Microsoft.Reporting.WinForms.ReportParameter("DeliveryDate",_deliveryDate.ToString()),
                      new Microsoft.Reporting.WinForms.ReportParameter("Customer",_customer.ToString()),
                       new Microsoft.Reporting.WinForms.ReportParameter("Adress",_adress.ToString()),
                        new Microsoft.Reporting.WinForms.ReportParameter("OldPayments",_oldpayments.ToString()),
                         new Microsoft.Reporting.WinForms.ReportParameter("Detail",_detail.ToString()),
            };
            reportViewer1.LocalReport.SetParameters(rParameters);
            //System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
            //pg.Margins.Top = 0;
            //pg.Margins.Bottom = 0;
            //pg.Margins.Left = 0;
            //pg.Margins.Right = 0;
            //System.Drawing.Printing.PaperSize size = new PaperSize("Customer",600,800);
            //size.RawKind = (int)PaperKind.Custom;
            //pg.PaperSize = size;
            //reportViewer1.SetPageSettings(pg);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
