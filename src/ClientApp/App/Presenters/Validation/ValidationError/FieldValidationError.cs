using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;

namespace Com.Suncor.Olt.Client.Presenters.Validation.ValidationError
{
    public class FieldValidationError : IValidationIssue
    {
        private readonly string message;
        private readonly List<string> formControlsToBindError;

        public FieldValidationError(string message, ProblemLevel problemLevel, params string[] formControlsToBindError)
        {
            this.message = message;
            ProblemLevel = problemLevel;
            this.formControlsToBindError = new List<string>(formControlsToBindError);
        }

        public ProblemLevel ProblemLevel { get; private set; }

        /// <summary>
        /// Bind this Validation Error to the controls on the form
        /// </summary>
        /// <param name="view"></param>
        public void Bind(IWorkPermitFormView view)
        {
            formControlsToBindError.ForEach(controlName => view.SetError(controlName, ProblemLevel, message));
        }
    }
}