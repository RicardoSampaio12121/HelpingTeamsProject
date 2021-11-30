/*
 * This classes have the purpose to store the information given by te XML and JSON
 * documents.
 */

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PSPGNR
{
    [XmlRoot(ElementName = "utente")]
    public class Utente
    {
        [JsonProperty("nus")]
        [XmlElement(ElementName = "nus")]
        public string nus { get; set; }

        [JsonProperty("first-name")]
        [XmlElement(ElementName = "first-name")]
        public string FirstName { get; set; }

        [JsonProperty("last-name")]
        [XmlElement(ElementName = "last-name")]
        public string LastName { get; set; }

        [JsonProperty("infracao")]
        [XmlElement(ElementName = "infracao")]
        public string infracao { get; set; }
    }

    [XmlRoot(ElementName = "Fiscalizacao")]
    public class Fiscalizacao
    {
        [JsonProperty("utente")]
        [XmlElement(ElementName = "utente")]
        public List<Utente> utente { get; set; }
    }

    public class Root
    {
        public Fiscalizacao Fiscalizacao { get; set; }
    }


}
