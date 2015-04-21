using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remielsoft.JetSave.DomianObjectModel
{
    public class NewsLetterDom:BaseDomainObjectModel
    {
        public int TopicId { get; set; }
        public string NewsDate { get; set; }
        public string TopicName { get; set; }
        public string Description { get; set; }
        public string IsDeleted { get; set; }
        public string ImageName { get; set; }
    }
}
