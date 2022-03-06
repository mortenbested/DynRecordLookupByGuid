using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecordLookupByGuid
{
    internal class MetadataLoader
    {
        private readonly IOrganizationService orgService;

        public MetadataLoader(IOrganizationService orgService)
        {
            this.orgService = orgService;
        }

        public List<CrmEntity> LoadEntities()
        {
            var entityProperties = new MetadataPropertiesExpression
            {
                AllProperties = false
            };
            entityProperties.PropertyNames.AddRange("LogicalName", "IsIntersect", "IsCustomEntity", "IsManaged", "PrimaryNameAttribute");

            var request = new RetrieveMetadataChangesRequest
            {
                Query = new EntityQueryExpression
                {
                    Properties = entityProperties
                }
            };

            RetrieveMetadataChangesResponse response = (RetrieveMetadataChangesResponse)this.orgService.Execute(request);

            List<CrmEntity> result = new List<CrmEntity>();

            foreach (EntityMetadata entityMeta in response.EntityMetadata)
            {
                if (entityMeta.IsIntersect != true)
                {
                    result.Add(new CrmEntity(
                        entityMeta.LogicalName,
                        entityMeta.IsCustomEntity.GetValueOrDefault(),
                        entityMeta.IsManaged.GetValueOrDefault(),
                        entityMeta.PrimaryNameAttribute
                        ));
                }
            }

            return result;
        }

    }
}
