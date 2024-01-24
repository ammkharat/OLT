using System;
using System.ComponentModel;

namespace Com.Suncor.Olt.Client.Utilities
{
    public class PrintWithDialogFocus
    {
        public void Print(Action performPrint)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += DoNothing;
            worker.RunWorkerCompleted += WorkerCompleted;
            worker.RunWorkerAsync(performPrint);
        }

        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Action performPrint = (Action)e.Result;
            performPrint();
        }

        // This is because the ToolStripButton (that we use for the print button) doesn't return from its click event. It's a known issue on the internets.
        // For some reason, having the event kick off a dummy background thread and then return works. You can't run the printing in the background thread. Print
        // Dialogs have to be kicked off on the UI thread. I tried to do the whole thing in the background for a while and it ended badly. (Dustin, Nov 2012)
        private void DoNothing(object sender, DoWorkEventArgs e)
        {
            e.Result = e.Argument;
        }
    }
}
