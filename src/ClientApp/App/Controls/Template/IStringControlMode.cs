using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Controls.Template
{
    public interface IStringControlMode
    {
        void VisibleClick();
        Visible<TernaryString> Value { get; set; }
    }
}