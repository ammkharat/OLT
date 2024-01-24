namespace Com.Suncor.Olt.Client
{
    public enum VisibleState
    {
        Visible = 0,
        Invisible = 1
    }

    public class Visible<T>
    {
        private readonly VisibleState visibleState;
        private readonly T value;

        public Visible(VisibleState visibleState, T value)
        {
            this.visibleState = visibleState;
            this.value = value;
        }

        public T Value
        {
            get { return value; }
        }

        public VisibleState VisibleState
        {
            get { return visibleState; }
        }
    }
}