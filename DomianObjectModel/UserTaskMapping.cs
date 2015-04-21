using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    [Serializable]
    public class UserTaskMaping: BaseDomainObjectModel
    {
        public Int32 UserTaskMappingId { get; set; }

        public String Description { get; set; }

        public MetaData MetadataUserTask { get; set; }
    }
}
