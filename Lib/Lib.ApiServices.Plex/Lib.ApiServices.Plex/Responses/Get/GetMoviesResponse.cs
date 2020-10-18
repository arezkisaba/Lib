namespace Lib.ApiServices.Plex
{
    public class GetMoviesResponse
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class MediaContainer
        {

            private MediaContainerVideo[] videoField;

            private long sizeField;

            private int allowSyncField;

            private string artField;

            private string identifierField;

            private int librarySectionIDField;

            private string librarySectionTitleField;

            private string librarySectionUUIDField;

            private string mediaTagPrefixField;

            private int mediaTagVersionField;

            private string thumbField;

            private string title1Field;

            private string title2Field;

            private string viewGroupField;

            private int viewModeField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Video")]
            public MediaContainerVideo[] Video
            {
                get
                {
                    return this.videoField;
                }
                set
                {
                    this.videoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public long size
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
        public partial class MediaContainerVideo
        {

            private MediaContainerVideoMedia mediaField;

            private MediaContainerVideoGenre[] genreField;

            private MediaContainerVideoDirector directorField;

            private MediaContainerVideoWriter[] writerField;

            private MediaContainerVideoCountry[] countryField;

            private MediaContainerVideoRole[] roleField;

            private string ratingKeyField;

            private string keyField;

            private string studioField;

            private string typeField;

            private string titleField;

            private string contentRatingField;

            private string summaryField;

            private decimal ratingField;

            private int viewCountField;

            private bool viewCountFieldSpecified;

            private int lastViewedAtField;

            private bool lastViewedAtFieldSpecified;

            private int yearField;

            private string taglineField;

            private string thumbField;

            private string artField;

            private int durationField;

            private System.DateTime originallyAvailableAtField;

            private int addedAtField;

            private int updatedAtField;

            private string audienceRatingImageField;

            private string chapterSourceField;

            private string primaryExtraKeyField;

            private string ratingImageField;

            private string titleSortField;

            /// <remarks/>
            public MediaContainerVideoMedia Media
            {
                get
                {
                    return this.mediaField;
                }
                set
                {
                    this.mediaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Genre")]
            public MediaContainerVideoGenre[] Genre
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
            public MediaContainerVideoDirector Director
            {
                get
                {
                    return this.directorField;
                }
                set
                {
                    this.directorField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Writer")]
            public MediaContainerVideoWriter[] Writer
            {
                get
                {
                    return this.writerField;
                }
                set
                {
                    this.writerField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Country")]
            public MediaContainerVideoCountry[] Country
            {
                get
                {
                    return this.countryField;
                }
                set
                {
                    this.countryField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Role")]
            public MediaContainerVideoRole[] Role
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
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int viewCount
            {
                get
                {
                    return this.viewCountField;
                }
                set
                {
                    this.viewCountField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool viewCountSpecified
            {
                get
                {
                    return this.viewCountFieldSpecified;
                }
                set
                {
                    this.viewCountFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int lastViewedAt
            {
                get
                {
                    return this.lastViewedAtField;
                }
                set
                {
                    this.lastViewedAtField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool lastViewedAtSpecified
            {
                get
                {
                    return this.lastViewedAtFieldSpecified;
                }
                set
                {
                    this.lastViewedAtFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int year
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
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string tagline
            {
                get
                {
                    return this.taglineField;
                }
                set
                {
                    this.taglineField = value;
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
            public string audienceRatingImage
            {
                get
                {
                    return this.audienceRatingImageField;
                }
                set
                {
                    this.audienceRatingImageField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string chapterSource
            {
                get
                {
                    return this.chapterSourceField;
                }
                set
                {
                    this.chapterSourceField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string primaryExtraKey
            {
                get
                {
                    return this.primaryExtraKeyField;
                }
                set
                {
                    this.primaryExtraKeyField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string ratingImage
            {
                get
                {
                    return this.ratingImageField;
                }
                set
                {
                    this.ratingImageField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string titleSort
            {
                get
                {
                    return this.titleSortField;
                }
                set
                {
                    this.titleSortField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class MediaContainerVideoMedia
        {

            private MediaContainerVideoMediaPart[] partField;

            private string videoResolutionField;

            private int idField;

            private int durationField;

            private int bitrateField;

            private int widthField;

            private int heightField;

            private decimal aspectRatioField;

            private int audioChannelsField;

            private string audioCodecField;

            private string videoCodecField;

            private string containerField;

            private string videoFrameRateField;

            private string videoProfileField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Part")]
            public MediaContainerVideoMediaPart[] Part
            {
                get
                {
                    return this.partField;
                }
                set
                {
                    this.partField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string videoResolution
            {
                get
                {
                    return this.videoResolutionField;
                }
                set
                {
                    this.videoResolutionField = value;
                }
            }

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
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int bitrate
            {
                get
                {
                    return this.bitrateField;
                }
                set
                {
                    this.bitrateField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int width
            {
                get
                {
                    return this.widthField;
                }
                set
                {
                    this.widthField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int height
            {
                get
                {
                    return this.heightField;
                }
                set
                {
                    this.heightField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal aspectRatio
            {
                get
                {
                    return this.aspectRatioField;
                }
                set
                {
                    this.aspectRatioField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public int audioChannels
            {
                get
                {
                    return this.audioChannelsField;
                }
                set
                {
                    this.audioChannelsField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string audioCodec
            {
                get
                {
                    return this.audioCodecField;
                }
                set
                {
                    this.audioCodecField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string videoCodec
            {
                get
                {
                    return this.videoCodecField;
                }
                set
                {
                    this.videoCodecField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string container
            {
                get
                {
                    return this.containerField;
                }
                set
                {
                    this.containerField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string videoFrameRate
            {
                get
                {
                    return this.videoFrameRateField;
                }
                set
                {
                    this.videoFrameRateField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string videoProfile
            {
                get
                {
                    return this.videoProfileField;
                }
                set
                {
                    this.videoProfileField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class MediaContainerVideoMediaPart
        {

            private int idField;

            private string keyField;

            private int durationField;

            private string fileField;

            private long sizeField;

            private string containerField;

            private string videoProfileField;

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
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string file
            {
                get
                {
                    return this.fileField;
                }
                set
                {
                    this.fileField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public long size
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
            public string container
            {
                get
                {
                    return this.containerField;
                }
                set
                {
                    this.containerField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string videoProfile
            {
                get
                {
                    return this.videoProfileField;
                }
                set
                {
                    this.videoProfileField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class MediaContainerVideoGenre
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
        public partial class MediaContainerVideoDirector
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
        public partial class MediaContainerVideoWriter
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
        public partial class MediaContainerVideoCountry
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
        public partial class MediaContainerVideoRole
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
