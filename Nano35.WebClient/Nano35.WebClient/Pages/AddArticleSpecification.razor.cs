using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Nano35.Contracts.Storage.Models;
using Nano35.HttpContext.storage;

namespace Nano35.WebClient.Pages
{
    public partial class AddArticleSpecification :
        ComponentBase
    {
        private SpecHttpContext _model = new SpecHttpContext();
        private List<SpecHttpContext> _addedSpecs = new List<SpecHttpContext>();
        [Parameter] public EventCallback<List<SpecHttpContext>> OnUpdateAddedSepecs { get; set; }

        private void AddSpec()
        {
            _addedSpecs.Add(_model);
            _model = new SpecHttpContext();
            OnUpdateAddedSepecs.InvokeAsync(_addedSpecs);
        }
    }
    
}