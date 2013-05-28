using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using POS.DAL;

namespace POS
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IScanner scanner;

        public MainWindowViewModel(IScanner scanner)
        {
            this.scanner = scanner;
            this.scanner.BarcodeScanned += Scanner_BarcodeScanned;
        }

        private void Scanner_BarcodeScanned(object sender, BarcodeScannedEventArgs e)
        {
            Product product;
            using (var db = new MyContext())
            {
                 product = db.Products.FirstOrDefault(p => p.Barcode == e.Barcode);
            }

            if (product!=null)
            {
                ProductCode = product.CatalogCode;
                ProductName = product.CatalogName;
                ProductPrice = string.Format("{0} $", product.Price);
            }
            else
            {
                ProductCode = string.Empty;
                ProductName = "N/A";
                ProductPrice = string.Empty;
            }
        }

        private string productCode;

        public string ProductCode
        {
            get { return productCode; }
            set
            {
                productCode = value;
                NotifyPropertyChanged();
            }
        }

        private string productName;

        public string ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
                NotifyPropertyChanged();
            }
        }

        private string productPrice;
        public string ProductPrice
        {
            get { return productPrice; }
            set
            {
                productPrice = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string property = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        } 
    }
}
