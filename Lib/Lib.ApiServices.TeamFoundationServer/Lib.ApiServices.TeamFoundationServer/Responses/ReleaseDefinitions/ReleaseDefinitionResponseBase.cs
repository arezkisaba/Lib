using System;

namespace Lib.ApiServices.TeamFoundationServer
{
    public class ReleaseDefinitionResponseBase
    {
        public string source { get; set; }
        public int revision { get; set; }
        public object description { get; set; }
        public Createdby createdBy { get; set; }
        public DateTime createdOn { get; set; }
        public Modifiedby modifiedBy { get; set; }
        public DateTime modifiedOn { get; set; }
        public bool isDeleted { get; set; }
        public Variables variables { get; set; }
        public object[] variableGroups { get; set; }
        public Environment[] environments { get; set; }
        public object[] artifacts { get; set; }
        public object[] triggers { get; set; }
        public string releaseNameFormat { get; set; }
        public object[] tags { get; set; }
        public Properties properties { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public object projectReference { get; set; }
        public string url { get; set; }
        public _Links2 _links { get; set; }

        public class Createdby
        {
            public string displayName { get; set; }
            public string url { get; set; }
            public _Links _links { get; set; }
            public string id { get; set; }
            public string uniqueName { get; set; }
            public string imageUrl { get; set; }
            public string descriptor { get; set; }
        }

        public class _Links
        {
            public Avatar avatar { get; set; }
        }

        public class Avatar
        {
            public string href { get; set; }
        }

        public class Modifiedby
        {
            public string displayName { get; set; }
            public string url { get; set; }
            public _Links1 _links { get; set; }
            public string id { get; set; }
            public string uniqueName { get; set; }
            public string imageUrl { get; set; }
            public string descriptor { get; set; }
        }

        public class _Links1
        {
            public Avatar1 avatar { get; set; }
        }

        public class Avatar1
        {
            public string href { get; set; }
        }

        public class Variables
        {
        }

        public class Properties
        {
        }

        public class _Links2
        {
            public Self self { get; set; }
            public Web web { get; set; }
        }

        public class Self
        {
            public string href { get; set; }
        }

        public class Web
        {
            public string href { get; set; }
        }

        public class Environment
        {
            public int id { get; set; }
            public string name { get; set; }
            public int rank { get; set; }
            public Owner owner { get; set; }
            public Variables1 variables { get; set; }
            public object[] variableGroups { get; set; }
            public Predeployapprovals preDeployApprovals { get; set; }
            public Deploystep deployStep { get; set; }
            public Postdeployapprovals postDeployApprovals { get; set; }
            public Deployphas[] deployPhases { get; set; }
            public Environmentoptions environmentOptions { get; set; }
            public object[] demands { get; set; }
            public object[] conditions { get; set; }
            public Executionpolicy executionPolicy { get; set; }
            public object[] schedules { get; set; }
            public Currentrelease currentRelease { get; set; }
            public Retentionpolicy retentionPolicy { get; set; }
            public Properties1 properties { get; set; }
            public Predeploymentgates preDeploymentGates { get; set; }
            public Postdeploymentgates postDeploymentGates { get; set; }
            public object[] environmentTriggers { get; set; }
            public string badgeUrl { get; set; }
        }

        public class Owner
        {
            public string displayName { get; set; }
            public string url { get; set; }
            public _Links3 _links { get; set; }
            public string id { get; set; }
            public string uniqueName { get; set; }
            public string imageUrl { get; set; }
            public string descriptor { get; set; }
        }

        public class _Links3
        {
            public Avatar2 avatar { get; set; }
        }

        public class Avatar2
        {
            public string href { get; set; }
        }

        public class Variables1
        {
        }

        public class Predeployapprovals
        {
            public Approval[] approvals { get; set; }
            public Approvaloptions approvalOptions { get; set; }
        }

        public class Approvaloptions
        {
            public int requiredApproverCount { get; set; }
            public bool releaseCreatorCanBeApprover { get; set; }
            public bool autoTriggeredAndPreviousEnvironmentApprovedCanBeSkipped { get; set; }
            public bool enforceIdentityRevalidation { get; set; }
            public int timeoutInMinutes { get; set; }
            public string executionOrder { get; set; }
        }

        public class Approval
        {
            public int rank { get; set; }
            public bool isAutomated { get; set; }
            public bool isNotificationOn { get; set; }
            public Approver approver { get; set; }
            public int id { get; set; }
        }

        public class Approver
        {
            public string displayName { get; set; }
            public string url { get; set; }
            public _Links4 _links { get; set; }
            public string id { get; set; }
            public string uniqueName { get; set; }
            public string imageUrl { get; set; }
            public string descriptor { get; set; }
        }

        public class _Links4
        {
            public Avatar3 avatar { get; set; }
        }

        public class Avatar3
        {
            public string href { get; set; }
        }

        public class Deploystep
        {
            public int id { get; set; }
        }

        public class Postdeployapprovals
        {
            public Approval1[] approvals { get; set; }
        }

        public class Approval1
        {
            public int rank { get; set; }
            public bool isAutomated { get; set; }
            public bool isNotificationOn { get; set; }
            public int id { get; set; }
        }

        public class Environmentoptions
        {
            public string emailNotificationType { get; set; }
            public string emailRecipients { get; set; }
            public bool skipArtifactsDownload { get; set; }
            public int timeoutInMinutes { get; set; }
            public bool enableAccessToken { get; set; }
            public bool publishDeploymentStatus { get; set; }
            public bool badgeEnabled { get; set; }
            public bool autoLinkWorkItems { get; set; }
            public bool pullRequestDeploymentEnabled { get; set; }
        }

        public class Executionpolicy
        {
            public int concurrencyCount { get; set; }
            public int queueDepthCount { get; set; }
        }

        public class Currentrelease
        {
            public int id { get; set; }
            public string url { get; set; }
            public _Links5 _links { get; set; }
        }

        public class _Links5
        {
        }

        public class Retentionpolicy
        {
            public int daysToKeep { get; set; }
            public int releasesToKeep { get; set; }
            public bool retainBuild { get; set; }
        }

        public class Properties1
        {
        }

        public class Predeploymentgates
        {
            public int id { get; set; }
            public object gatesOptions { get; set; }
            public object[] gates { get; set; }
        }

        public class Postdeploymentgates
        {
            public int id { get; set; }
            public object gatesOptions { get; set; }
            public object[] gates { get; set; }
        }

        public class Deployphas
        {
            public Deploymentinput deploymentInput { get; set; }
            public int rank { get; set; }
            public string phaseType { get; set; }
            public string name { get; set; }
            public object refName { get; set; }
            public object[] workflowTasks { get; set; }
        }

        public class Deploymentinput
        {
            public Parallelexecution parallelExecution { get; set; }
            public bool skipArtifactsDownload { get; set; }
            public Artifactsdownloadinput artifactsDownloadInput { get; set; }
            public int queueId { get; set; }
            public object[] demands { get; set; }
            public bool enableAccessToken { get; set; }
            public int timeoutInMinutes { get; set; }
            public int jobCancelTimeoutInMinutes { get; set; }
            public string condition { get; set; }
            public Overrideinputs overrideInputs { get; set; }
        }

        public class Parallelexecution
        {
            public string parallelExecutionType { get; set; }
        }

        public class Artifactsdownloadinput
        {
            public object[] downloadInputs { get; set; }
        }

        public class Overrideinputs
        {
        }
    }
}
