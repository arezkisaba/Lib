namespace Lib.ApiServices.Plex
{
    public class GetSectionsResponse
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class MediaContainer
        {
            private MediaContainerDirectory[] directoriesField;

            private int sizeField;

            private int allowSyncField;

            private string identifierField;

            private string mediaTagPrefixField;

            private int mediaTagVersionField;

            private string title1Field;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Directory")]
            public MediaContainerDirectory[] Directories
            {
                get
                {
                    return this.directoriesField;
                }
                set
                {
                    this.directoriesField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int size
            {
                get
                {
                    return this.sizeField;
                }
                set
                {
                    this.sizeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int allowSync
            {
                get
                {
                    return this.allowSyncField;
                }
                set
                {
                    this.allowSyncField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string identifier
            {
                get
                {
                    return this.identifierField;
                }
                set
                {
                    this.identifierField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string mediaTagPrefix
            {
                get
                {
                    return this.mediaTagPrefixField;
                }
                set
                {
                    this.mediaTagPrefixField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int mediaTagVersion
            {
                get
                {
                    return this.mediaTagVersionField;
                }
                set
                {
                    this.mediaTagVersionField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string title1
            {
                get
                {
                    return this.title1Field;
                }
                set
                {
                    this.title1Field = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class MediaContainerDirectory
        {

            private MediaContainerDirectoryLocation locationField;

            private int allowSyncField;

            private string artField;

            private string compositeField;

            private int filtersField;

            private int refreshingField;

            private string thumbField;

            private int keyField;

            private string typeField;

            private string titleField;

            private string agentField;

            private string scannerField;

            private string languageField;

            private string uuidField;

            private int updatedAtField;

            private int createdAtField;

            /// <remarks/>
            public MediaContainerDirectoryLocation Location
            {
                get
                {
                    return this.locationField;
                }
                set
                {
                    this.locationField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int allowSync
            {
                get
                {
                    return this.allowSyncField;
                }
                set
                {
                    this.allowSyncField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string art
            {
                get
                {
                    return this.artField;
                }
                set
                {
                    this.artField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string composite
            {
                get
                {
                    return this.compositeField;
                }
                set
                {
                    this.compositeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int filters
            {
                get
                {
                    return this.filtersField;
                }
                set
                {
                    this.filtersField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int refreshing
            {
                get
                {
                    return this.refreshingField;
                }
                set
                {
                    this.refreshingField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string thumb
            {
                get
                {
                    return this.thumbField;
                }
                set
                {
                    this.thumbField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int key
            {
                get
                {
                    return this.keyField;
                }
                set
                {
                    this.keyField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string type
            {
                get
                {
                    return this.typeField;
                }
                set
                {
                    this.typeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string title
            {
                get
                {
                    return this.titleField;
                }
                set
                {
                    this.titleField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string agent
            {
                get
                {
                    return this.agentField;
                }
                set
                {
                    this.agentField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string scanner
            {
                get
                {
                    return this.scannerField;
                }
                set
                {
                    this.scannerField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string language
            {
                get
                {
                    return this.languageField;
                }
                set
                {
                    this.languageField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string uuid
            {
                get
                {
                    return this.uuidField;
                }
                set
                {
                    this.uuidField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int updatedAt
            {
                get
                {
                    return this.updatedAtField;
                }
                set
                {
                    this.updatedAtField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int createdAt
            {
                get
                {
                    return this.createdAtField;
                }
                set
                {
                    this.createdAtField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class MediaContainerDirectoryLocation
        {

            private int idField;

            private string pathField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string path
            {
                get
                {
                    return this.pathField;
                }
                set
                {
                    this.pathField = value;
                }
            }
        }
    }
}
