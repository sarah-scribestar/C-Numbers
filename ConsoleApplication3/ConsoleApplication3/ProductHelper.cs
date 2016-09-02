using FileHelpers;

namespace DecryptNeo4j
{
    [DelimitedRecord(",")]
    [IgnoreFirst()]
    class DocInfo
    {
        public string ID;
        public string EncName;
        public string EncKey;
        public string DocVer;
        public string Email;
    }
}
