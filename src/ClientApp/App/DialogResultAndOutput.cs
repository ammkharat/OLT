using System.Windows.Forms;

namespace Com.Suncor.Olt.Client
{
    public class DialogResultAndOutput<T>
    {
        private readonly DialogResult result;
        private readonly T output;

        public DialogResultAndOutput(DialogResult result, T output)
        {
            this.result = result;
            this.output = output;
        }

        public DialogResult Result
        {
            get { return result; }
        }

        public T Output
        {
            get { return output; }
        }
    }
}
