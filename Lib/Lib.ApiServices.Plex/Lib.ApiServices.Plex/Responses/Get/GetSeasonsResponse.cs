namespace Lib.ApiServices.Plex
{
    public class GetSeasonsResponse
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class MediaContainer
        {

            private MediaContainerDirectory[] directoryField;

            private int sizeField;

            private int allowSyncField;

            private string artField;

            private string identifierField;

            private int keyField;

            private int librarySectionIDField;

            private string librarySectionTitleField;

            private string librarySectionUUIDField;

            private string mediaTagPrefixField;

            private int mediaTagVersionField;

            private int nocacheField;

            private int parentIndexField;

            private string parentTitleField;

            private string title1Field;

            private string title2Field;

            private string viewGroupField;

            private int viewModeField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Directory")]
            public MediaContainerDirectory[] Directory
            {
                get
                {
                    return this.directoryField;
                }
                set
                {
                    this.directoryField = value;
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
            public int librarySectionID
            {
                get
                {
                    return this.librarySectionIDField;
                }
                set
                {
                    this.librarySectionIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string librarySectionTitle
            {
                get
                {
                    return this.librarySectionTitleField;
                }
                set
                {
                    this.librarySectionTitleField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string librarySectionUUID
            {
                get
                {
                    return this.librarySectionUUIDField;
                }
                set
                {
                    this.librarySectionUUIDField = value;
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
            public int nocache
            {
                get
                {
                    return this.nocacheField;
                }
                set
                {
                    this.nocacheField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int parentIndex
            {
                get
                {
                    return this.parentIndexField;
                }
                set
                {
                    this.parentIndexField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string parentTitle
            {
                get
                {
                    return this.parentTitleField;
                }
                set
                {
                    this.parentTitleField = value;
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

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string title2
            {
                get
                {
                    return this.title2Field;
                }
                set
                {
                    this.title2Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string viewGroup
            {
                get
                {
                    return this.viewGroupField;
                }
                set
                {
                    this.viewGroupField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int viewMode
            {
                get
                {
                    return this.viewModeField;
                }
                set
                {
                    this.viewModeField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class MediaContainerDirectory
        {

            private int leafCountField;

            private string thumbField;

            private int viewedLeafCountField;

            private string keyField;

            private string titleField;

            private string ratingKeyField;

            private bool ratingKeyFieldSpecified;

            private int parentRatingKeyField;

            private bool parentRatingKeyFieldSpecified;

            private string typeField;

            private string parentKeyField;

            private string summaryField;

            private int indexField;

            private bool indexFieldSpecified;

            private int addedAtField;

            private bool addedAtFieldSpecified;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int leafCount
            {
                get
                {
                    return this.leafCountField;
                }
                set
                {
                    this.leafCountField = value;
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
            public int viewedLeafCount
            {
                get
                {
                    return this.viewedLeafCountField;
                }
                set
                {
                    this.viewedLeafCountField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string key
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
            public string ratingKey
            {
                get
                {
                    return this.ratingKeyField;
                }
                set
                {
                    this.ratingKeyField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool ratingKeySpecified
            {
                get
                {
                    return this.ratingKeyFieldSpecified;
                }
                set
                {
                    this.ratingKeyFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int parentRatingKey
            {
                get
                {
                    return this.parentRatingKeyField;
                }
                set
                {
                    this.parentRatingKeyField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool parentRatingKeySpecified
            {
                get
                {
                    return this.parentRatingKeyFieldSpecified;
                }
                set
                {
                    this.parentRatingKeyFieldSpecified = value;
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
            public string parentKey
            {
                get
                {
                    return this.parentKeyField;
                }
                set
                {
                    this.parentKeyField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string summary
            {
                get
                {
                    return this.summaryField;
                }
                set
                {
                    this.summaryField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int index
            {
                get
                {
                    return this.indexField;
                }
                set
                {
                    this.indexField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool indexSpecified
            {
                get
                {
                    return this.indexFieldSpecified;
                }
                set
                {
                    this.indexFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int addedAt
            {
                get
                {
                    return this.addedAtField;
                }
                set
                {
                    this.addedAtField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool addedAtSpecified
            {
                get
                {
                    return this.addedAtFieldSpecified;
                }
                set
                {
                    this.addedAtFieldSpecified = value;
                }
            }
        }
    }
}
