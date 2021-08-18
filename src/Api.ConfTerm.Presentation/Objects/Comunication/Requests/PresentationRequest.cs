using System;
using System.Linq;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Requests
{
    public abstract record PresentationRequest<TApplicationRequest>
    {
        public virtual TApplicationRequest ToApplicationRequest()
            => default;
        
        // In the format YYYY/mm/dd
        protected DateTime GetDateFromPresentationString(string presentationString) {
            var dateSplit = presentationString.Split("/").Select(str => int.Parse(str)).ToArray();
            return new DateTime(dateSplit[2], dateSplit[1], dateSplit[0]);
        }
    }
}
