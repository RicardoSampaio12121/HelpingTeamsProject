using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PSPGNR
{
    [XmlRoot(ElementName = "utente")]
    public class Utente
    {
        [XmlElement(ElementName = "nus")]
        public string Nus { get; set; }
        [XmlElement(ElementName = "first-name")]
        public string Firstname { get; set; }
        [XmlElement(ElementName = "last-name")]
        public string Lastname { get; set; }
        [XmlElement(ElementName = "infracao")]
        public string Infracao { get; set; }
    }

    [XmlRoot(ElementName = "Fiscalizacao")]
    public class Fiscalizacao
    {
        [XmlElement(ElementName = "utente")]
        public List<Utente> Utente { get; set; }
    }
}
