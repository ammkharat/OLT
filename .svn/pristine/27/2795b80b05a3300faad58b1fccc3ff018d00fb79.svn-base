using System.Drawing;
using Com.Suncor.Olt.Client.Presenters.Validation;

namespace Com.Suncor.Olt.Client.Forms
{
    public class GroupColour
    {
        public static readonly GroupColour Error = new GroupColour(Color.Red, "red", ProblemLevel.RequiredForSave);
        public static readonly GroupColour Warning = new GroupColour(Color.Yellow, "yellow", ProblemLevel.Warning);
        public static readonly GroupColour ErrorOnApproval = new GroupColour(Color.Orange, "orange", ProblemLevel.RequiredForApproval);        

        private readonly Color drawingColour;
        private readonly string displayName;
        private readonly ProblemLevel problemLevel;

        private GroupColour(Color drawingColour, string displayName, ProblemLevel problemLevel)
        {
            this.drawingColour = drawingColour;
            this.displayName = displayName;
            this.problemLevel = problemLevel;
        }

        public ProblemLevel ProblemLevel
        {
            get { return problemLevel; }
        }

        public Color DrawingColor
        {
            get { return drawingColour; }
        }

        public override string ToString()
        {
            return displayName;
        }

        public static GroupColour GetByColor(Color color)
        {
            if (color == Color.Red) return Error;
            if (color == Color.Yellow) return Warning;
            if (color == Color.Orange) return ErrorOnApproval;            
            return null;
        }

        public static GroupColour GetByProblemLevel(ProblemLevel problemLevel)
        {
            if (problemLevel == ProblemLevel.Warning) return Warning;
            if (problemLevel == ProblemLevel.RequiredForApproval) return ErrorOnApproval;
            if (problemLevel == ProblemLevel.RequiredForSave) return Error;            
            return null;
        }
    }
}