using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecordLookupByGuid
{
    internal class RecordSearcher
    {
        private readonly IOrganizationService orgService;

        public RecordSearcher(IOrganizationService orgService)
        {
            this.orgService = orgService;
        }

        public EntityReference Search(Guid recordGuid, IEnumerable<CrmEntity> entities)
        {
            ExecuteMultipleRequest executeMultipleRequest = new ExecuteMultipleRequest()
            {
                Settings = new ExecuteMultipleSettings()
                {
                    ContinueOnError = true,
                    ReturnResponses = true
                },
                Requests = new OrganizationRequestCollection()
            };

            foreach (CrmEntity entity in entities)
            {
                executeMultipleRequest.Requests.Add(new RetrieveRequest()
                {
                    ColumnSet = new ColumnSet(entity.PrimaryNameAttribute),
                    Target = new EntityReference(entity.LogicalName, recordGuid)
                });
            }

            var executeMultipleResponse = (ExecuteMultipleResponse)orgService.Execute(executeMultipleRequest);

            foreach (ExecuteMultipleResponseItem response in executeMultipleResponse.Responses)
            {
                if (response.Response != null)
                {
                    Entity foundRecord = ((RetrieveResponse)response.Response).Entity;
                    if (foundRecord != null && foundRecord.Id == recordGuid)
                    {
                        EntityReference entityRef = foundRecord.ToEntityReference();
                        CrmEntity entityMeta = entities.FirstOrDefault(e => e.LogicalName == foundRecord.LogicalName);
                        entityRef.Name = foundRecord.Contains(entityMeta.PrimaryNameAttribute) 
                            ? foundRecord.GetAttributeValue<string>(entityMeta.PrimaryNameAttribute)
                            : entityRef.Id.ToString();
                        return entityRef;
                    }
                }
            }

            return null;
        }
    }
}
