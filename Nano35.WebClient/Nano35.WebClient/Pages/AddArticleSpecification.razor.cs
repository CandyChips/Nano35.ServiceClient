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
        [Parameter] public List<SpecHttpContext> AddedSpecs { get; set; }

        private void AddSpec()
        {
            AddedSpecs.Add(_model);
            _model = new SpecHttpContext();
        }
    }
    
}