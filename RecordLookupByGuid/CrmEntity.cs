using System;
using System.Collections.Generic;

namespace RecordLookupByGuid
{
    internal class CrmEntity
    {
        public string LogicalName { get; }
        public bool IsCustomEntity { get; }
        public bool IsManaged { get; }
        public string PrimaryNameAttribute { get; }

        public CrmEntity(string logicalName, bool isCustomEntity, bool isManaged, string primaryNameAttribute)
        {
            this.LogicalName = logicalName;
            IsCustomEntity = isCustomEntity;
            IsManaged = isManaged;
            PrimaryNameAttribute = primaryNameAttribute;
        }

        public override bool Equals(object obj)
        {
            return obj is CrmEntity entity &&
                   LogicalName == entity.LogicalName;
        }

        public override int GetHashCode()
        {
            return 1374632327 + EqualityComparer<string>.Default.GetHashCode(LogicalName);
        }
    }
}
