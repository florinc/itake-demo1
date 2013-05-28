using System;

namespace POS
{
    public class BarcodeScannedEventArgs : EventArgs
    {
        public BarcodeScannedEventArgs(string barcode)
        {
            Barcode = barcode;
        }

        public string Barcode { get; set; }
    }
}