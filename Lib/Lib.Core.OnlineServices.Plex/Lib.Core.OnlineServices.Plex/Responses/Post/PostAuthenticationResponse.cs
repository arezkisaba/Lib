namespace Lib.Core.OnlineServices.Plex
{
    public class PostAuthenticationResponse
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class user
        {
            private userSubscription subscriptionField;

            private userRoles rolesField;

            private userEntitlements entitlementsField;

            private userProfile_settings profile_settingsField;

            private userProviders providersField;

            private string usernameField;

            private string emailField;

            private userJoinedat joinedatField;

            private string authenticationtokenField;

            private string email1Field;

            private uint idField;

            private string uuidField;

            private string mailing_list_statusField;

            private string thumbField;

            private string username1Field;

            private string titleField;

            private string cloudSyncDeviceField;

            private string localeField;

            private string authenticationTokenField;

            private string authTokenField;

            private string scrobbleTypesField;

            private byte restrictedField;

            private byte homeField;

            private byte guestField;

            private string queueEmailField;

            private string queueUidField;

            private byte homeSizeField;

            private byte maxHomeSizeField;

            private bool rememberMeField;

            private byte secureField;

            private byte certificateVersionField;

            /// <remarks/>
            public userSubscription subscription
            {
                get
                {
                    return this.subscriptionField;
                }
                set
                {
                    this.subscriptionField = value;
                }
            }

            /// <remarks/>
            public userRoles roles
            {
                get
                {
                    return this.rolesField;
                }
                set
                {
                    this.rolesField = value;
                }
            }

            /// <remarks/>
            public userEntitlements entitlements
            {
                get
                {
                    return this.entitlementsField;
                }
                set
                {
                    this.entitlementsField = value;
                }
            }

            /// <remarks/>
            public userProfile_settings profile_settings
            {
                get
                {
                    return this.profile_settingsField;
                }
                set
                {
                    this.profile_settingsField = value;
                }
            }

            /// <remarks/>
            public userProviders providers
            {
                get
                {
                    return this.providersField;
                }
                set
                {
                    this.providersField = value;
                }
            }

            /// <remarks/>
            public string username
            {
                get
                {
                    return this.usernameField;
                }
                set
                {
                    this.usernameField = value;
                }
            }

            /// <remarks/>
            public string email
            {
                get
                {
                    return this.emailField;
                }
                set
                {
                    this.emailField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("joined-at")]
            public userJoinedat joinedat
            {
                get
                {
                    return this.joinedatField;
                }
                set
                {
                    this.joinedatField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("authentication-token")]
            public string authenticationtoken
            {
                get
                {
                    return this.authenticationtokenField;
                }
                set
                {
                    this.authenticationtokenField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute("email")]
            public string email1
            {
                get
                {
                    return this.email1Field;
                }
                set
                {
                    this.email1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint id
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
            public string mailing_list_status
            {
                get
                {
                    return this.mailing_list_statusField;
                }
                set
                {
                    this.mailing_list_statusField = value;
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
            [System.Xml.Serialization.XmlAttributeAttribute("username")]
            public string username1
            {
                get
                {
                    return this.username1Field;
                }
                set
                {
                    this.username1Field = value;
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
            public string cloudSyncDevice
            {
                get
                {
                    return this.cloudSyncDeviceField;
                }
                set
                {
                    this.cloudSyncDeviceField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string locale
            {
                get
                {
                    return this.localeField;
                }
                set
                {
                    this.localeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string authenticationToken
            {
                get
                {
                    return this.authenticationTokenField;
                }
                set
                {
                    this.authenticationTokenField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string authToken
            {
                get
                {
                    return this.authTokenField;
                }
                set
                {
                    this.authTokenField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string scrobbleTypes
            {
                get
                {
                    return this.scrobbleTypesField;
                }
                set
                {
                    this.scrobbleTypesField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte restricted
            {
                get
                {
                    return this.restrictedField;
                }
                set
                {
                    this.restrictedField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte home
            {
                get
                {
                    return this.homeField;
                }
                set
                {
                    this.homeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte guest
            {
                get
                {
                    return this.guestField;
                }
                set
                {
                    this.guestField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string queueEmail
            {
                get
                {
                    return this.queueEmailField;
                }
                set
                {
                    this.queueEmailField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string queueUid
            {
                get
                {
                    return this.queueUidField;
                }
                set
                {
                    this.queueUidField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte homeSize
            {
                get
                {
                    return this.homeSizeField;
                }
                set
                {
                    this.homeSizeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte maxHomeSize
            {
                get
                {
                    return this.maxHomeSizeField;
                }
                set
                {
                    this.maxHomeSizeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public bool rememberMe
            {
                get
                {
                    return this.rememberMeField;
                }
                set
                {
                    this.rememberMeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte secure
            {
                get
                {
                    return this.secureField;
                }
                set
                {
                    this.secureField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte certificateVersion
            {
                get
                {
                    return this.certificateVersionField;
                }
                set
                {
                    this.certificateVersionField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class userSubscription
        {

            private userSubscriptionFeature[] featureField;

            private byte activeField;

            private string statusField;

            private string planField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("feature")]
            public userSubscriptionFeature[] feature
            {
                get
                {
                    return this.featureField;
                }
                set
                {
                    this.featureField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte active
            {
                get
                {
                    return this.activeField;
                }
                set
                {
                    this.activeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string status
            {
                get
                {
                    return this.statusField;
                }
                set
                {
                    this.statusField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string plan
            {
                get
                {
                    return this.planField;
                }
                set
                {
                    this.planField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class userSubscriptionFeature
        {

            private string idField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
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
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class userRoles
        {

            private userRolesRole roleField;

            /// <remarks/>
            public userRolesRole role
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
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class userRolesRole
        {

            private string idField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
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
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class userEntitlements
        {

            private userEntitlementsEntitlement[] entitlementField;

            private byte allField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("entitlement")]
            public userEntitlementsEntitlement[] entitlement
            {
                get
                {
                    return this.entitlementField;
                }
                set
                {
                    this.entitlementField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte all
            {
                get
                {
                    return this.allField;
                }
                set
                {
                    this.allField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class userEntitlementsEntitlement
        {

            private string idField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
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
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class userProfile_settings
        {

            private byte auto_select_audioField;

            private byte auto_select_subtitleField;

            private string default_audio_languageField;

            private string default_subtitle_languageField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte auto_select_audio
            {
                get
                {
                    return this.auto_select_audioField;
                }
                set
                {
                    this.auto_select_audioField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte auto_select_subtitle
            {
                get
                {
                    return this.auto_select_subtitleField;
                }
                set
                {
                    this.auto_select_subtitleField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string default_audio_language
            {
                get
                {
                    return this.default_audio_languageField;
                }
                set
                {
                    this.default_audio_languageField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string default_subtitle_language
            {
                get
                {
                    return this.default_subtitle_languageField;
                }
                set
                {
                    this.default_subtitle_languageField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class userProviders
        {

            private userProvidersProvider providerField;

            /// <remarks/>
            public userProvidersProvider provider
            {
                get
                {
                    return this.providerField;
                }
                set
                {
                    this.providerField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class userProvidersProvider
        {

            private string idField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
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
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class userJoinedat
        {

            private string typeField;

            private string valueField;

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
            [System.Xml.Serialization.XmlTextAttribute()]
            public string Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }
    }
}
