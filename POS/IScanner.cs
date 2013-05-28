using System;

namespace POS
{
    public interface IScanner
    {
        event EventHandler<BarcodeScannedEventArgs> BarcodeScanned;
    }
}