//INCLUDE_ASSEMBLY System.dll
//INCLUDE_ASSEMBLY System.Windows.Forms.dll

using System;
using IOComm;

namespace DXLog.net
{
    public class PttToggle : ScriptClass
    {
        public void Initialize(FrmMain main)
        {
        }
        public void Deinitialize()
        {
        }
        public void Main(FrmMain main, ContestData cdata, COMMain comMain)
        {
            var radioObject = comMain.RadioObject(cdata.FocusedRadio);
            if (radioObject == null)
            {
                main.SetMainStatusText(string.Format("CAT object for radio {0} isn't available!", cdata.FocusedRadio));
                return;
            }

            if (radioObject.TXStatus)
            {
                radioObject.SendCustomCommand("RX;");
            }
            else
            {
                radioObject.SendCustomCommand("TX;");
            }

        }
    }
}