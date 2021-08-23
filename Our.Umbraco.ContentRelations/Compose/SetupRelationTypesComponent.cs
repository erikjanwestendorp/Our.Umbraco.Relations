﻿using Microsoft.Extensions.Logging;
using Our.Umbraco.ContentRelations.Static;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;

namespace Our.Umbraco.ContentRelations.Compose
{
    public class SetupRelationTypesComponent : IComponent
    {

        private readonly ILogger<SetupRelationTypesComponent> _logger;
        private readonly IRelationService _relationService;

        public SetupRelationTypesComponent(
            ILogger<SetupRelationTypesComponent> logger,
            IRelationService relationService)
        {
            _logger = logger;
            _relationService = relationService;
        }

        public void Initialize()
        {
            var contentRelationType = _relationService.GetRelationTypeByAlias(Constants.RelationTypes.RelatedContent.Alias);

            if (contentRelationType != null) 
                return;
            
            var relationType = new RelationType(Constants.RelationTypes.RelatedContent.Alias, Constants.RelationTypes.RelatedContent.Name)
            {
                IsBidirectional = true
            };
            _relationService.Save(relationType);

        }

        public void Terminate() {} 
    }
}
