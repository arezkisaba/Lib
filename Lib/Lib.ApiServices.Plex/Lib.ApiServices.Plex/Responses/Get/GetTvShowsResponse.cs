namespace Lib.ApiServices.Plex
{
    public class GetTvShowsResponse
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

            private int librarySectionIDField;

            private string librarySectionTitleField;

            private string librarySectionUUIDField;

            private string mediaTagPrefixField;

            private int mediaTagVersionField;

            private int nocacheField;

            private string thumbField;

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

            private MediaContainerDirectoryGenre[] genreField;

            private MediaContainerDirectoryRole[] roleField;

            private string ratingKeyField;

            private string keyField;

            private string typeField;

            private string titleField;

            private string summaryField;

            private int indexField;

            private int leafCountField;

            private int viewedLeafCountField;

            private int childCountField;

            private int addedAtField;

            private string studioField;

            private string contentRatingField;

            private decimal ratingField;

            private bool ratingFieldSpecified;

            private ushort yearField;

            private bool yearFieldSpecified;

            private string thumbField;

            private string artField;

            private string bannerField;

            private string themeField;

            private int durationField;

            private bool durationFieldSpecified;

            private System.DateTime originallyAvailableAtField;

            private bool originallyAvailableAtFieldSpecified;

            private int updatedAtField;

            private bool updatedAtFieldSpecified;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Genre")]
            public MediaContainerDirectoryGenre[] Genre
            {
                get
                {
                    return this.genreField;
                }
                set
                {
                    this.genreField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Role")]
            public MediaContainerDirectoryRole[] Role
            {
                get
                {
                    return this.roleField;
                }
                set
                {
                    this.roleField = value;
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
            public int childCount
            {
                get
                {
                    return this.childCountField;
                }
                set
                {
                    this.childCountField = value;
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
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string studio
            {
                get
                {
                    return this.studioField;
                }
                set
                {
                    this.studioField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string contentRating
            {
                get
                {
                    return this.contentRatingField;
                }
                set
                {
                    this.contentRatingField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal rating
            {
                get
                {
                    return this.ratingField;
                }
                set
                {
                    this.ratingField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool ratingSpecified
            {
                get
                {
                    return this.ratingFieldSpecified;
                }
                set
                {
                    this.ratingFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public ushort year
            {
                get
                {
                    return this.yearField;
                }
                set
                {
                    this.yearField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool yearSpecified
            {
                get
                {
                    return this.yearFieldSpecified;
                }
                set
                {
                    this.yearFieldSpecified = value;
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
            public string banner
            {
                get
                {
                    return this.bannerField;
                }
                set
                {
                    this.bannerField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string theme
            {
                get
                {
                    return this.themeField;
                }
                set
                {
                    this.themeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int duration
            {
                get
                {
                    return this.durationField;
                }
                set
                {
                    this.durationField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool durationSpecified
            {
                get
                {
                    return this.durationFieldSpecified;
                }
                set
                {
                    this.durationFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
            public System.DateTime originallyAvailableAt
            {
                get
                {
                    return this.originallyAvailableAtField;
                }
                set
                {
                    this.originallyAvailableAtField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool originallyAvailableAtSpecified
            {
                get
                {
                    return this.originallyAvailableAtFieldSpecified;
                }
                set
                {
                    this.originallyAvailableAtFieldSpecified = value;
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
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool updatedAtSpecified
            {
                get
                {
                    return this.updatedAtFieldSpecified;
                }
                set
                {
                    this.updatedAtFieldSpecified = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class MediaContainerDirectoryGenre
        {

            private string tagField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string tag
            {
                get
                {
                    return this.tagField;
                }
                set
                {
                    this.tagField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class MediaContainerDirectoryRole
        {

            private string tagField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string tag
            {
                get
                {
                    return this.tagField;
                }
                set
                {
                    this.tagField = value;
                }
            }
        }


    }
}
